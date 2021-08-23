using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //https://www.geeksforgeeks.org/boundary-elements-matrix/
    class ArrayBorderPrint
    {
        /*
         Boundary elements of a Matrix
Difficulty Level : Basic
Last Updated : 06 Jul, 2021
Printing Boundary Elements of a Matrix.

Given a matrix of size n x m. Print the boundary elements of the matrix. Boundary elements are those elements which are not surrounded by elements on all four directions, i.e. elements in first row, first column, last row and last column. 

Examples: 

Input :
        1 2 3 4  
        5 6 7 8
        1 2 3 4
        5 6 7 8
Output : 
         1 2 3 4 
         5     8 
         1     4 
         5 6 7 8
Explanation:The boundary elements of the
matrix is printed.

Input:
        1 2 3   
        5 6 7 
        1 2 3 
Output: 
        1 2 3   
        5   7 
        1 2 3 
Explanation:The boundary elements of the 
matrix is printed.
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
Approach: The idea is simple. Traverse the matrix and check for every element if that element lies on the boundary or not, if yes then print the element else print space character. 

Algorithm : 
Traverse the array from start to end.
Assign the outer loop to point the row and the inner row to traverse the elements of row.
If the element lies in the boundary of matrix, then print the element, i.e. if the element lies in 1st row, 1st column, last row, last column
If the element is not boundary element print a blank space.
Implementation:
        */
        public static void printBoundary(int[,] a,
                                         int m,
                                         int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                        Console.Write(a[i, j] + " ");
                    else if (i == m - 1)
                        Console.Write(a[i, j] + " ");
                    else if (j == 0)
                        Console.Write(a[i, j] + " ");
                    else if (j == n - 1)
                        Console.Write(a[i, j] + " ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine(" ");
            }
        }

        // Driver Code
        static public void Main()
        {
            int[,] a = { { 1, 2, 3, 4 },
                      { 5, 6, 7, 8 },
                      { 1, 2, 3, 4 },
                      { 5, 6, 7, 8 } };

            printBoundary(a, 4, 4);
            /*
             output
1 2 3 4 
5     8 
1     4 
5 6 7 8
Complexity Analysis: 
Time Complexity: O(n*n), where n is the size of array. 
This is achieved by single traversal of the matrix.
Space Complexity: O(1). 
Since a constant space is needed.
            */
        }
    }
    /*
     Finding sum of boundary elements

Given an matrix of size n x m. Find the sum of boundary elements of the matrix. Boundary elements are those elements which is not surrounded by elements on all four directions, i.e. elements in first row, first column, last row and last column. 

Examples:  

Input :
        1 2 3 4  
        5 6 7 8
        1 2 3 4
        5 6 7 8
Output : 54
Explanation:The boundary elements of the matrix 
         1 2 3 4 
         5     8 
         1     4 
         5 6 7 8
Sum = 1+2+3+4+5+8+1+4+5+6+7+8 =54

Input :
        1 2 3   
        5 6 7 
        1 2 3 
Output : 24
Explanation:The boundary elements of the matrix
        1 2 3   
        5   7 
        1 2 3  
Sum = 1+2+3+5+7+1+2+3 = 24
Approach: The idea is simple. Traverse the matrix and check for every element if that element lies on the boundary or not, if yes then add them to get the sum of all the boundary elements. 

Algorithm : 
Create a variable to store the sum and Traverse the array from start to end.
Assign the outer loop to point the row and the inner row to traverse the elements of row.
If the element lies in the boundary of matrix then add th element to the sum, i.e. if the element lies in 1st row, 1st column, last row, last column
print the sum.
Implementation:
    */
    public class ArrayBorderSum
    {
        public static long getBoundarySum(int[,] a,
                                          int m, int n)
        {
            long sum = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                        sum += a[i, j];
                    else if (i == m - 1)
                        sum += a[i, j];
                    else if (j == 0)
                        sum += a[i, j];
                    else if (j == n - 1)
                        sum += a[i, j];
                }
            }
            return sum;
        }

        // Driver Code
        static public void Main()
        {
            int[,] a = { { 1, 2, 3, 4 },
                      { 5, 6, 7, 8 },
                      { 1, 2, 3, 4 },
                      { 5, 6, 7, 8 } };
            long sum = getBoundarySum(a, 4, 4);
            Console.WriteLine("Sum of boundary"
                              + " elements is " + sum);
            /*
             output: 

Sum of boundary elements is 54
Complexity Analysis: 
Time Complexity: O(n*n), where n is the size of the array. 
This is achieved by single traversal of the matrix.
Space Complexity: O(1). 
Since a constant space is needed.
            */
        }
    }
}
