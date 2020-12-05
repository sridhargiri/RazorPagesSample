using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find the row with maximum number of 1s
Given a boolean 2D array, where each row is sorted. Find the row with the maximum number of 1s.
Example:

Input matrix
0 1 1 1
0 0 1 1
1 1 1 1  // this row has maximum 1s
0 0 0 0

Output: 2
A simple method is to do a row wise traversal of the matrix, count the number of 1s in each row and compare the count with max. Finally, return the index of row with maximum 1s. The time complexity of this method is O(m*n) where m is number of rows and n is number of columns in matrix.

We can do better. Since each row is sorted, we can use Binary Search to count of 1s in each row. We find the index of first instance of 1 in each row. The count of 1s will be equal to total number of columns minus the index of first 1.

See the following code for implementation of the above approach.
     */
    class MaximumNumberOfOnes
    {
        public static int R = 4, C = 4;

        // Function to find the index of first index  
        // of 1 in a boolean array arr[]  
        public static int first(int[] arr,
                                int low, int high)
        {
            if (high >= low)
            {
                // Get the middle index  
                int mid = low + (high - low) / 2;

                // Check if the element at middle  
                // index is first 1  
                if ((mid == 0 || (arr[mid - 1] == 0)) &&
                                  arr[mid] == 1)
                {
                    return mid;
                }

                // If the element is 0, recur  
                // for right side  
                else if (arr[mid] == 0)
                {
                    return first(arr, (mid + 1), high);
                }

                // If element is not first 1, recur 
                // for left side  
                else
                {
                    return first(arr, low, (mid - 1));
                }
            }
            return -1;
        }

        // Function that returns index of row  
        // with maximum number of 1s.  
        public static int rowWithMax1s(int[][] mat)
        {
            // Initialize max values  
            int max_row_index = 0, max = -1;

            // Traverse for each row and count number   
            // of 1s by finding the index of first 1  
            int i, index;
            for (i = 0; i < R; i++)
            {
                index = first(mat[i], 0, C - 1);
                if (index != -1 && C - index > max)
                {
                    max = C - index;
                    max_row_index = i;
                }
            }

            return max_row_index;
        }
        // The main function that returns index of row with maximum number of 1s. 
        int rowWithMax1s_Optimise(int[][] mat)
        {
            // Initialize first row as row with max 1s 
            int max_row_index = 0;

            // The function first() returns index of first 1 in row 0. 
            // Use this index to initialize the index of leftmost 1 seen so far 
            int j = first(mat[0], 0, C - 1);
            if (j == -1) // if 1 is not present in first row 
                j = C - 1;

            for (int i = 1; i < R; i++)
            {
                // Move left until a 0 is found 
                while (j >= 0 && mat[i][j] == 1)
                {
                    j = j - 1;  // Update the index of leftmost 1 seen so far 
                    max_row_index = i;  // Update max_row_index 
                }
            }
            return max_row_index;
        }
        // Driver Code  
        public static void Main(string[] args)
        {
            int[][] mat = new int[][]
            {
        new int[] {0, 0, 0, 1},
        new int[] {0, 1, 1, 1},
        new int[] {1, 1, 1, 1},
        new int[] {0, 0, 0, 0}
            };
            Console.WriteLine("Index of row with maximum 1s is " +
                                               rowWithMax1s(mat));
        }
    }
}
