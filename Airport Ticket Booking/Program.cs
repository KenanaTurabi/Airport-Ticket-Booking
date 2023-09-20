using Airport_Ticket_Booking.Enums;
using Airport_Ticket_Booking.Menu;
using Airport_Ticket_Booking.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Airport_Ticket_Booking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadDataFromCsv readDataFromCsv = new ReadDataFromCsv();
            Passenger passenger = new Passenger();
            DataManpulation dataManpulation = new DataManpulation(passenger);
            String filePath = "Flights.csv";
            var flights = readDataFromCsv.ReadFromCsv(filePath);
            AirportTicketMenu Menu = new AirportTicketMenu();
            Manager manager = new Manager();
            while (true)
            {
                AirportTicketMenu.ViewMenu();
                int choice = Int32.Parse(Console.ReadLine());
                foreach (var flight in flights)
                {
                    flight.SetPriceAccordingToType();
                }
                switch (choice)
                {
                    case AirportTicketMenu.ViewAllFlights:
                        dataManpulation.ViewAllFlights(flights);
                        break;
                    case AirportTicketMenu.BookTicket:
                        Console.Write("plz enter flight id to complete booking process:");
                        int FlightId = Int32.Parse(Console.ReadLine());
                        dataManpulation.BookTicket(flights, FlightId);
                        break;
                    case AirportTicketMenu.EditTicket:
                        Console.Write("plz enter booking id to edit the booking:");
                        int BookingIdToEdit = Int32.Parse(Console.ReadLine());
                        dataManpulation.EditTicket(flights, BookingIdToEdit);
                        break;
                    case AirportTicketMenu.CancelBooking:
                        Console.Write("plz enter booking id to cancle the booking:");
                        int BookingId = Int32.Parse(Console.ReadLine());
                        dataManpulation.CancelBooking(BookingId);
                        break;
                    case AirportTicketMenu.ViewAllBookings:
                        dataManpulation.ViewAllBookings();
                        break;
                    case AirportTicketMenu.FilterBookingsByPrice:
                        manager.FilterBookings(SearchParameter.Price, DataManpulation.AllBookingsList);
                        break;
                    case AirportTicketMenu.FilterBookingsByDepartureCountry:
                        manager.FilterBookings(SearchParameter.DepartureCountry, DataManpulation.AllBookingsList);
                        break;
                    case AirportTicketMenu.FilterBookingsByDestinationCountry:
                        manager.FilterBookings(SearchParameter.DestinationCountry, DataManpulation.AllBookingsList);
                        break;

                    case AirportTicketMenu.FilterBookingsByDepartureDate:
                        manager.FilterBookings(SearchParameter.DepartureDate, DataManpulation.AllBookingsList);
                        break;
                    case AirportTicketMenu.FilterBookingsByDepartureAirport:
                        manager.FilterBookings(SearchParameter.DepartureAirport, DataManpulation.AllBookingsList);
                        break;
                    case AirportTicketMenu.FilterBookingsByArrivalAirport:
                        manager.FilterBookings(SearchParameter.ArrivalAirport, DataManpulation.AllBookingsList);
                        break;
                    case AirportTicketMenu.FilterBookingsByClass:
                        manager.FilterBookings(SearchParameter.Class, DataManpulation.AllBookingsList);
                        break;
                    case AirportTicketMenu.Exit:
                        Console.WriteLine("EXIT");
                        break;
                    default:
                        Console.WriteLine("EXIT");
                        break;

                }
            }
        }
    }
}
