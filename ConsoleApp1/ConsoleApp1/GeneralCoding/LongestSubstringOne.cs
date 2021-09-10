﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/longest-substring-containing-1/
    Given a binary string, the task is to print the length of the longest substring containing only ‘1’.

Examples:

Input: 110
Output: 2
Explanation: Length of the longest substring containing only ‘1’ is “11”.

Input: 11101110
Output: 3

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Approach: Traverse the string and count the number of contiguous 1‘s encountered. Store the maximum number of coninous 1s in a variable, say max. Finally, print the value of max obtained.



     */
    class LongestSubstringOne
    {
        static int Maxlength(String s)
        {
            int n = s.Length, i, j;
            int ans = 0;
            for (i = 0; i <= n - 1; i++)
            {

                // Count the number of contiguous 1's
                if (s[i] == '1')
                {

                    int count = 1;
                    for (j = i + 1;
                         j <= n - 1 && s[j] == '1'; j++)
                        count++;
                    ans = Math.Max(ans, count);
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Maxlength("11101110"));
            /*
             Output: 3
Time Complexity: O(N2)
Auxiliary Space: O(1)
            */
        }
    }
}