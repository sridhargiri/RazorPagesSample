using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Length of longest subset consisting of A 0s and B 1s from an array of strings | Set 2
Last Updated : 19 Apr, 2021
Given an array arr[] consisting of N binary strings, and two integers A and B, the task is to find the length of the longest subset consisting of at most A 0s and B 1s.
https://www.geeksforgeeks.org/length-of-longest-subset-consisting-of-a-0s-and-b-1s-from-an-array-of-strings-set-2/
Examples:

Input: arr[] = {“1”, “0”, “0001”, “10”, “111001”}, A = 5, B = 3
Output: 4
Explanation: 
One possible way is to select the subset {arr[0], arr[1], arr[2], arr[3]}.
Total number of 0s and 1s in all these strings are 5 and 3 respectively.
Also, 4 is the length of the longest subset possible.

Input: arr[] = {“0”, “1”, “10”}, A = 1, B = 1
Output: 2
Explanation: 
One possible way is to select the subset {arr[0], arr[1]}.
Total number of 0s and 1s in all these strings is 1 and 1 respectively.
Also, 2 is the length of the longest subset possible.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach: Refer to the previous post of this article for the simplest approach to solve the problem. 
Time Complexity: O(2N)
Auxiliary Space: O(1)

Dynamic Programming Approach: Refer to the previous post of this article for the Dynamic Programming approach. 
Time Complexity: O(N*A*B)
Auxiliary Space: O(N * A * B)

Space-Optimized Dynamic Programming Approach: The space complexity in the above approach can be optimized based on the following observations:

Initialize a 2D array, dp[A][B], where dp[i][j] represents the length of the longest subset consisting of at most i number of 0s and j number of 1s.
To optimize the auxiliary space from the 3D table to the 2D table, the idea is to traverse the inner loops in reverse order.
This ensures that whenever a value in dp[][] is changed, it will not be needed anymore in the current iteration.
Therefore, the recurrence relation looks like this:
dp[i][j] = max (dp[i][j], dp[i – zeros][j – ones] + 1)
where zeros is the count of 0s and ones is the count of 1s in the current iteration.



Follow the steps below to solve the problem:

Initialize a 2D array, say dp[A][B] and initialize all its entries as 0.
Traverse the given array arr[] and for each binary string perform the following steps:
Store the count of 0s and 1s in the current string in variables zeros and ones respectively.
Iterate in the range [A, zeros] using the variable i and simultaneously iterate in the range [B, ones] using the variable j and update the value of dp[i][j] to maximum of dp[i][j] and (dp[i – zeros][j – ones] + 1).
After completing the above steps, print the value of dp[A][B] as the result.
Below is the implementation of the above approach
    */
    class LongestSubset
    {
        static int length_of_longest_subset_consisting_of_a_0s_and_b_1s_from_an_array_of_strings_set_2(string[] arr, int A, int B)
        {
            // Initialize a 2D array with its
            // entries as 0
            int[,] dp = new int[A + 1, B + 1];
            foreach (string str in arr)
            {
                int zeros = 0, ones = 0;
                foreach (char ch in str)
                {
                    if (ch == '0')
                        zeros++;
                    else
                        ones++;
                }

                // Iterate in the range [A, zeros]
                for (int i = A; i >= zeros; i--)

                    // Iterate in the range [B, ones]
                    for (int j = B; j >= ones; j--)

                        // Update the value of dp[i][j]
                        dp[i, j] = Math.Max(dp[i, j], dp[i - zeros, j - ones] + 1);
            }

            // Print the result
            return dp[A, B];
        }
        static void Main(string[] args)
        {
            String[] arr = { "1", "0", "0001", "10", "111001" };
            int A = 5, B = 3;

            Console.WriteLine(length_of_longest_subset_consisting_of_a_0s_and_b_1s_from_an_array_of_strings_set_2(arr, A, B));
            /*
             Output: 
4
 

Time Complexity: O(N * A * B)
Auxiliary Space: O(A * B)
            */
        }
    }
}

