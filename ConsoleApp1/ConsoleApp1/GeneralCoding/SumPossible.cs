using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
Check if is possible to get given sum from a given set of elements
Difficulty Level : Easy
Last Updated : 08 Feb, 2019
Given array of numbers and a integer x. Find whether it is possible or not to get x by adding elements of given array, we may pick a single element multiple times. For a given array, there can be many sum queries.

Examples:

Input : arr[] = { 2, 3}
         q[]  = {8, 7}
Output : Yes Yes
Explanation : 
2 + 2 + 2 + 2 = 8
2 + 2 + 3 = 7
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to first sort the given array and then use the concept similar to Sieve of Eratosthenes. First take a large sized array ( which is maximum size of x). Initially keep zero in all it’s indexes. Make 1 at zero index ( we can get zero whatever the array is) . Now, traverse through the whole array and make all possible values as 1.
	https://www.geeksforgeeks.org/check-if-is-possible-to-get-given-sum-from-a-given-set-of-elements/
	 */
	class SumPossible
	{

		// to check whether x is possible or not
		static int[] ispossible = new int[1000];
		static void check(int[] arr, int N)
		{

			ispossible[0] = 1;
			Array.Sort(arr);

			for (int i = 0; i < N; ++i)
			{
				int val = arr[i];

				// if it is already possible
				if (ispossible[val] == 1)
					continue;

				// make 1 to all it's next elements
				for (int j = 0; j + val < 1000; ++j)
					if (ispossible[j] == 1)
						ispossible[j + val] = 1;
			}
		}

		// Driver code
		public static void Main()
		{
			int[] arr = { 2, 3 };
			int N = arr.Length;
			check(arr, N);
			int x = 7;
			if (ispossible[x] == 1)
				Console.WriteLine(x + " is possible.");
			else
				Console.WriteLine(x + " is not possible.");
		}
	}
//	Output:

//7 is possible.

}
