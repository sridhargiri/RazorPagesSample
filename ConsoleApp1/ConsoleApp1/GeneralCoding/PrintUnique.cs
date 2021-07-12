using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/print-all-unique-elements-present-in-a-sorted-array/
    Print all unique elements present in a sorted array
Difficulty Level : Easy
Last Updated : 26 Jun, 2021
Given a sorted array arr[] of size N, the task is to print all the unique elements in the array.

An array element is said to be unique if the frequency of that element in the array is 1.

Examples:

Input: arr[ ] = {1, 1, 2, 2, 3, 4, 5, 5}
Output: 3 4
Explanation: Since 1, 2, 5 are occurring more than once in the array, the distinct elements are 3 and 4.

Input: arr[ ] = {1, 2, 3, 3, 3, 4, 5, 6}
Output: 1 2 4 5 6



Approach: The simplest approach to solve the problem is to traverse the array arr[] and print only those elements whose frequency is 1. Follow the steps below to solve the problem:

Iterate over the array arr[] and initialize a variable, say cnt = 0,   to count the frequency of the current array element.
Since the array is already sorted, check if the current element is the same as the previous element. If found to be true, then update cnt += 1.
Otherwise, if cnt = 1, then print the element. Otherwise, continue.
Below is the implementation of the above approach:
     */
    public class PrintUnique
    {
        static void RemoveDuplicates(int[] arr, int n)
        {

            int i = 0;

            // Traverse the array
            while (i < n)
            {

                int cur = arr[i];

                // Stores frequency of
                // the current element
                int cnt = 0;

                // Iterate until end of the
                // array is reached or current
                // element is not the same as the
                // previous element
                while (i < n && cur == arr[i])
                {
                    cnt++;
                    i++;
                }

                // If current element is unique
                if (cnt == 1)
                {
                    Console.WriteLine(cur);
                }

            }
        }
        static void Main(string[] args)
        {
            // Given Input
            int[] arr = { 1, 3, 3, 5, 5, 6, 10 };
            int N = 7;

            // Function Call
            RemoveDuplicates(arr, N);
            /*
             Output
1 6 10 
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
