using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{
    internal class ReadDataFromCsv
    {
        public static List<Flight> flights;

        public static List<Flight> UpdatedFlights;

        public static void ReadFromCsv(string filePath)
        {
           using (var reader = new StreamReader(filePath))
           using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
                flights = csv.GetRecords<Flight>().ToList();
                UpdatedFlights = new List<Flight>();

            }
        }
        

    }
}
