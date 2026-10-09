using EventManagementSystem.Data.Interfaces;
using EventManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Repositories
{
    public class InMemoryDatabaseManager : IDatabaseManager
    {
        public List<Attendee> Attendees()
        {
            throw new NotImplementedException();
        }

        public List<Event> Events()
        {
            throw new NotImplementedException();
        }

        public List<Organizer> Organizers()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> Tickets()
        {
            throw new NotImplementedException();
        }

        public List<Venue> Venues()
        {
            throw new NotImplementedException();
        }
    }
}
