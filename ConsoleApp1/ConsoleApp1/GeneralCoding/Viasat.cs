using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /**
 Given N lists of strings, return a single list of unique values,
 and a second list of all the duplicate values with the counts of each item.
 Input: [["foo bar", "bazz"], ["foo Bar"]]
 Output: ["foo bar", "bazz"]
         {"foo bar": 2}
 */
    public class Viasat
    {
        public static void Main(string[] args)
        {
            List<List<string>> valueLists = new List<List<string>>();
            // Your functions here
            valueLists.Add(new List<string> { "foo bar", "bazz", });
            valueLists.Add(new List<string> { "foo bar" });
            var merged = new List<String>();
            foreach (var item in valueLists)
            {
                merged.AddRange(item);
            }
            var g = merged.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => new { Element = x.Key, Count = x.Count() }).First();
            var d = merged.Distinct();
            Console.WriteLine(string.Join(",", d));
            Console.WriteLine(g.Element + ":" + g.Count);
        }
    }
}
