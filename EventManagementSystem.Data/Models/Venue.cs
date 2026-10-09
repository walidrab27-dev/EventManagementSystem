using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Models
{
    public class Venue : BaseEntity
    {
        private static int _venueId = 0;
        private string _name;
        private string _location;
        private int _capacity;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                _name = value;
            }
        }
        public string Location
        {
            get { return _location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Location cannot be null or empty.");
                _location = value;
            }
        }
        public int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Capacity must be a positive integer.");
                _capacity = value;
            }
        }

        public Venue(string name, string location, int capacity) : base()
        {
            Name = name;
            Location = location;
            Capacity = capacity;
            Id = ++_venueId;
        }
        public List<Event> Events { get; } = new List<Event>();
    }
}
