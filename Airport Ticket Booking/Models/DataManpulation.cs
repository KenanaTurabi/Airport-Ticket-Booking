using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{
    internal class DataManpulation
    {
        public static List<Booking> AllBookingsList = new List<Booking>();
        public static Passenger passenger = new Passenger();
        public static void ViewAllFlights()
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
        public static void BookTicket()
        {
            Console.Write("plz enter flight id to complete booking process:");
            int EnteredFlightId = Int32.Parse(Console.ReadLine());
            Flight flightToBook = ReadDataFromCsv.UpdatedFlights.Where(f => f.FlightId == EnteredFlightId).FirstOrDefault();
            if (flightToBook == null)
            {
                Console.WriteLine("No flight with this id !");
            }
            else
            {
                passenger.BookFlight(flightToBook, AllBookingsList);

            }
        }
        public static void EditTicket()
        {
            Console.Write("plz enter booking id to edit the booking:");
            int BookingIdToEdit = Int32.Parse(Console.ReadLine());
            passenger.ModifyBooking(BookingIdToEdit, ReadDataFromCsv.UpdatedFlights);
        }
        public static void CancelBooking()
        {
            Console.Write("plz enter booking id to cancle the booking:");
            passenger.CancleBooking(Int32.Parse(Console.ReadLine()));
        }
        public static void ViewAllBookings()
        {
            passenger.ViewBookings();
        }
    }
}
