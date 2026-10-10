using EventManagementSystem.Data.Services;
using System;

namespace EventManagementSystem.ConsoleApp
{
    public class EventReportPrinter
    {
        private readonly EventQueryService _queryService;

        public EventReportPrinter(EventQueryService queryService)
        {
            _queryService = queryService;
        }

        public void PrintAllReports()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t=== Event Management System Reports ===\n");
            Console.ResetColor();

            // --- 1. Get all events organized by a specific organizer ---
            Console.WriteLine("1. Events by Organizer (ID: 3):");
            var eventsByOrganizer = _queryService.GetAllEventsOrganizedBySpecificOrganizer(3);
            foreach (var group in eventsByOrganizer)
            {
                Console.WriteLine($"   Organizer: {group.Key}");
                foreach (var dto in group)
                {
                    Console.WriteLine($"     - {dto.Title} at {dto.VenueName} ({dto.Date.ToShortDateString()})");
                }
            }

            // --- 2. Get all attendees for a specific event ---
            Console.WriteLine("\n2. Attendees for Event (ID: 1):");
            var attendeesByEvent = _queryService.GetAllAttendeesorspecificEvent(1);
            foreach (var group in attendeesByEvent)
            {
                Console.WriteLine($"   Event: {group.Key}");
                foreach (var dto in group)
                {
                    Console.WriteLine($"     - Attendee: {dto.AttendeeName}");
                }
            }

            // --- 3. Total ticket revenue per event ---
            Console.WriteLine("\n3. Total Ticket Revenue per Event (ID: 1):");
            var revenue = _queryService.TotalTicketRevenuPperEvent(1);
            Console.WriteLine($"   Revenue: {revenue:C}");

            // --- 4. Number of attendees per event ---
            Console.WriteLine("\n4. Number of Attendees per Event (ID: 1):");
            var numAttendees = _queryService.NumberOfAttendeesPerEvent(1);
            Console.WriteLine($"   Total Attendees: {numAttendees}");

            // --- 5. Upcoming events sorted by date ---
            Console.WriteLine("\n5. Upcoming Events Sorted by Date:");
            var upcomingEvents = _queryService.UpcomingEventsSortedByDate();
            foreach (var ev in upcomingEvents)
            {
                Console.WriteLine($"   - {ev.Title} ({ev.EventDate.ToShortDateString()})");
            }

            // --- 6. Attendees who didn't check in ---
            Console.WriteLine("\n6. Attendees Who Didn't Check In:");
            var noShows = _queryService.AttendeesWhoDidntCheckIn();
            foreach (var name in noShows)
            {
                Console.WriteLine($"   - {name}");
            }

            // --- 7. Most attended events ---
            Console.WriteLine("\n7. Most Attended Events (Top 5):");
            var mostAttended = _queryService.MostAttendedEvents();
            foreach (var ev in mostAttended)
            {
                Console.WriteLine($"   - {ev.Title}: {ev.Count} Attendees");
            }

            // --- 8. Attendees attending multiple events ---
            Console.WriteLine("\n8. Attendees Attending Multiple Events:");
            var multipleEvents = _queryService.AttendeesAttendingMultipleEvents();
            foreach (var attendee in multipleEvents)
            {
                Console.WriteLine($"   - {attendee.Name}: {attendee.Count} Events");
            }

            // --- 9. Events that are fully booked ---
            Console.WriteLine("\n9. Fully Booked Events:");
            var fullyBookedEvents = _queryService.EventsThatFullyBooked();
            foreach (var eventInfo in fullyBookedEvents)
            {
                Console.WriteLine($"   - {eventInfo.Title} | Sold: {eventInfo.TicketCount}/{eventInfo.Capacity}");
            }
        }
    }
}