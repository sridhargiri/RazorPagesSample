using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Minimum substring flips required to convert a Binary String to another
Last Updated : 01 Mar, 2021
Given two binary strings S1 and S2 of size N and M respectively, the task is to find the minimum number of reversal of substrings of equal characters required to convert the string S1 to S2. If it is not possible to convert the string S1 to S2, then print “-1”.

Examples:

Input: S1 = “100001”, S2 = “110111”
Output: 2
Explanation:
Initially string S1 = “100001”.
Reversal 1: Reverse the substring S1[1, 1], then the string S1 becomes “110001”.
Reversal 2: Reverse the substring S1[3, 4], then the string S1 becomes “110111”.
After the above reversals, the string S1 and S2 are equal.
Therefore, the count of reversals is 2.

Input: S1 = 101, S2 = 10
Output: -1

Approach: Follow the below steps to solve this problem:
    Initialize a variable, say answer, to store the resultant count of reversal required.
If the length of the given strings S1 and S2 are not the same, then print “-1”.
Iterate over the range [0, N – 1] and perform the following steps:
If S1[i] and S2[i] are not the same, then iterate till S1[i] and S2[i] are the same. Increment the answer by 1 as the current substring needs to be flipped.
Otherwise, continue to the next iteration.
After completing the above steps, print the value of the answer as the resultant flipping of substrings required.
Below is the implementation of the above approach:

    */
    class MinSubstringFlips
    {
        static int canMakeSame(string s1, string s2)
        {
            // Stores the minimum count of 
            // reversal of substrings required 
            int ans = 0;

            // If the length of the strings 
            // are not the same then return -1 
            if (s1.Length != s2.Length)
            {
                return -1;
            }

            int N = s1.Length;

            // Iterate over each character 
            for (int i = 0; i < N; i++)
            {

                // If s1[i] is not 
                // equal to s2[i] 
                if (s1[i] != s2[i])
                {

                    // Iterate until s1[i] != s2[i] 
                    while (i < s1.Length && s1[i] != s2[i])
                    {
                        i++;
                    }

                    // Increment answer by 1 
                    ans++;
                }
            }

            // Return the resultant count of 
            // reversal of substring required 
            return ans;
        }
        static void Main(string[] args)
        {
            string S1 = "100001";
            string S2 = "110111";
            Console.WriteLine(canMakeSame(S1, S2));
        }
        /*
         Output:
2
Time Complexity: O(N)
Auxiliary Space: O(1)
        */
    }
}
