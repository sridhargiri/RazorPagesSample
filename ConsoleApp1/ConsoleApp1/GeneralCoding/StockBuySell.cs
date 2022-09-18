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
    /*
     https://www.geeksforgeeks.org/stock-buy-sell/
     Stock Buy Sell to Maximize Profit
    The cost of a stock on each day is given in an array, find the max profit that you can make by buying and selling in those days. 
    For example, if the given array is {100, 180, 260, 310, 40, 535, 695}, the maximum profit can earn by buying on day 0, selling on day 3. 
    Again, buy on day 4 and sell on day 6. If the given array of prices is sorted in decreasing order, then profit cannot be earned at all.
    Naive approach: A simple approach is to try buying the stocks and selling them on every single day when profitable and keep updating the maximum profit so far.

     */
    public class StocksBuyandSellMultipleTimes
    {

        // Function to return the maximum profit
        // that can be made after buying and
        // selling the given stocks
        static int maxProfit(int[] price, int start, int end)
        {

            // If the stocks can't be bought
            if (end <= start)
                return 0;

            // Initialise the profit
            int profit = 0;

            // The day at which the stock
            // must be bought
            for (int i = start; i < end; i++)
            {

                // The day at which the
                // stock must be sold
                for (int j = i + 1; j <= end; j++)
                {

                    // If buying the stock at ith day and
                    // selling it at jth day is profitable
                    if (price[j] > price[i])
                    {

                        // Update the current profit
                        int curr_profit = price[j] - price[i]
                                        + maxProfit(price, start, i - 1)
                                        + maxProfit(price, j + 1, end);

                        // Update the maximum profit so far
                        profit = Math.Max(profit, curr_profit);
                    }
                }
            }
            return profit;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] price = { 100, 180, 260, 310, 40, 535, 695 };
            //int[] price = { 4, 24, 2, 7, 8, 15, 6, 23, 1, 9 };
            int n = price.Length;

            Console.Write(maxProfit(price, 0, n - 1));
            /*
             Output
865
Time Complexity: O(n2)
Space Complexity: O(1)
            */
        }
        /*
https://www.geeksforgeeks.org/stock-buy-sell/
        Efficient approach: If we are allowed to buy and sell only once, then we can use the following algorithm. Maximum difference between two elements. Here we are allowed to buy and sell multiple times. 
Following is the algorithm for this problem.  

Find the local minima and store it as starting index. If not exists, return.
Find the local maxima. And store it as an ending index. If we reach the end, set the end as the ending index.
Update the solution (Increment count of buy-sell pairs)
Repeat the above steps if the end is not reached
        
         */
        class Interval
        {
            public int buy, sell;
        }
        public class StockBuySellOnlyOnce
        {
            // This function finds the buy sell 
            // schedule for maximum profit
            void stockBuySell(int[] price, int n)
            {
                // Prices must be given for at least two days
                if (n == 1)
                    return;

                int count = 0;

                // solution array
                List<Interval> sol = new List<Interval>();

                // Traverse through given price array
                int i = 0;
                while (i < n - 1)
                {
                    // Find Local Minima. Note that 
                    // the limit is (n-2) as we are
                    // comparing present element 
                    // to the next element.
                    while ((i < n - 1) && (price[i + 1] <= price[i]))
                        i++;

                    // If we reached the end, break 
                    // as no further solution possible
                    if (i == n - 1)
                        break;

                    Interval e = new Interval();
                    e.buy = i++;
                    // Store the index of minima

                    // Find Local Maxima. Note that 
                    // the limit is (n-1) as we are
                    // comparing to previous element
                    while ((i < n) && (price[i] >= price[i - 1]))
                        i++;

                    // Store the index of maxima
                    e.sell = i - 1;
                    sol.Add(e);

                    // Increment number of buy/sell
                    count++;
                }

                // print solution
                if (count == 0)
                    Console.WriteLine("There is no day when buying the stock "
                                    + "will make profit");
                else
                    for (int j = 0; j < count; j++)
                        Console.WriteLine("Buy on day: " + sol[j].buy
                                        + "     "
                                        + "Sell on day : " + sol[j].sell);

                return;
            }

            // Driver code
            public static void Main(String[] args)
            {
                StockBuySellOnlyOnce stock = new StockBuySellOnlyOnce();

                // stock prices on consecutive days
                int[] price = { 100, 180, 260, 310, 40, 535, 695 };
                int n = price.Length;

                // function call
                stock.stockBuySell(price, n);
                /*
                 Output
Buy on day: 0     Sell on day: 3
Buy on day: 4     Sell on day: 6
Time Complexity: The outer loop runs till I become n-1. The inner two loops increment the value of I in every iteration. So overall time complexity is O(n)
                */
            }
        }
    }
    /*
    Dinivi (Asked by Raja kannappan on 8th august 2022) 
    Given an array of stock prices, let’s say end of day stock prices of GOOG, we want to determine when we should buy and we should sell to get maximum profit. Remember that, we need to buy first before selling.

For example for this given input [ 4, 24, 2, 7, 8, 15, 6, 23, 1, 9 ], we need to buy at 2 (position 2) and sell at 23 (position 7) to get maximum profit of 21.

Write a method maxProfit, which given an array of stock prices, returns maximum profit, buy index and sell index for that particular input.
    */
    /*
     Valley Peak Approach:

In this approach, we just need to find the next greater element and subtract it from the current element so that the difference keeps increasing until we reach a minimum. If the sequence is a decreasing sequence, so the maximum profit possible is 0.

Implementation:
    */
    public class StockBuySellValleyPeak
    {

        static int maxProfit(int[] prices, int size)
        {

            // maxProfit adds up the difference
            // between adjacent elements if they 
            // are in increasing order
            int maxProfit = 0;

            // The loop starts from 1 as its 
            // comparing with the previous
            for (int i = 1; i < size; i++)
                if (prices[i] > prices[i - 1])
                    maxProfit += prices[i] - prices[i - 1];

            return maxProfit;
        }

        // Driver code
        public static void Main(string[] args)
        {

            // Stock prices on consecutive days
            int[] price = { 100, 180, 260, 310, 40, 535, 695 };
            int n = price.Length;

            // Function call
            Console.WriteLine(maxProfit(price, n));
            /*
             Output
865
Time Complexity: O(n)
Auxiliary Space: O(1)
            */
        }
    }
}
