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

        // Driver Code 
        static void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            int n = arr.Length;
            int k = 3;

            // Function Call 
            calcSum(arr, n, k);

        }
    }
}
