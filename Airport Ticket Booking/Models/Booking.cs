using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Models.Flight;

namespace Airport_Ticket_Booking.Models
{
    internal class Booking
    {
        public Flight flight = new Flight();
        public int BookingId { get; set; }
        public int PassengerId { get; set; }
       // public int FlightId { get; set; }
        public DateTime BookingDateTime { get; set; }

        public override string ToString()
        {
            return $"\nBookingId: {BookingId}, flight: {flight.ToString()}, PassengerId: {PassengerId},BookingDateTime: {BookingDateTime}\n";
        }
    }
}
