using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //4 different ways of finding digit length
    class DigitLength
    {
        //using repeated division

        static int countDigit1(long n)
        {
            int count = 0;
            while (n != 0)
            {
                n = n / 10;
                ++count;
            }
            return count;
        }
        //using recursion
        static int countDigit2(long n)
        {
            if (n == 0)
                return 0;
            return 1 + countDigit2(n / 10);
        }
        //Log based Solution: 
        //We can use log10(logarithm of base 10) to count the number of digits of positive numbers(logarithm is not defined for negative numbers).
        //Digit count of N = upper bound of log10(N). 
        static int countDigit(long n)
        {
            return (int)Math.Floor(Math.Log10(n) + 1);
        }
        // To count the no. of digits in a number by string conversion
        static void count_digits(int n)
        {
            // converting number to string using
            // to_string in C#

            string num = Convert.ToString(n);

            // calculate the size of string
            Console.WriteLine(+num.Length);
        }
        // Driver Code
        public static void Main(string[] args)
        {
            // number
            int n = 345;
            count_digits(n);

             n = 345289467;
            Console.WriteLine("Number of digits : "
                              + countDigit(n));
        }
    }
}
