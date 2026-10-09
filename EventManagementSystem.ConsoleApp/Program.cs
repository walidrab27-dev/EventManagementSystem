using EventManagementSystem.Data.Interfaces;
using EventManagementSystem.Data.Models;
using EventManagementSystem.Data.Repositories;
using EventManagementSystem.Data.Services;
using System;

namespace EventManagementSystem.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDatabaseManager dbManager = new SqlDatabaseManager(@"Server=walidrab27\SQLEXPRESS;Database=EventManagementSystemDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
            EventQueryService eventQueryService = new EventQueryService(dbManager);
            var fullyBookedEvents = eventQueryService.EventsThatFullyBooked();
            foreach (var eventInfo in fullyBookedEvents)
            {
                Console.WriteLine($"Event: {eventInfo.Title}, Tickets Sold: {eventInfo.TicketCount} / {eventInfo.Capacity}");
            }
        }
    }
}
