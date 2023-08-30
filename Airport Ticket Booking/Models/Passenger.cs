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
    }
}
