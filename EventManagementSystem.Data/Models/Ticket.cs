using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Models
{
    public class Ticket : BaseEntity
    {
        private static int _ticketId = 0;
        private decimal _price;
        private DateTime? _checkIn;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative.");
                _price = value;
            }
        }
        public DateTime? CheckIn
        {
            get { return _checkIn; }
            set
            {
                _checkIn = value;
            }
        }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
        public Ticket(decimal price, DateTime? checkIn, int eventId, int attendeeId)
        {
            Price = price;
            CheckIn = checkIn;
            EventId = eventId;
            AttendeeId = attendeeId;
            Id = ++_ticketId;
        }
    }
}
