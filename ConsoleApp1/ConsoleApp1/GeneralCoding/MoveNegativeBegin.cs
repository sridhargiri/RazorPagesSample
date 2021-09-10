using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/move-negative-numbers-beginning-positive-end-constant-extra-space/?ref=leftbar-rightbar
    Move all negative numbers to beginning and positive to end with constant extra space
Difficulty Level : Easy
Last Updated : 09 Jun, 2021
An array contains both positive and negative numbers in random order. Rearrange the array elements so that all negative numbers appear before all positive numbers.

Examples : 

Input: -12, 11, -13, -5, 6, -7, 5, -3, -6
Output: -12 -13 -5 -7 -3 -6 11 6 5
Note: Order of elements is not important here.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach 1:
The idea is to simply apply the partition process of quicksort. 
    https://www.geeksforgeeks.org/quick-sort/
     */
    public class MoveNegativeBegin
    {
        static void rearrange(int[] arr, int n)
        {

            int j = 0, temp;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j++;
                }
            }
        }

        // A utility function to print an array
        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { -1, 2, -3, 4, 5, 6, -7, 8, 9 };
            int n = arr.Length;

            rearrange(arr, n);
            printArray(arr, n);
            /*
             Output -1 -3 -7 4 5 6 2 8 9
Time complexity: O(N) 
Auxiliary Space: O(1)
            */
        }
    }
    /*
     Two Pointer Approach: The idea is to solve this problem with constant space and linear time is by using a two-pointer or two-variable approach where we simply take two variables like left and right which hold the 0 and N-1 indexes. Just need to check that :

Check If the left and right pointer elements are negative then simply increment the left pointer.
Otherwise, if the left element is positive and the right element is negative then simply swap the elements, and simultaneously increment and decrement the left and right pointers.
Else if the left element is positive and the right element is also positive then simply decrement the right pointer.
Repeat the above 3 steps until the left pointer ≤ right pointer.
Below is the implementation of the above approach:
     */
    class NegativeBegin
    {
        // Function to shift all the
        // negative elements on left side
        static void shiftall(int[] arr, int left, int right)
        {

            // Loop to iterate over the
            // array from left to the right
            while (left <= right)
            {

                // Condition to check if the left
                // and the right elements are
                // negative
                if (arr[left] < 0 && arr[right] < 0)
                    left++;

                // Condition to check if the left
                // pointer element is positive and
                // the right pointer element is negative
                else if (arr[left] > 0 && arr[right] < 0)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }

                // Condition to check if both the
                // elements are positive
                else if (arr[left] > 0 && arr[right] > 0)
                    right--;
                else
                {
                    left++;
                    right--;
                }
            }
        }

        // Function to print the array
        static void display(int[] arr, int right)
        {

            // Loop to iterate over the element
            // of the given array
            for (int i = 0; i <= right; ++i)
            {
                Console.Write(arr[i] + " ");

            }
            Console.WriteLine();
        }

        // Drive code                  
        static void Main()
        {
            int[] arr = { -12, 11, -13, -5, 6, -7, 5, -3, 11 };
            int arr_size = arr.Length;
            shiftall(arr, 0, arr_size - 1);
            display(arr, arr_size - 1);
            /*
             Output
-12 -3 -13 -5 -7 6 5 11 11
This is an in-place rearranging algorithm for arranging the positive and negative numbers where the order of elements is not maintained.

Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
