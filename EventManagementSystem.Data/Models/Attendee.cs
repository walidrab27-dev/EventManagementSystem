using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Models
{
    public class Attendee : Person
    {
        private static int _attendeeId = 0;
        public List<Ticket> Tickets { get; } = new List<Ticket>();
        public Attendee(string name, string email) : base(name, email)
        {
            Id = ++_attendeeId;
        }
    }
}
