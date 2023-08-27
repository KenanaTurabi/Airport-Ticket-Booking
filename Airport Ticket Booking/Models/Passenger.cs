using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{
    internal class Passenger
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }

        public List<Booking>PassengerBookingsList=new List<Booking>();
        public int BookingId { get; set; }   


        public void CancleBooking(int BookingId)//passenger extention
        {
            Booking booking = PassengerBookingsList.Where(x => x.BookingId == BookingId).FirstOrDefault();
            PassengerBookingsList.Remove(booking);
           // BookingsList.RemoveAll(booking => booking.BookingId == BookingId);
        }

        public void ModifyBooking(int BookingId)
        {
            var BookingToModify = PassengerBookingsList.FirstOrDefault(book =>book.BookingId == BookingId);
            if (BookingToModify == null)
            {
                Console.WriteLine($"This Booking does not exist ");
            }
            else
            {
                Console.WriteLine("Enter new flight id");
                BookingToModify.FlightId =Int32.Parse( Console.ReadLine());
                Console.WriteLine("Enter new passenger name");
                BookingToModify.PassengerName = Console.ReadLine();
            }


        }

        public void BookFlight(int FlightId)
        {
            Booking booking = new Booking();
            booking.PassengerId = PassengerId;
            booking.PassengerName = Name;
            booking.FlightId = FlightId;
            booking.BookingId = BookingId;
            PassengerBookingsList.Add(booking);

        }

        public void ViewBookings() 
        {
            Console.WriteLine("This is Your Booking list: ");
            PassengerBookingsList.ForEach(booking => Console.WriteLine($"{booking}\n"));
        }
    }
}
