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

        public List<Booking>BookingsList=new List<Booking>();
        public int BookingId { get; set; }   


        public void CancleBooking(int BookingId)//passenger extention
        {
           BookingsList.RemoveAll(booking => booking.BookingId == BookingId);
        }

        public void ModifyBooking(List<Booking> bookings, int BookingId, int PassengerId, DateTime NewDateTime,int FligthId)
        {
            var BookingToModify = bookings.FirstOrDefault(book => book.PassengerId == PassengerId && book.BookingId == BookingId);
            if (BookingToModify == null)
            {
                Console.WriteLine($"This Booking not exist ");
            }
            else
            {
                BookingToModify.FlightId = FligthId;
                BookingToModify.BookingDateTime = NewDateTime;
            }


        }

        public void BookFlight(int FlightId)
        {
            Booking booking = new Booking();
            booking.PassengerId = PassengerId;
            booking.PassengerName = Name;
            booking.FlightId = FlightId;
            BookingId++;
            booking.BookingId = BookingId;
            BookingsList.Add(booking);

        }

        public void ViewBookings() 
        {
            Console.WriteLine("This is Your Booking list: ");
            BookingsList.ForEach(booking => Console.WriteLine($"{booking}\n"));
        }
    }
}
