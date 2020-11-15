using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     You are given coins of different denominations and a total amount of money amount. 
    Write a function to compute the fewest number of coins that you need to make up that amount. 
    If that amount of money cannot be made up by any combination of the coins, return -1.

You may assume that you have an infinite number of each kind of coin.

 

Example 1:

Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1
Example 2:

Input: coins = [2], amount = 3
Output: -1
Example 3:

Input: coins = [1], amount = 0
Output: 0
Example 4:

Input: coins = [1], amount = 1
Output: 1
Example 5:

Input: coins = [1], amount = 2
Output: 2
 

Constraints:

1 <= coins.length <= 12
1 <= coins[i] <= 231 - 1
0 <= amount <= 104

    Example:
You are given coins of different denominations and a total amount of money amount. 
    Write a function to compute the fewest number of coins that you need to make up that amount. 
    If that amount of money cannot be made up by any combination of the coins, return -1.
Example 1:
Input: coins = [1, 2, 5], amount = 11
Output: 3 
Explanation: 11 = 5 + 5 + 1
Example 2:
Input: coins = [2], amount = 3
Output: -1
Note:
You may assume that you have an infinite number of each kind of coin.
Algorithm:
1 This problem makes a case for applying dynamic programming. The bigger problem is represented by the minimum number of coins needed to construct the given amount. Say the value is given by a dp array whose index = amount given. In order to determine whether a given coin denomination goes into constructing the given amount, we subtract that coin denomination from the index (equal to given amount) to reuse the solution to a subproblem of finding how many coins needed to construct a sub-amount = amount — coins[j] denomination.
2 The dp array is initialized with amount + 1. This not only helps in evaluating number of coins with respect to Math.min values initially, but also serves as a check at the end of constructing the dp array. If the index = amount in dp array still corresponds to a value greater than amount then the given combination of denomination can not be used to construct the given amount hence can safely return -1, else can return the value stored in the dp array with index = amount to indicate the minimum number of coins needed.
Test:
1 Test with an amount that can not be constructed using the given denominations.
2 Test with an even amount and all odd denominations/ one odd denomination. Likewise an odd amount and all even denominations.

    Complexity Analysis:
Since we iterate through the loop of amount size and coins array size, therefore time complexity is T O(amt * coins). 
    Space complexity is given by S O(amt), the size of the dp array.


     */
    class MinCoinChange
    {
        public static int CoinChange(int[] coins, int amount)
        {
            //get size of dp array
            int max = amount + 1;
            //declare dp
            int[] dp = new int[max];
            Array.Fill(dp, max);
            //declare dp[0] to be 0
            dp[0] = 0;

            //iterate over from 1 to amount  and j from 0 to coins length
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
            //T(amt * coins) S O(amt) where amt is size of amount and coins is the size of coins array
        }
        public static void Main(string[] args)
        {
            int[] coins = { 9, 6, 5, 1 };
            //int[] coins = { 1, 2, 5 };
            int mincoins = CoinChange(coins, 11);
            Console.WriteLine(mincoins);
        }
    }
}
