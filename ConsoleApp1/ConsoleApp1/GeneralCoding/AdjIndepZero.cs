using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if a Binary String contains A pairs of 0s and B independent 0s or not
Last Updated : 18 Mar, 2021
Given a binary string S and two positive integers A and B, the task is to check if the string consists of A independent pair of adjacent 0s and B independent number of 0s in the binary string or not. If found to be true, then print “Yes”. Otherwise, print “No”.
https://www.geeksforgeeks.org/check-if-a-binary-string-contains-a-pairs-of-0s-and-b-independent-0s-or-not/
Examples:

Input: S = “10100”, A = 1, B = 1
Output: Yes
Explanation:
The given string consists of A (=1) pairs of adjacent 0s and B (=1) independent number of 0s.

Input: S = “0101010”, A = 1, B = 2
Output: No
Explanation:
The given string has no pair of adjacent 0s.

Approach: Follow the steps below to solve the problem:




Traverse the given string S using a variable, say i, and perform the following steps:
If the current character is ‘0’ and its adjacent character is ‘0’ and A is at least 1, then decrease A by 1 and increase the pointer i by 1.
Otherwise, if the current character is ‘0’ and B is at least 1, then decrease B by 1.
After completing the above steps, if the value of A and B is 0, then print “Yes”. Otherwise, print “No”.
Below is the implementation of the above approach:
    */
    class AdjIndepZero
    {
        static void parking(string S, int a, int b)
        {
            // Traverse the string 
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '0')
                {
                    // If there are adjacent 
                    // 0s and a is positive 
                    if (i + 1 < S.Length
                        && S[i + 1] == '0'
                        && a > 0)
                    {

                        i++;
                        a--;
                    }

                    // If b is positive 
                    else if (b > 0)
                    {
                        b--;
                    }
                }
            }

            // Condition for Yes 
            if (a == 0 && b == 0)
            {
                Console.WriteLine("yes");
            }
            else
                Console.WriteLine("no");
        }
        static void Main(string[] args)
        {
            string S = "10100";
            int A = 1, B = 1;
            parking(S, A, B);
            /*
             Output:
Yes
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
