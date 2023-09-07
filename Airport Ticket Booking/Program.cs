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
            List<Booking> AllBookingsList = new List<Booking>();
            Passenger passenger = new Passenger();
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
                        foreach (var flight in ReadDataFromCsv.UpdatedFlights)
                        {
                            Console.WriteLine($"FlightId: {flight.FlightId}");
                            Console.WriteLine($"--------");
                            Console.WriteLine($"DepartureCountry: {flight.DepartureCountry}, " +
                                $"DestinationCountry: {flight.DestinationCountry}, DepartureDate: {flight.DepartureDate}, DepartureAirport: {flight.DepartureAirport}," +
                                $" ArrivalAirport: {flight.ArrivalAirport},FlightClass: {flight.FlightClass}, Price: {flight.GetPrice()}");
                            Console.WriteLine();
                        }
                    }
                    else if (choice == AirportTicketMenu.BookTicket)
                    {
                        Console.Write("plz enter flight id to complete booking process:");
                        int EnteredFlightId =Int32.Parse(Console.ReadLine());
                        Flight flightToBook= ReadDataFromCsv.UpdatedFlights.Where(f => f.FlightId == EnteredFlightId).FirstOrDefault();
                        if (flightToBook ==null)
                        {
                            Console.WriteLine("No flight with this id !");
                        }
                        else
                        {
                            passenger.BookFlight(flightToBook, AllBookingsList);

                        }
                    }
                    else if (choice == AirportTicketMenu.EditTicket)
                    {
                        Console.Write("plz enter booking id to edit the booking:");
                        int BookingIdToEdit = Int32.Parse(Console.ReadLine());
                        passenger.ModifyBooking(BookingIdToEdit, ReadDataFromCsv.UpdatedFlights);
                                             
                    }
                    else if (choice == AirportTicketMenu.CancelBooking)
                    {
                        Console.Write("plz enter booking id to cancle the booking:");
                        passenger.CancleBooking(Int32.Parse(Console.ReadLine()));
                    }
                    else if (choice == AirportTicketMenu.ViewAllBookings)
                    {
                        passenger.ViewBookings();

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByPrice)
                    {
                        manager.FilterBookings(SearchParameter.Price, AllBookingsList);
                        
                    }
                    else if(choice == AirportTicketMenu.FilterBookingsByDepartureCountry)
                    {
                        manager.FilterBookings(SearchParameter.DepartureCountry, AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByDestinationCountry)
                    {
                        manager.FilterBookings(SearchParameter.DestinationCountry, AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByDepartureDate)
                    {
                        manager.FilterBookings(SearchParameter.DepartureDate, AllBookingsList);

                    }
                    else if (choice ==  AirportTicketMenu.FilterBookingsByDepartureAirport)
                    {
                        manager.FilterBookings(SearchParameter.DepartureAirport, AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByArrivalAirport)
                    {
                        manager.FilterBookings(SearchParameter.ArrivalAirport, AllBookingsList);

                    }
                    else if (choice == AirportTicketMenu.FilterBookingsByClass)
                    {
                        manager.FilterBookings(SearchParameter.Class, AllBookingsList);

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
