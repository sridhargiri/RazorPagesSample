using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/maximum-size-rectangle-binary-sub-matrix-1s/
    Maximum size rectangle binary sub-matrix with all 1s
Difficulty Level : Hard
Last Updated : 06 Nov, 2020
Given a binary matrix, find the maximum size rectangle binary-sub-matrix with all 1’s. 

Example: 

Input:
0 1 1 0
1 1 1 1
1 1 1 1
1 1 0 0
Output :
1 1 1 1
1 1 1 1
Explanation : 
The largest rectangle with only 1's is from 
(1, 0) to (2, 3) which is
1 1 1 1
1 1 1 1 

Input:
0 1 1
1 1 1
0 1 1      
Output:
1 1
1 1
1 1
Explanation : 
The largest rectangle with only 1's is from 
(0, 1) to (2, 2) which is
1 1
1 1
1 1

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
There is already an algorithm discussed a dynamic programming based solution for finding largest square with 1s. 

Approach: In this post an interesting method is discussed that uses largest rectangle under histogram as a subroutine. 
If the height of bars of the histogram is given then the largest area of the histogram can be found. This way in each row, the largest area of bars of the histogram can be found. To get the largest rectangle full of 1’s, update the next row with the previous row and find the largest area under the histogram, i.e. consider each 1’s as filled squares and 0’s with an empty square and consider each row as the base.

Illustration: 

Input :
0 1 1 0
1 1 1 1
1 1 1 1
1 1 0 0
Step 1: 
0 1 1 0  maximum area  = 2
Step 2:
row 1  1 2 2 1  area = 4, maximum area becomes 4
row 2  2 3 3 2  area = 8, maximum area becomes 8
row 3  3 4 0 0  area = 6, maximum area remains 8
Algorithm: 

https://www.geeksforgeeks.org/largest-rectangle-under-histogram/

Run a loop to traverse through the rows.
Now If the current row is not the first row then update the row as follows, if matrix[i][j] is not zero then matrix[i][j] = matrix[i-1][j] + matrix[i][j].
Find the maximum rectangular area under the histogram, consider the ith row as heights of bars of a histogram. 
        This can be calculated as given in this article Largest Rectangular Area in a Histogram
        https://www.geeksforgeeks.org/largest-rectangle-under-histogram/
Do the previous two steps for all rows and print the maximum area of all the rows.
Note: It is strongly recommended to refer this post first as most of the code taken from there. 

