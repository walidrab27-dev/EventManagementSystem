using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.DTOs
{
    public class EventOrganizerDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string NameOrganizer { get; set; }
        public string VenueName { get; set; }
    }
}
