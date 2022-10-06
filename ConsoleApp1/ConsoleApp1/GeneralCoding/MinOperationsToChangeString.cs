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
            /*
             Output 3
The time complexity of above solution is exponential. In worst case, we may end up doing O(3m) operations. The worst case happens when none of characters of two strings match. Below is a recursive call diagram for worst case. 
Auxiliary Space: O(1), because no extra space is utilized.
            */
        }
    }
    /*
     We can see that many subproblems are solved, again and again, for example, eD(2, 2) is called three times. Since same subproblems are called again, this problem has Overlapping Subproblems property. So Edit Distance problem has both properties (see this and this) of a dynamic programming problem. Like other typical Dynamic Programming(DP) problems, recomputations of same subproblems can be avoided by constructing a temporary array that stores results of subproblems
    */
    public class MinimumOperationsToConvertString
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
                    // If first string is empty, only option is
                    // to insert all characters of second string
                    if (i == 0)

                        // Min. operations = j
                        dp[i, j] = j;

                    // If second string is empty, only option is
                    // to remove all characters of second string
                    else if (j == 0)

                        // Min. operations = i
                        dp[i, j] = i;

                    // If last characters are same, ignore last
                    // char and recur for remaining string
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    // If the last character is different,
                    // consider all possibilities and find the
                    // minimum
                    else
                        dp[i, j] = 1
                                   + min(dp[i, j - 1], // Insert
                                         dp[i - 1, j], // Remove
                                         dp[i - 1,
                                            j - 1]); // Replace
                }
            }

            return dp[m, n];
        }
        /*
         Space Complex Solution: In the above-given method we require O(m x n) space. 
        This will not be suitable if the length of strings is greater than 2000 as it can only create 2D array of 2000 x 2000. 
        To fill a row in DP array we require only one row the upper row. 
        For example, if we are filling the i = 10 rows in DP array we require only values of 9th row. So we simply create a DP array of 2 x str1 length. This approach reduces the space complexity. Here is the C++ implementation of the above-mentioned problem
        */
        static void editDistDP_1(String str1, String str2, int m, int n)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;

            // Create a DP array to memoize result
            // of previous computations
            int[,] DP = new int[2, len1 + 1];


            // Base condition when second String
            // is empty then we remove all characters
            for (int i = 0; i <= len1; i++)
                DP[0, i] = i;

            // Start filling the DP
            // This loop run for every
            // character in second String
            for (int i = 1; i <= len2; i++)
            {

                // This loop compares the char from
                // second String with first String
                // characters
                for (int j = 0; j <= len1; j++)
                {

                    // if first String is empty then
                    // we have to perform add character
                    // operation to get second String
                    if (j == 0)
                        DP[i % 2, j] = i;

                    // if character from both String
                    // is same then we do not perform any
                    // operation . here i % 2 is for bound
                    // the row number.
                    else if (str1[j - 1] == str2[i - 1])
                    {
                        DP[i % 2, j] = DP[(i - 1) % 2, j - 1];
                    }

                    // if character from both String is
                    // not same then we take the minimum
                    // from three specified operation
                    else
                    {
                        DP[i % 2, j] = 1 + Math.Min(DP[(i - 1) % 2, j],
                                               Math.Min(DP[i % 2, j - 1],
                                                   DP[(i - 1) % 2, j - 1]));
                    }
                }
            }

            // after complete fill the DP array
            // if the len2 is even then we end
            // up in the 0th row else we end up
            // in the 1th row so we take len2 % 2
            // to get row
            Console.Write(DP[len2 % 2, len1] + "\n");
        }

        // Driver code
        public static void Main()
        {
            String str1 = "sunday";
            String str2 = "saturday";
            Console.Write(editDistDP(str1, str2, str1.Length, str2.Length));
            /*
             Output-3
Time Complexity: O(m x n) 
Auxiliary Space: O(m x n)
            */
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
