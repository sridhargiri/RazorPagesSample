using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class FindClosest
    {
        /*
         find the element that is closest to zero
         */
        public static int ClosestTo(this IEnumerable<int> collection, int target)
        {
            // NB Method will return int.MaxValue for a sequence containing no elements.
            // Apply any defensive coding here as necessary.
            var closest = int.MaxValue;
            var minDifference = int.MaxValue;
            foreach (var element in collection)
            {
                var difference = Math.Abs((long)element - target);
                if (minDifference > difference)
                {
                    minDifference = (int)difference;
                    closest = element;
                }
            }

            return closest;
        }
    }
    class FindClosestCallingCode
    {
        static string B(string tcmid, string pid, string itemid)
        {
            return "tcm:" + pid + "-" + itemid + "-" + tcmid.Substring(12, 2);

        }
        static void Main(string[] args)
        {
            int[] array = new int[14] { 7, -10, 13, 8, 4, 9, -12, -3, 35, -9, 10, -1, -2, 7 };
            var closest = array.ToList().ClosestTo(0);
            Console.WriteLine(closest);
            Console.ReadLine();
            //Console.WriteLine(B("tcm:123-456-78", "321", "645"));
        }
    }
}
