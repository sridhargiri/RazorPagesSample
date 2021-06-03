using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/calculate-money-placed-in-boxes-after-n-days-based-on-given-conditions/
     Calculate money placed in boxes after N days based on given conditions
Last Updated : 19 May, 2021
Given 7 empty boxes b1, b2, b3, b4, b5, b6, b7 and an integer N, the task is to find the total amount of money that can be placed in the boxes after N days based on the following conditions:

Each day, the money can be put only in one box in circular fashion b1, b2, b3, b4, b5, b6, b7, b1, b2, ….. and so on.
In the box b1, put 1 more than the money already present in the box b1.
In each box except b1, put 1 more than the money present in the previous box.
Examples:

Input: N = 4
Output: 15
Explanation:
Putting money in the box b1 on day 1 = 1
Putting money in the box b2 on day 2 = 2
Putting money in the box b3 on day 3 = 3
Putting money in the box b4 on day 4 = 4
Putting money in the box b5 on day 5 = 5
After the 5th day, total amount = 1 + 2 + 3 + 4 + 5 = 15

Input: N = 15
Output: 66
Explanation: After the 15th day, the total amount = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 3 = 66
Approach: Follow the steps below to solve the problem



The money spent on ith day is ((i – 1)/ 7) + ((i – 1) % 7 + 1), where i lies in the range [1, N]
Simulate the same for days [1, N]
Print the total cost.
Below is the implementation of the above approach:
    */
    class MoneyBox
    {

        // Function to find the total money
        // placed in boxes after N days
        public static int totalMoney(int N)
        {

            // Stores the total money
            int ans = 0;

            // Iterate for N days
            for (int i = 0; i < N; i++)
            {

                // Adding the Week number
                ans += i / 7;

                // Adding previous amount + 1
                ans += i % 7 + 1;
            }

            // Return the total amount
            return ans;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(totalMoney(15));
            /*
             Output:
66
Time Complexity: O(N)
Auxilary Space: O(1)
            */
        }
    }
    /*
     Efficient Approach: The above approach can be optimized by finding out the number of completed weeks and the number of days remaining in the last week. 

Follow the steps to solve the problem:

Initialize variables X and Y, to store the amount of money that can be placed in the complete weeks and partial weeks respectively.
The money in each week can be calculated as:
1st  Week: 1 2 3 4 5 6 7 = 28 + (7 x 0)
2nd  Week: 2 3 4 5 6 7 8 = 28 + (7 x 1)
3rd  Week: 3 4 5 6 7 8 9 = 28 + (7 x 2)
4th  Week: 4 5 6 7 8 9 10 = 28 + (7 x 3) and so on.
Therefore, update:
X = 28 + 7 x (Number of completed weeks – 1)
Y = Sum of remaining days + ( Number of complete weeks * Number of days remaining in the last week)
Therefore, total amount is equal to X + Y. Print the total amount placed.
Below is the implementation of the above approach
    */
    class MoneyBox_Another
    {
        // Function to find total
        // money placed in the box
        static int totalMoney(int N)
        {
            // Number of complete weeks
            int CompWeeks = N / 7;

            // Remaining days in
            // the last week
            int RemDays = N % 7;

            int X = 28 * CompWeeks
                    + 7 * (CompWeeks
                           * (CompWeeks - 1) / 2);

            int Y = RemDays
                        * (RemDays + 1) / 2
                    + CompWeeks * RemDays;

            int cost = X + Y;

            return cost;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(totalMoney(15));
            /*
             Output:
66
Time Complexity: O(1)
Auxiliary Space: O(1)
            */
        }
    }
}
