﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PrimeNumberProblem
    {

        /*
         
Create a list of consecutive integers from 2 to n: (2, 3, 4, …, n).
Initially, let p equal 2, the first prime number.
Starting from p2, count up in increments of p and mark each of these numbers greater than or equal to p2 itself in the list. 
        These numbers will be p(p+1), p(p+2), p(p+3), etc..
Find the first number greater than p in the list that is not marked. 
        If there was no such number, stop. Otherwise, let p now equal this number (which is the next prime), and repeat from step 3.

         */
        public static void SieveOfEratosthenes(int n)
        {

            // Create a boolean array "prime[0..n]" and initialize 
            // all entries it as true. A value in prime[i] will 
            // finally be false if i is Not a prime, else true. 

            bool[] prime = new bool[n + 1];

            for (int i = 0; i < n; i++)
                prime[i] = true;

            for (int p = 2; p * p <= n; p++)
            {
                // If prime[p] is not changed, 
                // then it is a prime 
                if (prime[p] == true)
                {
                    // Update all multiples of p 
                    for (int i = p * p; i <= n; i += p)
                        prime[i] = false;
                }
            }

            // Print all prime numbers 
            for (int i = 2; i <= n; i++)
            {
                if (prime[i] == true)
                    Console.Write(i + " ");
            }

        }
        // function check whether a
        // number is prime or not
        static bool isPrime(int n)
        {
            // Corner case
            if (n <= 1)
                return false;

            // Check from 2 to n-1
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        // Driver Code
        static void Main()
        {
            if (isPrime(11))
                Console.Write(" true");

            else
                Console.Write(" false");
        }
    }
}
