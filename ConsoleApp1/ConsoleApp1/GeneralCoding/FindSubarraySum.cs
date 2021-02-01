﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.GeneralCoding
{
    class FindSubarraySum
    {
        /*
         Find subarray with given sum | Set 1 (Nonnegative Numbers)
Difficulty Level : Medium
 Last Updated : 30 Oct, 2020
Given an unsorted array of nonnegative integers, find a continuous subarray which adds to a given number.
Examples :

Input: arr[] = {1, 4, 20, 3, 10, 5}, sum = 33
Ouptut: Sum found between indexes 2 and 4
Sum of elements between indices
2 and 4 is 20 + 3 + 10 = 33

Input: arr[] = {1, 4, 0, 0, 3, 10, 5}, sum = 7
Ouptut: Sum found between indexes 1 and 4
Sum of elements between indices
1 and 4 is 4 + 0 + 0 + 3 = 7

Input: arr[] = {1, 4}, sum = 0
Output: No subarray found
There is no subarray with 0 sum
There may be more than one subarrays with sum as the given sum. The following solutions print first such subarray.

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
Simple Approach: A simple solution is to consider all subarrays one by one and check the sum of every subarray. Following program implements the simple solution. Run two loops: the outer loop picks a starting point I and the inner loop tries all subarrays starting from i.

Algorithm:




Traverse the array from start to end.
From every index start another loop from i to the end of array to get all subarray starting from i, keep a varibale sum to calculate the sum.
For every index in inner loop update sum = sum + array[j]
If the sum is equal to the given sum then print the subarray.

         */
        // Returns true if the there is a 
        // subarray of arr[] with sum 
        // equal to 'sum' otherwise returns 
        // false. Also, prints the result 
        int subArraySum(int[] arr, int n,
                        int sum)
        {
            int curr_sum, i, j;

            // Pick a starting point 
            for (i = 0; i < n; i++)
            {
                curr_sum = arr[i];

                // try all subarrays 
                // starting with 'i' 
                for (j = i + 1; j <= n; j++)
                {
                    if (curr_sum == sum)
                    {
                        int p = j - 1;
                        Console.Write("Sum found between "
                                      + "indexes " + i + " and " + p);
                        return 1;
                    }
                    if (curr_sum > sum || j == n)
                        break;
                    curr_sum = curr_sum + arr[j];
                }
            }

            Console.Write("No subarray found");
            return 0;
        }
        /*
         Efficient Approach: There is an idea if all the elements of the array are positive. If a subarray has sum greater than the given sum then there is no possibility that adding elements to the current subarray the sum will be x (given sum). Idea is to use a similar approach to a sliding window. Start with an empty subarray, add elements to the subarray until the sum is less than x. If the sum is greater than x, remove elements from the start of the current subarray.

Algorithm:

Create three variables, l=0, sum = 0
Traverse the array from start to end.
Update the variable sum by adding current element, sum = sum + array[i]
If the sum is greater than the given sum, update the variable sum as sum = sum – array[l], and update l as, l++.
If the sum is equal to given sum, print the subarray and break the loop.
         
         */


        // Returns true if the 
        // there is a subarray of 
        // arr[] with sum equal to 
        // 'sum' otherwise returns false. 
        // Also, prints the result 
        int subArraySum1(int[] arr, int n,
                        int sum)
        {
            int curr_sum = arr[0],
                start = 0, i;

            // Pick a starting point 
            for (i = 1; i <= n; i++)
            {
                // If curr_sum exceeds 
                // the sum, then remove 
                // the starting elements 
                while (curr_sum > sum && start < i - 1)
                {
                    curr_sum = curr_sum - arr[start];
                    start++;
                }

                // If curr_sum becomes equal to 
                // sum, then return true 
                if (curr_sum == sum)
                {
                    int p = i - 1;
                    Console.WriteLine("Sum found between "
                                      + "indexes " + start + " and " + p);
                    return 1;
                }

                // Add this element to curr_sum 
                if (i < n)
                    curr_sum = curr_sum + arr[i];
            }
            Console.WriteLine("No subarray found");
            return 0;
        }
        // Driver Code 
        public static void Main()
        {
            FindSubarraySum arraysum = new FindSubarraySum();
            int[] arr = { 15, 2, 4, 8, 9, 5, 10, 23 };
            int n = arr.Length;
            int sum = 23;
            arraysum.subArraySum(arr, n, sum);
            //Output :
            //Sum found between indexes 1 and 4
            //            Complexity Analysis:

            //Time Complexity: O(n ^ 2) in worst case.
            //Nested loop is used to traverse the array so the time complexity is O(n ^ 2)
            //Space Complexity: O(1).
            //As constant extra space is required.
            arraysum.subArraySum1(arr, n, sum);
            /*
             Output :
Sum found between indexes 1 and 4
Complexity Analysis:

Time Complexity : O(n).
Only one traversal of the array is required. So the time complexity is O(n).
Space Complexity: O(1).
As constant extra space is required.
            */
        }
    }
}
