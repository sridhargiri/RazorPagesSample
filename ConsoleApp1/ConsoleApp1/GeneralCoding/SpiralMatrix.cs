using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/print-a-given-matrix-in-spiral-form/
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
            /* 
            k - starting row index
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
            /*
             Output
1 2 3 4 5 6 12 18 17 16 15 14 13 7 8 9 10 11 
Complexity Analysis: 

Time Complexity: O(m*n). 
To traverse the matrix O(m*n) time is required.
Space Complexity: O(1). 
No extra space is required.
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/spiral-pattern/
    Spiral Pattern
    Given a number N, the task is to print the following pattern:

Examples: 

Input : N = 4
Output : 4 4 4 4 4 4 4
         4 3 3 3 3 3 4
         4 3 2 2 2 3 4
         4 3 2 1 2 3 4
         4 3 2 2 2 3 4
         4 3 3 3 3 3 4
         4 4 4 4 4 4 4

Input : N = 2
Output : 2 2 2
         2 1 2
         2 2 2
    Approach 1:

The common observation is that the square thus formed will be of size (2*N-1)x(2*N-1). 
    Fill the first row and column, last row and column with N, and then gradually decrease N and fill the remaining rows and columns 
    similarly. Decrease N every time after filling 2 rows and 2 columns.
     */
    public class SpiralPattern
    {

        // Function to print the pattern
        static void PrintSpiral(int value)
        {

            // Declare a square matrix
            int row = 2 * value - 1;
            int column = 2 * value - 1;
            int[,] arr = new int[row, column];

            int i, j, k;

            for (k = 0; k < value; k++)
            {

                // store the first row
                // from 1st column to
                // last column
                j = k;
                while (j < column - k)
                {
                    arr[k, j] = value - k;
                    j++;
                }

                // store the last column
                // from top to bottom
                i = k + 1;
                while (i < row - k)
                {
                    arr[i, row - 1 - k] = value - k;
                    i++;
                }

                // store the last row
                // from last column
                // to 1st column
                j = column - k - 2;
                while (j >= k)
                {
                    arr[column - k - 1, j] = value - k;
                    j--;
                }

                // store the first column
                // from bottom to top
                i = row - k - 2;
                while (i > k)
                {
                    arr[i, k] = value - k;
                    i--;
                }
            }

            // print the pattern
            for (i = 0; i < row; i++)
            {
                for (j = 0; j < column; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        /*
         Approach 2: Starting the indexing from i = 1 and j = 1, it can be observed that every value of the required matrix will be max(abs(i – n), abs(j – n)) + 1.
        Time complexity is O(n^2) and Auxiliary space : O(1)
         */
        static void PrintSpiralPattern(int n)
        {

            // Calculating boundary size
            int size = 2 * n - 1;

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    // Printing the values
                    Console.Write(Math.Max(Math.Abs(i - n), Math.Abs(j - n)) + 1 + " ");
                }
                Console.WriteLine();
            }
        }
        // Driver code
        public static void Main()
        {
            int n = 5;
            PrintSpiral(n);
            /*
output
5 5 5 5 5 5 5 5 5 
5 4 4 4 4 4 4 4 5 
5 4 3 3 3 3 3 4 5 
5 4 3 2 2 2 3 4 5 
5 4 3 2 1 2 3 4 5 
5 4 3 2 2 2 3 4 5 
5 4 3 3 3 3 3 4 5 
5 4 4 4 4 4 4 4 5 
5 5 5 5 5 5 5 5 5
            */
        }
    }

}
