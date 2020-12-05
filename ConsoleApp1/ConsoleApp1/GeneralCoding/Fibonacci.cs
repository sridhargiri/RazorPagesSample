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
