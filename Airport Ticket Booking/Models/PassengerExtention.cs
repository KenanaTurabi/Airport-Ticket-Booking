using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{
    internal static class  PassengerExtention
    {
        public static void CancleBooking(this Passenger passenger, int BookingId)//passenger extention
        {
            Booking booking = passenger.PassengerBookingsList.Where(x => x.BookingId == BookingId).FirstOrDefault();
            passenger.PassengerBookingsList.Remove(booking);
        }

        public static void ModifyBooking(this Passenger passenger, int BookingId,IEnumerable<Flight> flights)
        {
            var BookingToModify = passenger.PassengerBookingsList.FirstOrDefault(book => book.BookingId == BookingId);
            if (BookingToModify == null)
            {
                Console.WriteLine($"This Booking does not exist ");
            }
            else
            {
                Console.Write("Enter new flight id: ");
                int flightId = Int32.Parse(Console.ReadLine());
                var checkIfExist = flights.Where(flight => flight.FlightId == flightId).ToList();
                if (checkIfExist.Any())
                {
                    BookingToModify.flight.FlightId = flightId;
                }
                else
                {
                    Console.WriteLine("this flight id does not exist!");
                }             
            }
        }

        public static void BookFlight(this Passenger passenger, Flight flight, List<Booking> AllBookingsList)
        {
            Booking booking = new Booking();
            booking.PassengerId = passenger.PassengerId;
            passenger.BookingId++;
            booking.flight = flight;
            booking.BookingId = passenger.BookingId;
            booking.BookingDateTime = DateTime.Now;
            passenger.PassengerBookingsList.Add(booking);
            AllBookingsList.Add(booking);
            Console.WriteLine("your booking done successfully");

        }
        public static void ViewBookings(this Passenger passenger)
        {
            Console.WriteLine("This is Your Booking list: ");
            passenger.PassengerBookingsList.ForEach(booking => Console.WriteLine(booking.ToString()));
        }

    }
}
