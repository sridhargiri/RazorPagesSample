using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SumOfEvenOddIndices
    {
        static void countSubarrays(int[] arr, int n)
        {
            // Initialize variables
            int count = 0;

            // Iterate over the array
            for (int i = 0; i < n; i++)
            {
                int sum = 0;

                for (int j = i; j < n; j++)
                {

                    // Check if position is
                    // even then add to sum
                    // then add it to sum
                    if ((j - i) % 2 == 0)
                        sum += arr[j];

                    // else subtract it to sum
                    else
                        sum -= arr[j];

                    // Increment the count
                    // if the sum equals 0
                    if (sum == 0)

                        count++;
                }
            }

            // Print the count of subarrays
            Console.WriteLine(count);
        }
        public static void Main(string[] args)
        {
            // Given array arr[]
            int[] arr = { 2, 4, 6, 4, 2 };

            // Size of the array
            int n = arr.Length;

            // Function call
            countSubarrays(arr, n);
        }
    }
}
