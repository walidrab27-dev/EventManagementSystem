using EventManagementSystem.Data.DTOs;
using EventManagementSystem.Data.Interfaces;
using EventManagementSystem.Data.Models;
using EventManagementSystem.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Services
{
    public class EventQueryService
    {
        private List<Event> _allEvents;
        private List<Organizer> _allOrganizers;
        private List<Attendee> _allAttendees;
        private List<Venue> _allVenues;
        private List<Ticket> _allTickets;
        public EventQueryService(IDatabaseManager databaseManager)
        {
                _allEvents = databaseManager.Events();
                _allOrganizers = databaseManager.Organizers();
                _allAttendees = databaseManager.Attendees();
                _allVenues = databaseManager.Venues();
                _allTickets = databaseManager.Tickets();
        }
        public IEnumerable<IGrouping<string, EventOrganizerDto>> GetAllEventsOrganizedBySpecificOrganizer(int organizerId)
        {
            var res = _allEvents.Where(e => e.OrganizerId == organizerId).Join(_allOrganizers, e => e.OrganizerId, o => o.Id,
                (e, o) => new
                {
                    Title = e.Title,
                    Date = e.EventDate,
                    NameOrganizer = o.Name,
                    Venue = e.VenueId
                }).Join(_allVenues, x => x.Venue, v => v.Id,
                    (e, v) => new EventOrganizerDto
                    {
                        Title = e.Title,
                        Date = e.Date,
                        NameOrganizer = e.NameOrganizer,
                        VenueName = v.Name
                    }).GroupBy(x=>x.NameOrganizer);
            return res;
        }
        public IEnumerable<IGrouping<string, EventAttendeeDto>> GetAllAttendeesorspecificEvent(int eventId)
        {
            var res = _allTickets.Where(x => x.EventId == eventId).Join(_allAttendees, x => x.AttendeeId, a => a.Id,
                (x,a) => new
                {
                    AttendeeName = a.Name,
                    EventId = x.EventId
                }).Join(_allEvents,x=>x.EventId,a=>a.Id,
                (x,a) => new EventAttendeeDto
                {
                    AttendeeName = x.AttendeeName,
                    Title = a.Title
                }).GroupBy(a=>a.Title);

            return res;
        }
        public decimal TotalTicketRevenuPperEvent(int eventId)
        {
            var res = _allTickets.Where(x=>x.EventId == eventId).Sum(x => x.Price);
            return res;
        }
        public int NumberOfAttendeesPerEvent(int eventId)
        {
            var res = _allTickets.Where(x => x.EventId == eventId).Count();
            return res;
        }
        public IOrderedEnumerable<Event> UpcomingEventsSortedByDate()
        {
            var res = _allEvents.Where(e => e.EventDate > DateTime.Now).OrderBy(e => e.EventDate);
            return res;
        }
        public IEnumerable<string> AttendeesWhoDidntCheckIn()
        {
            //var res = _allAttendees.GroupJoin(_allTickets, a => a.Id, t => t.AttendeeId,
            //    (a, t) => new { a, t }).SelectMany(
            //        x => x.t.DefaultIfEmpty(),
            //        (x, ticket) => new
            //        {
            //            Name = x.a.Name,
            //            CheckIn = ticket?.CheckIn
            //        }
            //    ).Where(x=>x.CheckIn==null).Select(a=>a.Name);
            var res = _allTickets.Where(r => r.CheckIn == null).Join(_allAttendees, t => t.AttendeeId, a => a.Id,
                (t, a) => a.Name).Distinct();
            return res;
        }
        public IEnumerable<MostAttendedEventsDto> MostAttendedEvents()
        {
            var res = _allTickets.Join(_allEvents, t => t.EventId, e => e.Id,
                (t, e) => new
                {
                    TickedId = t.Id,
                    Title = e.Title
                }
                ).GroupBy(x => x.Title).Select(
                    g => new MostAttendedEventsDto
                    {
                        Title = g.Key,
                        Count = g.Count()
                    }
                ).OrderByDescending(c=>c.Count).Take(5);

            return res;
        }
        public IEnumerable<AttendeesAttendingMultipleEventsDto> AttendeesAttendingMultipleEvents()
        {
            var res = _allTickets.Join(_allAttendees, t => t.AttendeeId, a => a.Id,
                (t, a) => new
                {
                    TicketId = t.Id,
                    Name = a.Name
                }).GroupBy(x => x.Name).Select(
                    g => new AttendeesAttendingMultipleEventsDto
                    {
                        Name = g.Key,
                        Count = g.Count()
                    }
                ).Where(x=>x.Count!=1);

            return res;
        }
        public IEnumerable<EventsFullyBookedDto> EventsThatFullyBooked()
        {
            //var res = _allTickets.GroupBy(x => x.EventId).Join(_allEvents, g => g.Key, e => e.Id,
            //    (g, e) => new
            //    {
            //        Event = e,
            //        TicketCount = g.Count()
            //    }).Join(_allVenues, x => x.Event.VenueId, v => v.Id,
            //        (x, v) => new EventsFullyBookedDto
            //        {
            //            Title = x.Event.Title,
            //            TicketCount = x.TicketCount,
            //            Capacity = v.Capacity
            //        }).Where(x => x.TicketCount == x.Capacity);
            var res = _allEvents.Join(_allVenues,e=>e.VenueId,v=>v.Id,
                    (e,v) => new
                    {
                        Event = e,
                        Venue = v
                    }
                ).Where(x=>_allTickets.Count(t=>t.EventId==x.Event.Id)>=x.Venue.Capacity)
                .Select(
                    x=> new EventsFullyBookedDto
                    {
                        Title = x.Event.Title,
                        TicketCount = _allTickets.Count(t => t.EventId == x.Event.Id),
                        Capacity = x.Venue.Capacity
                    }
                );
            return res;
        }
    }
}
