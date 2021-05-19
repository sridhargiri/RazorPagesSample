using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/square-root-of-a-number-without-using-sqrt-function/    
Square root of a number without using sqrt() function
Difficulty Level : Medium
Last Updated : 22 Apr, 2021
Given a number N, the task is to find the square root of N without using sqrt() function.

Examples: 

Input: N = 25 
Output: 5

Input: N = 3 
Output: 1.73205

Input: N = 2.5 
Output: 1.58114 
    Approach:  

Start iterating from i = 1. If i * i = n, then print i as n is a perfect square whose square root is i.
Else find the smallest i for which i * i is strictly greater than n.
Now we know square root of n lies in the interval i – 1 and i and we can use Binary Search algorithm to find the square root.
Find mid of i – 1 and i and compare mid * mid with n, with precision upto 5 decimal places. 
If mid * mid = n then return mid.
If mid * mid < n then recur for the second half.
If mid * mid > n then recur for the first half.
Below is the implementation of the above approach:  
     */
    class FindSquareRoot
    {

        // Recursive function that returns
        // square root of a number with
        // precision upto 5 decimal places
        static double Square(double n,
                             double i, double j)
        {
            double mid = (i + j) / 2;
            double mul = mid * mid;

            // If mid itself is the square root,
            // return mid
            if ((mul == n) ||
                (Math.Abs(mul - n) < 0.00001))
                return mid;

            // If mul is less than n,
            // recur second half
            else if (mul < n)
                return Square(n, mid, j);

            // Else recur first half
            else
                return Square(n, i, mid);
        }

        // Function to find the square root of n
        static void findSqrt(double n)
        {
            double i = 1;

            // While the square root is not found
            Boolean found = false;
            while (!found)
            {

                // If n is a perfect square
                if (i * i == n)
                {
                    Console.WriteLine(i);
                    found = true;
                }

                else if (i * i > n)
                {

                    // Square root will lie in the
                    // interval i-1 and i
                    double res = Square(n, i - 1, i);
                    Console.Write("{0:F5}", res);
                    found = true;
                }
                i++;
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            double n = 3;

            findSqrt(n);
            //Output: 
            //1.73205
        }
    }
}
