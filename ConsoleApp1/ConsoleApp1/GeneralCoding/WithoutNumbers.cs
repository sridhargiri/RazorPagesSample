using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Print 1 to 100 without using numbers EVERY india Friday May 21 2021 interview at evening 6pm
    */

    public class WithoutNumbers
    {
        // Prints numbers from 1 to n
        static void printNos(int n)
        {
            if (n > 0)
            {
                printNos(n - 1);
                Console.WriteLine(n + " ");
            }
            return;
        }
        public static void Print_1_to_100_without_using_numbers()
        {
            string oe1 = "**********";
            for (int i = 'A'/'A'; i <= 'd'; i++)
            {
                Console.WriteLine(i);
            }
            for (int j = 1; j <= (oe1.Length * oe1.Length); j++)
            {
                Console.WriteLine(j);
            }
        }
        public static void Main(string[] args)
        {
            Print_1_to_100_without_using_numbers();
            //printNos(100);
        }
    }
}
