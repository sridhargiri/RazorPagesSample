using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/print-common-characters-two-strings-alphabetical-order-2/
    Print common characters of two Strings in alphabetical order
Difficulty Level : Easy
Last Updated : 26 Apr, 2021
Given two strings, print all the common characters in lexicographical order. If there are no common letters, print -1. All letters are lower case. 
 

Examples: 

Input : 
string1 : geeks
string2 : forgeeks
Output : eegks
Explanation: The letters that are common between 
the two strings are e(2 times), k(1 time) and 
s(1 time).
Hence the lexicographical output is "eegks"

Input : 
string1 : hhhhhello
string2 : gfghhmh
Output : hhh
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to use character count arrays. 
1) Count occurrences of all characters from ‘a’ to ‘z’ in the first and second strings. Store these counts in two arrays a1[] and a2[]. 
2) Traverse a1[] and a2[] (Note size of both is 26). For every index i, print character ‘a’ + i number of times equal min(a1[i], a2[i]).
 

Below is the implementation of the above steps

     */
    class CommonCharacter
    {
        static int MAX_CHAR = 26;
        // C# program to print common characters 
        // of two Strings in alphabetical order 
        static void printCommon(string s1, string s2)
        {
            // two arrays of length 26 to store occurrence 
            // of a letters alphabetically for each string 
            int[] a1 = new int[MAX_CHAR];
            int[] a2 = new int[MAX_CHAR];

            int length1 = s1.Length;
            int length2 = s2.Length;

            for (int i = 0; i < length1; i++)
                a1[s1[i] - 'a'] += 1;

            for (int i = 0; i < length2; i++)
                a2[s2[i] - 'a'] += 1;

            // If a common index is non-zero, it means 
            // that the letter corresponding to that 
            // index is common to both strings 
            for (int i = 0; i < MAX_CHAR; i++)
            {
                if (a1[i] != 0 && a2[i] != 0)
                {
                    // Find the minimum of the occurrence 
                    // of the character in both strings and print 
                    // the letter that many number of times 
                    for (int j = 0; j < Math.Min(a1[i], a2[i]); j++)
                        Console.Write(((char)(i + 'a')));
                }
            }
        }
        // Driver code 
        public static void Main()
        {
            string s1 = "geeksforgeeks", s2 = "practiceforgeeks";
            printCommon(s1, s2);
        }
    }
}

