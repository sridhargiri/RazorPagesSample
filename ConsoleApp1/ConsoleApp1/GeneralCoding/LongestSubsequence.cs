using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Length of longest non-decreasing subsequence such that difference between adjacent elements is at most one
Last Updated : 20 Feb, 2021
Given an array arr[] consisting of N integers, the task is to find the length of the longest non-decreasing subsequence such that the difference between adjacent elements is at most 1.

Examples:

Input: arr[] = {8, 5, 4, 8, 4}
Output: 3
Explanation: {4, 4, 5}, {8, 8} are the two such non-decreasing subsequences of length 2 and 3 respectively. Therefore, the length of the longest of the two subsequences is 3. 

Input: arr[] = {4, 13, 2, 3}
Output: 3
Explanation: {2, 3, 4}, {13} are the two such non-decreasing subsequences of length 3 and 1 respectively. Therefore, the length of the longest of the two subsequences is 3. 

Approach: Follow the steps below to solve the problem:




Sort the array arr[] in increasing order.
Initialize a variable, say maxLen = 1, to store the maximum possible length of a subsequence. Initialize another variable, say len = 1 to store the current length for each subsequence.
Traverse the array arr[] with a pointer i and for each element:
Check if abs(arr[i] – arr[i – 1]) ≤ 1. If found to be true, then increment len by 1. Update maxLen = max(maxLen, len).
Otherwise, set len = 1 i.e. start a new subsequence.
Print the value of maxLen as the final answer.
Below is the implementation of the above approach:
    */
    class LongestSubsequence
    {

        static void longestSequence(int[] arr, int N)
        {
            // Base case 
            if (N == 0)
            {
                Console.WriteLine(0);
                return;
            }

            // Sort the array in ascending order 
            Array.Sort(arr);

            // Stores the maximum length 
            int maxLen = 1;

            int len = 1;

            // Traverse the array 
            for (int i = 1; i < N; i++)
            {

                // If difference between current 
                // pair of adjacent elements is 1 or 0 
                if (arr[i] == arr[i - 1]
                    || arr[i] == arr[i - 1] + 1)
                {
                    len++;

                    // Extend the current sequence 
                    // Update len and max_len 
                    maxLen = Math.Max(maxLen, len);
                }
                else
                {

                    // Otherwise, start a new subsequence 
                    len = 1;
                }
            }
            Console.WriteLine(maxLen);
        }
        // Driver Code 
        public static void main(String[] args)
        {
            // Given array 
            int[] arr = { 8, 5, 4, 8, 4 };

            // Size of the array 
            int N = arr.Length;

            // Function call to find the longest 
            // subsequence 
            longestSequence(arr, N);
        }
        /*
         *output:
3
Time Complexity: O(N * logN)
Auxiliary Space: O(1)*/
    }
}
