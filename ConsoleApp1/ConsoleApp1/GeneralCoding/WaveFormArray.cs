using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class WaveFormArray
    {
        /*
         Sort an array in wave form

Given an unsorted array of integers, sort the array into a wave like array. An array ‘arr[0..n-1]’ is sorted in wave form if arr[0] >= arr[1] <= arr[2] >= arr[3] <= arr[4] >= …..
Examples:

 Input:  arr[] = {10, 5, 6, 3, 2, 20, 100, 80}
 Output: arr[] = {10, 5, 6, 2, 20, 3, 100, 80} OR
                 {20, 5, 10, 2, 80, 6, 100, 3} OR
                 any other array that is in wave form

 Input:  arr[] = {20, 10, 8, 6, 4, 2}
 Output: arr[] = {20, 8, 10, 4, 6, 2} OR
                 {10, 8, 20, 2, 6, 4} OR
                 any other array that is in wave form

 Input:  arr[] = {2, 4, 6, 8, 10, 20}
 Output: arr[] = {4, 2, 8, 6, 20, 10} OR
                 any other array that is in wave form

 Input:  arr[] = {3, 6, 5, 10, 7, 20}
 Output: arr[] = {6, 3, 10, 5, 20, 7} OR
                 any other array that is in wave form
A Simple Solution is to use sorting. First sort the input array, then swap all adjacent elements.

For example, let the input array be {3, 6, 5, 10, 7, 20}. After sorting, we get {3, 5, 6, 7, 10, 20}. After swapping adjacent elements, we get {5, 3, 7, 6, 20, 10}.

Below are implementations of this simple approach.
         */

        // A utility method to swap two numbers. 
        void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        // This function sorts arr[0..n-1] in wave form, i.e., 
        // arr[0] >= arr[1] <= arr[2] >= arr[3] <= arr[4].. 
        void sortInWave(int[] arr, int n)
        {
            // Sort the input array 
            Array.Sort(arr);

            // Swap adjacent elements 
            for (int i = 0; i < n - 1; i += 2)
                swap(arr, i, i + 1);
        }
        /*
         The time complexity of the above solution is O(nLogn) if a O(nLogn) sorting algorithm like Merge Sort, Heap Sort, .. etc is used.

This can be done in O(n) time by doing a single traversal of given array. The idea is based on the fact that if we make sure that all even positioned (at index 0, 2, 4, ..) elements are greater than their adjacent odd elements, we don’t need to worry about odd positioned element. Following are simple steps.
1) Traverse all even positioned elements of input array, and do following.
….a) If current element is smaller than previous odd element, swap previous and current.
….b) If current element is smaller than next odd element, swap next and current.

Below are implementations of above simple algorithm
        */
        void sortInWave1(int[] arr, int n)
        {
            // Traverse all even elements 
            for (int i = 0; i < n; i += 2)
            {

                // If current even element is smaller 
                // than previous 
                if (i > 0 && arr[i - 1] > arr[i])
                    swap(arr, i - 1, i);

                // If current even element is smaller 
                // than next 
                if (i < n - 1 && arr[i] < arr[i + 1])
                    swap(arr, i, i + 1);
            }
        }
        /*
         Print a matrix in Reverse Wave Form

Given a matrix, print it in Reverse Wave Form.

Examples :

Input :  1  2  3  4
         5  6  7  8
         9  10 11 12
         13 14 15 16
Output : 4 8 12 16 15 11 7 3 2 6 10 14 13 9 5 1

Input :  1  9  4  10
         3  6  90 11
         2  30 85 72
         6  31 99 15 
Output : 10 11 72 15 99 85 90 4 9 6 30 31 6 2 3 1
Approach :To get the reverse wave form for a given matrix, we first print the elements of the last column of the matrix in downward direction then print the elements of the 2nd last column in the upward direction, then print the elements in third last column in downward direction and so on. For example 1, the flow goes like :
matrix-reverse-wave-form

Below is the implementation to print reverse wave form of a matrix :
         */
        static int R = 4;
        static int C = 4;

        // function to print reverse wave  
        // form for a given matrix 
        static void WavePrint(int m, int n, int[,] arr)
        {

            int i, j = n - 1, wave = 1;

            // m- Ending row index 
            // n - Ending column index 
            // i, j - Iterator 
            // wave - for Direction 
            // wave = 1 - Wave direction down 
            // wave = 0 - Wave direction up */ 
            while (j >= 0)
            {

                // Check whether to go in 
                // upward or downward 
                if (wave == 1)
                {

                    // Print the element of the  
                    // matrix downward since the 
                    // value of wave = 1 
                    for (i = 0; i < m; i++)
                        Console.Write(arr[i, j] + " ");

                    wave = 0;
                    j--;
                }

                else
                {

                    // Print the elements of the  
                    // matrix upward since the value 
                    // of wave = 0 
                    for (i = m - 1; i >= 0; i--)
                        Console.Write(arr[i, j] + " ");

                    wave = 1;
                    j--;
                }
            }
        }
        public static void Main()
        {
            WaveFormArray ob = new WaveFormArray();
            int[] arr = { 10, 90, 49, 2, 1, 5, 23 };
            int n = arr.Length;

            ob.sortInWave(arr, n);
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            //Output:
            //    2 1 10 5 49 23 90 
            ob.sortInWave1(arr, n);
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            //Time O(n), Output:

            //90 10 49 1 5 2 23

            int[,] arr1 = { { 1, 2, 3, 4 },
                       { 5, 6, 7, 8 },
                       { 9, 10, 11, 12 },
                       { 13, 14, 15, 16 } };

            WavePrint(R, C, arr1);
        }
    }
}
