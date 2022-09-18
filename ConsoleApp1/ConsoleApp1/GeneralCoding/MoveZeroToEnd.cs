using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/move-zeroes-end-array/
    Given an array of random numbers, Push all the zero’s of a given array to the end of the array. 
    For example, if the given arrays is {1, 9, 8, 4, 0, 0, 2, 7, 0, 6, 0}, it should be changed to {1, 9, 8, 4, 2, 7, 6, 0, 0, 0, 0}. 
    The order of all other elements should be same. Expected time complexity is O(n) and extra space is O(1).
Example: 
 

Input :  arr[] = {1, 2, 0, 4, 3, 0, 5, 0};
Output : arr[] = {1, 2, 4, 3, 5, 0, 0, 0};

Input : arr[]  = {1, 2, 0, 0, 0, 3, 6};
Output : arr[] = {1, 2, 3, 6, 0, 0, 0};
    There can be many ways to solve this problem. Following is a simple and interesting way to solve this problem. 
Traverse the given array ‘arr’ from left to right. While traversing, maintain count of non-zero elements in array. 
    Let the count be ‘count’. For every non-zero element arr[i], put the element at ‘arr[count]’ and increment ‘count’. 
    After complete traversal, all non-zero elements have already been shifted to front end and ‘count’ is set as index of first 0. 
    Now all we need to do is that run a loop which makes all elements zero from ‘count’ till end of the array.
Below is the implementation of the above approach

     */
    public class MoveZeroToEnd
    {
        // Function which pushes all zeros
        // to end of an array.
        static void PushZerosToEnd(int[] arr, int n)
        {
            // Count of non-zero elements
            int count = 0;

            // Traverse the array. If element encountered is
            // non-zero, then replace the element
            // at index â..countâ.. with this element
            for (int i = 0; i < n; i++)
                if (arr[i] != 0)

                    // here count is incremented
                    arr[count++] = arr[i];

            // Now all non-zero elements have been shifted to
            // front and â..countâ.. is set as index of first 0.
            // Make all elements 0 from count to end.
            while (count < n)
                arr[count++] = 0;
        }

        // Driver function
        public static void Main()
        {
            int[] arr = { 1, 9, 8, 4, 0, 0, 2, 7, 0, 6, 0, 9 };
            int n = arr.Length;
            PushZerosToEnd(arr, n);
            Console.WriteLine("Array after pushing all zeros to the back: ");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            /*
             Output
Array after pushing all zeros to end of array:
1 9 8 4 2 7 6 9 0 0 0 0 
Time Complexity: O(n) where n is number of elements in input array.
Auxiliary Space: O(1)
            */
        }
    }
    /*
     Method 2: Partitioning the array

Approach: The approach is pretty simple. 
    We will use 0 as a pivot element and whenever we see a non zero element we will swap it with the pivot element. 
    So all the non zero element will come at the beginning
    */
    public class ShiftZeroToEnd
    {

        // C# Program to move all zeros to the end
        public static void Main()
        {
            int[] A = { 5, 6, 0, 4, 6, 0, 9, 0, 8 };
            int n = A.Length;
            int j = 0, temp;
            for (int i = 0; i < n; i++)
            {
                if (A[i] != 0)
                {
                    temp = A[j];
                    A[j] = A[i];
                    A[i] = temp;
                    j++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(A[i]);
                Console.Write(" ");
            }
        }
        /*
         Output
5 6 4 6 9 8 0 0 0 
Complexity Analysis:

Time Complexity: O(N)

Auxiliary Space: O(1) 
        */
    }
}
