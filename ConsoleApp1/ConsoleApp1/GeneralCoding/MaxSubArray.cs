using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MaxSubArray
    {

        // Function to find the sum of  
        // all subarrays of size K 
        static void calcSum(int[] arr, int n, int k)
        {
            // Initialize sum = 0 
            int sum = 0;

            // Consider first subarray of size k 
            // Store the sum of elements 
            for (int i = 0; i < k; i++)
                sum += arr[i];

            // Print the current sum 
            Console.Write(sum + " ");

            // Consider every subarray of size k 
            // Remove first element and add current 
            // element to the window 
            for (int i = k; i < n; i++)
            {

                // Add the element which enters 
                // into the window and substract 
                // the element which pops out from 
                // the window of the size K 
                sum = (sum - arr[i - k]) + arr[i];

                // Print the sum of subarray 
                Console.Write(sum + " ");
            }
        }
        // Function to find the sum of  
        // all subarrays of size K 
        static void calcSum1(int[] arr, int n, int k)
        {

            // Loop to consider every  
            // subarray of size K 
            for (int i = 0; i <= n - k; i++)
            {

                // Initialize sum = 0 
                int sum = 0;

                // Calculate sum of all elements 
                // of current subarray 
                for (int j = i; j < k + i; j++)
                    sum += arr[j];

                // Print sum of each subarray 
                Console.Write(sum + " ");
            }
        }
        /*
         Given an array of integers, print sums of all subsets in it. Output sums can be printed in any order.

Examples :

Input : arr[] = {2, 3}
Output: 0 2 3 5

Input : arr[] = {2, 4, 5}
Output : 0 2 4 5 6 7 9 11
Method 1 (Recursive)
We can recursively solve this problem. There are total 2n subsets. For every element, we consider two choices, we include it in a subset and we don’t include it in a subset. Below is recursive solution based on this idea.
        Note: We haven’t actually created sub-sets to find their sums rather we have just used recursion to find sum of non-contiguous sub-sets of the given set.

The above mentioned techniques can be used to perform various operations on sub-sets like multiplication, division, XOR, OR, etc, without actually creating and storing the sub-sets and thus making the program memory efficient.
        */

        static void subsetSums(int[] arr, int l, int r, int sum)
        {

            // Print current subset 
            if (l > r)
            {
                Console.Write(sum + " ");
                return;
            }

            // Subset including arr[l] 
            subsetSums(arr, l + 1, r, sum + arr[l]);

            // Subset excluding arr[l] 
            subsetSums(arr, l + 1, r, sum);
        }
        // Driver Code 
        static void Main()
        {

            int[] arr = { 5, 4, 3 };
            int n = arr.Length;

            subsetSums(arr, 0, n - 1, 0);
            // ouput 12 9 8 5 7 4 3 0
            arr = new int[6] { 1, 2, 3, 4, 5, 6 };
            n = arr.Length;
            int k = 3;

            // Function Call 
            calcSum(arr, n, k);

        }
    }
}
