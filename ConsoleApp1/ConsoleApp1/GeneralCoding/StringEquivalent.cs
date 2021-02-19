using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
	 * Given two strings A and B of equal size. Two strings are equivalent either of the following conditions hold true:
1) They both are equal. Or,
2) If we divide the string A into two contiguous substrings of same size A1 and A2 and string B into two contiguous substrings of same size B1 and B2, then one of the following should be correct:

A1 is recursively equivalent to B1 and A2 is recursively equivalent to B2
A1 is recursively equivalent to B2 and A2 is recursively equivalent to B1
Check whether given strings are equivalent or not. Print YES or NO.

	 * input : A = “aaba”, B = “abaa”
Output : YES
Explanation : Since condition 1 doesn’t hold true, we can divide string A into “aaba” = “aa” + “ba” and string B into “abaa” = “ab” + “aa”. Here, 2nd subcondition holds true where A1 is equal to B2 and A2 is recursively equal to B1

Input : A = “aabb”, B = “abab”
Output : NO
	 Naive Solution : A simple solution is to consider all possible scenarios. Check first if the both strings are equal return “YES”, otherwise divide the strings and check if A1 = B1 and A2 = B2 or A1 = B2 and A2 = B1 by using four recursive calls. Complexity of this solution would be O(n2), where n is the size of the string.

Efficient Solution : Let’s define following operation on string S. We can divide it into two halves and if we want we can swap them. And also, we can recursively apply this operation to both of its halves. By careful observation, we can see that if after applying the operation on some string A, we can obtain B, then after applying the operation on B we can obtain A. And for the given two strings, we can recursively find the least lexicographically string that can be obtained from them. Those obtained strings if are equal, answer is YES, otherwise NO. For example, least lexicographically string for “aaba” is “aaab”. And least lexicographically string for “abaa” is also “aaab”. Hence both of these are equivalent.

Below is the implementation of the above approach.
Output:
YES
NO
Time Complexity : O(n), where n is the size of the string.
	*/
	class StringEquivalent
	{

		// This function returns the least lexicogr- 
		// aphical String obtained from its two halves 
		static String leastLexiString(String s)
		{
			// Base Case - If String size is 1 
			if (s.Length == 1)
				return s;

			// Divide the String into its two halves 
			String x = leastLexiString(s.Substring(0,
									s.Length / 2));
			String y = leastLexiString(s.Substring(
									s.Length / 2));

			// Form least lexicographical String 
			return ((x + y).CompareTo(y + x).ToString());
		}

		static Boolean areEquivalent(String a, String b)
		{
			return !(leastLexiString(a).Equals(
					leastLexiString(b)));
		}

		// Driver Code 
		public static void Main(String[] args)
        {
			String a = "aaba";
			String b = "abaa";
			if (areEquivalent(a, b))
				Console.WriteLine("YES");
			else
				Console.WriteLine("NO");

			a = "aabb";
			b = "abab";
			if (areEquivalent(a, b))
				Console.WriteLine("YES");
			else
				Console.WriteLine("NO");
		}
	}

	// This code is contributed by PrinciRaj1992 

}
