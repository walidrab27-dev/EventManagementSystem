using EventManagementSystem.Data.Interfaces;
using EventManagementSystem.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Repositories
{
    public class SqlDatabaseManager : IDatabaseManager
    {
        private readonly string _connectionString;
        public SqlDatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Event> Events()
        {
            List<Event> events;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Event", connection);
                SqlDataReader reader = command.ExecuteReader();
                events = new List<Event>();
                while(reader.Read())
                {
                    var event1 = new Event();
                    event1.Id = (int)reader["id"];
                    event1.Title = reader["title"].ToString();
                    event1.OrganizerId = (int)reader["organizerId"];
                    event1.VenueId = (int)reader["venueId"];
                    event1.EventDate = (DateTime)reader["eventDate"];
                    event1.CreatedAt = (DateTime)reader["createdAt"];
                    event1.UpdatedAt = (DateTime)reader["updatedAt"];
                    events.Add(event1);
                }
            }
            return events;
        }

        public List<Attendee> Attendees()
        {
            List<Attendee> attendees;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Attendee", connection);
                SqlDataReader reader = command.ExecuteReader();
                attendees = new List<Attendee>();
                while (reader.Read())
                {
                    var attendee = new Attendee();
                    attendee.Id = (int)reader["id"];
                    attendee.Name = reader["name"].ToString();
                    attendee.Email = reader["email"].ToString();
                    attendee.CreatedAt = (DateTime)reader["createdAt"];
                    attendee.UpdatedAt = (DateTime)reader["updatedAt"]; 
                    attendees.Add(attendee);
                }
            }
            return attendees;
        }

        public List<Organizer> Organizers()
        {
            List<Organizer> organizers;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Organizer", connection);
                SqlDataReader reader = command.ExecuteReader();
                organizers = new List<Organizer>();
                while (reader.Read())
                {
                    var organizer = new Organizer();
                    organizer.Id = (int)reader["id"];
                    organizer.Name = reader["name"].ToString();
                    organizer.Email = reader["email"].ToString();
                    organizer.CreatedAt = (DateTime)reader["createdAt"];
                    organizer.UpdatedAt = (DateTime)reader["updatedAt"];
                    organizers.Add(organizer);
                }
            }
            return organizers;
        }

        public List<Venue> Venues()
        {
            List<Venue> venues;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Venue", connection);
                SqlDataReader reader = command.ExecuteReader();
                venues = new List<Venue>();
                while (reader.Read())
                {
                    var venue = new Venue();
                    venue.Id = (int)reader["id"];
                    venue.Name = reader["name"].ToString();
                    venue.Location = reader["location"].ToString();
                    venue.Capacity = (int)reader["capacity"];
                    venue.CreatedAt = (DateTime)reader["createdAt"];
                    venue.UpdatedAt = (DateTime)reader["updatedAt"];
                    venues.Add(venue);
                }
            }
            return venues;
        }
        public List<Ticket> Tickets()
        {
            List<Ticket> tickets;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Ticket", connection);
                SqlDataReader reader = command.ExecuteReader();
                tickets = new List<Ticket>();
                while (reader.Read())
                {
                    var ticket = new Ticket();
                    ticket.Id = (int)reader["id"];
                    ticket.Price = (decimal)reader["price"];
                    if (reader["checkIn"] != DBNull.Value)
                    {
                        ticket.CheckIn = (DateTime?)reader["checkIn"];
                    }
                    else
                    {
                        ticket.CheckIn = null;
                    }
                    ticket.AttendeeId = (int)reader["attendeeId"];
                    ticket.EventId = (int)reader["eventId"];
                    ticket.CreatedAt = (DateTime)reader["createdAt"];
                    ticket.UpdatedAt = (DateTime)reader["updatedAt"];
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }
    }
}
