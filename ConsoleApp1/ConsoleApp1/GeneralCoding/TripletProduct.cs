using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/count-number-of-triplets-with-product-not-exceeding-a-given-number/
    Count number of triplets with product not exceeding a given number
Last Updated : 30 Apr, 2021
Given a positive integer N, the task is to find the number of triplets of positive integers (X, Y, Z), whose product is at most N.

Examples:

Input: N = 2
Output: 4
Explanation: Below are the triplets whose product is at most N(= 2):

(1, 1, 1): Product is 1*1*1 = 1.
(1, 1, 2): Product is 1*1*2 = 2.
(1, 2, 1): Product is 1*2*1 = 2.
(2, 1, 1): Product is 2*1*1 = 2.
Therefore, the total count is 4.

Input: 6
Output: 25



Naive Approach: The simplest approach to solve the given problem is to generate all possible triplets whose values lie over the range [0, N] and count those triplets whose product of values is at most N. After checking for all the triplets, print the total count obtained.
Time Complexity: O(N3)
Auxiliary Space: O(1)

Efficient Approach: The above approach can also be optimized by generating all possible pairs (i, j) over the range [1, N] and increment the count of all possible pairs by N / (i * j). Follow the steps below to solve the problem:

Initialize a variable, say ans, that stores the count of all possible triplets.
Generate all possible pairs (i, j) over the range [1, N] and if the product of the pairs is greater than N, then check for the next pairs. Otherwise, increment the count of all possible pairs by N/(i*j).
After completing the above steps, print the value of ans as the result.
Below is the implementation of the above approach:
     */
    public class TripletProduct
    {
        static int countTriplets(int N)
        {
            // Stores the count of triplets
            int ans = 0;

            // Iterate over the range [0, N]
            for (int i = 1; i <= N; i++)
            {

                // Iterate over the range [0, N]
                for (int j = 1; j <= N; j++)
                {

                    // If the product of
                    // pairs exceeds N
                    if (i * j > N)
                        break;

                    // Increment the count of
                    // possible triplets
                    ans += N / (i * j);
                }
            }

            // Return the total count
            return ans;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(countTriplets(10));
            /*
             Output:
53
Time Complexity: O(N2)
Auxiliary Space: O(1)
            */
        }
    }
}
