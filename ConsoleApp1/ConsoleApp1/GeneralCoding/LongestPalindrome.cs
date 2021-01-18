using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{


	class LongestPalindrome
	{

		// Function to print a subString str[low..high]
		static void printSubStr(String str, int low, int high)
		{
			for (int i = low; i <= high; ++i)
				Console.Write(str[i]);
		}

		/*
		 Given a string, find the longest substring which is palindrome. 

	For example, 

	Input: Given string :"forgeeksskeegfor", 
	Output: "geeksskeeg"

	Input: Given string :"Geeks", 
	Output: "ee"
		Method 1: Brute Force. 
	Approach: The simple approach is to check each substring whether the substring is a palindrome or not. 
		To do this first, run three nested loops, the outer two loops pick all substrings one by one by fixing the corner characters, the inner loop checks whether the picked substring is palindrome or not. 
		*/

		// This function prints the
		// longest palindrome subString
		// It also returns the length
		// of the longest palindrome
		static int longestPalSubstr(String str)
		{
			// get length of input String
			int n = str.Length;

			// All subStrings of length 1
			// are palindromes
			int maxLength = 1, start = 0;

			// Nested loop to mark start and end index
			for (int i = 0; i < str.Length; i++)
			{
				for (int j = i; j < str.Length; j++)
				{
					int flag = 1;

					// Check palindrome
					for (int k = 0; k < (j - i + 1) / 2; k++)
						if (str[i + k] != str[j - k])
							flag = 0;

					// Palindrome
					if (flag != 0 && (j - i + 1) > maxLength)
					{
						start = i;
						maxLength = j - i + 1;
					}
				}
			}

			Console.Write("longest palindrome subString is: ");
			printSubStr(str, start, start + maxLength - 1);

			// return length of LPS
			return maxLength;
		}
		/*
		 Method 2: Dynamic Programming. 
Approach: The time complexity can be reduced by storing results of sub-problems. The idea is similar to this post.  

Maintain a boolean table[n][n] that is filled in bottom up manner.
The value of table[i][j] is true, if the substring is palindrome, otherwise false.
To calculate table[i][j], check the value of table[i+1][j-1], if the value is true and str[i] is same as str[j], then we make table[i][j] true.
Otherwise, the value of table[i][j] is made false.
We have to fill table previously for substring of length = 1 and length =2 because 
as we are finding , if table[i+1][j-1] is true or false , so in case of 
(i) length == 1 , lets say i=2 , j=2 and i+1,j-1 doesn’t lies between [i , j] 
(ii) length == 2 ,lets say i=2 , j=3 and i+1,j-1 again doesn’t lies between [i , j].
		*/

		static int longestPalSubstr_op(string str)
		{

			// Get length of input string
			int n = str.Length;

			// Table[i, j] will be false if substring
			// str[i..j] is not palindrome. Else
			// table[i, j] will be true
			bool[,] table = new bool[n, n];

			// All substrings of length 1 are palindromes
			int maxLength = 1;
			for (int i = 0; i < n; ++i)
				table[i, i] = true;

			// Check for sub-string of length 2.
			int start = 0;

			for (int i = 0; i < n - 1; ++i)
			{
				if (str[i] == str[i + 1])
				{
					table[i, i + 1] = true;
					start = i;
					maxLength = 2;
				}
			}

			// Check for lengths greater than 2.
			// k is length of substring
			for (int k = 3; k <= n; ++k)
			{

				// Fix the starting index
				for (int i = 0; i < n - k + 1; ++i)
				{

					// Get the ending index of substring from
					// starting index i and length k
					int j = i + k - 1;

					// Checking for sub-string from ith index
					// to jth index iff str.charAt(i+1) to
					// str.charAt(j-1) is a palindrome
					if (table[i + 1, j - 1] && str[i] == str[j])
					{
						table[i, j] = true;
						if (k > maxLength)
						{
							start = i;
							maxLength = k;
						}
					}
				}
			}
			Console.Write("Longest palindrome substring is: ");
			printSubStr(str, start, start + maxLength - 1);

			// Return length of LPS
			return maxLength;
		}

		// Driver Code
		public static void Main(String[] args)
		{
			String str = "forgeeksskeegfor";
			Console.Write("\nLength is: "
				+ longestPalSubstr(str));
		}
	}

	// This code is contributed by shikhasingrajput

}
