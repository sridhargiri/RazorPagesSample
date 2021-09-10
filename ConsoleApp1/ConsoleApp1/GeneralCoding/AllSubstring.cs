using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AllSubstring
    {
        //O(n3) time
        //https://www.geeksforgeeks.org/program-print-substrings-given-string/
        // Function to print all sub strings
        static void subString(char[] str)
        {
            int n = str.Length;
            // Pick starting point
            for (int len = 1; len <= n; len++)
            {
                // Pick ending point
                for (int i = 0; i <= n - len; i++)
                {
                    //  Print characters from current
                    // starting point to current ending
                    // point.  
                    int j = i + len - 1;
                    for (int k = i; k <= j; k++)
                        Console.Write(str[k]);

                    Console.WriteLine();
                }
            }
        }
        /*
         Finding all subsets of a given set in Java

Problem: Find all the subsets of a given set.

Input: 
S = {a, b, c, d}
Output:
{}, {a} , {b}, {c}, {d}, {a,b}, {a,c},
{a,d}, {b,c}, {b,d}, {c,d}, {a,b,c}, 
{a,b,d}, {a,c,d}, {b,c,d}, {a,b,c,d}
The total number of subsets of any given set is equal to 2^ (no. of elements in the set). If we carefully notice it is nothing but binary numbers from 0 to 15 which can be shown as below:

0000	{}
0001	{a}
0010	{b}
0011	{a, b}
0100	{c}
0101	{a, c}
0110	{b, c}
0111	{a, b, c}
1000	{d}
1001	{a, d}
1010	{b, d}
1011	{a, b, d}
1100	{c, d}
1101	{a, c, d}
1110	{b, c, d}
1111	{a, b, c, d}
Starting from right, 1 at ith position shows that the ith element of the set is present as 0 shows that the element is absent. Therefore, what we have to do is just generate the binary numbers from 0 to 2^n – 1, where n is the length of the set or the numbers of elements in the set.
        */
        static void printAllSubstring(string stringinput)
        {
            char[] set = stringinput.ToCharArray();
            int n = set.Length;

            // Run a loop for printing all 2^n 
            // subsets one by one 
            for (int i = 0; i < (1 << n); i++)
            {
                Console.WriteLine("{ ");

                // Print current subset 
                for (int j = 0; j < n; j++)

                    // (1<<j) is a number with jth bit 1 
                    // so when we 'and' them with the 
                    // subset number we get which numbers 
                    // are present in the subset and which 
                    // are not 
                    if ((i & (1 << j)) > 0)
                        Console.WriteLine(set[j] + " ");

                Console.WriteLine("}");
            }
        }
        static Boolean CheckEvenCharCount(String s)
        {

            // creating a frequency array
            int[] freq = new int[26];

            // Finding length of s
            int n = s.Length;

            // counting frequency of all characters
            for (int i = 0; i < s.Length; i++)
            {
                freq[s[i] - 97] += 1;
            }

            // checking if any odd frequency
            // is there or not
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] % 2 == 1)
                {
                    return false;
                }
            }
            return true;
        }
        public static void Main(string[] args)
        {
            string ss = "abbaa";
            //for (int i = 0; i < ss.Length; i++)
            //{
            //    for (int j = 1; j <= ss.Length - i; j++)
            //    {
            //        Console.WriteLine(ss.Substring(i, j));
            //    }
            //}
            for (int i = 1; i <= ss.Length; i++)
            {
                for (int j = 0; j <= ss.Length - i; j++)
                {
                    string temp = ss.Substring(j, i);
                    Console.WriteLine(temp);
                    if (CheckEvenCharCount(temp))
                        Console.WriteLine("has even frequency");
                }
            }
            //subString(ss.ToCharArray());
        }
    }
    /*
     https://www.geeksforgeeks.org/check-string-substring-another/?ref=leftbar-rightbar
    Check if a string is substring of another
Difficulty Level : Medium
Last Updated : 22 Jul, 2021
Given two strings s1 and s2, find if s1 is a substring of s2. If yes, return the index of the first occurrence, else return -1.

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
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Simple Approach: The idea is to run a loop from start to end and for every index in the given string check whether the sub-string can be formed from that index. This can be done by running a nested loop traversing the given string and in that loop run another loop checking for sub-string from every index. 
For example, consider there to be a string of length N and a substring of length M. Then run a nested loop, where the outer loop runs from 0 to (N-M) and the inner loop from 0 to M. For very index check if the sub-string traversed by the inner loop is the given sub-string or not. 

     */
    public class IfSubstring
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
        /*
         Another Efficient Solution: 

An efficient solution would need only one traversal i.e. O(n) on the longer string s1. Here we will start traversing the string s1 and maintain a pointer for string s2 from 0th index.
For each iteration we compare the current character in s1 and check it with the pointer at s2.
If they match we increment the pointer on s2 by 1. And for every mismatch we set the pointer back to 0.
Also keep a check when the s2 pointer value is equal to the length of string s2, if true we break and return the value (pointer of string s1 – pointer of string s2)
Works with strings containing duplicate characters.
        */
        int Substr(string s2, string s1)
        {
            int counter = 0; // pointing s2
            int i = 0;
            for (; i < s1.Length; i++)
            {
                if (counter == s2.Length)
                    break;
                if (s2[counter] == s1[i])
                {
                    counter++;
                }
                else
                {
                    // Special case where character preceding the i'th character is duplicate
                    if (counter > 0)
                    {
                        i -= counter;
                    }
                    counter = 0;
                }
            }
            return counter < s2.Length ? -1 : i - counter;
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
                Console.Write("Present at index " + res);
            /*
             Output
Present at index 5
Complexity Analysis: 
Time complexity: O(m * n) where m and n are lengths of s1 and s2 respectively. 
A nested loop is used the outer loop runs from 0 to N-M and inner loop from 0 to M so the complexity is O(m*n).
Space Complexity: O(1). 
As no extra space is required.
            */
        }
    }
}