Implementation
    */
    class MaxBinarySubArray
    {
        // Finds the maximum area under the
        // histogram represented by histogram.
        // See below article for details.
        // https://
        // www.geeksforgeeks.org/largest-rectangle-under-histogram/
        public static int maxHist(int R, int C, int[] row)
        {
            // Create an empty stack. The stack
            // holds indexes of hist[] array.
            // The bars stored in stack are always
            // in increasing order of their heights.
            Stack<int> result = new Stack<int>();

            int top_val; // Top of stack

            int max_area = 0; // Initialize max area in
                              // current row (or histogram)

            int area = 0; // Initialize area with
                          // current top

            // Run through all bars of
            // given histogram (or row)
            int i = 0;
            while (i < C)
            {
                // If this bar is higher than the
                // bar on top stack, push it to stack
                if (result.Count == 0
                    || row[result.Peek()] <= row[i])
                {
                    result.Push(i++);
                }

                else
                {
                    // If this bar is lower than top
                    // of stack, then calculate area of
                    // rectangle with stack top as
                    // the smallest (or minimum height)
                    // bar. 'i' is 'right index' for
                    // the top and element before
                    // top in stack is 'left index'
                    top_val = row[result.Peek()];
                    result.Pop();
                    area = top_val * i;

                    if (result.Count > 0)
                    {
                        area
                            = top_val * (i - result.Peek() - 1);
                    }
                    max_area = Math.Max(area, max_area);
                }
            }

            // Now pop the remaining bars from
            // stack and calculate area with
            // every popped bar as the smallest bar
            while (result.Count > 0)
            {
                top_val = row[result.Peek()];
                result.Pop();
                area = top_val * i;
                if (result.Count > 0)
                {
                    area = top_val * (i - result.Peek() - 1);
                }

                max_area = Math.Max(area, max_area);
            }
            return max_area;
        }

        // Returns area of the largest
        // rectangle with all 1s in A[][]
        public static int maxRectangle(int R, int C, int[][] A)
        {
            // Calculate area for first row
            // and initialize it as result
            int result = maxHist(R, C, A[0]);

            // iterate over row to find
            // maximum rectangular area
            // considering each row as histogram
            for (int i = 1; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {

                    // if A[i][j] is 1 then
                    // add A[i -1][j]
                    if (A[i][j] == 1)
                    {
                        A[i][j] += A[i - 1][j];
                    }
                }

                // Update result if area with current
                // row (as last row of rectangle) is more
                result = Math.Max(result, maxHist(R, C, A[i]));
            }

            return result;
        }

        // Driver code
        public static void Main(string[] args)
        {
            int R = 4;
            int C = 4;

            int[][] A
                = new int[][] { new int[] { 0, 1, 1, 0 },
                            new int[] { 1, 1, 1, 1 },
                            new int[] { 1, 1, 1, 1 },
                            new int[] { 1, 1, 0, 0 } };
            Console.Write("Area of maximum rectangle is "
                          + maxRectangle(R, C, A));
            /*
             Output
Area of maximum rectangle is 8
Complexity Analysis:  

Time Complexity: O(R x C). 
Only one traversal of the matrix is required, so the time complexity is O(R X C)
Space Complexity: O(C). 
Stack is required to store the columns, so so space complexity is O(C)
            */
        }
    }
    /*
(Tekion) Maximum size square sub-matrix with all 1s
Difficulty Level : Medium
Last Updated : 18 Jul, 2019
Given a binary matrix, find out the maximum size square sub-matrix with all 1s.

For example, consider the below binary matrix.
maximum-size-square-sub-matrix-with-all-1s

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Algorithm:
Let the given binary matrix be M[R][C]. The idea of the algorithm is to construct an auxiliary size matrix S[][] in which each entry S[i][j] represents size of the square sub-matrix with all 1s including M[i][j] where M[i][j] is the rightmost and bottommost entry in sub-matrix.

1) Construct a sum matrix S[R][C] for the given M[R][C].
     a)    Copy first row and first columns as it is from M[][] to S[][]
     b)    For other entries, use following expressions to construct S[][]
         If M[i][j] is 1 then
            S[i][j] = min(S[i][j-1], S[i-1][j], S[i-1][j-1]) + 1
         Else //If M[i][j] is 0
    S[i][j] = 0
2) Find the maximum entry in S[R][C]
3) Using the value and coordinates of maximum entry in S[i], print
   sub-matrix of M[][]

   0  1  1  0  1
   1  1  0  1  0
   0  1  1  1  0
   1  1  1  1  0
   1  1  1  1  1
   0  0  0  0  0
For the given M[R][C] in above example, constructed S[R][C] would be:

   0  1  1  0  1
   1  1  0  1  0
   0  1  1  1  0
   1  1  2  2  0
   1  2  2  3  1
   0  0  0  0  0
The value of maximum entry in above matrix is 3 and coordinates of the entry are(4, 3). Using the maximum value and its coordinates, we can find out the required sub-matrix
        https://www.geeksforgeeks.org/maximum-size-sub-matrix-with-all-1s-in-a-binary-matrix/
    */
    public class MaxSubBinaryMatrix
    {
        // method for Maximum size square sub-matrix with all 1s
        static void printMaxSubSquare(int[,] M)
        {
            int i, j;
            //no of rows in M[,]
            int R = M.GetLength(0);
            //no of columns in M[,]
            int C = M.GetLength(1);
            int[,] S = new int[R, C];

            int max_of_s, max_i, max_j;

            /* Set first column of S[,]*/
            for (i = 0; i < R; i++)
                S[i, 0] = M[i, 0];

            /* Set first row of S[][]*/
            for (j = 0; j < C; j++)
                S[0, j] = M[0, j];

            /* Construct other entries of S[,]*/
            for (i = 1; i < R; i++)
            {
                for (j = 1; j < C; j++)
                {
                    if (M[i, j] == 1)
                        S[i, j] = Math.Min(S[i, j - 1],
                                Math.Min(S[i - 1, j], S[i - 1, j - 1])) + 1;
                    else
                        S[i, j] = 0;
                }
            }

            /* Find the maximum entry, and indexes of 
                maximum entry in S[,] */
            max_of_s = S[0, 0]; max_i = 0; max_j = 0;
            for (i = 0; i < R; i++)
            {
                for (j = 0; j < C; j++)
                {
                    if (max_of_s < S[i, j])
                    {
                        max_of_s = S[i, j];
                        max_i = i;
                        max_j = j;
                    }
                }
            }

            Console.WriteLine("Maximum size sub-matrix is: ");
            for (i = max_i; i > max_i - max_of_s; i--)
            {
                for (j = max_j; j > max_j - max_of_s; j--)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Driver program 
        public static void Main()
        {
            int[,] M = new int[6, 5]{{0, 1, 1, 0, 1},
                    {1, 1, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {1, 1, 1, 1, 0},
                    {1, 1, 1, 1, 1},
                    {0, 0, 0, 0, 0}};

            printMaxSubSquare(M);
            /*
             Output:
Maximum size sub-matrix is: 
1 1 1 
1 1 1 
1 1 1 
Time Complexity: O(m*n) where m is number of rows and n is number of columns in the given matrix.
Auxiliary Space: O(m*n) where m is number of rows and n is number of columns in the given matrix.
Algorithmic Paradigm: Dynamic Programming
            */
        }

    }
    /*
(Tekion) Space Optimized Solution: In order to compute an entry at any position in the matrix we only need the current row and the previous row
    */
    public class MaxSubBinaryMatrixOptimised
    {

        static int R = 6;
        static int C = 5;

        static void printMaxSubSquare(int[,] M)
        {
            int[,] S = new int[2, C];
            int Maxx = 0;

            // set all elements of S to 0 first
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    S[i, j] = 0;
                }
            }

            // Construct the entries
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {

                    // Compute the entrie at the current position
                    int Entrie = M[i, j];
                    if (Entrie != 0)
                    {
                        if (j != 0)
                        {
                            Entrie = 1 + Math.Min(S[1, j - 1], Math.Min(S[0, j - 1], S[1, j]));
                        }
                    }

                    // Save the last entrie and add the new one
                    S[0, j] = S[1, j];
                    S[1, j] = Entrie;

                    // Keep track of the max square length
                    Maxx = Math.Max(Maxx, Entrie);
                }
            }

            // Print the square
            Console.Write("Maximum size sub-matrix is: \n");
            for (int i = 0; i < Maxx; i++)
            {
                for (int j = 0; j < Maxx; j++)
                {
                    Console.Write("1 ");
                }
                Console.WriteLine();
            }
        }

        // Driver Code
        public static void Main(string[] args)
        {
            int[,] M = {{0, 1, 1, 0, 1},
                 {1, 1, 0, 1, 0},
                 {0, 1, 1, 1, 0},
                 {1, 1, 1, 1, 0},
                 {1, 1, 1, 1, 1},
                 {0, 0, 0, 0, 0}};

            printMaxSubSquare(M);
        }
    }
}
