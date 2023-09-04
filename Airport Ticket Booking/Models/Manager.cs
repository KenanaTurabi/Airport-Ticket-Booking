using Airport_Ticket_Booking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{
    internal class Manager
    {
        public void FilterByPrice(float price, List<Booking> BookingList)
        {
            var filteredBookingsByPrice = BookingList.Where(book => book.flight.GetPrice() == price).ToList();
            if (filteredBookingsByPrice.Count() == 0)
            {
                Console.WriteLine($"This price value does not exist in the booking list");
            }
            else
            {
                foreach (var book in filteredBookingsByPrice)
                {
                    Console.WriteLine(book.ToString());
                }
            }
        }
        public void FilterByDestinationCountry(string DestinationCountry, List<Booking> BookingList)
        {
            var filteredBookingsByDestinationCountry = BookingList.Where(book => book.flight.DestinationCountry == DestinationCountry).ToList();
            if (filteredBookingsByDestinationCountry.Count() == 0)
                Console.WriteLine($"This DestinationCountry does not exist in the bookings list ");
            else
            {
                foreach (var book in filteredBookingsByDestinationCountry)
                {
                    Console.WriteLine(book.ToString());
                }
            }           
        }
        public void FilterByDepartureCountry(string DepartureCountry, List<Booking> BookingList)
        {
            var filteredBookingsByDepartureCountry = BookingList.Where(book => book.flight.DepartureCountry == DepartureCountry).ToList();
            if (filteredBookingsByDepartureCountry.Count() == 0)
                Console.WriteLine($"This DepartureCountry does not exist in the bookings list ");
            else
            {
                foreach (var book in filteredBookingsByDepartureCountry)
                {
                    Console.WriteLine(book.ToString());
                }
            }           
        }
        public void FilterByArrivalAirport(string ArrivalAirport, List<Booking> BookingList)
        {
            var filteredBookingsByArrivalAirport = BookingList.Where(book => book.flight.ArrivalAirport == ArrivalAirport).ToList();
            if(filteredBookingsByArrivalAirport.Count() == 0)
            {
                Console.WriteLine($"This ArrivalAirport does not exist in the bookings list ");
            }
            else
            {
                foreach (var book in filteredBookingsByArrivalAirport)
                {
                    Console.WriteLine(book.ToString());
                }
            }      
        }
        public void FilterByDepartureAirport(string DepartureAirport, List<Booking> BookingList)
        {
            var filteredBookingsByDepartureAirport = BookingList.Where(book => book.flight.DepartureAirport == DepartureAirport).ToList();
            if( filteredBookingsByDepartureAirport.Count() == 0)
            {
                Console.WriteLine($"This DepartureAirport does not exist in the bookings list ");
            }
            else
            {
                foreach (var book in filteredBookingsByDepartureAirport)
                {
                    Console.WriteLine(book.ToString());
                }
            }         
        }
        public void FilterByFlightClass(FlightClassEnum flightClass, List<Booking> BookingList)
        {
            var filteredBookingsByflightClass = BookingList.Where(book => book.flight.FlightClass == flightClass).ToList();
            if(filteredBookingsByflightClass.Count() == 0)
            {
                Console.WriteLine($"This flightClass does not exist in the bookings list ");
            }
            else 
            {
                foreach (var book in filteredBookingsByflightClass)
                {
                    Console.WriteLine(book.ToString());
                }
            }          
        }
        public void FilterByFlightDateTime(DateTime dateTime, List<Booking> BookingList)
        {
            var filteredBookingsByDateTime = BookingList.Where(book => book.flight.DepartureDate == dateTime).ToList();
            if (filteredBookingsByDateTime.Count() == 0)
            {
                Console.WriteLine($"This DateTime does not exist in the bookings list ");
            }
            else
            {
                foreach (var book in filteredBookingsByDateTime)
                {
                    Console.WriteLine(book.ToString());
                }
            }        
        }
        public void FilterBookings(SearchParameter filterBookingsAccordingTo, List<Booking> BookingList)
        {
            if (filterBookingsAccordingTo == SearchParameter.Price)
            {
                Console.Write("plz enter a price: ");
                FilterByPrice(float.Parse(Console.ReadLine()),BookingList);
            }
            else if (filterBookingsAccordingTo == SearchParameter.DestinationCountry)
            {
                Console.Write("plz enter a DestinationCountry: ");
                FilterByDestinationCountry(Console.ReadLine(), BookingList);
            }
            else if (filterBookingsAccordingTo == SearchParameter.DepartureCountry)
            {
                Console.Write("plz enter a DepartureCountry: ");
                FilterByDepartureCountry(Console.ReadLine(), BookingList);
            }
            else if (filterBookingsAccordingTo == SearchParameter.ArrivalAirport)
            {
                Console.Write("plz enter a ArrivalAirport: ");
                FilterByArrivalAirport(Console.ReadLine(), BookingList);
            }
            else if (filterBookingsAccordingTo == SearchParameter.DepartureAirport)
            {
                Console.Write("plz enter a ArrivalAirport: ");
                FilterByDepartureAirport(Console.ReadLine(), BookingList);
            }
            else if (filterBookingsAccordingTo == SearchParameter.Class)
            {
                Console.Write("plz enter a Class: ");
                FlightClassEnum flightClassEnumay = (FlightClassEnum)Enum.Parse(typeof(FlightClassEnum), Console.ReadLine());
                FilterByFlightClass(flightClassEnumay, BookingList);
            }
            else
            {
                Console.Write("plz enter a DateTime: ");
                FilterByFlightDateTime(DateTime.Parse(Console.ReadLine()), BookingList);
            }                 
        }
    }
}

