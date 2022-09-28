using System;
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
    /*
     https://www.geeksforgeeks.org/minimum-number-of-given-operations-required-to-convert-a-string-to-another-string/
    Minimum number of given operations required to convert a string to another string
    Given two strings S and T of equal length. Both strings contain only the characters ‘0’ and ‘1’. The task is to find the minimum number of operations to convert string S to T. There are 2 types of operations allowed on string S: 

Swap any two characters of the string.
Replace a ‘0’ with a ‘1’ or vice versa.
Examples: 

Input: S = “011”, T = “101” 
Output: 1 
Swap the first and second character.

Input: S = “010”, T = “101” 
Output: 2 
Swap the first and second character and replace the third character with ‘1’. 
    Approach: Find 2 values for the string S, the number of indices that have 0 but should be 1 and the number of indices that have 1 but should be 0. The result would be the maximum of these 2 values since we can use swaps on the minimum of these 2 values and the remaining unmatched characters can be inverted i.e. ‘0’ can be changed to ‘1’ and ‘1’ can be changed to ‘0’.

Below is the implementation of the above approach:

     */

    public class MinOperationsConvertString
    {

        // Function to return the minimum operations
        // of the given type required to convert
        // string s to string t
        static int minOperations(string s,
                                 string t, int n)
        {
            int ct0 = 0, ct1 = 0;
            for (int i = 0; i < n; i++)
            {

                // Characters are already equal
                if (s[i] == t[i])
                    continue;

                // Increment count of 0s
                if (s[i] == '0')
                    ct0++;

                // Increment count of 1s
                else
                    ct1++;
            }

            return Math.Max(ct0, ct1);
        }

        // Driver code
        public static void Main()
        {
            string s = "010", t = "101";
            int n = s.Length;
            Console.Write(minOperations(s, t, n));
            /*
             Output
2
Time Complexity: O(N)

Auxiliary Space: O(1) it is using constant space for variables


             */
        }
    }
}
