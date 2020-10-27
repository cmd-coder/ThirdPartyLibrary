using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace ThirdPartyLibrary
{
    public class CSVHandler
    {
        
        public static void ImplementCSVDataHandling()
        {
            string path = @"C:\Users\dell\source\repos\ThirdPartyLibrary\ThirdPartyLibrary\Utility\Address.csv";
            string exportPath = @"C:\Users\dell\source\repos\ThirdPartyLibrary\ThirdPartyLibrary\Utility\export.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data Reading done successfully");
                foreach(AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.WriteLine();
                }

                using (var writer = new StreamWriter(exportPath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
