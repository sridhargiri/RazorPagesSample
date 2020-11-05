using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Algorithm: 
Create and initialize variables k – starting row index, m – ending row index, l – starting column index, n – ending column index
Run a loop until all the squares of loops are printed.
In each outer loop traversal print the elements of a square in a clockwise manner.
Print the top row, i.e. Print the elements of the kth row from column index l to n, and increase the count of k.
Print the right column, i.e. Print the last column or n-1th column from row index k to m and decrease the count of n.
Print the bottom row, i.e. if k < m, then print the elements of m-1th row from column n-1 to l and decrease the count of m
Print the left column, i.e. if l < n, then print the elements of lth column from m-1th row to k and increase the count of l.


     */
    public class SpiralMatrix
    {
        // Function print matrix in spiral form
        static void spiralPrint(int m, int n, int[,] a)
        {
            int i, k = 0, l = 0;
            /* k - starting row index
            m - ending row index
            l - starting column index
            n - ending column index
            i - iterator
            */

            while (k < m && l < n)
            {
                // Print the first row
                // from the remaining rows
                for (i = l; i < n; ++i)
                {
                    Console.Write(a[k, i] + " ");
                }
                k++;

                // Print the last column from the
                // remaining columns
                for (i = k; i < m; ++i)
                {
                    Console.Write(a[i, n - 1] + " ");
                }
                n--;

                // Print the last row from
                // the remaining rows
                if (k < m)
                {
                    for (i = n - 1; i >= l; --i)
                    {
                        Console.Write(a[m - 1, i] + " ");
                    }
                    m--;
                }

                // Print the first column from
                // the remaining columns
                if (l < n)
                {
                    for (i = m - 1; i >= k; --i)
                    {
                        Console.Write(a[i, l] + " ");
                    }
                    l++;
                }
            }
        }

        // Driver Code
        public static void Main()
        {
            int R = 3;
            int C = 6;
            int[,] a = { { 1, 2, 3, 4, 5, 6 },
                      { 7, 8, 9, 10, 11, 12 },
                      { 13, 14, 15, 16, 17, 18 } };

            // Function Call
            spiralPrint(R, C, a);
        }
    }
}
