using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if two numbers are co-prime or not
     https://www.geeksforgeeks.org/check-two-numbers-co-prime-not/
    Two numbers A and B are said to be Co-Prime or mutually prime if the Greatest Common Divisor of them is 1. 
    You have been given two numbers A and B, find if they are Co-prime or not.
Examples : 
 

Input : 2 3
Output : Co-Prime

Input : 4 8
Output : Not Co-Prime
     */
    public class CoPrime
    {

        // Recursive function to
        // return gcd of a and b
        static int __gcd(int a, int b)
        {
            // Everything divides 0
            if (a == 0 || b == 0)
                return 0;

            // base case
            if (a == b)
                return a;

            // a is greater
            if (a > b)
                return __gcd(a - b, b);

            return __gcd(a, b - a);
        }

        // function to check and print if
        // two numbers are co-prime or not
        static void coprime(int a, int b)
        {

            if (__gcd(a, b) == 1)
                Console.WriteLine("Co-Prime");
            else
                Console.WriteLine("Not Co-Prime");
        }

        // Driver code
        public static void Main()
        {
            int a = 5, b = 6;
            coprime(a, b);
            a = 8;
            b = 16;
            coprime(a, b);
            /*
             Output : 

Co-Prime
Not Co-Prime
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/coprime-divisors-of-a-number/
    Coprime divisors of a number
    Given an integer N. The task is to find a pair of co-prime divisors of N, greater than 1. If such divisors don’t exists then print ‘-1’. 

Examples:

Input: N = 45 
Output: 3 5 
Explanation: Since 3 and 5 are divisors of 45 and gcd( 3, 5 ) = 1 . 
Hence, they satisfy the condition.

Input: N = 25 
Output: -1 
Explanation: No pair of divisors of 25 satisfy the condition such 
that their gcd is 1.

Approach: 



Iterate from x = 2 to sqrt(N), to find all divisors of N
For any value x, check if it divides N
If it divides, then keep dividing N by x as long as it is divisible.
Now, check if N > 1, then the pair of divisors (x, N) will have 
gcd(x, N) == 1, since all the factors of ‘x’ has been eliminated from N.
Similarly, check for all values of x.
Below is the implementation of the above approach:
     */
    public class CoprimeDivisor
    {

        // Function which finds the
        // required pair of divisors
        // of N
        public static void findCoprimePair(int N)
        {
            // We iterate upto sqrt(N)
            // as we can find all the
            // divisors of N in this
            // time
            for (int x = 2;
                    x <= Math.Sqrt(N); x++)
            {
                if (N % x == 0)
                {
                    // If x is a divisor of N
                    // keep dividing as long
                    // as possible
                    while (N % x == 0)
                    {
                        N /= x;
                    }
                    if (N > 1)
                    {
                        // We have found a
                        // required pair
                        Console.WriteLine(x +
                                          " " + N);
                        return;
                    }
                }
            }

            // No such pair of divisors
            // of N was found, hence
            // print -1
            Console.WriteLine(-1);
        }

        // Driver code
        public static void Main(String[] args)
        {
            // Sample example 1
            int N = 45;
            findCoprimePair(N);

            // Sample example 2
            N = 25;
            findCoprimePair(N);
            /*
             Output: 
3 5
-1
            */
        }
    }
}
