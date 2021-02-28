using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AllSubstring
    {
        //O(n3) time

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
        public static void Main(string[] args)
        {
            string ss = "abcd";
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
                    Console.WriteLine(ss.Substring(j, i));
                }
            }
            subString(ss.ToCharArray());
        }
    }
}
