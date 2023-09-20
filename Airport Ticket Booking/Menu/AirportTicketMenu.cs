using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Menu
{
    internal class AirportTicketMenu
    {
        public const int ViewAllFlights = 1;
        public const int BookTicket = 2;
        public const int EditTicket = 3;
        public const int CancelBooking = 4;
        public const int ViewAllBookings = 5;
        public const int FilterBookingsByPrice = 6;
        public const int FilterBookingsByDepartureCountry = 7;
        public const int FilterBookingsByDestinationCountry = 8;
        public const int FilterBookingsByDepartureDate = 9;
        public const int FilterBookingsByDepartureAirport = 10;
        public const int FilterBookingsByArrivalAirport = 11;
        public const int FilterBookingsByClass = 12;
        public const int Exit = 13;
        public static void ViewMenu()
        {
            Console.WriteLine($"----Airport Ticket Booking -----");
            Console.WriteLine();
            Console.WriteLine($"----Passenger Menu -----");
            Console.WriteLine();
            Console.WriteLine($"{ViewAllFlights}- see all flights");
            Console.WriteLine($"{BookTicket}- book a ticket");
            Console.WriteLine($"{EditTicket}- edit a ticket");
            Console.WriteLine($"{CancelBooking}- cancel a booking");
            Console.WriteLine($"{ViewAllBookings}- see all of your bookings");
            Console.WriteLine();
            Console.WriteLine($"----Manager Menu -----");
            Console.WriteLine();
            Console.WriteLine($"{FilterBookingsByPrice}- filter bookings by price");
            Console.WriteLine($"{FilterBookingsByDepartureCountry}- filter bookings by DepartureCountry");
            Console.WriteLine($"{FilterBookingsByDestinationCountry}- filter bookings by DestinationCountry");
            Console.WriteLine($"{FilterBookingsByDepartureDate}- filter bookings by DepartureDate");
            Console.WriteLine($"{FilterBookingsByDepartureAirport}- filter bookings by DepartureAirport");
            Console.WriteLine($"{FilterBookingsByArrivalAirport}- filter bookings by ArrivalAirport");
            Console.WriteLine($"{FilterBookingsByClass}- filter bookings by class");
            Console.WriteLine($"{Exit}- Exit");
            Console.Write($"plz enter your choice:  ");

        }
    }
}
