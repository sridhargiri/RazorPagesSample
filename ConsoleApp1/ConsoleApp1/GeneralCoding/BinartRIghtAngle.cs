using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Program to print binary right angle triangle
Difficulty Level : Basic
 Last Updated : 14 Aug, 2018
Binary right angle triangle consists of only 0’s and 1’s in alternate positions.

Examples :

Input : 4
Output :
         0    
         1    0    
         0    1    0    
         1    0    1    0

Input : 3
Output : 
         0    
         1    0    
         0    1    0 
    */
    class BinartRIghtAngle
    {

        // function to print binary right  
        // angle triangle 
        static void binaryRightAngleTriangle(int n)
        {

            // declare row and column 
            int row, col;

            for (row = 0; row < n; row++)
            {
                for (col = 0; col <= row; col++)
                {
                    if (((row + col) % 2) == 0)
                        Console.Write("0");
                    else
                        Console.Write("1");

                    Console.Write("\t");
                }

                Console.WriteLine();
            }
        }
        /*
         output
        Output :

0    
1    0    
0    1    0    
1    0    1    0  
        *
        */

        /*
         Logic to print the given number pattern
1
10
101
1010
10101
https://codeforwin.org/2016/10/triangle-number-pattern-using-0-1-in-c-1.html
To print these type of patterns, the main thing you need to get is the loop formation to iterate over rows and columns. Before I discuss the logic to print the given number pattern. Have a close eye to the pattern. Below is the logic to print the given number pattern.

The pattern consists of total N number of rows (where N is the total number of rows to be printed). Therefore the loop formation to iterate through rows will be for(i=1; i<=N; i++).
Here each row contains exactly i number of columns (where i is the current row number). Hence the inner loop formation to iterate through each columns will be for(j=1; j<=i; j++).
Once you are done with the loop formation to iterate through rows and columns. You need to print the 0's and 1's. Notice that here for each odd columns 1 gets printed and for every even columns 0 gets printed. Hence you need to check a simple condition if(j % 2 == 1) before printing 1s or 0s.
Lets, now code it down.
        */

        static void binaryRightAngleTriangle_1(int n)
        {
            int i, j;
            for (i = 1; i <= n; i++)
            {
                for (j = i; j <= i; j++)
                {
                    if (j % 2 == 1)
                    {
                        Console.Write("1");
                    }
                    else Console.Write("0");
                }
                Console.WriteLine();
            }
        }
        public static void Main()
        {
            // no. of rows to be printed 
            int n = 4;

            binaryRightAngleTriangle(n);
        }
    }
}
