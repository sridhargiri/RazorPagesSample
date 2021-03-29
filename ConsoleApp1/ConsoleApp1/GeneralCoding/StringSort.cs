using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
	/*
	 Print array of strings in sorted order without copying one string into another
Difficulty Level : Easy
Last Updated : 07 May, 2019
Given an array of n strings. The task is to print the strings in sorted order. The approach should be such that no string should be copied to another string during the sorting process.


Examples:

Input : {"geeks", "for", "geeks", "quiz")
Output : for geeks geeks quiz

Input : {"ball", "pen", "apple", "kite"}
Output : apple ball kite pen
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: It has the following steps:

Maintain another array indexed_arr which stores/maintains the index of each string.
We can apply any sorting technique to this indexed_arr.
An Illustration:

	https://www.geeksforgeeks.org/print-array-strings-sorted-order-without-copying-one-string-another/?ref=rp


--> str[] = {"world", "hello"}
--> corresponding index array will be
    indexed_arr = {0, 1}
--> Now, how the strings are compared and 
    accordingly values in indexed_arr are changed.
--> Comparison process:
    if (str[index[0]].compare(str[index[1]] > 0
        temp = index[0]
        index[0] = index[1]
        index[1] = temp

// after sorting values of
// indexed_arr = {1, 0}
--> for i=0 to 1
        print str[index[i]]

This is how the strings are compared and their 
corresponding indexes in the indexed_arr
are being manipulated/swapped so that after the sorting process
is completed, the order of indexes in the indexed_arr
gives us the sorted order of the strings.
	*/
	public class StringSort
	{

		// function to print strings in sorted order
		static void printInSortedOrder(String[] arr, int n)
		{
			int[] index = new int[n];
			int i, j, min;

			// Initially the index of the strings
			// are assigned to the 'index[]'
			for (i = 0; i < n; i++)
			{
				index[i] = i;
			}

			// selection sort technique is applied	
			for (i = 0; i < n - 1; i++)
			{
				min = i;
				for (j = i + 1; j < n; j++)
				{
					// with the help of 'index[]'
					// strings are being compared
					if (arr[index[min]].CompareTo(arr[index[j]]) > 0)
					{
						min = j;
					}
				}

				// index of the smallest string is placed
				// at the ith index of 'index[]'
				if (min != i)
				{
					int temp = index[min];
					index[min] = index[i];
					index[i] = temp;
				}
			}

			// printing strings in sorted order
			for (i = 0; i < n; i++)
			{
				Console.Write(arr[index[i]] + " ");
			}
		}

		// Driver program to test above
		static public void Main()
		{
			String[] arr = { "geeks", "quiz", "geeks", "for" };
			int n = 4;
			printInSortedOrder(arr, n);
		}
	}

	// This code is contributed by 29AjayKumar

}
