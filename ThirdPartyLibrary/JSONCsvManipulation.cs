using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyLibrary
{
    public class JSONCsvManipulation
    {
        public static void ImplementCsvToJson()
        {
            string path = @"C:\Users\dell\source\repos\ThirdPartyLibrary\ThirdPartyLibrary\Utility\Address.csv";
            string exportPath = @"C:\Users\dell\source\repos\ThirdPartyLibrary\ThirdPartyLibrary\Utility\addressDetails.json";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data Reading done successfully");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.WriteLine();
                }

                string jsonToCsvPath = @"C:\Users\dell\source\repos\ThirdPartyLibrary\ThirdPartyLibrary\Utility\fromJsonToCsv.csv";
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(exportPath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, records);
                }

                IList<AddressData> addressdata = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(exportPath));
                using(var writer=new StreamWriter(jsonToCsvPath))
                using(var csvExport=new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(addressdata);
                }
            }
        }
    }
}
