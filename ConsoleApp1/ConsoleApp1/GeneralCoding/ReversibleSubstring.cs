using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/check-if-the-string-has-a-reversible-equal-substring-at-the-ends/
    Check if the string has a reversible equal substring at the ends
Last Updated : 13 Sep, 2021
Given a string S consisting of N characters, the task is to check if this string has an reversible equal substring from the start and the end. If yes, print True and then the longest substring present following the given conditions, otherwise print False.

Example:

Input: S = “abca”
Output: 
True
a
Explanation:
The substring “a”  is only the longest substring that  satisfy the given criteria. Therefore, print a.

Input: S = “acdfbcdca”
Output: 
True
acd
Explanation:
The substring “acd”  is only the longest substring that  satisfy the given criteria. Therefore, print acd.

Input: S = “abcdcb”
Output: False



Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The given problem can be solved by using the Two Pointer Approach. Following the steps below to solve the given problem:

Initialize a string, say ans as “” that stores the resultant string satisfying the given criteria.
Initialize two variables, say i and j as 0 and (N – 1) respectively.
Iterate a loop until j is non-negative and f the characters S[i] and S[j] are the same, then just add the character S[i] in the variable ans and increment the value of i by 1 and decrement the value of j by 1. Otherwise, break the loop.
After completing the above steps, if the string ans is empty then print False. Otherwise, print True and then print the string ans as the result.
Below is the implementation of the above approach:
     */
    public class ReversibleSubstring
    {
        static void commonSubstring(string s)
        {
            int n = s.Length;
            int i = 0;
            int j = n - 1;

            // Stores the resultant string
            string ans = "";
            while (j >= 0)
            {

                // If the characters are same
                if (s[i] == s[j])
                {
                    ans += s[i];
                    i++;
                    j--;
                }

                // Otherwise, break
                else
                {
                    break;
                }
            }

            // If the string can't be formed
            if (ans.Length == 0)
                Console.WriteLine("false");

            // Otherwise print resultant string
            else
            {
                Console.WriteLine("true");
            }
        }
        public static void Main(string[] args)
        {
            string S = "abca";
            commonSubstring(S);
            /*
             Output
a
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/check-two-strings-common-substring/
     Check if two strings have a common substring (satisfy - atleast one char is common)
Difficulty Level : Easy
Last Updated : 30 Apr, 2021
You are given two strings str1 and str2. You have to check if the two strings share a common substring.
Examples : 
 

Input : str1 = "HELLO"
        str2 = "WORLD"
Output : YES
Explanation :  The substrings "O" and
"L" are common to both str1 and str2

Input : str1 = "HI"
        str2 = "ALL"
Output : NO
Explanation : Because str1 and str2 
have no common substrings
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
A basic approach runs in O(n^2), where we compare every character of string 1 with every character of string 2 and replace every matched character with a “_” and set flag variable as true.
An efficient approach works in O(n). 
    We basically need to check if there is a common character or not. 
    We create a vector of size 26 for alphabets and initialize them as 0. 
    For every character in string 1 we increment vector index of that character eg: v[s1[i]-‘a’]++, for every character of string 2 we check vector for the common characters if v[s2[i]-‘a’] > 0 then set flag = true and v[s2[i]-‘a’]– such that one character of string 2 is compared with only one character of string 1.
 
     */
    public class CommonStrings
    {
        static int MAX_CHAR = 26;

        // function to return true if strings have
        // common substring and no if strings have
        // no common substring
        static bool CommonStringBetweenTwoString(String s1, String s2)
        {
            // vector for storing character occurrences
            bool[] v = new bool[MAX_CHAR];

            // increment vector index for
            // every character of str1
            for (int i = 0; i < s1.Length; i++)
                v[s1[i] - 'a'] = true;

            // checking common substring of str2 in str1
            for (int i = 0; i < s2.Length; i++)
                if (v[s2[i] - 'a'])
                    return true;

            return false;
        }

        // Driver code
        public static void Main()
        {
            String str1 = "hello";
            String str2 = "world";
            if (CommonStringBetweenTwoString(str1, str2))
                Console.Write("Yes");
            else
                Console.Write("No");
            //op yes
            //Time Complexity : O(n) 
        }
    }
}
