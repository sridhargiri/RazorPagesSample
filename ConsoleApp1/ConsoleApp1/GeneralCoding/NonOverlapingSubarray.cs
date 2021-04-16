using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Max sum of M non-overlapping subarrays of size K
Difficulty Level : Hard
Last Updated : 09 May, 2020
Given an array and two numbers M and K. We need to find sum of max M subarrays of size K (non-overlapping) in the array. (Order of array remains unchanged). K is the size of subarrays and M is the count of subarray. It may be assumed that size of array is more than m*k. If total array size is not multiple of k, then we can take partial last array.

Examples :

Input: N = 7, M = 3, K = 1 
       arr[] = {2, 10, 7, 18, 5, 33, 0}; 
Output: 61 
Explanation: subsets are: 33, 18, 10 (3 subsets of size 1) 

Input: N = 4, M = 2, K = 2 
       arr[] = {3, 2, 100, 1}; 
Output:  106 
Explanation: subsets are: (3, 2), (100, 1) 2 subsets of size 2
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Here we can see that we need to find M subarrays each of size K so,
1. We create a presum array, which contains in each index sum of all elements from ‘index‘ to ‘index + K’ in the given array. And size of the sum array will be n+1-k.
2. Now if we include the subarray of size k, then we can not include any of the elements of that subarray again in any other subarray as it will create overlapping subarrays. So we make recursive call by excluding the k elements of included subarray.
3. if we exclude a subarray then we can use the next k-1 elements of that subarray in other subarrays so we will make recursive call by just excluding the first element of that subarray.
4. At last return the max(included sum, excluded sum).
    
     https://www.geeksforgeeks.org/max-sum-of-m-non-overlapping-subarrays-of-size-k/
    */
    class NonOverlapingSubarray
    {

        // calculating presum of array. 
        // presum[i] is going to store 
        // prefix sum of subarray of 
        // size k beginning with arr[i]
        static void calculatePresumArray(int[] presum,
                              int[] arr, int n, int k)
        {
            for (int i = 0; i < k; i++)
                presum[0] += arr[i];

            // store sum of array index i to i+k 
            // in presum array at index i of it.
            for (int i = 1; i <= n - k; i++)
                presum[i] += presum[i - 1] + arr[i + k - 1]
                                              - arr[i - 1];
        }

        // calculating maximum sum of
        // m non overlapping array
        static int maxSumMnonOverlappingSubarray(
                         int[] presum, int m, int size,
                                      int k, int start)
        {

            // if m is zero then no need 
            // any array of any size so
            // return 0.
            if (m == 0)
                return 0;

            // if start is greater then the 
            // size of presum array return 0.
            if (start > size - 1)
                return 0;

            //int mx = 0;

            // if including subarray of size k
            int includeMax = presum[start] +
                    maxSumMnonOverlappingSubarray(presum,
                              m - 1, size, k, start + k);

            // if excluding element and searching 
            // in all next possible subarrays
            int excludeMax =
                    maxSumMnonOverlappingSubarray(presum,
                                  m, size, k, start + 1);

            // return max
            return Math.Max(includeMax, excludeMax);
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 2, 10, 7, 18, 5, 33, 0 };
            int n = arr.Length;
            int m = 3, k = 1;
            int[] presum = new int[n + 1 - k];
            calculatePresumArray(presum, arr, n, k);

            // resulting presum array
            // will have a size = n+1-k
            Console.WriteLine(
                  maxSumMnonOverlappingSubarray(presum,
                                  m, n + 1 - k, k, 0));//op 61
        }
    }
}
