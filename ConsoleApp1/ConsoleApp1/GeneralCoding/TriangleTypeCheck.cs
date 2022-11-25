using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     asked in XA group hackerrank test
    */
    public class TriangleTypeCheck
    {
        public static void Main(string[] args)
        {
            var ret = TriangleType(new List<string> { "2 2 1", "3 3 3", "3 4 5", "1 1 3" });
            foreach (var item in ret)
            {
                Console.WriteLine(item);
            }
            /*
            1. the first one is vali as it has 2 equal parts i.e. isosceles
            2. second is valid and has all 3 equal, so Equilateral
            3. third is valid but none of the two speciic forms
            4. triangle is invalid as per formula in the comments
            so output is,
            isosceles
            equilateral
            none of these
            none of these
            */
        }
        public static List<string> TriangleType(List<string> triangleToy)
        {
            List<string> t = new List<string>();
            foreach (string s in triangleToy)
            {
                List<int> sides = new List<int>();
                var sides1 = s.Split(' ');
                foreach (var s1 in sides1)
                {
                    sides.Add(int.Parse(s1));
                }
                bool invalid =
                    (sides[0] + sides[1] <= sides[2]) ||
                    (sides[0] + sides[2] <= sides[1]) ||
                    (sides[1] + sides[2] <= sides[0]);
                if (!invalid)
                {
                    if ((sides[0] == sides[1]) && (sides[1] == sides[2]))
                        t.Add("Equilateral");
                    else if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
                        t.Add("Isosceles");
                    else
                        t.Add("None of these");
                }
                else
                    t.Add("None of these");
            }
            return t;
            /*
            WHEN A + B <= C OR A + C <= B OR B + C <= A THEN 'Not A Triangle' 
            WHEN A = B AND B = C THEN 'Equilateral' 
            WHEN A = B OR B = C OR A = C THEN 'Isosceles' 
            ELSE 'Scalene' 
            */
        }
    }
}
