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
        public List<Flight> flights;


        public List<Flight> ReadFromCsv(string filePath)
        {
           using (var reader = new StreamReader(filePath))
           using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
                flights = csv.GetRecords<Flight>().ToList();
                return flights;
            }
        }
        

    }
}
