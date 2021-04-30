using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/check-occurrences-character-appear-together/?ref=rp
    Check if all occurrences of a character appear together
Difficulty Level : Easy
Last Updated : 25 Jun, 2018
Given a string s and a character c, find if all occurrences of c appear together in s or not. If the character c does not appear in the string at all, the answer is true.

Examples

Input: s = "1110000323", c = '1'
Output: Yes
All occurrences of '1' appear together in
"1110000323"

Input: s  = "3231131", c = '1'
Output: No
All occurrences of 1 are not together

Input: s  = "abcabc", c = 'c'
Output: No
All occurrences of 'c' are not together

Input: s  = "ababcc", c = 'c'
Output: Yes
All occurrences of 'c' are together
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to traverse given string, as soon as we find an occurrence of c, we keep traversing until we find a character which is not c. We also set a flag to indicate that one more occurrences of c are seen. If we see c again and flag is set, then we return false.
    */
    class AppearTogether
    {

        static bool checkIfAllTogether(string s,
                                         char c)
        {

            // To indicate if one or more 
            // occurrences of 'c' are seen
            // or not.
            bool oneSeen = false;

            // Traverse given string
            int i = 0, n = s.Length;
            while (i < n)
            {

                // If current character is
                // same as c, we first check
                // if c is already seen.         
                if (s[i] == c)
                {
                    if (oneSeen == true)
                        return false;

                    // If this is very first
                    // appearance of c, we 
                    // traverse all consecutive
                    // occurrences.
                    while (i < n && s[i] == c)
                        i++;

                    // To indicate that character
                    // is seen once.
                    oneSeen = true;
                }

                else
                    i++;
            }

            return true;
        }

        // Driver code
        public static void Main()
        {
            string s = "111111110029";

            if (checkIfAllTogether(s, '1'))
                Console.Write("Yes");
            else
                Console.Write("No");
            /*
             Output:
Yes
The complexity of above program is O(n).
            */
        }
    }
}
