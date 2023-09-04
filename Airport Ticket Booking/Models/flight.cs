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
        private float Price;
        public  DateTime DepartureDate { get; set; }
        public string DepartureCountry { get; set; }
        public string DestinationCountry { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public FlightClassEnum FlightClass { get; set; }


        Dictionary<FlightClassEnum, float> PriceDictionary = new Dictionary<FlightClassEnum, float>()
            {
            { FlightClassEnum.Business,1000 },
            { FlightClassEnum.Economy,2000 },
            { FlightClassEnum.FirstClass,3000 }


            };
        public void SetPriceAccordingToType() 
        {
            if (PriceDictionary.TryGetValue(FlightClass, out float price))
            {
                Price = price;
            }
            else
            {
                Price = 0; 
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
