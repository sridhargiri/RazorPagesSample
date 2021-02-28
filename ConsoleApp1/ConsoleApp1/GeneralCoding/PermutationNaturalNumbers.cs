using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
	 Check if an Array is a permutation of numbers from 1 to N
Given an array arr containing N positive integers, the task is to check if the given array arr represents a permutation or not.

A sequence of N integers is called a permutation if it contains all integers from 1 to N exactly once.

Examples:

Input: arr[] = {1, 2, 5, 3, 2}
Output: No
Explanation:
The given array is not a permutation of numbers from 1 to N, because it contains 2 twice, and 4 is missing for the array to represent a permutation of length 5.

Input: arr[] = {1, 2, 5, 3, 4}
Output: Yes
Explanation:
Given array contains all integers from 1 to 5 exactly once. Hence, it represents a permutation of length 5.




Naive Approach: Clearly, the given array will represent a permutation of length N only, where N is the length of the array. So we have to search for each element from 1 to N in the given array. If all the elements are found then the array represents a permutation else it does not.

Time Complexity: O(N2)

Efficient Approach:
The above method can be optimized using a set data structure.

Traverse the given array and insert every element in the set data structure.
Also, find the maximum element in the array. This maximum element will be value N which will represent the size of the set.
After traversal of the array, check if the size of the set is equal to N.
If the size of the set if equal to N then the array represents a permutation else it doesn’t.
Below is the implementation of the above approach:
	 */
	class PermutationNaturalNumbers
	{

		// Function to check if an 
		// array represents a permutation or not 
		static bool permutation_of_n_natural_numbers(int[] arr, int n)
		{
			// Set to check the count 
			// of non-repeating elements 
			HashSet<int> hash = new HashSet<int>();

			int maxEle = 0;

			for (int i = 0; i < n; i++)
			{

				// Insert all elements in the set 
				hash.Add(arr[i]);

				// Calculating the max element 
				maxEle = Math.Max(maxEle, arr[i]);
			}

			if (maxEle != n)
				return false;

			// Check if set size is equal to n 
			if (hash.Count == n)
				return true;

			return false;
		}

		// Driver code 
		public static void Main(String[] args)
		{
			int[] arr = { 1, 2, 5, 3, 2 };
			int n = arr.Length;

			if (permutation_of_n_natural_numbers(arr, n))
				Console.WriteLine("Yes");
			else
				Console.WriteLine("No");
		}
	}

	// Output:
	// No

}
