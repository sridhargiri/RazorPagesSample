using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/program-to-print-hut/?ref=rp
    Program to print Hut
Difficulty Level : Expert
Last Updated : 03 Jan, 2019
Given a number N, the task is to print Hut of width n.


Output

Below is the code to implement the above problem:
     */
    class HutPattern
    {

        // Program to print the Hut
        public static void hut_pattern(int n)
        {
            int i, j, t;

            if (n % 2 == 0)
            {
                n++;
            }

            for (i = 0; i <= n - n / 3; i++)
            {

                for (j = 0; j < n; j++)
                {
                    t = 2 * n / 5;

                    if (t % 2 != 0)
                    {
                        t--;
                    }

                    if (i == n / 5 || i == n - n / 3 ||
                       (j == n - 1 && i >= n / 5) ||
                       (j >= n / 5 && j < n - n / 5 && i == 0) ||
                       (j == 0 && i >= n / 5) ||
                       (j == t && i > n / 5) ||
                       (i <= n / 5 && (i + j == n / 5 ||
                                       j - i == n / 5)) ||
                       (j - i == n - n / 5))
                    {

                        Console.Write("*");
                    }

                    else if (i == n / 5 + n / 7 &&
                            (j >= n / 7 && j <= t - n / 7))
                    {
                        Console.Write("_");
                    }

                    else if (i >= n / 5 + n / 7 &&
                            (j == n / 7 || j == t - n / 7))
                    {
                        Console.Write("|");
                    }

                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }

        // Driver Code
        static void Main()
        {
            // Get the width of the Hut in n 
            int n = 20;

            // Print the Hut 
            hut_pattern(n);
            /*
             Output:
   **********  
  * *        * 
 *   *        *
***************
*     *       *
* ___ *       *
* | | *       *
* | | *       *
* | | *       *
* | | *       *
***************
*/
        }
    }
}
