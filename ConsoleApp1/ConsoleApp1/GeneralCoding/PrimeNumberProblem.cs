using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class PrimeNumberProblem
    {
        /*
May related to https://www.hackerrank.com/challenges/alice-and-bobs-silly-game/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
https://www.geeksforgeeks.org/sieve-of-eratosthenes/
Given a number n, print all primes smaller than or equal to n. It is also given that n is a small number.     
Create a list of consecutive integers from 2 to n: (2, 3, 4, …, n).
Initially, let p equal 2, the first prime number.
Starting from p2, count up in increments of p and mark each of these numbers greater than or equal to p2 itself in the list. 
These numbers will be p(p+1), p(p+2), p(p+3), etc.
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
            if (isPrime(3))
                Console.WriteLine("true");

            else
                Console.WriteLine("false");
            int n = 30;
            Console.WriteLine("Following are the prime numbers smaller than or equal to " + n);
            SieveOfEratosthenes(n);
            /*
Output
true

Following are the prime numbers smaller than or equal to 30
2 3 5 7 11 13 17 19 23 29
Time Complexity: O(n*log(log(n)))
Auxiliary Space: O(n)
 
             */
        }
    }
    /*
https://www.geeksforgeeks.org/sum-of-all-the-prime-numbers-in-a-given-range/
    Sum of all the prime numbers in a given range
    Given a range [l, r], the task is to find the sum of all the prime numbers within that range.

Examples: 

Input : l=1 and r=6
Output : 10
2+3+5=10
    Input : l=4 and r=13
    Output : 365+7+11+13=36
     Approach 1: (Naive Approach) 
Iterate the loop from ‘l’ to ‘r’ and add all the numbers which are prime.

Below is the implementation of the above approach
    */
    public class PrimeNumberSumRangeNaiveApproach
    {

        // Method to compute the prime
        // number Time Complexity is O(sqrt(N))
        static bool checkPrime(int numberToCheck)
        {
            if (numberToCheck == 1)
            {
                return false;
            }
            for (int i = 2; i * i <= numberToCheck; i++)
            {
                if (numberToCheck % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Method to iterate the loop from l to r
        // If prime number detects, sum the value
        static int primeSum(int l, int r)
        {
            int sum = 0;
            for (int i = r; i >= l; i--)
            {

                // Check for prime
                bool isPrime = checkPrime(i);
                if (isPrime)
                {

                    // Sum the prime number
                    sum = sum + i;
                }
            }
            return sum;
        }
        // Time Complexity is O(r x sqrt(N))

        // Driver code
        public static void Main()
        {
            int l = 4, r = 13;

            // Call the method with l and r
            Console.Write(primeSum(l, r));
            /*
             Output
36
Time Complexity is O(r x sqrt(N))       
Auxiliary Space: O(1)       
            */
        }
    }
    /*
     Approach 2: (Dynamic Programming) 

Declare an array dp and arr
Fill the array arr to 0
Iterate the loop till sqrt(N) and if arr[i] = 0 (marked as prime), then set all of its multiples as non-prime by marking the respective location as 1
Update the dp array with the running prime numbers sum, where each location ‘dp[i]’ holds the sum of all the prime numbers within the range [1, i]
    */
    public class PrimeNumberSumRange
    {


        // Suppose the constraint is N<=1000
        static int N = 1000;

        // Declare an array for dynamic approach
        static long[] dp = new long[N + 1];

        // Method to compute the array
        static void sieve()
        {
            // Declare an extra array as arr
            int[] arr = new int[N + 1];
            arr[0] = 1;
            arr[1] = 1;

            // Iterate the loop till sqrt(n)
            // Time Complexity is O(log(n) X sqrt(n))
            for (int i = 2; i <= Math.Sqrt(N); i++)

                // if ith element of arr is 0 i.e. marked as prime
                if (arr[i] == 0)

                    // mark all of it's multiples till N as non-prime
                    // by setting the locations to 1
                    for (int j = i * i; j <= N; j += i)
                        arr[j] = 1;

            long runningPrimeSum = 0;

            // Update the array 'dp' with the running sum
            // of prime numbers within the range [1, N]
            // Time Complexity is O(n)
            for (int i = 1; i <= N; i++)
            {
                if (arr[i] == 0)
                    runningPrimeSum += i;

                //Here, dp[i] is the sum of all the prime numbers
                //within the range [1, i]
                dp[i] = runningPrimeSum;
            }
        }

        // Driver code
        public static void Main()
        {
            int l = 4, r = 13;

            sieve();
            Console.WriteLine(dp[r] - dp[l - 1]);
            /*
Output 36
Time Complexity: O(n*log(log(n)))
Auxiliary Space: O(n)       
            */
        }
    }

}
