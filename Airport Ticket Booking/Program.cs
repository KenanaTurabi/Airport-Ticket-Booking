using Airport_Ticket_Booking.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Airport_Ticket_Booking
{
    internal class Program
    {
        public List<Booking> AllBookingsList = new List<Booking>();
        public static void Menu()
        {
            Console.WriteLine($"----Airport Ticket Booking -----");
            Console.WriteLine();
            Console.WriteLine($"----Passenger Menu -----");
            Console.WriteLine();
            Console.WriteLine($"1- see all flights");
            Console.WriteLine($"2- book a ticket");
            Console.WriteLine($"3- edit a ticket");
            Console.WriteLine($"4- cancel a booking");
            Console.WriteLine($"5- see all of your bookings");
            Console.WriteLine();
            Console.WriteLine($"----Manager Menu -----");
            Console.WriteLine();
            Console.WriteLine($"6- filter bookings by price");
            Console.WriteLine($"7- filter bookings by DepartureCountry");
            Console.WriteLine($"8- filter bookings by DestinationCountry");
            Console.WriteLine($"9- filter bookings by DepartureDate");
            Console.WriteLine($"10- filter bookings by DepartureAirport");
            Console.WriteLine($"11- filter bookings by ArrivalAirport");
            Console.WriteLine($"12- filter bookings by class");
            Console.WriteLine($"13- Exit");

            Console.Write($"plz enter your choice:  ");
            
        }
        static void Main(string[] args)
        {
            Passenger passenger = new Passenger();

            while (true)
            {
                Menu();
                int choice = Int32.Parse(Console.ReadLine());
                string csvFilePath = "Flights.csv";
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var flights = csv.GetRecords<Flight>();
                    if (choice == 1)
                    {
                        foreach (var flight in flights)
                        {
                            Console.WriteLine($"FlightId: {flight.FlightId}");
                            Console.WriteLine($"--------");
                            Console.WriteLine($"DepartureCountry: {flight.DepartureCountry}, " +
                                $"DestinationCountry: {flight.DestinationCountry}, DepartureDate: {flight.DepartureDate}, DepartureAirport: {flight.DepartureAirport}," +
                                $" ArrivalAirport: {flight.ArrivalAirport},FlightClass: {flight.FlightClass}, Price: {flight.Price}");
                            Console.WriteLine();

                        }
                    }
                    else if (choice == 2)
                    {
                    Console.Write("plz enter flight id to complete booking process:");
                    passenger.BookFlight(Int32.Parse(Console.ReadLine()));

                    }
                    else if(choice==3)
                    {
                    Console.Write("plz enter booking id to edit the booking:");
                    passenger.ModifyBooking(Int32.Parse(Console.ReadLine()));
                    }
                    else if (choice == 4)
                    {
                    Console.Write("plz enter booking id to cancle the booking:");
                    passenger.CancleBooking(Int32.Parse(Console.ReadLine()));
                    }

                    else if (choice == 5)
                    {
                        passenger.ViewBookings();

                    }

                }
            }
           
        }
    }
}
