using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     
     Ways to represent a number as a sum of 1’s and 2’s
    Given a positive integer N. The task is to find the number of ways of representing N as a sum of 1s and 2s.

Examples:

Input : N = 3
Output : 3
3 can be represented as (1+1+1), (2+1), (1+2).

Input : N = 5
Output : 8
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
For N = 1, answer is 1.
For N = 2. (1 + 1), (2), answer is 2.
For N = 3. (1 + 1 + 1), (2 + 1), (1 + 2), answer is 3.
For N = 4. (1 + 1 + 1 + 1), (2 + 1 + 1), (1 + 2 + 1), (1 + 1 + 2), (2 + 2) answer is 5.
And so on.

It can be observe that it form Fibonacci Series. So, the number of ways of representing N as a sum of 1s and 2s is (N + 1)th Fibonacci number.
How ?
We can easily see that the recursive function is exactly same as Fibonacci Numbers. To obtain the sum of N, we can add 1 to N – 1. Also, we can add 2 to N – 2. And only 1 and 2 are allowed to make the sum N. So, to obtain sum N using 1s and 2s, total ways are: number of ways to obtain (N – 1) + number of ways to obtain (N – 2).
    
     We can find N’th Fibonacci Number in O(Log n) time. Please refer method 5 of this post.
    https://www.geeksforgeeks.org/program-for-nth-fibonacci-number/


Below is the implementation of this approach:
    
     */
    class NumberRepresentation_1n2
    {

        // Function to multiply matrix. 
        static void multiply(int[,] F, int[,] M)
        {
            int x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            int y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            int z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            int w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;
        }

        // Power function in log n 
        static void power(int[,] F, int n)
        {
            if (n == 0 || n == 1)
            {
                return;
            }
            int[,] M = { { 1, 1 }, { 1, 0 } };

            power(F, n / 2);
            multiply(F, F);

            if (n % 2 != 0)
            {
                multiply(F, M);
            }
        }

        /* function that returns (n+1)th Fibonacci number 
        Or number of ways to represent n as sum of 1's 
        2's */
        static int countWays(int n)
        {
            int[,] F = { { 1, 1 }, { 1, 0 } };
            if (n == 0)
            {
                return 0;
            }
            power(F, n);
            return F[0, 0];
        }

        // Driver program 
        public static void Main()
        {
            int n = 5;
            System.Console.WriteLine(countWays(n));
        }
        //Output:
        //Time Complexity: O(logn).
        //8
    }
}
