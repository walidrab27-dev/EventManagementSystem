using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Models
{
    public class Organizer : Person
    {
        private static int _organId = 0;
        public List<Event> Events { get; } = new List<Event>();
        public Organizer(string name, string email) : base(name, email)
        {
            Id = ++_organId;
        }
        public Organizer()
        {
            
        }
    }
}
