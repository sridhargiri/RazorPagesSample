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
        /*
         Length of longest increasing subsequence in a string
Last Updated : 12 Mar, 2021
Given a string S, the task is to find the length of the longest increasing subsequence present in the given string.

A sequence of characters placed in increasing order of their ASCII values is called an increasing sequence.

Examples:

Input: S = “abcfgffs”
Output: 6
Explanation: Subsequence “abcfgs” is the longest increasing subsequence present in the string. Therefore, the length of the longest increasing subsequence is 6.

Input: S = “aaabac”
Output: 3



Approach: The idea is to use Dynamic Programming. Follow the steps given below to solve the problem:

Initialize an array, say dp[] of size 26, to store at every ith index, the length of the longest increasing subsequence having (‘a’ + i)th character as the last character in the subsequence.
Initialize variable, say lis, to store the length of the required subsequence.
Iterate over each character of the string S.
For every character encountered, i.e. S[i] – ‘a’, check for all characters, say j, with ASCII values smaller than that of the current character.
Initialize a variable, say curr, to store the length of LIS ending with current character.
Update curr with max(curr, dp[j]).
Update length of the LIS, say lis, with max(lis, curr + 1).
Update dp[S[i] – ‘a’] with max of d[S[i] – ‘a’] and curr.
Finally, print the value of lis as the required length of LIS.
Below is the implementation of the above approach
        */
        static void longest_increasing_Sequence_string_optimised(string s)
        {
            int[] dp = new int[30]; int N = s.Length;

            // Stores the length of LIS 
            int lis = int.MinValue;
            // Iterate over each 
            // character of the string 
            for (int i = 0; i < N; i++)
            {

                // Store position of the 
                // current character 
                int val = s[i] - 'a';

                // Stores the length of LIS 
                // ending with current character 
                int curr = 0;

                // Check for all characters 
                // less then current character 
                for (int j = 0; j < val; j++)
                {
                    curr = Math.Max(curr, dp[j]);
                }

                // Include current character 
                curr++;

                // Update length of longest 
                // increasing subsequence 
                lis = Math.Max(lis, curr);

                // Updating LIS for current character 
                dp[val] = Math.Max(dp[val], curr);
            }
            Console.WriteLine(lis);
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

            /*
             *output:
    3
    Time Complexity: O(N * logN)
    Auxiliary Space: O(1)
            */
            longest_increasing_Sequence_string_optimised("fdryutiaghfse");
            /*
             Output:
4
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
