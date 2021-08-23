using System;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp1
{
    class Zenoti
    {
    }
    /*
     Print farthest elemt from 0, if there are multiple elements print the one having least value

     */
    public class FarthestElementZero
    {

    }
    /*
     break string at spaces preserve double quotes
    input
    xyz abc mnp "asdf dfaa asdf" asd "fdas asdsdafF"
    output
    xyz 
    abc 
    mnp 
    "asdf dfaa asdf" 
    asd 
    "fdas asdsdafF"
     */
    class BreakString
    {
        public static void Main()
        {
            String s = Console.ReadLine();
            //var re=new Regex("(?<=\")[^\"]*(?=\")|[^\"]+");
            var re = new Regex(@"([^\s]*""[^""]+""[^\s]*)|\w+");
            var strings = re.Matches(s).Cast<Match>().Select(m => m.Value).ToArray();
            foreach (var k in strings)
            {
                Console.WriteLine(k);
            }
        }
    }

}
