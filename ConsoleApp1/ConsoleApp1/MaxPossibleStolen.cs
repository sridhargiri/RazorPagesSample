/*
 Find maximum possible stolen value from houses
Last Updated: 20-03-2020
There are n houses build in a line, each of which contains some value in it. A thief is going to steal the maximal value of these houses, but he can’t steal in two adjacent houses because the owner of the stolen houses will tell his two neighbours left and right side. What is the maximum stolen value?

Examples:

Input: hval[] = {6, 7, 1, 3, 8, 2, 4}
Output: 19

Explanation: The thief will steal 6, 1, 8 and 4 from the house.

Input: hval[] = {5, 3, 4, 11, 2}
Output: 16

Explanation: Thief will steal 5 and 11
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Naive Approach: Given an array, the solution is to find the maximum sum subsequence where no two selected elements are adjacent. So the approach to the problem is a recursive solution. So there are two cases.

If an element is selected then the next element cannot be selected.
if an element is not selected then the next element can be selected.
So the recursive solution can easily be devised. The sub-problems can be stored thus reducing the complexity and converting the recursive solution to Dynamic programming problem


Algorithm:
Create an extra space dp, DP array to store the sub-problems.
Tackle some basic cases, if the length of the array is 0, print 0, if the length of the array is 1, print the first element, if the length of the array is 2, print maximum of two elements.
Update dp[0] as array[0] and dp[1] as maximum of array[0] and array[1]
Traverse the array from the second element to the end of array.
For every index, update dp[i] as maximum of dp[i-2] + array[i] and dp[i-1], this step defines the two cases, if an element is selected then the previous element cannot be selected and if an element is not selected then the previous element can be selected.
Print the value dp[n-1]
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MaxPossibleStolen
    {
        // Function to calculate the  
        // maximum stolen value 
        static int maxLoot(int[] hval, int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return hval[0];
            if (n == 2)
                return Math.Max(hval[0], hval[1]);

            // dp[i] represent the maximum value stolen 
            // so far after reaching house i. 
            int[] dp = new int[n];

            // Initialize the dp[0] and dp[1] 
            dp[0] = hval[0];
            dp[1] = Math.Max(hval[0], hval[1]);

            // Fill remaining positions 
            for (int i = 2; i < n; i++)
                dp[i] = Math.Max(hval[i] + dp[i - 2], dp[i - 1]);

            return dp[n - 1];
        }

        // Driver program 
        public static void Main()
        {
            int[] hval = { 6, 7, 1, 3, 8, 2, 4 };
            int n = hval.Length;
            Console.WriteLine("Maximum loot value : " +
                                     maxLoot(hval, n));
        }
    }
}

