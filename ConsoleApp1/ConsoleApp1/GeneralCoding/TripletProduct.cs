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
    /*
 https://www.geeksforgeeks.org/count-triplets-whose-sum-equal-perfect-cube/
    Count all triplets whose sum is equal to a perfect cube
Difficulty Level : Medium
Last Updated : 29 Apr, 2021
Given an array of n integers, count all different triplets whose sum is equal to the perfect cube i.e, for any i, j, k(i < j < k) satisfying the condition that a[i] + a[j] + a[j] = X3 where X is any integer. 3 ≤ n ≤ 1000, 1 ≤ a[i, j, k] ≤ 5000 
Example: 
 

Input:
N = 5
2 5 1 20 6
Output:
3
Explanation:
There are only 3 triplets whose total sum is a perfect cube.
Indices  Values SUM
0 1 2    2 5 1   8
0 1 3    2 5 20  27
2 3 4    1 20 6  27
Since 8 and 27 are prefect cube of 2 and 3.
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive approach is to iterate over all the possible numbers by using 3 nested loops and check whether their sum is a perfect cube or not. The approach would be very slow as time complexity can go up to O(n3).
An Efficient approach is to use dynamic programming and basic mathematics. According to the given condition sum of any of three positive integers is not greater than 15000. Therefore there can be only 24(150001/3) cubes are possible in the range of 1 to 15000. 
Now instead of iterating all triplets we can do much better by the help of above information. Fixed first two indices i and j such that instead of iterating over all k(j < k ≤ n), we can iterate over all the 24 possible cubes, and for each one, (let’s say P) check how many occurrence of P – (a[i] + a[j]) are in a[j+1, j+2, … n]. 
But if we compute the number of occurrences of a number say K in a[j+1, j+2, … n] then this would again be counted as slow approach and would definitely give TLE. So we have to think of a different approach. 
Now here comes to a Dynamic Programming. Since all numbers are smaller than 5000 and n is at most 1000. Hence we can compute a DP array as, 
dp[i][K]:= Number of occurrence of K in A[i, i+1, i+2 … n] 
    */
    public class TripletSumCube
    {

        public static int[,] dp;

        // Function to calculate all occurrence
        // of a number in a given range
        public static void computeDpArray(int[] arr,
                                          int n)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 1; j <= 15000; ++j)
                {

                    // if i == 0
                    // assign 1 to present state

                    if (i == 0 && j == arr[i])
                        dp[i, j] = 1;
                    else if (i == 0)
                        dp[i, j] = 0;

                    // else add +1 to current state
                    // with previous state
                    else if (arr[i] == j)
                        dp[i, j] = dp[i - 1, j] + 1;
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }
        }

        // Function to calculate triplets whose
        // sum is equal to the pefect cube
        public static int countTripletSum(int[] arr,
                                          int n)
        {
            computeDpArray(arr, n);

            int ans = 0; // Initialize answer
            for (int i = 0; i < n - 2; ++i)
            {
                for (int j = i + 1; j < n - 1; ++j)
                {
                    for (int k = 1; k <= 24; ++k)
                    {
                        int cube = k * k * k;

                        int rem = cube - (arr[i] + arr[j]);

                        // count all occurrence of
                        // third triplet in range
                        // from j+1 to n
                        if (rem > 0)
                            ans += dp[n - 1, rem] -
                                   dp[j, rem];
                    }
                }
            }
            return ans;
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 2, 5, 1, 20, 6 };
            int n = arr.Length;
            dp = new int[1001, 15001];

            Console.Write(countTripletSum(arr, n));
            /*
             Output:

 3
Time complexity: O(N2*24) 
Auxiliary space: O(107)
            */
        }
    }
}
