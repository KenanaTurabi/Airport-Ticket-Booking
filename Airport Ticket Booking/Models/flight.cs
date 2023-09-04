using Airport_Ticket_Booking.Enums;
using Airport_Ticket_Booking.Models;
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
        private float Price { get; set; }
        public  DateTime DepartureDate { get; set; }
        public string DepartureCountry { get; set; }
        public string DestinationCountry { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public FlightClassEnum FlightClass { get; set; }

        public void SetPriceAccordingToType() 
        {
            float price=0;
            if (FlightClass == FlightClassEnum.Business)
            {
               Price= 1000;
            }
            else if (FlightClass == FlightClassEnum.Economy)
            {
                Price= 2000;
            }
            else
            {
                Price=  3000;
            }
        }
        public float GetPrice()
        {
            return Price;
        }
       


       
public override string ToString()
        {
            return $"FlightId: {FlightId}, Price: {Price}, DepartureDate: {DepartureDate},DepartureCountry: {DepartureCountry},DestinationCountry: {DestinationCountry},DepartureAirport: {DepartureAirport},ArrivalAirport: {ArrivalAirport},FlightClass,{FlightClass} ";
        }

    }
}
