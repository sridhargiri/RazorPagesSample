using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Given a number N, the task is to find the number of cards needed to make a House of Cards of N levels.
    Examples:

Input: N = 3
Output: 15
From the above image, it is clear that for the House of Cards for 3 levels 15 cards are needed

Input: N = 2
Output: 7
    Approach:

If we observe carefully, then a series will be formed as shown below in which i-th item denotes the number of triangular cards needed to make a pyramid of i levels:
2, 7, 15, 26, 40, 57, 77, 100, 126, 155………and so on.

The above series is a method of difference series where differences are in AP as 5, 8, 11, 14……. and so on.
Therefore nth term of the seris will be:
nth term = 2 + {5 + 8 + 11 +14 +.....(n-1) terms}
         = 2 + (n-1)*(2*5+(n-1-1)*3)/2
         = 2 + (n-1)*(10+(n-2)*3)/2
         = 2 + (n-1)*(10+3n-6)/2
         = 2 + (n-1)*(3n+4)/2
         = n*(3*n+1)/2;

     */

    class Cards
    {
        // Function to find number of cards needed 
        public static int noOfCards(int n)
        {
            return n * (3 * n + 1) / 2;
        }

        // Driver Code 
        public static void Main(String[] args)
        {
            int n = 3;
            Console.Write(noOfCards(n));
        }
    }

    // This code is contributed by 29AjayKumar 

}
