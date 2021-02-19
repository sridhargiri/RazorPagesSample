using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*Given two strings s1 and s2, find if s1 is a substring of s2. If yes, return the index of the first occurrence, else return -1.

Examples : 

Input: s1 = "for", s2 = "geeksforgeeks"
Output: 5
Explanation:
String "for" is present as a substring
of s2.

Input: s1 = "practice", s2 = "geeksforgeeks"
Output: -1.
Explanation:
There is no occurrence of "practice" in
"geeksforgeeks"
    
     Simple Approach: The idea is to run a loop from start to end and for every index in the given string check whether the sub-string can be formed from that index. This can be done by running a nested loop traversing the given string and in that loop run another loop checking for sub-string from every index. 
For example, consider there to be a string of length N and a substring of length M. Then run a nested loop, where the outer loop runs from 0 to (N-M) and the inner loop from 0 to M. For very index check if the sub-string traversed by the inner loop is the given sub-string or not. 
    Time complexity: O(m * n) where m and n are lengths of s1 and s2 respectively. 
A nested loop is used the outer loop runs from 0 to N-M and inner loop from 0 to M so the complexity is O(m*n).
Space Complexity: O(1). 
As no extra space is required.


    Another Efficient Solution: 

An efficient solution would need only one traversal i.e. O(n) on the longer string s1. Here we will start traversing the string s1 and maintain a pointer for string s2 from 0th index. 
For each iteration we compare the current character in s1 and check it with the pointer at s2. 
If they match we increment the pointer on s2 by 1. And for every mismatch we set the pointer back to 0. 
Also keep a check when the s2 pointer value is equal to the length of string s2, if true we break and return the value (pointer of string s1 – pointer of string s2)


    Complexity Analysis:

Since we are traversing the first string 1 time so the order is O(n) and we are not allocating extra space to space complexity will be O(1)
    
    public int strstr(String str, String target)
    {
 
        int t = 0;
        int len = str.length();
        int i;
 
        // Iterate from 0 to len - 1
        for (i = 0; i < len; i++) {
            if (t == target.length())
                break;
            if (str.charAt(i) == target.charAt(t))
                t++;
            else
                t = 0;
        }
 
        return t < target.length() ? -1 : i - t;
    }
 
     */
    class IsSubstring
    {

        // Returns true if s1 is substring of s2
        static int isSubstring(string s1, string s2)
        {
            int M = s1.Length;
            int N = s2.Length;

            /* A loop to slide pat[] one by one */
            for (int i = 0; i <= N - M; i++)
            {
                int j;

                /* For current index i, check for
                pattern match */
                for (j = 0; j < M; j++)
                    if (s2[i + j] != s1[j])
                        break;

                if (j == M)
                    return i;
            }

            return -1;
        }

        /* Driver code */
        public static void Main()
        {
            string s1 = "for";
            string s2 = "geeksforgeeks";

            int res = isSubstring(s1, s2);

            if (res == -1)
                Console.Write("Not present");
            else
                Console.Write("Present at index "
                              + res);
        }
    }
}
