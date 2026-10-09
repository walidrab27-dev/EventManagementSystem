using EventManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Interfaces
{
    public interface IDatabaseManager
    {
        List<Event> Events();
        List<Attendee> Attendees();
        List<Organizer> Organizers();
        List<Venue> Venues();
        List<Ticket> Tickets();
    }
}
