using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Maximum number of buckets that can be filled
Last Updated : 15 Feb, 2021
Given an array arr[] consisting of capacities of N buckets where arr[i] denotes the capacity of the ith bucket. If the total amount of water available is the sum of array indices (1-based indexing), the task is to find the maximum number of buckets that can be fully filled with the available water.

Examples:

Input: arr[] = {1, 5, 3, 4, 7, 9}
Output: 4
Explanation:
Total available water = Sum of arrayindices of arr[] = 1 + 2 + 3 + 4 + 5 = 15.
Sorting the array in ascending order modifies the array to {1, 3, 4, 5, 7, 9}.
Fill the bucket having capacity 1, then . Now, available water = 14. 
Fill the bucket having capacity 3 . Now, available water = 11.
Fill bucket having capacity 4. Now, available water = 7.
Fill bucket having capacity 5. Now, available water = 2.
Therefore, the total buckets that can be fully filled with water is 4.

Input: arr[] = {2, 5, 8, 3, 2, 10, 8}
Output: 5

Approach: The given problem can be solved Greedily. Follow the steps below to solve the given problem:
    
Calculate the total water availability by calculating the sum of first N natural numbers.
Sort the array arr[] in ascending order.
Traverse the given array arr[] and find the sum of array elementsy till that index, say i, where the sum exceeds the total availability.
After completing the above steps, print the value of index i as the maximum number of buckets that can be filled.
Below is the implementation of the above approach:
     */
    class MaxBuckets
    {
        static void getBuckets(int[] arr, int N)
        {
            // Find the total available water 
            int availableWater = N * (N - 1) / 2;

            // Sort the array in ascending order 
            Array.Sort(arr);

            int i = 0, sum = 0;

            // Check if bucket can be 
            // filled with available water 
            while (sum <= availableWater)
            {
                sum += arr[i];
                i++;
            }
            Console.WriteLine(i - 1);
        }
        public static void Main(string[] args)
        {
            int[] arr = { 1, 5, 3, 4, 7, 9 };
            getBuckets(arr, arr.Length);
        }
        /*
         Output:
4
Time Complexity: O(N*log N)
Auxiliary Space: O(1)
        */
    }
}
