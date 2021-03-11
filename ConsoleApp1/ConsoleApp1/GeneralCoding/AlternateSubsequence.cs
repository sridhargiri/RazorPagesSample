using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find the Maximum Alternate Subsequence Sum from a given array

Given an array arr[] of size n having both positive and negative integer excluding zero. Find the maximum sum of maximum size alternate subsequence of a given sequence that is, in a subsequence sign of each adjacent element is opposite for example if the first one is positive then the second one has to be negative followed by another positive integer and so on.
Examples:

Input : arr[] = {1, 2, 3, 4, -1, -2} 
Output : 3 
Explanation: 
Here, maximum size subsequences are [1, -1] [1, -2] [2, -1] [2, -2] [3, -1] 
[3, -2] [4, -1] [4, -2] but the subsequence which have maximum sum is [4, -1] 
and the sum of this subsequence is 3. Hence, the output is 3.
Input : arr[] = {-1, -6, 12, -4, -5} 
Output : 7 
Explanation: 
Here, maximum size subsequences are [-1, 12, -4] [-1, 12, -5] [-6, -12, -4] 
[-6, 12, -5] but the subsequence which have maximum sum is [-1, 12, -4] 
and the sum of this subsequence is 7. Hence, the output is 7. 
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive approach:
To solve the problem mentioned above the simple approach is to find all the alternating subsequences and their sum and return the maximum sum among all of them. 
Efficient Approach:
The efficient approach to solve the above problem is to pick the maximum element among continuous positive and continuous negative elements every time and add it to the maximum sum so far. The variable which stores the maximum sum will hold the final answer.
Below is the implementation of the above-mentioned approach:
    */
    class AlternateSubsequence
    {
        static int maxAlternatingSum(int[] arr,
                                int n)
        {
            // Initialize sum to 0 
            int max_sum = 0;

            int i = 0;

            while (i < n)
            {
                int current_max = arr[i];
                int k = i;

                while (k < n &&
                      ((arr[i] > 0 && arr[k] > 0) ||
                       (arr[i] < 0 && arr[k] < 0)))
                {
                    current_max = Math.Max(current_max,
                                           arr[k]);
                    k += 1;
                }

                // Calculate the sum 
                max_sum += current_max;

                i = k;
            }

            // Return the final result 
            return max_sum;
        }

        // Driver Code 
        public static void Main()
        {
            // Array initialization 
            int[] arr = {1, 2, 3, 4, -1, -2};

            // Length of array 
            int n = arr.Length;

            Console.Write(maxAlternatingSum(arr, n));
        }
    }
}
