using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
	 * Find an element in array such that sum of left array is equal to sum of right array
	 Given, an array of size n. Find an element that divides the array into two sub-arrays with equal sum.Examples: 

Input: 1 4 2 5
Output: 2
Explanation: If 2 is the partition, 
      subarrays are : {1, 4} and {5}

Input: 2 3 4 1 4 5
Output: 1
Explanation: If 1 is the partition, 
 Subarrays are : {2, 3, 4} and {4, 5}

Method 1 (Simple) 
Consider every element starting from the second element. Compute the sum of elements on its left and sum of elements on its right. If these two sums are the same, return the element.

Method 2 (Using Prefix and Suffix Arrays : 

We form a prefix and suffix sum arrays

Given array: 1 4 2 5
Prefix Sum:  1  5 7 12
Suffix Sum:  12 11 7 5

Now, we will traverse both prefix arrays.
The index at which they yield equal result,
is the index where the array is partitioned 
with equal sum.
Below is the implementation of the above approach:

	 
	 */
	class LeftRightSum
	{

		// Finds an element in an 
		// array such that left 
		// and right side sums 
		// are equal
		static int findElement(int[] arr,
							int n)
		{
			// Forming prefix sum
			// array from 0
			int[] prefixSum = new int[n];
			prefixSum[0] = arr[0];
			for (int i = 1; i < n; i++)
				prefixSum[i] = prefixSum[i - 1] +
										arr[i];

			// Forming suffix sum 
			// array from n-1
			int[] suffixSum = new int[n];
			suffixSum[n - 1] = arr[n - 1];
			for (int i = n - 2; i >= 0; i--)
				suffixSum[i] = suffixSum[i + 1] +
										arr[i];

			// Find the point where prefix 
			// and suffix sums are same.
			for (int i = 1; i < n - 1; i++)
				if (prefixSum[i] == suffixSum[i])
					return arr[i];

			return -1;
		}

		// Driver code
		public static void Main()
		{
			int[] arr = { 1, 4, 2, 5 };
			int n = arr.Length;
			Console.WriteLine(findElement(arr, n));
		}
	}

	// This code is contributed by anuj_67.

}
