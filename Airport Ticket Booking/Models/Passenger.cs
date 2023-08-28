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
                BookingToModify.FlightId =Int32.Parse(Console.ReadLine());
            }


        }

        public void BookFlight(int FlightId)
        {
            Booking booking = new Booking();
            booking.PassengerId = PassengerId;
            BookingId++;
            booking.FlightId = FlightId;
            booking.BookingId = BookingId;
            booking.BookingDateTime=DateTime.Now;
            PassengerBookingsList.Add(booking);
            Console.WriteLine("your booking done successfully");
            
        }
       
        public void ViewBookings() 
        {
            Console.WriteLine("This is Your Booking list: ");
            PassengerBookingsList.ForEach(booking => Console.WriteLine(booking.ToString()));
        }
    }
}
