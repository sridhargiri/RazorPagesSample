using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimum-number-of-manipulations-required-to-make-two-strings-anagram-without-deletion-of-character/
    Minimum Number of Manipulations required to make two Strings Anagram Without Deletion of Character
Difficulty Level : Easy
Last Updated : 17 Feb, 2021
Given two strings s1 and s2, we need to find the minimum number of manipulations required to make two strings anagram without deleting any character. 
Note:- The anagram strings have same set of characters, sequence of characters can be different. 
If deletion of character is allowed and cost is given, refer to Minimum Cost To Make Two Strings Identical
    https://www.geeksforgeeks.org/minimum-cost-make-two-strings-identical/
Question Source: https://www.geeksforgeeks.org/yatra-com-interview-experience-set-7/
Examples: 

Input : 
       s1 = "aba"
       s2 = "baa"
Output : 0
Explanation: Both String contains identical characters

Input :
       s1 = "ddcf"
       s2 = "cedk"
Output : 2
Explanation : Here, we need to change two characters
in either of the strings to make them identical. We 
can change 'd' and 'f' in s1 or 'e' and 'k' in s2.
Assumption: Length of both the Strings is considered similar 
     */
    class AnagramManipulate
    {

        // Counts the no of manipulations
        // required
        static int countManipulations_to_make_anagram(string s1,
                                      string s2)
        {
            int count = 0;

            // store the count of character
            int[] char_count = new int[26];

            // iterate though the first String
            // and update count
            for (int i = 0; i < s1.Length; i++)
                char_count[s1[i] - 'a']++;

            // iterate through the second string
            // update char_count.
            // if character is not found in
            // char_count then increase count
            for (int i = 0; i < s2.Length; i++)
                char_count[s2[i] - 'a']--;

            for (int i = 0; i < 26; ++i)
            {
                if (char_count[i] != 0)
                {
                    count += Math.Abs(char_count[i]);
                }
            }

            return count;
        }

        // Driver code
        public static void Main()
        {

            string s1 = "ddcf";
            string s2 = "cedk";

            Console.WriteLine(
                countManipulations_to_make_anagram(s1, s2));//op 2. Time Complexity: O(n), where n is the length of the string
        }
    }
}
