using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
    https://cses.fi/problemset/task/1622
Write a program to print all permutations of a given string
Difficulty Level : Medium
Last Updated : 17 May, 2021
A permutation, also called an “arrangement number” or “order,” is a rearrangement of the elements of an ordered list S into a one-to-one correspondence with S itself. A string of length n has n! permutation. 

Source: Mathword(http://mathworld.wolfram.com/Permutation.html)

Below are the permutations of string ABC. 
ABC ACB BAC BCA CBA CAB
 
Here is a solution that is used as a basis in backtracking
     */
    class StringPermutation
    {
        /**
        * permutation function
        * @param str string to
        calculate permutation for
        * @param l starting index
        * @param r end index
        */
        private static void permute(String str,
                                    int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        /**
        * Swap Characters at position
        * @param a string value
        * @param i position 1
        * @param j position 2
        * @return swapped string
        */
        public static String swap(String a,
                                int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
        /*
         Note : The above solution prints duplicate permutations if there are repeating characters in input string. Please see below link for a solution that prints only distinct permutations even if there are duplicates in input.
        */
        static void permute_efficient(string s, string answer)
        {
            if (s.Length == 0)
            {
                Console.WriteLine(answer);
                return;
            }
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                string left_substr = s.Substring(0, i);
                string right_substr = s.Substring(i + 1);
                string rest = left_substr + right_substr;
                permute_efficient(rest, answer + ch);
            }

        }
        // Driver Code
        public static void Main()
        {
            String str = "aabac";
            int n = str.Length;
            permute_efficient(str, "");
            /*
             Output: 

ABC
ACB
BAC
BCA
CBA
CAB
            */
        }
    }
}
