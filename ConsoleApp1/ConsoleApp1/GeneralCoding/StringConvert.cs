using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
	 Check if it is possible to convert one string into another with given constraints
Difficulty Level : Medium
Last Updated : 31 Mar, 2020
Given two strings contains three characters i.e ‘A’, ‘B ‘and ‘#’ only. Check is it possible to convert first string into another string by performing following operations on string first.
1- ‘A’ can move towards Left only
2- ‘B’ can move towards Right only
3- Neither ‘A’ nor ‘B’ cross each other
If it is possible then print “Yes” otherwise “No”.

Examples:

Input : str1=” #A#B#B# “, str2=” A###B#B ”
Output :Yes
Explanation :
‘A’ in str1 is right to the ‘A’ in str2 so ‘A’ of str1 can move easily towards the left because there is no ‘B’ on its left positions and for first ‘B’ in str1 is left to the ‘B’ in str2 so ‘B’ of str2 can move easily towards the right because there is no ‘A’ on its right positions and it is same for next ‘B’ so str1 can be easily converted into str2.

Input :str1=” #A#B# “, str2=” #B#A# ”
Output :No
Explanation :
Here first ‘A’ in str1 is left to the ‘A’ in str2 and according to the condition ‘A’ can’tmove towards right. so str1 can’t be converted into str2.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Method :
1-Length of Both string must be same
2-No. of A’s and B’s in both the strings must be equal
3-Order of A and B in both the strings should be same(for ex: if ‘A’ is coming before ‘B’in string second then the same sequence must be follow on string first)
https://www.geeksforgeeks.org/check-if-it-is-possible-to-convert-one-string-into-another/?ref=rp

	 */
	public class GFG
	{

		// Function to check is it possible to convert
		// first String into another String or not.
		static bool isItPossible(char[] str1, char[] str2,
									int m, int n)
		{

			// To Check Length of Both String is Equal or Not
			if (m != n)
				return false;

			// To Check Frequency of A's and B's are
			// equal in both Strings or not.
			if (count(str1, 'A') !=
				count(str2, 'A') ||
				count(str1, 'B') !=
					count(str2, 'B'))
				return false;

			// Start traversing
			for (int i = 0; i < m; i++)
			{
				if (str1[i] != '#')
				{
					for (int j = 0; j < n; j++)
					{

						// To Check no two elements cross each other.
						if ((str2[j] != str1[i]) && str2[j] != '#')
							return false;

						if (str2[j] == str1[i])
						{
							str2[j] = '#';

							// To Check Is it Possible to Move
							// towards Left or not.
							if (str1[i] == 'A' && i < j)
								return false;

							// To Check Is it Possible to Move
							// towards Right or not.
							if (str1[i] == 'B' && i > j)
								return false;

							break;
						}
					}
				}
			}

			return true;
		}

		private static int count(char[] str1, char c)
		{
			int count = 0;
			foreach (char temp in str1)
			{
				if (c == temp)
					count++;
			}
			return count;
		}

		// Drivers code
		public static void Main(String[] args)
		{
			String str1 = "A#B#";
			String str2 = "A##B";

			int m = str1.Length;
			int n = str2.Length;

			Console.Write(isItPossible(str1.ToCharArray(), str2.ToCharArray(), m, n) ?
					"Yes\n" : "No\n");

		}
	}

	// Output:
	//Yes
	//Time Complexity : O(n^2)

}
