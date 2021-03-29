using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    /*
	 https://www.geeksforgeeks.org/check-whether-two-strings-can-be-made-equal-by-copying-their-characters-with-the-adjacent-ones/?ref=rp
	Check whether two strings can be made equal by copying their characters with the adjacent ones
Last Updated : 15 Oct, 2019
Given two strings str1 and str2, the task is to check whether both of the string can be made equal by copying any character of the string with its adjacent character. Note that this operation can be performed any number of times.

Examples:

Input: str1 = “abc”, str2 = “def”
Output: No
As all the characters in both the string are different.
So, there is no way they can be made equal.

Input: str1 = “abc”, str2 = “fac”
Output: Yes
str1 = “abc” -> “aac”
str2 = “fac” -> “aac”

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: In order for the strings to be made equal with the given operation, they have to be of equal lengths and there has to be at least one character which is common in both the strings. To check that, create a frequency array freq[] which will store the frequency of all the characters of str1 and then for every character of str2 if its frequency in str1 is greater than 0 then it is possible to make both the strings equal.

Below is the implementation of the above approach:
	 */
    class StringEqual
    {
        static int MAX = 26;

        // Function that returns true if both
        // the strings can be made equal
        // with the given operation
        static Boolean canBeMadeEqual(String str1,
                                    String str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;

            // Lengths of both the strings
            // have to be equal
            if (len1 == len2)
            {

                // To store the frequency of the
                // characters of str1
                int[] freq = new int[MAX];

                for (int i = 0; i < len1; i++)
                {
                    freq[str1[i] - 'a']++;
                }

                // For every character of str2
                for (int i = 0; i < len2; i++)
                {

                    // If current character of str2
                    // also appears in str1
                    if (freq[str2[i] - 'a'] > 0)
                        return true;
                }
            }
            return false;
        }

        // Driver code
        public static void Main(String[] args)
        {
            String str1 = "abc", str2 = "defa";

            if (canBeMadeEqual(str1, str2))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }

    // op - No

}
