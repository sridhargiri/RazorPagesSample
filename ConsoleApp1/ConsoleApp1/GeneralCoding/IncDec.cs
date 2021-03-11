using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if an array is increasing or decreasing

Given an array arr[] of N elements where N ≥ 2, the task is to check the type of array whether it is:

Increasing.
Decreasing.
Increasing then decreasing.
Decreasing then increasing.
Note that the given array is definitely one of the given types.

Examples:

Input: arr[] = {1, 2, 3, 4, 5}
Output: Increasing

Input: arr[] = {1, 2, 4, 3}
Output: Increasing then decreasing




Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The following conditions must satitisfy for:

Increasing array: The first two and the last two elements must be in increasing order.
Decreasing array: The first two and the last two elements must be in decreasing order.
Increasing then decreasing array: The first two elements must be in increasing order and the last two elements must be in decreasing order.
Decreasing then increasing array: The first two elements must be in decreasing order and the last two elements must be in increasing order.
Below is the implementation of the above approach:
    */
    class IncDec
    {

        // Function to check the type of the array  
        public static void checkType(int[] arr, int n)
        {

            // If the first two and the last two elements  
            // of the array are in increasing order  
            if (arr[0] <= arr[1] &&
                arr[n - 2] <= arr[n - 1])
                Console.Write("Increasing");

            // If the first two and the last two elements  
            // of the array are in decreasing order  
            else if (arr[0] >= arr[1] &&
                     arr[n - 2] >= arr[n - 1])
                Console.Write("Decreasing");

            // If the first two elements of the array are in  
            // increasing order and the last two elements  
            // of the array are in decreasing order  
            else if (arr[0] <= arr[1] &&
                     arr[n - 2] >= arr[n - 1])
                Console.Write("Increasing then decreasing");

            // If the first two elements of the array are in  
            // decreasing order and the last two elements  
            // of the array are in increasing order  
            else
                Console.Write("Decreasing then increasing");
        }

        // Driver code  
        static public void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };

            int n = arr.Length;

            checkType(arr, n);
        }
    }
}
