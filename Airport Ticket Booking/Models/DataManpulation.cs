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
        private readonly Passenger _passenger;
        public DataManpulation(Passenger passenger)
        {
            _passenger = passenger;

        }
        public void ViewAllFlights(List<Flight> flights)
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
        public void BookTicket(List<Flight> flights, int FlightId)
        {
            Flight flightToBook =flights.Where(f => f.FlightId ==FlightId).FirstOrDefault();
            if (flightToBook == null)
            {
                Console.WriteLine("No flight with this id !");
            }
            else
            {
                _passenger.BookFlight(flightToBook, AllBookingsList);

            }
        }
        public void EditTicket(List<Flight> flights,int BookingIdToEdit)
        {
            _passenger.ModifyBooking(BookingIdToEdit, flights);
        }
        public void CancelBooking(int BookingId)
        {
            _passenger.CancleBooking(BookingId);
        }
        public void ViewAllBookings()
        {
            _passenger.ViewBookings();
        }
    }
}
