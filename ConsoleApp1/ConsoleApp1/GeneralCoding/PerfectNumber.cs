﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     A number is a perfect number if is equal to sum of its proper divisors, that is, sum of its positive divisors excluding the number itself. Write a function to check if a given number is perfect or not.
Examples:

Input: n = 15
Output: false
Divisors of 15 are 1, 3 and 5. Sum of 
divisors is 9 which is not equal to 15.

Input: n = 6
Output: true
Divisors of 6 are 1, 2 and 3. Sum of 
divisors is 6.
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
A Simple Solution is to go through every number from 1 to n-1 and check if it is a divisor. Maintain sum of all divisors. If sum becomes equal to n, then return true, else return false.

An Efficient Solution is to go through numbers till square root of n. If a number ‘i’ divides n, then add both ‘i’ and n/i to sum.

Below is the implementation of efficient solution.
    */

    class PerfectNumber
    {

        // Returns true if n is perfect 
        static bool isPerfect(int n)
        {
            // To store sum of divisors 
            int sum = 1;

            // Find all divisors and add them 
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    if (i * i != n)
                        sum = sum + i + n / i;
                    else
                        sum = sum + i;
                }
            }
            // If sum of divisors is equal to 
            // n, then n is a perfect number 
            if (sum == n && n != 1)
                return true;

            return false;
        }

        // Driver program 
        static void Main()
        {
            Console.WriteLine("Below are all perfect" +
                                        "numbers till 10000");
            for (int n = 2; n < 10000; n++)
                if (isPerfect(n))
                    Console.WriteLine(n + " is a perfect number");
        }
    }
    /*
	 Output:
Below are all perfect numbers til 10000
6 is a perfect number
28 is a perfect number
496 is a perfect number
8128 is a perfect number
Time Complexity: √n

Below are some interesting facts about Perfect Numbers:
1) Every even perfect number is of the form 2p?1(2p ? 1) where 2p ? 1 is prime.
2) It is unknown whether there are any odd perfect numbers.
	*/
}
