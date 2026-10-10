using EventManagementSystem.Data.Interfaces;
using EventManagementSystem.Data.Repositories;
using EventManagementSystem.Data.Services;
using System;

namespace EventManagementSystem.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IDatabaseManager dbManager = new InMemoryDatabaseManager();
                //IDatabaseManager dbManager = new SqlDatabaseManager(@"Server=walidrab27\SQLEXPRESS;Database=EventManagementSystemDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
                EventQueryService eventQueryService = new EventQueryService(dbManager);
                EventReportPrinter reportPrinter = new EventReportPrinter(eventQueryService);

                reportPrinter.PrintAllReports();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}