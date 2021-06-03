using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/count-of-numbers-in-range-where-first-digit-is-equal-to-last-digit-of-the-number/?ref=rp
     Count of Numbers in Range where first digit is equal to last digit of the number
Difficulty Level : Medium
Last Updated : 12 Apr, 2021
Given a range represented by two positive integers L and R. Find the count of numbers in the range where the first digit is equal to the last digit of the number.

Examples: 

Input : L = 2, R = 60
Output : 13
Explanation : Required numbers are 
2, 3, 4, 5, 6, 7, 8, 9, 11, 22, 33, 44 and 55

Input : L = 1, R = 1000
Output : 108
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Prerequisites: Digit DP
There can be two approaches to solve this type of problem, one can be a combinatorial solution and others can be a dynamic programming based solution. Below is a detailed approach to solving this problem using digit dynamic programming. 

Dynamic Programming Solution: Firstly, if we are able to count the required numbers up to R i.e. in the range [0, R], we can easily reach our answer in the range [L, R] by solving for from zero to R and then subtracting the answer we get after solving for from zero to L – 1. Now, we need to define the DP states. 

DP States:  



Since we can consider our number as a sequence of digits, one state is the position at which we are currently in. This position can have values from 0 to 18 if we are dealing with the numbers up to 1018. In each recursive call, we try to build the sequence from left to right by placing a digit from 0 to 9.
The second state is the firstD which defines the first digit of the number we are trying to build and can have values from 0 to 9.
The third state is the lastD which defines the last digit of the number we are trying to build and can have values from 0 to 9.
Another state is the boolean variable tight which tells the number we are trying to build has already become smaller than R so that in the upcoming recursive calls we can place any digit from 0 to 9. If the number has not become smaller, the maximum limit of digit we can place is digit at the current position in R.
In each recursive call, we set the last digit as the digit we placed in the last position, and we set the first digit as the first non-zero digit of the number. In the final recursive call, when we are at the last position if the first digit is equal to the last digit, return 1, otherwise 0.

Below is the implementation of the above approach
    */
    class FirstDigitLastDigit
    {
        static int M = 20;

        // states - position, first digit,
        // last digit, tight
        static int[,,,] dp = new int[M, M, M, 2];

        // This function returns the count of
        // required numbers from 0 to num
        static int count(int pos, int firstD,
                         int lastD, int tight,
                         List<int> num)
        {

            // Last position
            if (pos == num.Count)
            {

                // If first digit is equal to
                // last digit
                if (firstD == lastD)
                    return 1;
                return 0;
            }

            // If this result is already computed
            // simply return it
            if (dp[pos, firstD, lastD, tight] != -1)
                return dp[pos, firstD, lastD, tight];
            int ans = 0;

            // Maximum limit upto which we can place
            // digit. If tight is 1, means number has
            // already become smaller so we can place
            // any digit, otherwise num[pos]
            int limit = (tight == 1 ? 9 : num[pos]);

            for (int dig = 0; dig <= limit; dig++)
            {
                int currFirst = firstD;

                // If the position is 0, current
                // digit can be first digit
                if (pos == 0)
                    currFirst = dig;

                // In current call, if the first
                // digit is zero and current digit
                // is nonzero, update currFirst
                if (currFirst == 0 && dig != 0)
                    currFirst = dig;

                int currTight = tight;

                // At this position, number becomes
                // smaller
                if (dig < num[pos])
                    currTight = 1;

                // Next recursive call, set last
                // digit as dig
                ans += count(pos + 1, currFirst,
                             dig, currTight, num);
            }
            return dp[pos, firstD, lastD, tight] = ans;
        }

        // This function converts a number into its
        // digit vector and uses above function to
        // compute the answer
        static int solve(int x)
        {
            List<int> num = new List<int>();
            while (x > 0)
            {
                num.Add(x % 10);
                x /= 10;
            }

            num.Reverse();

            // Initialize dp
            for (int i = 0; i < M; i++)
                for (int j = 0; j < M; j++)
                    for (int k = 0; k < M; k++)
                        for (int l = 0; l < 2; l++)
                            dp[i, j, k, l] = -1;

            return count(0, 0, 0, 0, num);
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int L = 2, R = 60;
            Console.WriteLine(solve(R) - solve(L - 1));

            L = 1;
            R = 1000;
            Console.WriteLine(solve(R) - solve(L - 1));
            /*
             Output
13
108
Time Complexity : O(18 * 10 * 10 * 2 * 10), if we are dealing with the numbers upto 1018
            */
        }
    }
    /*
     Alternative approach:
We can also solve this problem by recursion, for every position we can fill any number which satisfies the given condition except for the first and last position because they will be paired together, and for this, we will use recursion and in every call just check if the first number is smaller or larger than the last number if it turns out to be greater than we will add 8 otherwise 9 and call for number / 10, once the number becomes smaller than 10 first and the last digit becomes same so return the number itself.

Below is the implementation of the above approach
    */
    class FirstDigitLastDigitSame
    {

        public static int solve(int x)
        {
            int ans = 0, first = 0,
                last, temp = x;

            // Base Case
            if (x < 10)
                return x;

            // Calculating the
            // last digit
            last = x % 10;

            // Calculating the
            // first digit
            while (x != 0)
            {
                first = x % 10;
                x /= 10;
            }

            if (first <= last)
                ans = 9 + temp / 10;
            else
                ans = 8 + temp / 10;

            return ans;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int L = 2, R = 60;
            Console.WriteLine(solve(R) -
                              solve(L - 1));

            L = 1; R = 1000;
            Console.WriteLine(solve(R) -
                              solve(L - 1));
            //Output
            //13
            //108
        }
    }
}
