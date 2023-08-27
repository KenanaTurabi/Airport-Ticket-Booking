using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{
    internal class Flight
    {
        public int FlightId { get; set; }
        public float Price { get; set; }
        public  DateTime DepartureDate { get; set; }
        public string DepartureCountry { get; set; }
        public int DestinatioCountry { get; set; }
        public int DepartureAirport { get; set; }
        public int ArrivalAirport { get; set; }
        public enum FlightClass { Economy, Business, FirstClass }

    }
}
