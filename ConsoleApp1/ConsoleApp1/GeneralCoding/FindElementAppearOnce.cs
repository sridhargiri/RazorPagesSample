using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find the element that appears once in a sorted array
Difficulty Level : Medium
 Last Updated : 26 Feb, 2021
Given a sorted array in which all elements appear twice (one after one) and one element appears only once. Find that element in O(log n) complexity.

Example: 

Input:   arr[] = {1, 1, 3, 3, 4, 5, 5, 7, 7, 8, 8}
Output:  4

Input:   arr[] = {1, 1, 3, 3, 4, 4, 5, 5, 7, 7, 8}
Output:  8
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
A Simple Solution is to traverse the array from left to right. Since the array is sorted, we can easily figure out the required element.

Below is the implementation of the above approach.
    */
    class FindElementAppearOnce
    {
        // A Linear Search based function to find
        // the element that appears only once
        static void search(int[] arr, int n)
        {
            int ans = -1;
            for (int i = 0; i < n; i += 2)
            {
                if (arr[i] != arr[i + 1])
                {
                    ans = arr[i];
                    break;
                }
            }

            if (arr[n - 2] != arr[n - 1])
                ans = arr[n - 1];

            // ans = -1 if no such element is present.
            Console.Write("The required element is "
                            + ans);
        }
        static void reqsearch(int[] arr, int n)
        {
            int XOR = 0;

            for (int i = 0; i < n; i++)
            {
                XOR = XOR ^ arr[i];
            }
            Console.Write("The required element is " + XOR);
        }
        /*
         
         The required element is 2
Time Complexity: O(n)
Space Complexity: O(1) 

Another Simple Solution is to use the properties of XOR (a ^ a = 0 & a ^ 0 = a). The idea to find the XOR of the complete array. The XOR of the array is the required answer.

Below is the implementation of the above approach.
        */
        public static void Main(String[] args)
        {
            int[] arr = { 1, 1, 2, 4, 4, 5, 5, 6, 6 };
            int len = arr.Length;

            search(arr, len);
        }
    }
}
