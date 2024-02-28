using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace ConsoleApp1
{
    // for andela sync with jude on 28th feb 1:30pm for wolters kluwers
    public class JsonClass
    {
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string CountryAbbr { get; set; }
        public List<Location> Places { get; set; }
    }
    public class Location
    {
        public string PlaceName { get; set; }
        public string Longitude { get; set; }
        public string State { get; set; }
        public string StateAbbr { get; set; }
        public string Lattitude { get; set; }




    }
    public class Reading
    {
        public static void Main(string[] args)
        {
            using (ZipArchive zip = ZipFile.Open("C:\\Users\\Sridhar.Swaminathan\\downloads\\reading.zip", ZipArchiveMode.Read))
                foreach (ZipArchiveEntry entry in zip.Entries)
                    if (entry.Name == "reading.txt")
                        entry.ExtractToFile("C:\\Users\\Sridhar.Swaminathan\\downloads\\myfile.txt");
            string ss=File.ReadAllText("C:\\Users\\Sridhar.Swaminathan\\downloads\\myfile.txt");
            var des=JsonConvert.DeserializeObject<JsonClass>(ss);
            Console.WriteLine(des.Country);
            Console.WriteLine(des.Places[0].State);

        }
    }
}
