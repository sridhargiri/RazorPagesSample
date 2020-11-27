/*
 Count maximum elements of an array whose absolute difference does not exceed K
Given an array A and positive integer K. The task is to find maximum number elements for which the absolute difference of any of the pair does not exceed K.

Examples:

Input: A[] = {1, 26, 17, 12, 15, 2}, K = 5
Output: 3
There are maximum 3 values so that the absolute difference of each pair
does not exceed K(K=5) ie., {12, 15, 17}

Input: A[] = {1, 2, 5, 10, 8, 3}, K = 4
Output: 4
There are maximum 4 values so that the absolute difference of each pair
does not exceed K(K=4) ie., {1, 2, 3, 5}


1.Sort the given Array in ascending order.
2.Iterate from index i = 0 to n.
3.For every A[i] count how many values which are in range A[i] to A[i] + K ie., A[i]<= A[j] <= A[i]+K
4.Return Max Count


 */

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class CountMaximum
    {

        // Function to return the maximum elements  
        // in which absolute difference of any pair  
        // does not exceed K  
        static int maxCount(int[] A, int N, int K)
        {
            int maximum = 0;
            int i = 0, j = 0;
            int start = 0;
            int end = 0;

            // Sort the Given array  
            Array.Sort(A);

            // Find max elements  
            for (i = 0; i < N; i++)
            {

                // Count all elements which are in range  
                // A[i] to A[i] + K  
                while (j < N && A[j] <= A[i] + K)
                    j++;
                if (maximum < (j - i))
                {
                    maximum = (j - i);
                    start = i;
                    end = j;
                }
            }

            // Return the max count  
            return maximum;
        }

        // Driver code  
        public static void Main()
        {
            int[] A = { 1, 26, 17, 12, 15, 2 };
            int N = A.Length;
            int K = 5;
            Console.Write(maxCount(A, N, K));
        }
    }
}
