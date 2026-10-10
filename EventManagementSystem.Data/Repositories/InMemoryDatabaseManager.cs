using EventManagementSystem.Data.Interfaces;
using EventManagementSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace EventManagementSystem.Data.Repositories
{
    public class InMemoryDatabaseManager : IDatabaseManager
    {
        private readonly List<Attendee> _attendees;
        private readonly List<Organizer> _organizers;
        private readonly List<Venue> _venues;
        private readonly List<Event> _events;
        private readonly List<Ticket> _tickets;

        public InMemoryDatabaseManager()
        {
            _organizers = new List<Organizer>
            {
                new Organizer("Tech Innovators", "contact@techinnovators.com"),
                new Organizer("Health Plus", "info@healthplus.com"),
                new Organizer("Cairo Coding School", "cairocodingschool@gmail.com"),
                new Organizer("Art Vibes", "hello@artvibes.com"),
                new Organizer("Sports Hub", "support@sportshub.com")
            };
            _venues = new List<Venue>
            {
                new Venue("Cairo Stadium", "Nasr City", 50000),
                new Venue("Al Manara Center", "New Cairo", 2),
                new Venue("Smart Village Hall", "6th of October", 500),
                new Venue("Opera House", "Zamalek", 1000),
                new Venue("Alex Library Room", "Alexandria", 3)
            };
            _events = new List<Event>
            {
                new Event("Tech Conference 2026", DateTime.Now.AddDays(10), 1, 2),
                new Event("Health Marathon", DateTime.Now.AddDays(20), 2, 1),
                new Event("C# Hackathon", DateTime.Now.AddDays(-5), 3, 3),
                new Event("Modern Art Exhibition", DateTime.Now.AddDays(15), 4, 4),
                new Event("Local Football Final", DateTime.Now.AddDays(2), 5, 1),
                new Event("Backend Meetup", DateTime.Now.AddDays(30), 3, 5)
            };
            _attendees = new List<Attendee>
            {
                new Attendee("Ahmed Ali", "ahmed@example.com"),
                new Attendee("Sara Youssef", "sara@example.com"),
                new Attendee("Omar Khaled", "omar@example.com"),
                new Attendee("Mona Hassan", "mona@example.com"),
                new Attendee("Khaled Tarek", "khaled@example.com"),
                new Attendee("Youssef Ibrahim", "youssef@example.com")
            };
            _tickets = new List<Ticket>
            {
                new Ticket(150.50m, DateTime.Now, 1, 1),
                new Ticket(150.50m, null, 1, 2),
                new Ticket(50.00m, null, 2, 1),
                new Ticket(0m, DateTime.Now.AddDays(-5), 3, 3),
                new Ticket(0m, DateTime.Now.AddDays(-5), 3, 4),
                new Ticket(200.00m, null, 4, 5) { Id = 6 },
                new Ticket(200.00m, DateTime.Now, 4, 6),
                new Ticket(500.00m, null, 5, 1),
                new Ticket(100.00m, DateTime.Now, 6, 2), 
                new Ticket(100.00m, null, 6, 3)
            };
        }

        public List<Attendee> Attendees() => _attendees;
        public List<Event> Events() => _events;
        public List<Organizer> Organizers() => _organizers;
        public List<Ticket> Tickets() => _tickets;
        public List<Venue> Venues() => _venues;
    }
}