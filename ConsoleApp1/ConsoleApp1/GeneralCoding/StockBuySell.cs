using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/maximum-profit-after-buying-and-selling-the-stocks-with-transaction-fees-set-2/
    Maximum profit after buying and selling the stocks with transaction fees | Set 2
Difficulty Level : Hard
Last Updated : 20 Jul, 2021
Given an array arr[] of positive integers representing prices of stocks and an integer transactionFee, the task is to find the maximum profit possible after buying and selling stocks any number of times and giving the transaction fee for each transaction.

Examples:

Input: arr[] = {6, 1, 7, 2, 8, 4}, transactionFee = 2
Output: 8
Explanation: 
A maximum profit of 8 can be obtained by two transactions.
Transaction 1: Buy at price 1 and sell at price 7. Profit = 7 – 1 – 2 = 4.
Transaction 2: Buy at price 2 and sell at price 8. Profit = 8 – 2 – 2 = 4.
Therefore, total profit = 4 + 4 = 8, which is the maximum possible.

Input: arr[] = {2, 7, 5, 9, 6, 4}, transactionFee = 1
Output: 7

Naive Approach: Refer to the previous post for the simplest approach to solve the problem.
Time Complexity: O(N2)
Auxiliary Space: O(1)

Efficient Approach: To optimize the above approach, the idea is to use Dynamic Programming. For each day, maintain the maximum profit, if stocks are bought on that day (buy) and the maximum profit if all stocks are sold on that day (sell). For each day, update buy and sell using the following relations:



buy = max(sell – arr[i], buy)
sell = max(buy +arr[i] – transactionFee, sell)

Below is the implementation of the above approach:
     */
    class StockBuySell
    {
        static int MaxProfit(int[] arr, int n, int transactionFee)
        {

            int buy = -arr[0];
            int sell = 0;

            // Traversing the stocks for
            // each day
            for (int i = 1; i < n; i++)
            {
                int temp = buy;

                // Update buy and sell
                buy = Math.Max(buy, sell - arr[i]);
                sell = Math.Max(sell, temp + arr[i] - transactionFee);
            }

            // Return the maximum profit
            return Math.Max(sell, buy);
        }
        public static void Main(string[] args)
        {
            int[] arr = { 6, 1, 7, 2, 8, 4 };
            int n = arr.Length;
            int transactionFee = 2;
            Console.WriteLine(MaxProfit(arr, n, transactionFee));
            /*
             Output:
8
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
