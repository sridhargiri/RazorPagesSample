using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ConsecutiveSum
    {
        /*
         https://www.geeksforgeeks.org/print-all-possible-consecutive-numbers-with-sum-n/
         Print all possible consecutive numbers with sum N
Difficulty Level : Easy
Last Updated : 12 Jul, 2021
Given a number N. The task is to print all possible consecutive numbers that add up to N.

Examples : 
Input: N = 100
Output:
9 10 11 12 13 14 15 16 
18 19 20 21 22 

Input: N = 125
Output:
8 9 10 11 12 13 14 15 16 17 
23 24 25 26 27 
62 63 
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
One important fact is we can not find consecutive numbers above N/2 that adds up to N, because N/2 + (N/2 + 1) would be more than N. So we start from start = 1 till end = N/2 and check for every consecutive sequence whether it adds up to N or not. If it is then we print that sequence and start looking for the next sequence by incrementing start point. 
        */
        static void findConsecutiveSum(int N)
        {
            // Note that we don't
            // ever have to sum
            // numbers > ceil(N/2)
            int start = 1;
            int end = (N + 1) / 2;

            // Repeat the loop
            // from bottom to half
            while (start < end)
            {
                // Check if there exist
                // any sequence from
                // bottom to half which
                // adds up to N
                int sum = 0;
                for (int i = start; i <= end; i++)
                {
                    sum = sum + i;

                    // If sum = N, this means
                    // consecutive sequence exists
                    if (sum == N)
                    {
                        // found consecutive
                        // numbers! print them
                        for (int j = start; j <= i; j++)

                            Console.Write(j + " ");
                        Console.WriteLine();
                        break;
                    }

                    // if sum increases N then
                    // it can not exist in the
                    // consecutive sequence
                    // starting from bottom
                    if (sum > N)
                        break;
                }
                sum = 0;
                start++;
            }
        }
        /*
         Output : 

8 9 10 11 12 13 14 15 16 17 
23 24 25 26 27 
62 63 
        */
        /*
         Optimized Solution: 
In the above solution, we keep recalculating sums from start to end, which results in O(N^2) worst-case time complexity. This can be avoided by using a precomputed array of sums, or better yet – just keeping track of the sum you have so far and adjusting it depending on how it compares to the desired sum.
Time complexity of below code is O(N). 
        */
        static void findConsecutiveSum2(int N)
        {
            int start = 1, end = 1;
            int sum = 1;

            while (start <= N / 2)
            {
                if (sum < N)
                {
                    end += 1;
                    sum += end;
                }
                else if (sum > N)
                {
                    sum -= start;
                    start += 1;
                }
                else if (sum == N)
                {
                    for (int i = start;
                            i <= end; ++i)

                        Console.Write(i
                                    + " ");

                    Console.WriteLine();
                    sum -= start;
                    start += 1;
                }
            }
        }
        // Driver code
        static public void Main()
        {
            int N = 125;
            findConsecutiveSum2(N);
            /*
             Output : 

8 9 10 11 12 13 14 15 16 17 
23 24 25 26 27 
62 63 
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/count-ways-express-number-sum-consecutive-numbers/
    Count ways to express a number as sum of consecutive numbers
Difficulty Level : Medium
Last Updated : 18 Jun, 2021
Given an integer N, the task is to find the number of ways to represent this number as a sum of 2 or more consecutive natural numbers.

Examples: 
Input: N = 15 
Output: 3 
Explanation: 
15 can be represented as: 
 

1 + 2 + 3 + 4 + 5
4 + 5 + 6
7 + 8
Input: N = 10 
Output: 1 
Approach: The idea is to represent N as a sequence of length L+1 as: 
N = a + (a+1) + (a+2) + .. + (a+L) 
=> N = (L+1)*a + (L*(L+1))/2 
=> a = (N- L*(L+1)/2)/(L+1) 
We substitute the values of L starting from 1 till L*(L+1)/2 < N 
If we get ‘a’ as a natural number then the solution should be counted.
 
     */
    public class WaysConsecutiveSum
    {

        // Utility method to compute
        // number of ways in which N
        // can be represented as sum
        // of consecutive number
        static int countConsecutive(int N)
        {

            // constraint on values of L
            // gives us the time
            // Complexity as O(N^0.5)
            int count = 0;
            for (int L = 1; L * (L + 1)
                            < 2 * N;
                 L++)
            {
                double a = (double)((1.0
                                       * N
                                   - (L * (L + 1))
                                         / 2)
                                  / (L + 1));

                if (a - (int)a == 0.0)
                    count++;
            }

            return count;
        }

        // Driver code to test above
        // function
        public static void Main()
        {
            int N = 15;
            Console.WriteLine(
                countConsecutive(N));

            N = 10;
            Console.Write(
                countConsecutive(N));
            /*
             
Output: 
3
1
Time Complexity: O(N^0.5)
            */
        }
    }
}
