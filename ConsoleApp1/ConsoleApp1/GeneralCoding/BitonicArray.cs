using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
     Program to check if an array is bitonic or not

Given an array of N elements. The task is to check if the array is bitonic or not.

An array is said to be bitonic if the elements in the array are first strictly increasing then strictly decreasing.

Examples:

Input: arr[] = {-3, 9, 11, 20, 17, 5, 1}
Output: YES

Input: arr[] = {5, 6, 7, 8, 9, 10, 1, 2, 11};
Output: NO
Approach:

Start traversing the array and keep checking if the next element is greater than the current element or not.
If at any point, the next element is not greater than the current element, break the loop.
Again start traversing from the current element and check if the next element is less than current element or not.
If at any point before the end of array is reached, if the next element is not less than the current element, break the loop and print NO.
If the end of array is reached successfully, print YES.
Below is the implementation of above approach:
    */
	class BitonicArray
	{
		// Function to check if the 
		// given array is bitonic 
		static int checkBitonic(int[] arr,
								int n)
		{
			int i, j;

			// Check for increasing sequence 
			for (i = 1; i < n; i++)
			{
				if (arr[i] > arr[i - 1])
					continue;

				if (arr[i] <= arr[i - 1])
					break;
			}

			if (i == n - 1)
				return 1;

			// Check for decreasing sequence 
			for (j = i + 1; j < n; j++)
			{
				if (arr[j] < arr[j - 1])
					continue;

				if (arr[j] >= arr[j - 1])
					break;
			}

			i = j;

			if (i != n)
				return 0;

			return 1;
		}

		// Driver Code 
		public static void Main()
		{
			int[] arr = { -3, 9, 7, 20, 17, 5, 1 };

			int n = arr.Length;

			Console.WriteLine((
					checkBitonic(arr, n) == 1) ?
										"YES" : "NO");
		}
	}

	// This code is contributed by Bilal 

}
