using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/convert-given-strings-into-t-by-replacing-characters-in-between-strings-any-number-of-times/
    Convert given Strings into T by replacing characters in between strings any number of times
Last Updated : 10 Jul, 2021
Given an array, arr[] of N strings and a string T of size M, the task is to check if it is possible to make all the strings in the array arr[] same as the string T by removing any character from one string, say arr[i] and inserting it at any position to another string arr[j] any number of times.

Examples:

Input: arr[] = {“abc”, “abb”, “acc”}, T = “abc”
Output: Yes
Explanation:
Below is one of the possible way to make the all strings in the array to the string T is:

Remove character at index 2 of the string arr[1](= “abb”) and then insert it at the index 1 of the string arr[2](= “acc”). After this the array modifies to {“abc”, “”ab”, “abcc”}.
Remove character at index 3 of the string arr[2](= “abcc”) and then insert it at the index 2 of the string arr[1]( = “ab”). After this the array modifies to {“abc”, “”abc”, “abc”}.
After the above steps, all the strings of the array arr[] are equal to the string T(= abc). Therefore, print Yes.

Input: arr[] = {“abc”, “bbb”, “ccc”}, T = “abc”
Output: No



Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The given problem can be solved based on the following observation that the output will be “Yes” if and only if the following conditions are satisfied:

None the string contains any character which is not present in T.
All the characters of T must be present N times in all the given strings of S[] combined.
Follow the steps to solve the problem:

Initialize two arrays, say freqS[256] and freqT[256] with value 0 to store the frequency of characters present in all strings of the array, arr[] and the string T respectively.
Traverse the given array of strings arr[] and store the frequency of character for every string in the array freqS[].
Iterate over the characters of the string T and store the frequency of character of the string T in the array freqT[].
Iterate in the range [0, 255] using the variable i and perform the following steps:
If the value of freqS[i] and freqT[i] are 0 or the value of freqS[i] is equal to N*freq[T], then continue the iteration.
Otherwise, initialize a boolean variable, say A as true and break out of the loop.
After completing the above steps, if the value of A is true, then print “No”. Otherwise, print “Yes“.
Below is the implementation of the above approach
     */
    class AllStringSame
    {

        // Function to check if it possible
        // to make all the strings equal to
        // the string T
        static String checkIfPossible(
            int N, String[] arr, String T)
        {
            // Stores the frequency of all
            // the strings in the array arr[]
            int[] freqS = new int[256];

            // Stores the frequency of the
            // string T
            int[] freqT = new int[256];

            // Iterate over the characters
            // of the string T

            foreach (char ch in T.ToCharArray())
            {

            }
            // Iterate in the range [0, N-1]
            for (int i = 0; i < N; i++)
            {

                // Iterate over the characters
                // of the string arr[i]
                foreach (char ch in arr[i].ToCharArray())
                {
                    freqS[ch - 'a']++;
                }
            }

            for (int i = 0; i < 256; i++)
            {

                // If freqT[i] is 0 and
                // freqS[i] is not 0
                if (freqT[i] == 0
                    && freqS[i] != 0)
                {
                    return "No";
                }

                // If freqS[i] is 0 and
                // freqT[i] is not 0
                else if (freqS[i] == 0
                         && freqT[i] != 0)
                {
                    return "No";
                }

                // If freqS[i] is not freqT[i]*N
                else if (freqT[i] != 0
                         && freqS[i]
                                != (freqT[i] * N))
                {
                    return "No";
                }
            }

            // Otherwise, return "Yes"
            return "Yes";
        }

        // Driver Code
        public static void main(String[] args)
        {
            String[] arr = { "abc", "abb", "acc" };
            String T = "abc";
            int N = arr.Length;
            Console.WriteLine(checkIfPossible(N, arr, T));
            /*
             Output:
Yes
Time Complexity: O(N*L + M), Where L is the length of the longest string in the array arr[].
Auxiliary Space: O(26)
            */
        }
    }
}
