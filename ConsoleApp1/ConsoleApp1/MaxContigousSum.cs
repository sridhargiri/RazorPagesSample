using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MaxContigousSum
    {

        // Returns maximum sum in a 
        // subarray of size k. 
        static int maxSum(int[] arr, int n,
                          int k)
        {
            // Initialize result 
            int max_sum = int.MinValue;

            // Consider all blocks starting 
            // with i. 
            for (int i = 0; i < n - k + 1; i++)
            {
                int current_sum = 0;
                for (int j = 0; j < k; j++)
                    current_sum = current_sum
                                  + arr[i + j];

                // Update result if required. 
                max_sum = Math.Max(current_sum,
                                   max_sum);
            }

            return max_sum;
        }
        static int maxSum1(int[] arr, int n,
                          int k)
        {
            // Initialize result 
            int max_sum = 0;
            int window_sum = 0;
            int i = 0;
            for (i = 0; i < k; i++)
            {
                max_sum += arr[i];
            }
            window_sum = max_sum;
            for (i = k; i < n; i++)
            {
                window_sum += arr[i] - arr[i - k];

                // Update result if required. 
                max_sum = Math.Max(window_sum,
                                   max_sum);
            }

            return max_sum;
        }

        // Driver code 
        public static void Main()
        {
            int[] arr = { 1, 4, 2, 10, 2, 3, 1,
                      0, 20 };
            int k = 4;
            int n = arr.Length;
            Console.WriteLine(maxSum1(arr, n, k));
        }
    }
}
