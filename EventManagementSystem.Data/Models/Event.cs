using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Models
{
    public class Event : BaseEntity
    {
        private static int _eventId = 0;
        private string _title;
        private DateTime _eventDate;
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be null or empty.");
                _title = value;
            }
        }
        public DateTime EventDate
        {
            get { return _eventDate; }
            set
            {
                _eventDate = value;
            }
        }
        public int OrganizerId { get; set; }
        public int VenueId { get; set; }
        public Organizer Organizer { get; set; }
        public Venue Venue { get; set; }
        public List<Ticket> Tickets { get; } = new List<Ticket>();
        public Event(string title, DateTime eventDate, int organizerId, int venueId)
        {
            Title = title;
            EventDate = eventDate;
            OrganizerId = organizerId;
            VenueId = venueId;
            Id = ++_eventId;
        }
        public Event()
        {
            
        }
    }
}
