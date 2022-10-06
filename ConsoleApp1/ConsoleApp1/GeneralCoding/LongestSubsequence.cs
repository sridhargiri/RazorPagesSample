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
    /*
https://www.geeksforgeeks.org/longest-increasing-subsequence-dp-3/
     Method 2: Dynamic Programming.
We can see that there are many subproblems in the above recursive solution which are solved again and again. So this problem has Overlapping Substructure property and recomputation of same subproblems can be avoided by either using Memoization or Tabulation.



The simulation of approach will make things clear:  

Input  : arr[] = {3, 10, 2, 11}
LIS[] = {1, 1, 1, 1} (initially)
Iteration-wise simulation : 

arr[2] > arr[1] {LIS[2] = max(LIS [2], LIS[1]+1)=2}
arr[3] < arr[1] {No change}
arr[3] < arr[2] {No change}
arr[4] > arr[1] {LIS[4] = max(LIS [4], LIS[1]+1)=2}
arr[4] > arr[2] {LIS[4] = max(LIS [4], LIS[2]+1)=3}
arr[4] > arr[3] {LIS[4] = max(LIS [4], LIS[3]+1)=3}
We can avoid recomputation of subproblems by using tabulation as shown in the below code: 

Below is the implementation of the above approach:  
    */
    public class LongestIncreasingSubsequence
    {
        /* lis() returns the length of the longest increasing
        subsequence in arr[] of size n */
        static int lis(int[] arr, int n)
        {
            int[] lis = new int[n];
            int i, j, max = 0;

            /* Initialize LIS values for all indexes */
            for (i = 0; i < n; i++)
                lis[i] = 1;

            /* Compute optimized LIS values in bottom up manner
             */
            for (i = 1; i < n; i++)
                for (j = 0; j < i; j++)
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;

            /* Pick maximum of all LIS values */
            for (i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];

            return max;
        }

        public static void Main()
        {
            int[] arr = { 10, 22, 9, 33, 21, 50, 41, 60 };
            int n = arr.Length;
            Console.WriteLine("Length of lis is " + lis(arr, n) + "\n");
            /*
             Output
Length of lis is 5
Complexity Analysis: 

Time Complexity: O(n2). 
As nested loop is used.
Auxiliary Space: O(n). 
Use of any array to store LIS values at each index.
            */
        }

        // This code is contributed by Ryuga
    }
    /*
     https://www.geeksforgeeks.org/longest-increasing-subarray/
    Longest increasing subarray
Difficulty Level : Easy
Last Updated : 24 May, 2021
Given an array containing n numbers. The problem is to find the length of the longest contiguous subarray such that every element in the subarray is strictly greater than its previous element in the same subarray. Time Complexity should be O(n).

Examples:  

Input : arr[] = {5, 6, 3, 5, 7, 8, 9, 1, 2}
Output : 5
The subarray is {3, 5, 7, 8, 9}

Input : arr[] = {12, 13, 1, 5, 4, 7, 8, 10, 10, 11}
Output : 4
The subarray is {4, 7, 8, 10} 
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
Algorithm:  

lenOfLongIncSubArr(arr, n)
    Declare max = 1, len = 1
    for i = 1 to n-1
    if arr[i] > arr[i-1]
        len++
    else
        if max < len
            max = len
        len = 1
    if max < len
        max = len
    return max 
    */
    public class LongestIncreasingSubarray
    {

        // function to find the length of longest
        // increasing contiguous subarray
        public static int lenOfLongIncSubArr(int[] arr,
                                                 int n)
        {
            // 'max' to store the length of longest
            // increasing subarray
            // 'len' to store the lengths of longest
            // increasing subarray at diiferent
            // instants of time
            int max = 1, len = 1;

            // traverse the array from the 2nd element
            for (int i = 1; i < n; i++)
            {

                // if current element if greater than
                // previous element, then this element
                // helps in building up the previous
                // increasing subarray encountered
                // so far
                if (arr[i] > arr[i - 1])
                    len++;
                else
                {

                    // check if 'max' length is less
                    // than the length of the current
                    // increasing subarray. If true,
                    // than update 'max'
                    if (max < len)
                        max = len;

                    // reset 'len' to 1 as from this
                    // element again the length of the
                    // new increasing subarray is being
                    // calculated
                    len = 1;
                }
            }

            // comparing the length of the last
            // increasing subarray with 'max'
            if (max < len)
                max = len;

            // required maximum length
            return max;
        }

        /* Driver program to test above function */
        public static void Main()
        {
            int[] arr = { 5, 6, 3, 5, 7, 8, 9, 1, 2 };
            int n = arr.Length;
            Console.WriteLine("Length = " + lenOfLongIncSubArr(arr, n));
            /*
             Output:  

Length = 5
Time Complexity: O(n)
            */
        }
    }
    /*
https://www.geeksforgeeks.org/length-of-longest-subarray-with-smaller-elements-on-immediate-left-for-each-array-element/
    Length of longest subarray with smaller elements on immediate left for each Array element
Difficulty Level : Basic
Last Updated : 13 Dec, 2021
Given an array arr[] of length N, the task is to find the length of the longest subarray with smaller elements on the immediate left for each element in the given array.

Example:
Input: arr[] = { 2, 1, 7, 6, 7 }
Output: 0 0 2 0 1
Explanation: 
Index 0 (2): No substring is present to the immediate left having all smaller elements. So, length=0
Index 1 (1): No substring is present to the immediate left having all smaller elements. So, length=0
Index 2 (7): Substring {2, 1} is present to the immediate left having all smaller elements. So, length=2
Index 3 (6): No substring is present to the immediate left having all smaller elements. So, length=0
Index 4 (2): Substring {6} is present to the immediate left having all smaller elements. So, length=1



Input: arr[] = { 4, 5, 7, 6, 10 }
Output: 0 1 2 0 4

 
Approach: For every element travel to its left until the element to the left is greater or the array ends to find the length of the longest subarray with smaller elements on the immediate left. Follow the below steps, to solve this problem:

Traverse each element in array arr[].
For each element run another loop in the left direction.
Count all the elements smaller than the current element until a greater element comes or the array ends.
Print the answer according to the above observation.
Below is the implementation of the above approach:
     */
    public class SubarrayLeftSmall
    {
        static void subarraySmallElementsToLeft(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int ans = 0;
                for (int j = i - 1; j >= 0; j--)
                {

                    // If a greater element comes
                    if (arr[i] <= arr[j])
                    {
                        break;
                    }
                    // Else
                    ans++;
                }
                Console.WriteLine(ans + " ");
            }
        }
        public static void Main(string[] args)
        {
            int n = 5;
            int[] arr = { 1, 4, 2, 6, 3 };
            subarraySmallElementsToLeft(arr, n);
            /*
             Output
0 1 0 3 0 
 

Time Complexity: O(N2)
Auxiliary Space: O(1)

 
             */
        }
    }
}
