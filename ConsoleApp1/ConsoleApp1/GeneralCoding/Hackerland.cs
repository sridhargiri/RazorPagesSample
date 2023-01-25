using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    Question https://www.hackerrank.com/challenges/hackerland-radio-transmitters/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
    Java code https://programs.programmingoneonone.com/2021/07/hackerrank-hackerland-radio-transmitters-problem-solution.html
STDIN       Function
-----       --------
5 1         x[] size n = 5, k = 1
1 2 3 4 5   x = [1, 2, 3, 4, 5] 
output 2
     */
    public class Hackerland
    {
        public static int HackerlandRadioTransmitters(int[] x, int k)
        {
            Array.Sort(x);
            int total = 0;
            for (int i = 0; i < x.Length; i++)
            {
                int current = x[i];
                for (int j = i + 1; j < x.Length && x[j] <= current + k; j++)
                {
                    i++;
                }
                current = x[i];
                total++;
                for (int j = i + 1; j < x.Length && x[j] <= current + k; j++)
                {
                    i++;
                }
            }
            return total;
        }
        public static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);
            var x = Console.ReadLine().TrimEnd().Split(' ').ToArray().Select(xTemp => Convert.ToInt32(xTemp)).ToArray();

            int result = Hackerland.HackerlandRadioTransmitters(x, k);
            Console.WriteLine(result);
        }
    }
}
