﻿using Airport_Ticket_Booking.Enums;
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
        public string DestinationCountry { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public FlightClassEnum FlightClass { get; set; }

    }
}
