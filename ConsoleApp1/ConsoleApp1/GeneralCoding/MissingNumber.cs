using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MissingNumber
    {
        // Function to find missing number 
        static int getMissingNo(int[] a, int n)
        {
            int i = 0, total = 1;

            for (i = 2; i <= (n + 1); i++)
            {
                total += i;
                total -= a[i - 2];
            }
            return total;
        }

        /* program to test above function */
        public static void Main()
        {
            int[] a = { 1, 2, 4, 5, 6, 7 };
            int miss = getMissingNo(a, 5);
            Console.Write(miss);
        }
    }
}
