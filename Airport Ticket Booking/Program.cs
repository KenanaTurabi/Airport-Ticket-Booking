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
            String filePath = "Flights.csv";
            var flights= readDataFromCsv.ReadFromCsv(filePath);
            AirportTicketMenu Menu =new AirportTicketMenu();
            Manager manager = new Manager();
            while (true)
            {
                AirportTicketMenu.ViewMenu();
                int choice = Int32.Parse(Console.ReadLine());
                    foreach (var flight in flights)
                    {
                        flight.SetPriceAccordingToType();
                    }
                    if (choice == AirportTicketMenu.ViewAllFlights)
                    {
                      DataManpulation.ViewAllFlights(flights);
                    }
                    else if (choice == AirportTicketMenu.BookTicket)
                    {
                    Console.Write("plz enter flight id to complete booking process:");
                    int FlightId = Int32.Parse(Console.ReadLine());
                    DataManpulation.BookTicket(flights,FlightId);
                    }
                    else if (choice == AirportTicketMenu.EditTicket)
                    {
                    Console.Write("plz enter booking id to edit the booking:");
                    int BookingIdToEdit = Int32.Parse(Console.ReadLine());
                    DataManpulation.EditTicket(flights, BookingIdToEdit);
                    }
                    else if (choice == AirportTicketMenu.CancelBooking)
                    {
                    Console.Write("plz enter booking id to cancle the booking:");
                    int BookingId = Int32.Parse(Console.ReadLine());
                    DataManpulation.CancelBooking(BookingId);
                    }
                    else if (choice == AirportTicketMenu.ViewAllBookings)
                    {
                       DataManpulation.ViewAllBookings();
                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByPrice)
                    {
                        manager.FilterBookings(SearchParameter.Price, DataManpulation.AllBookingsList);
                        
                    }
                    else if(choice == AirportTicketMenu.FilterBookingsByDepartureCountry)
                    {
                        manager.FilterBookings(SearchParameter.DepartureCountry, DataManpulation.AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByDestinationCountry)
                    {
                        manager.FilterBookings(SearchParameter.DestinationCountry, DataManpulation.AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByDepartureDate)
                    {
                        manager.FilterBookings(SearchParameter.DepartureDate, DataManpulation.AllBookingsList);

                    }
                    else if (choice ==  AirportTicketMenu.FilterBookingsByDepartureAirport)
                    {
                        manager.FilterBookings(SearchParameter.DepartureAirport, DataManpulation.AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByArrivalAirport)
                    {
                        manager.FilterBookings(SearchParameter.ArrivalAirport, DataManpulation.AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByClass)
                    {
                        manager.FilterBookings(SearchParameter.Class, DataManpulation.AllBookingsList);

                    }

                    else if(choice == AirportTicketMenu.Exit)
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
