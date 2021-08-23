using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/check-if-string-s1-can-be-formed-using-repeated-insertions-of-another-string-s2/
    Check if string S1 can be formed using repeated insertions of another string S2
Last Updated : 20 Aug, 2021
Given two strings S1 and S2 consisting of unique characters, the task is to check S1 can be formed by repeated insertions of string S2.

Input: S1 = “aabb”, S2 = “ab”
Output: Yes
Explanation: the mentioned string can be obtained after series of moves:

Insert string “ab” in an empty string. Current string will be “ab“
insert “ab” after “a”. The final string will be “aabb”
Input: S1 = “ababcd”, S2 = “abc”
Output: No
Explanation: It is not possible to obtain above string with any series of moves.

 
Approach: Given problem can be solved using stack data structure. The idea is to insert the characters of S1 into the stack till the last character of S2 is found. Then pop the characters of length(S2) from Stack and compare with S2. If not the same, stop and return false. Else repeat the process till S1 becomes empty.

Below are the steps for the above approach:



First, check the below cases and return false if found true:
The count of unique characters in S1 must be the same as S2
The length of string S1 must be a multiple of S2
Maintain a stack for all the characters
Iterate through the string S1 and push characters in a stack
If the current character is the last character of the string S2 then match all the characters to the left in the stack
If for any position the stack is empty or the character doesn’t matches then return False
After the complete iteration on the string check if the stack is empty. If the stack is not empty then return false else return true
Below is the implementation of the above approach:
     */
    class RepeatedInsertionString
    {
        static bool validInsertionstring(string S1, string S2)
        {

            // Store the size of string
            int N = S1.Length;
            int M = S2.Length;

            // Maintain a stack for characters
            Stack<char> st = new Stack<char>();

            // Iterate through the string
            for (int i = 0; i < N; i++)
            {

                // push the current character
                // on top of the stack
                st.Push(S1[i]);

                // If the current character is the
                // last character of string S2 then
                // pop characters until S2 is not formed
                if (S1[i] == S2[M - 1])
                {

                    // index of last character of the string S2
                    int idx = M - 1;

                    // pop characters till 0-th index
                    while (idx >= 0)
                    {
                        if (st.Count == 0)
                        {
                            return false;
                        }
                        char c = st.Peek();
                        st.Pop();
                        if (c != S2[idx])
                        {
                            return false;
                        }
                        idx--;
                    }
                }
            }

            // Check if stack in non-empty
            if (st.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Main(string[] args)
        {
            string S1 = "aabb";
            string S2 = "ab";
            string s = validInsertionstring(S1, S2) ? "y" : "n"; Console.WriteLine(s);
            /*
             Output:
Yes
Time Complexity: O(N*M)
Auxiliary Space: O(N)
            */
        }
    }
}
