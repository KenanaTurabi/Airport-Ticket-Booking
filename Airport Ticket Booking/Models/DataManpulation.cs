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
        private static Passenger Passenger;
        public DataManpulation(Passenger passenger)
        {
            Passenger = passenger;

        }
        public static void ViewAllFlights(List<Flight> flights)
        {
            foreach (var flight in flights)
            {
                Console.WriteLine($"FlightId: {flight.FlightId}");
                Console.WriteLine($"--------");
                Console.WriteLine($"DepartureCountry: {flight.DepartureCountry}, " +
                    $"DestinationCountry: {flight.DestinationCountry}, DepartureDate: {flight.DepartureDate}, DepartureAirport: {flight.DepartureAirport}," +
                    $" ArrivalAirport: {flight.ArrivalAirport},FlightClass: {flight.FlightClass}, Price: {flight.GetPrice()}");
                Console.WriteLine();
            }
        }
        public static void BookTicket(List<Flight> flights, int FlightId)
        {
            Flight flightToBook =flights.Where(f => f.FlightId ==FlightId).FirstOrDefault();
            if (flightToBook == null)
            {
                Console.WriteLine("No flight with this id !");
            }
            else
            {
                Passenger.BookFlight(flightToBook, AllBookingsList);

            }
        }
        public static void EditTicket(List<Flight> flights,int BookingIdToEdit)
        {
            Passenger.ModifyBooking(BookingIdToEdit, flights);
        }
        public static void CancelBooking(int BookingId)
        {
            Passenger.CancleBooking(BookingId);
        }
        public static void ViewAllBookings()
        {
            Passenger.ViewBookings();
        }
    }
}
