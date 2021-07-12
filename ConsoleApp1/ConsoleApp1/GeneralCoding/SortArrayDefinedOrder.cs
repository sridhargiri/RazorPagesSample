using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Sort an array according to the order defined by another array
    https://www.geeksforgeeks.org/sort-array-according-order-defined-another-array/
    Given two arrays A1[] and A2[], sort A1 in such a way that the relative order among the elements will be same as those are in A2. For the elements not present in A2, append them at last in sorted order. 
Example: 

Input: A1[] = {2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8}
       A2[] = {2, 1, 8, 3}
Output: A1[] = {2, 2, 1, 1, 8, 8, 3, 5, 6, 7, 9}
The code should handle all cases like the number of elements in A2[] may be more or less compared to A1[]. A2[] may have some elements which may not be there in A1[] and vice versa is also possible.

Source: Amazon Interview | Set 110 (On-Campus) 
    https://www.geeksforgeeks.org/amazon-interview-set-110-campus/

We strongly recommend that you click here and practice it, before moving on to the solution.
Method 1 (Using Sorting and Binary Search) 
Let the size of A1[] be m and the size of A2[] be n. 

Create a temporary array temp of size m and copy the contents of A1[] to it.
Create another array visited[] and initialize all entries in it as false. visited[] is used to mark those elements in temp[] which are copied to A1[].
Sort temp[]
Initialize the output index ind as 0.
Do following for every element of A2[i] in A2[] 
Binary search for all occurrences of A2[i] in temp[], if present then copy all occurrences to A1[ind] and increment ind. Also mark the copied elements visited[]
Copy all unvisited elements from temp[] to A1[]
Below image is a dry run of the above approach:
    */
    public class SortArrayDefinedOrder
    {

        /* A Binary Search based function to find
        index of FIRST occurrence of x in arr[].
        If x is not present, then it returns -1 */
        static int first(int[] arr, int low,
                         int high, int x, int n)
        {
            if (high >= low)
            {
                /* (low + high)/2; */
                int mid = low + (high - low) / 2;

                if ((mid == 0 || x > arr[mid - 1]) && arr[mid] == x)
                    return mid;
                if (x > arr[mid])
                    return first(arr, (mid + 1), high,
                                 x, n);
                return first(arr, low, (mid - 1), x, n);
            }
            return -1;
        }

        // Sort A1[0..m-1] according to the order
        // defined by A2[0..n-1].
        static void sortAccording(int[] A1, int[] A2,
                                  int m, int n)
        {

            // The temp array is used to store a copy
            // of A1[] and visited[] is used to mark
            // the visited elements in temp[].
            int[] temp = new int[m];
            int[] visited = new int[m];

            for (int i = 0; i < m; i++)
            {
                temp[i] = A1[i];
                visited[i] = 0;
            }

            // Sort elements in temp
            Array.Sort(temp);

            // for index of output which is
            // sorted A1[]
            int ind = 0;

            // Consider all elements of A2[], find
            // them in temp[] and copy to A1[] in
            // order.
            for (int i = 0; i < n; i++)
            {

                // Find index of the first occurrence
                // of A2[i] in temp
                int f = first(temp, 0, m - 1, A2[i], m);

                // If not present, no need to proceed
                if (f == -1)
                    continue;

                // Copy all occurrences of A2[i] to A1[]
                for (int j = f; (j < m && temp[j] == A2[i]); j++)
                {
                    A1[ind++] = temp[j];
                    visited[j] = 1;
                }
            }

            // Now copy all items of temp[] which are
            // not present in A2[]
            for (int i = 0; i < m; i++)
                if (visited[i] == 0)
                    A1[ind++] = temp[i];
        }

        // Utility function to print an array
        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver program to test above function.
        public static void Main()
        {
            int[] A1 = { 2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8 };
            int[] A2 = { 2, 1, 8, 3 };
            int m = A1.Length;
            int n = A2.Length;
            Console.WriteLine("Sorted array is ");
            sortAccording(A1, A2, m, n);
            printArray(A1, m);
            /*
             Output
Sorted array is 
2 2 1 1 8 8 3 5 6 7 9 
 

Time complexity: The steps 1 and 2 require O(m) time. Step 3 requires O(M * Log M) time. Step 5 requires O(N Log M) time. 
            Therefore overall time complexity is O(M Log M + N Log M).
            */
        }
    }

}
