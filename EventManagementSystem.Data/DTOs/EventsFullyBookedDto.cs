using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.DTOs
{
    public class EventsFullyBookedDto
    {
        public string Title { get; set; }
        public int Capacity { get; set; }
        public int TicketCount { get; set; }
    }
}
