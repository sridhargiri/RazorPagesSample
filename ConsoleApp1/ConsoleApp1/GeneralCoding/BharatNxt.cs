using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     Skillenza question for BharatNxt (Fintech company)

    Max Stocks
In a stock market, there is a product with its infinite stocks. The stock prices are given for N days, where arr[i] denotes the price of the stock on the ith day. 
    There is a rule that a customer can buy at most i stock on an ith day. 
    If the customer has k amount of money initially, find out the maximum number of stocks a customer can buy.

For example, for 3 days the price of a stock is given as 7, 10, 4. 
    You can buy 1 stock worth 7 rs on day 1, 2 stocks worth 10 rs each on day 2 and 3 stock worth 4 rs each on day 3.


Sample Input :

price[] = { 10, 7, 19 }, 
k = 45.
Sample Output :4


A customer purchases 1 stock on day 1 for 10 rs, 2 stocks on day 2 for 7rs each, and 1 stock on day 3 for 19 rs. 
    Therefore, a total of 10, 7 * 2 = 14 and 19 respectively. Hence, the total amount is 10 + 14 + 19 = 43 and the number of stocks purchased is 4.

stdin
9 70
35 85 59 42 17 46 52 11 42 

stdout
6

    https://www.geeksforgeeks.org/buy-maximum-stocks-stocks-can-bought-th-day/
    Buy Maximum Stocks if i stocks can be bought on i-th day

    In a stock market, there is a product with its infinite stocks. The stock prices are given for N days, where arr[i] denotes the price of the stock on the ith day. There is a rule that a customer can buy at most i stock on the ith day. If the customer has k amount of money initially, find out the maximum number of stocks a customer can buy. 

For example, for 3 days the price of a stock is given as 7, 10, 4. You can buy 1 stock worth 7 rs on day 1, 2 stocks worth 10 rs each on day 2 and 3 stock worth 4 rs each on day 3.

Examples: 

Input : price[] = { 10, 7, 19 }, 
              k = 45.
Output : 4
A customer purchases 1 stock on day 1 for 10 rs, 
2 stocks on day 2 for 7 rs each and 1 stock on day 3 for 19 rs.Therefore total of
10, 7 * 2 = 14 and 19 respectively. Hence, 
total amount is 10 + 14 + 19 = 43 and number 
of stocks purchased is 4.

Input  : price[] = { 7, 10, 4 }, 
               k = 100.
Output : 6

    The idea is to use greedy approach, where we should start buying product from the day when the stock price is least and so on. 
So, we will sort the pair of two values i.e { stock price, day } according to the stock price, and if stock prices are same, then we sort according to the day. 
Now, we will traverse along the sorted list of pairs, and start buying as follows: 
Let say, we have R rs remaining till now, and the cost of product on this day be C, and we can buy atmost L products on this day then, 
total purchase on this day (P) = min(L, R/C) 
Now, add this value to the answer 
total_purchase = total_purchase + P, where P =min(L, R/C) 
Now, subtract the cost of buying P items from remaining money, R = R – P*C. 
Total number of products that we can buy is equal to total_purchase.

    Implementation
     */
    public class BharatNxt
    {

        // Driver code
        static void Main(string[] args)
        {

            int[] price = { 35, 85, 59, 42, 17, 46, 52, 11, 42 };
            int K = 70;

            // int []price = { 7, 10, 4 };
            // int K = 100;
            Console.WriteLine(
              buyMaximumProducts(price, K, price.Length));
        }

        // Helper class
        class Pair : IComparable<Pair>
        {

            public int first, second;

            public Pair(int first, int second)
            {
                this.first = first;
                this.second = second;
            }

            // For Sorting using Pair.first value
            public int CompareTo(Pair other)
            {
                return this.first - other.first;
            }
        }

        // Return the maximum stocks
        static int buyMaximumProducts(int[] price, int K, int n)
        {

            Pair[] arr = new Pair[n];

            // Making pair of product cost and number of day..
            for (int i = 0; i < n; i++)
                arr[i] = new Pair(price[i], i + 1);

            // Sorting the pair array.
            Array.Sort(arr);

            // Calculating the maximum number of stock count.
            int ans = 0;
            for (int i = 0; i < n; i++)
            {

                ans += Math.Min(arr[i].second,  K / arr[i].first);

                K -= arr[i].first
                  * Math.Min(arr[i].second,
                             K / arr[i].first);
            }

            return ans;
        }
    }
}
