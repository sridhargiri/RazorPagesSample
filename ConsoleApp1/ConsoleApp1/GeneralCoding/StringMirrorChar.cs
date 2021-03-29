using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
	 Mirror characters of a string
Difficulty Level : Easy
Last Updated : 01 Jun, 2018
Given a string and a number N, we need to mirror the characters from N-th position up to the length of the string in the alphabetical order. In mirror operation, we change ‘a’ to ‘z’, ‘b’ to ‘y’, and so on.

Examples:

Input : N = 3
        paradox
Output : paizwlc
We mirror characters from position 3 to end.

Input : N = 6
        pneumonia
Output : pnefnlmrz
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Below are different characters and their mirrors.

a b c d e f g h i j k l m || n o p q r s t u v w x y z

https://www.geeksforgeeks.org/mirror-characters-string/

Mirroring the alphabetical order means that a corresponds to z, b corresponds to y. Which means that first character becomes the last and so on. Now, to achieve this we maintain a string(or a character array) which contains the English alphabets in lower case. Now from the pivot point up to the length, we can look up the reverse alphabetical order of a character by using its ASCII value as an index. Using the above technique, we transform the given string in the required one
	*/
	class StringMirrorChar
	{

		// Function which take the given string
		// and the position from which the
		// reversing shall be done and returns
		// the modified string
		static String compute(string str, int n)
		{

			// Creating a string having reversed
			// alphabetical order
			string reverseAlphabet =
				"zyxwvutsrqponmlkjihgfedcba";
			int l = str.Length;

			// The string up to the point
			// specified in the question,
			// the string remains unchanged
			// and from the point up to
			// the length of the string, we
			// reverse the alphabetical order
			String answer = "";

			for (int i = 0; i < n; i++)
				answer = answer + str[i];

			for (int i = n; i < l; i++)
				answer = answer +
				reverseAlphabet[str[i] - 'a'];
			return answer;
		}

		// Driver function
		public static void Main()
		{
			string str = "pneumonia";
			int n = 4;
			Console.Write(compute(str, n - 1));
		}

	}
	//Output:
	//pnefnlmrz
	//Complexity = O(length)

}
