using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/count-occurrences-of-substring-x-before-every-occurrence-of-substring-y-in-a-given-string/     
     Count occurrences of substring X before every occurrence of substring Y in a given string
Last Updated : 18 May, 2021
Given three strings S, X, and Y consisting of N, A, and B characters respectively, the task is to find the number of occurrences of the substring X before every occurrence of the substring Y in the given string S.

Examples:

Input S = ”abcdefdefabc”, X = ”def”, Y = ”abc”
Output: 0 2
Explanation:
First occurence of Y(= “abc”): No of occurrences of X(= “def”) = 0.
Second occurrence of Y: No of occurrences of X = 0.

Input: S = ”accccbbbbbbaaa”, X = ”a”, Y = ”b”
Output: 0 6 6 6

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: Follow the steps below to solve the problem:



Initialize a variable, say count, that stores the total number occurrences of X.
Traverse the given string S and perform the following steps:
If the substring over the range [i, B] is equal to Y, then increment count by 1.
If the substring over the range [i, A] is equal to X, then print the value of count as the resultant count of the string Y before the current occurrence of the string X.
Below is the implementation of the above approach:
    */
    class SubstringOccurence
    {

        // Function to count occurrences of
        // the string Y in the string S for
        // every occurrence of X in S
        static void countOccurrences(String S, String X,
                                     String Y)
        {
            // Stores the count of
            // occurrences of X
            int count = 0;

            // Stores the lengths of the
            // three strings
            int N = S.Length, A = X.Length;
            int B = Y.Length;

            // Traverse the string S
            for (int i = 0; i < N; i++)
            {

                // If the current substring
                // is Y, then increment the
                // value of count by 1
                if (S.Substring(i, Math.Min(N, i + B))
                        .Equals(Y))
                    count++;

                // If the current substring
                // is X, then print the count
                if (S.Substring(i, Math.Min(N, i + A))
                        .Equals(X))
                    Console.WriteLine( count + " ");
            }
        }

        // Driver Code
        public static void main(String[] args)
        {
            String S = "abcdefdefabc";
            String X = "abc";
            String Y = "def";
            countOccurrences(S, X, Y);
            /*
             Output: 
0 2
 

Time Complexity: O(N*(A + B))
Auxiliary Space: O(1)
            */
        }
    }
}
