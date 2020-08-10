using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KeyP
    {
        public static void Main(string[] args)
        {
            string[] m = {"hfail",
"bz",
"hfail",
"ru",
"fkqb",
"fkqb",
"hfail",
"ru",
"ru",
"hfail",
"bz",
"fkqb",
"bz",
"bz",
"fkqb",
"bz",
"fkqb",
"ru",
"fkqb",
"ru",
"ru",
"bz",
"hfail",
"fkqb",
"hfail",
"bz",
"hfail",
"ru",
"hfail",
"bz",
"bz",
"bz",
"fkqb",
"ru",
"fkqb",
"hfail",
"fkqb",
"bz",
"bz",
"hfail",
"hfail",
"hfail",
"bz",
"hfail",
"ru",
"ru",
"hfail",
"hfail",
"bz",
"hfail",
 };

            string[] s = { "redShirt", "greenPants", "redShirt", "orangeShoes", "blackPants", "blackPants" };
            Console.WriteLine(featuredProduct(m.ToList()));
        }
        public static string featuredProduct(List<string> products)
        {
            Dictionary<string, int> statistics = products
    .GroupBy(word => word)
    .ToDictionary(
        kvp => kvp.Key, // the word itself is the key
        kvp => kvp.Count()); // number of occurences is the value

            string[] duplicates = statistics
        .OrderByDescending(kvp => kvp.Value > 1)
        .Select(kvp => kvp.Key)
        .ToArray();
            var list = duplicates.ToList(); list.Sort();
            int i = list.Count;
            return list[i - 1];
        }

    }
}
