using Airport_Ticket_Booking.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Airport_Ticket_Booking
{
    internal class Program
    {

        public void Menue()
        {
            Console.WriteLine($"----Airport Ticket Booking -----");
            Console.WriteLine($"1- see all flights");
            Console.WriteLine($"2- book a ticket");
            Console.WriteLine($"3- edit a ticket");
            Console.WriteLine($"4- cancle a booking");
            Console.WriteLine($"plz");
        }
        static void Main(string[] args)
        {
            string csvFilePath = "Flights.csv";
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var flights = csv.GetRecords<Flight>();

                foreach (var flight in flights)
                {
                    Console.WriteLine($"FlightId: {flight.FlightId}");
                    Console.WriteLine($"--------");
                    Console.WriteLine($"DepartureCountry: {flight.DepartureCountry}, " +
                        $"DestinationCountry: {flight.DestinationCountry}, DepartureDate: {flight.DepartureDate}, DepartureAirport: {flight.DepartureAirport}," +
                        $" ArrivalAirport: {flight.ArrivalAirport},FlightClass: {flight.Class}, Price: {flight.Price}");
                    Console.WriteLine();

                }
            }
        }
    }
}
