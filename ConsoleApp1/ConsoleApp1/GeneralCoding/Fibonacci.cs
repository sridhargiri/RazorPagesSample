using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Fibonacci
    {
        /*using recursion
         * 
         Time Complexity: T(n) = T(n-1) + T(n-2) which is exponential. 
We can observe that this implementation does a lot of repeated work (see the following recursion tree). So this is a bad implementation for nth Fibonacci number.
         


         The Fibonacci numbers are the numbers in the following integer sequence.
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ……..

In mathematical terms, the sequence Fn of Fibonacci numbers is defined by the recurrence relation 

Fn = Fn-1 + Fn-2
with seed values 

F0 = 0 and F1 = 1.
        Examples: 

Input  : n = 2
Output : 1

Input  : n = 9
Output : 34
        Write a function int fib(int n) that returns Fn. For example, if n = 0, then fib() should return 0. If n = 1, then it should return 1. For n > 1, it should return Fn-1 + Fn-2

For n = 9
Output:34
Following are different methods to get the nth Fibonacci number. 

Method 1 (Use recursion) 
A simple method that is a direct recursive implementation mathematical recurrence relation given above.
         */

        public static int Fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
        /*
         Method 2 (Use Dynamic Programming) 
We can avoid the repeated work done is method 1 by storing the Fibonacci numbers calculated so far. */

        static int fib_dynamic(int n)
        {

            // Declare an array to 
            // store Fibonacci numbers.
            // 1 extra to handle 
            // case, n = 0
            int[] f = new int[n + 2];
            int i;

            /* 0th and 1st number of the 
               series are 0 and 1 */
            f[0] = 0;
            f[1] = 1;

            for (i = 2; i <= n; i++)
            {
                /* Add the previous 2 numbers
                   in the series and store it */
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }

        /*sum of nth fibonacci numbers
         * Let S(N) represent the sum of the first N terms of Fibonacci Series. Now, in order to simply find S(N), calculate the (N + 2)th Fibonacci number and subtract 1 from the result. 
         * The Nth term of this series can be calculated by the formula
         Now the value of S(N) can be calculated by (FN + 2 – 1).

Therefore, the idea is to calculate the value of SN using the above formula:

Below is the implementation of the above approach:
        */
        public static void sumFib(int N)
        {
            // Apply the formula 
            long num = (long)Math.Round(
                Math.Pow((Math.Sqrt(5) + 1)
                             / 2.0,
                         N + 2) / Math.Sqrt(5));
            Console.WriteLine(num - 1);
        }
        /*
         Method 2 ( Use Dynamic Programming ) 
We can avoid the repeated work done is method 1 by storing the Fibonacci numbers calculated so far.
         */

        static int fib1(int n)
        {

            // Declare an array to  
            // store Fibonacci numbers. 
            // 1 extra to handle  
            // case, n = 0 
            int[] f = new int[n + 2];
            int i;

            /* 0th and 1st number of the  
               series are 0 and 1 */
            f[0] = 0;
            f[1] = 1;

            for (i = 2; i <= n; i++)
            {
                /* Add the previous 2 numbers 
                   in the series and store it */
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }
        /*
         Method 3 ( Space Optimized Method 2 ) 
We can optimize the space used in method 2 by storing the previous two numbers only because that is all we need to get the next Fibonacci number in series. 
         */

        static int Fib2(int n)
        {
            int a = 0, b = 1, c = 0;

            // To return the first Fibonacci number  
            if (n == 0) return a;

            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return b;
        }
    }
}
