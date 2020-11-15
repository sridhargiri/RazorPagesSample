using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Given a positive integer n, print the matrix filled with rectangle pattern as shown below:
a a a a a
a b b b a
a b c b a
a b b b a
a a a a a

where a = n, b = n – 1,c = n – 2 and so on.
 Examples:

Input : n = 4
Output :
4 4 4 4 4 4 4 
4 3 3 3 3 3 4 
4 3 2 2 2 3 4 
4 3 2 1 2 3 4 
4 3 2 2 2 3 4 
4 3 3 3 3 3 4 
4 4 4 4 4 4 4 

Input : n = 3
Output :
3 3 3 3 3 
3 2 2 2 3 
3 2 1 2 3 
3 2 2 2 3 
3 3 3 3 3 
    For the given n, the number of rows or columns to be printed will be 2*n – 1

     */
    class ConcentricRectangle
    {
        static void printPattern(int n)
        {
            int arraySize = n * 2 - 1;
            int[,] result = new int[arraySize, arraySize];

            // Fill the values  
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    result[i, j] = Math.Max(Math.Abs(i - arraySize / 2),
                                        Math.Abs(j - arraySize / 2)) + 1;
                }
            }

            // Print the array  
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Driver Code  
        public static void Main(String[] args)
        {
            int n = 4;

            printPattern(n);
        }
    }
}
