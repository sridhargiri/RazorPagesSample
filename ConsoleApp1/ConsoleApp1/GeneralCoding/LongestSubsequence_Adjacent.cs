using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class LongestSubsequence_Adjacent
    {
        /*
         Longest subsequence with different adjacent characters
Last Updated : 06 Sep, 2020
Given string str. The task is to find the longest subsequence of str such that all the characters adjacent to each other in the subsequence are different.
Examples: 
 

Input: str = “ababa” 
Output: 5 
Explanation: 
“ababa” is the subsequence satisfying the condition
Input: str = “xxxxy” 
Output: 2 
Explanation: 
“xy” is the subsequence satisfying the condition 
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Method 1: Greedy Approach 
It can be observed that choosing the first character which is not similar to the previously chosen character given the longest subsequence of the given string with different adjacent characters. 
The idea is to keep track of previously picked character while iterating through the string and if the current character is different from the previous character then count the current character to find the longest subsequence.
Below is the implementation of the above approach: 
        */
        static int longestSubsequence_adjacent_characters(String s)
        {

            // Length of the String s
            int n = s.Length;
            int answer = 0;

            // Previously picked character
            char prev = '-';

            for (int i = 0; i < n; i++)
            {

                // If the current character is
                // different from the previous
                // then include this character
                // and update previous character
                if (prev != s[i])
                {
                    prev = s[i];
                    answer++;
                }
            }
            return answer;
        }
        /*
         Output: 
5





 

Time Complexity: O(N), where N is the length of the given string.
Method 2: Dynamic Programming 




For each character in the given string str, do the following: 
Choose the current characters in the string for the resultant subsequence and recurr for the remaining string to find the next possible characters for the resultant subsequence.
Omit the current characters and recurr for the remaining string to find the next possible characters for the resultant subsequence.
The maximum value in the above recursive call will be the longest subsequence with different adjacent elements.
The recurrence relation is given by: 
 
Let dp[pos][prev] be the length of longest subsequence 
till index pos such that alphabet prev was picked previously.a dp[pos][prev] = max(1 + function(pos+1, s[pos] - 'a' + 1, s), 
                    function(pos+1, prev, s));





Below is the implementation of the above approach: 
        Output: 
5





 

Time Complexity: O(N), where N is the length of the given string. 
Auxiliary Space: O(26*N) where N is the length of the given string.
         */

        // dp table
        static int[,] dp = new int[100005, 27];

        // A recursive function to find the
        // update the [,]dp table
        static int calculate(int pos, int prev, String s)
        {

            // If we reach end of the String
            if (pos == s.Length)
            {
                return 0;
            }

            // If subproblem has been computed
            if (dp[pos, prev] != -1)
                return dp[pos, prev];

            // Initialise variable to 
            // find the maximum length
            int val = 0;

            // Choose the current character
            if (s[pos] - 'a' + 1 != prev)
            {
                val = Math.Max(val, 1 +
                               calculate(pos + 1,
                                         s[pos] - 'a' + 1,
                                         s));
            }

            // Omit the current character
            val = Math.Max(val, calculate(pos + 1, prev, s));

            // Return the store answer to the
            // current subproblem
            return dp[pos, prev] = val;
        }

        // Function to find the longest Subsequence
        // with different adjacent character
        static int longestSubsequence_adjacent_characters_dp(String s)
        {

            // Length of the String s
            int n = s.Length;

            // Initialise the memoisation table
            for (int i = 0; i < 100005; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    dp[i, j] = -1;
                }
            }

            // Return the readonly ans after every
            // recursive call
            return calculate(0, 0, s);
        }

        public static void Main(String[] args)
        {
            String str = "ababa";

            Console.Write(longestSubsequence_adjacent_characters(str));
            Console.Write(longestSubsequence_adjacent_characters_dp(str));
        }
    }
}
