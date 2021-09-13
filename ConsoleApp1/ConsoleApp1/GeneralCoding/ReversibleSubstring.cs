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
}
