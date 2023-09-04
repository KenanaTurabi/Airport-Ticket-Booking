using Airport_Ticket_Booking.Enums;
using Airport_Ticket_Booking.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Airport_Ticket_Booking
{
    internal class Program
    {
        private const int ViewAllFlights=1;
        private const int BookTicket=2;
        private const int EditTicket=3;
        private const int CancelBooking=4;
        private const int ViewAllBookings=5;
        private const int FilterBookingsByPrice=6;
        private const int FilterBookingsByDepartureCountry = 7;
        private const int FilterBookingsByDestinationCountry = 8;
        private const int FilterBookingsByDepartureDate = 9;
        private const int FilterBookingsByDepartureAirport = 10;
        private const int FilterBookingsByArrivalAirport = 11;
        private const int FilterBookingsByClass = 12;
        private const int Exit= 13;

        public static void Menu()
        {
            Console.WriteLine($"----Airport Ticket Booking -----");
            Console.WriteLine();
            Console.WriteLine($"----Passenger Menu -----");
            Console.WriteLine();
            Console.WriteLine($"{ViewAllFlights}- see all flights");
            Console.WriteLine($"{BookTicket}- book a ticket");
            Console.WriteLine($"{EditTicket}- edit a ticket");
            Console.WriteLine($"{CancelBooking}- cancel a booking");
            Console.WriteLine($"{ViewAllBookings}- see all of your bookings");
            Console.WriteLine();
            Console.WriteLine($"----Manager Menu -----");
            Console.WriteLine();
            Console.WriteLine($"{FilterBookingsByPrice}- filter bookings by price");
            Console.WriteLine($"{FilterBookingsByDepartureCountry}- filter bookings by DepartureCountry");
            Console.WriteLine($"{FilterBookingsByDestinationCountry}- filter bookings by DestinationCountry");
            Console.WriteLine($"{FilterBookingsByDepartureDate}- filter bookings by DepartureDate");
            Console.WriteLine($"{FilterBookingsByDepartureAirport}- filter bookings by DepartureAirport");
            Console.WriteLine($"{FilterBookingsByArrivalAirport}- filter bookings by ArrivalAirport");
            Console.WriteLine($"{FilterBookingsByClass}- filter bookings by class");
            Console.WriteLine($"{Exit}- Exit");
            Console.Write($"plz enter your choice:  ");
            
        }
        static void Main(string[] args)
        {
            List<Booking> AllBookingsList = new List<Booking>();
            Passenger passenger = new Passenger();
            Manager manager = new Manager();
            while (true)
            {
                Menu();
                int choice = Int32.Parse(Console.ReadLine());
                string csvFilePath = "Flights.csv";
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var flights = csv.GetRecords<Flight>().ToList();
                    var UpdatedFlights = new List<Flight>();
                     
                    foreach(var flight in flights)
                    {
                        flight.SetPriceAccordingToType();
                        UpdatedFlights.Add(flight);

                    }
                   
                    if (choice == ViewAllFlights)
                    {
                        foreach (var flight in UpdatedFlights)
                        {
                            Console.WriteLine($"FlightId: {flight.FlightId}");
                            Console.WriteLine($"--------");


                            Console.WriteLine($"DepartureCountry: {flight.DepartureCountry}, " +
                                $"DestinationCountry: {flight.DestinationCountry}, DepartureDate: {flight.DepartureDate}, DepartureAirport: {flight.DepartureAirport}," +
                                $" ArrivalAirport: {flight.ArrivalAirport},FlightClass: {flight.FlightClass}, Price: {flight.GetPrice()}");
                            Console.WriteLine();

                        }
                    }
                    else if (choice == BookTicket)
                    {
                        Console.Write("plz enter flight id to complete booking process:");
                        int EnteredFlightId =Int32.Parse(Console.ReadLine());
                        Flight flightToBook= UpdatedFlights.Where(f => f.FlightId == EnteredFlightId).FirstOrDefault();
                        if (flightToBook ==null)
                        {
                            Console.WriteLine("No flight with this id !");
                        }
                        else
                        {
                            passenger.BookFlight(flightToBook, AllBookingsList);

                        }
                    }
                    else if (choice == EditTicket)
                    {
                        Console.Write("plz enter booking id to edit the booking:");
                        int BookingIdToEdit = Int32.Parse(Console.ReadLine());
                        passenger.ModifyBooking(BookingIdToEdit, UpdatedFlights);
                        

                        
                    }
                    else if (choice == CancelBooking)
                    {
                        Console.Write("plz enter booking id to cancle the booking:");
                        passenger.CancleBooking(Int32.Parse(Console.ReadLine()));
                    }
                    else if (choice == ViewAllBookings)
                    {
                        passenger.ViewBookings();

                    }
                    else if (choice == FilterBookingsByPrice)
                    {
                        manager.FilterBookings(SearchParameter.Price, AllBookingsList);
                        
                    }
                    else if(choice == FilterBookingsByDepartureCountry)
                    {
                        manager.FilterBookings(SearchParameter.DepartureCountry, AllBookingsList);

                    }
                    else if (choice == FilterBookingsByDestinationCountry)
                    {
                        manager.FilterBookings(SearchParameter.DestinationCountry, AllBookingsList);

                    }
                    else if (choice == FilterBookingsByDepartureDate)
                    {
                        manager.FilterBookings(SearchParameter.DepartureDate, AllBookingsList);

                    }
                    else if (choice == FilterBookingsByDepartureAirport)
                    {
                        manager.FilterBookings(SearchParameter.DepartureAirport, AllBookingsList);

                    }
                    else if (choice == FilterBookingsByArrivalAirport)
                    {
                        manager.FilterBookings(SearchParameter.ArrivalAirport, AllBookingsList);

                    }
                    else if (choice == FilterBookingsByClass)
                    {
                        manager.FilterBookings(SearchParameter.Class, AllBookingsList);

                    }

                    else if(choice== Exit)
                    {
                        Console.WriteLine("EXIT");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("EXIT");
                        break;
                    }                                   
                }
            }         
        }
    }
}
