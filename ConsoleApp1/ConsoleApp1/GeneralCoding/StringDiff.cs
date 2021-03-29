using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Sum of minimum and the maximum difference between two given Strings
Last Updated : 27 Apr, 2020
Given two strings S1 and S2 of the same length. The task is to find the sum of the minimum and the maximum difference between two given strings if you are allowed to replace the character ‘+’ in the strings with any other character.

Note: If two strings have the same characters at every index, then the difference between them is zero.

Examples:

Input: S1 = “a+c”, S2 = “++b”
Output: 4
Explanation:
Minimim difference = 1. For minimum differnce:
In the string S1 = “a+c”, the “+” can be replaced by “b” thereby making S1 = “abc”
In the string S2 = “++b”, the “++” can be replaced by “ab” thereby making S2 = “abb”
Above, only the 3rd index has a different character. So, the minimum difference = 1
Maximum difference = 1. For maximum differnce:
In the string S1 = “a+c”, the “+” can be replaced by “z” thereby making S1 = “azc”
In the string S2 = “++b”, the “++” can be replaced by “bz” thereby making S2 = “bzb”
Above, all the indices has the difference characters. So, the maximum difference = 3
Minimum Difference + Maximum Difference = 1 + 3 = 4

Input: S1 = “+++a”, S2 = “+++a”
Output: 3
Explanation:
Minimim difference = 0. For minimum differnce:
In the string S1 = “+++a”, the “+++” can be replaced by “aaa” thereby making S1 = “aaaa”
In the string S2 = “+++a”, the “+++” can be replaced by “aaa” thereby making S2 = “aaaa”
Above, all the indices has the same characters. So, the minimum difference = 0
Maximum difference = 3. For maximum differnce:
In the string S1 = “+++a”, the “+++” can be replaced by “aaa” thereby making S1 = “aaaa”
In the string S2 = “+++a”, the “+++” can be replaced by “bbb” thereby making S2 = “bbba”
Above, all the indices except the last has the difference characters. So, the maximum difference = 3
Minimum Difference + Maximum Difference = 0 + 3 = 3

https://www.geeksforgeeks.org/sum-of-minimum-and-the-maximum-difference-between-two-given-strings/

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach:

Minimum Difference: In order to get the minimum difference between the strings, all the occurrences of “+” can be replaced by the same character. Therefore, if there is a “+” at any position, then that specific index can be made equal to the other string. Therefore, we only count the number of indices where the character is not “+” in either of the strings and the characters which are not same.
Maximum Difference: In order to get the maximum difference between the strings, all the occurrences of “+” can be replaced by the different character. Therefore, if there is a “+” at any position, then that specific index can be replaced with a different character other than that present in the second string. Therefore, we count the number of indices where the character is “+” in either of the strings and the characters which are not same.
Below is the implementation of the above approach:
    */
    class StringDiff
    {

        // Function to find the sum of the
        // minimum and the maximum difference
        // between two given Strings
        static void solve(char[] a, char[] b)
        {
            int l = a.Length;

            // Variables to store the minimum
            // difference and the maximum difference
            int min = 0, max = 0;

            // Iterate through the length of the String as
            // both the given Strings are of the same length
            for (int i = 0; i < l; i++)
            {

                // For the maximum difference, we can replace
                // "+" in both the Strings with different char
                if (a[i] == '+' || b[i] == '+' || a[i] != b[i])
                    max++;

                // For the minimum difference, we can replace
                // "+" in both the Strings with the same char
                if (a[i] != '+' && b[i] != '+' && a[i] != b[i])
                    min++;
            }

            Console.Write(min + max + "\n");
        }

        // Driver code
        public static void Main(String[] args)
        {
            String s1 = "a+c", s2 = "++b";
            solve(s1.ToCharArray(), s2.ToCharArray());
        }
        /*
         Output:
4
Time Complexity: O(N)
        */
    }

}
