using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/check-if-all-the-diagonals-of-the-matrix-are-palindromic-or-not/
     Check if all the diagonals of the Matrix are palindromic or not
Last Updated : 07 Oct, 2021
Given a matrix mat[][] of dimensions N*M, the task is to check if all the diagonals of the matrix(from top-right to bottom-left) are palindromic or not. If found to be true, then print Yes. Otherwise, print No.

Examples:


Input: mat[][] = [[1, 0, 0, 0], [0, 1, 1, 1], [0, 1, 0, 1], [0, 1, 1, 0]]
Output: Yes
Explanation:
All the diagonals of the matrix mat[][] is given by:

{1}
{0, 0}
{0, 1, 0}
{0, 1, 1, 0}
{1, 0, 1}
{1, 1}
{0}
As all the above diagonals are palindromic. Therefore, print Yes.

Input: mat[][] = [[1, 0, 0, 0], [1, 1, 0, 1], [1, 0, 1, 1], [0, 1, 0, 1]]
Output: No

Approach: The given problem can be solved by performing the diagonal traversal of the matrix and for every diagonal traversal check if the elements are palindromic or not. If there exists any such diagonal which is not palindromic, then print Yes. Otherwise, print No.

Below is the implementation of the above approach: 
    */
    class DiagonalPalindrome
    {
        static string isbinaryMatrixPalindrome(int[,] mat)
        {

            // Traverse the matrix and check if
            // top right and bottom left elements
            // have same value
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = mat.GetLength(1); j > i; j--)
                {

                    // If top right element is not
                    // equal to the bottom left
                    // element return false
                    if (mat[i, j] != mat[j, i])
                    {
                        return "Np";
                    }
                }
            }

            return "Yes";
        }
        static void Main(string[] args)
        {
            int[,] mat = {
                { 1, 0, 0, 1, 1 },
                      { 0, 1, 0, 1, 0 },
                      { 0, 0, 1, 1, 1 },
                      { 1, 1, 1, 0, 1 },
                      { 1, 0, 1, 1, 0 }
            };
            Console.WriteLine(isbinaryMatrixPalindrome(mat));
            /*
             Output:
Yes
Time Complexity: O(N2)
Auxiliary Space: O(1)
            */
        }
    }
}
