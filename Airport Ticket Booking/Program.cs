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
            ReadDataFromCsv.ReadFromCsv();
            AirportTicketMenu Menu =new AirportTicketMenu();
            Manager manager = new Manager();
            while (true)
            {
                AirportTicketMenu.ViewMenu();
                int choice = Int32.Parse(Console.ReadLine());
                    foreach (var flight in ReadDataFromCsv.flights)
                    {
                        flight.SetPriceAccordingToType();
                        ReadDataFromCsv.UpdatedFlights.Add(flight);
                    }
                    if (choice == AirportTicketMenu.ViewAllFlights)
                    {
                      DataManpulation.ViewAllFlights();
                    }
                    else if (choice == AirportTicketMenu.BookTicket)
                    {
                        DataManpulation.BookTicket();
                    }
                    else if (choice == AirportTicketMenu.EditTicket)
                    {
                      DataManpulation.EditTicket();
                    }
                    else if (choice == AirportTicketMenu.CancelBooking)
                    {
                      DataManpulation.CancelBooking();
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
