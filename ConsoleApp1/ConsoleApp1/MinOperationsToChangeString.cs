﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Given two strings str1 and str2 and below operations that can performed on str1. Find minimum number of edits (operations) required to convert ‘str1’ into ‘str2’.
Like other typical Dynamic Programming(DP) problems, recomputations of same subproblems can be avoided by constructing a temporary array that stores results of subproblems.

Insert
Remove
Replace
All of the above operations are of equal cost.

Examples:

Input:   str1 = "geek", str2 = "gesek"
Output:  1
We can convert str1 into str2 by inserting a 's'.

Input:   str1 = "cat", str2 = "cut"
Output:  1
We can convert str1 into str2 by replacing 'a' with 'u'.

Input:   str1 = "sunday", str2 = "saturday"
Output:  3
Last three and first characters are same.  We basically
need to convert "un" to "atur".  This can be done using
below three operations. 
Replace 'n' with 'r', insert t, insert a
     */
    class MinOperationsToChangeString
    {
        static int min(int x, int y, int z)
        {
            if (x <= y && x <= z)
                return x;
            if (y <= x && y <= z)
                return y;
            else
                return z;
        }

        static int editDistDP(String str1, String str2, int m, int n)
        {
            // Create a table to store 
            // results of subproblems 
            int[,] dp = new int[m + 1, n + 1];

            // Fill d[][] in bottom up manner 
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    // If first string is empty, only option is to 
                    // insert all characters of second string 
                    if (i == 0)

                        // Min. operations = j 
                        dp[i, j] = j;

                    // If second string is empty, only option is to 
                    // remove all characters of second string 
                    else if (j == 0)

                        // Min. operations = i 
                        dp[i, j] = i;

                    // If last characters are same, ignore last char 
                    // and recur for remaining string 
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    // If the last character is different, consider all 
                    // possibilities and find the minimum 
                    else
                        dp[i, j] = 1 + min(dp[i, j - 1], // Insert 
                                           dp[i - 1, j], // Remove 
                                           dp[i - 1, j - 1]); // Replace 
                }
            }

            return dp[m, n];
        }

        // Driver code 
        public static void Main()
        {
            String str1 = "sunday";
            String str2 = "saturday";
            Console.Write(editDistDP(str1, str2, str1.Length,
                                     str2.Length));
        }
    }
}
