using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if sequence of removed middle elements from an array is sorted or not
Last Updated : 23 Mar, 2021
Given an array arr[] consisting of N integers, the task is to check if the sequence of numbers formed by repeatedly removing the middle elements from the given array arr[] is sorted or not. If there are two middle elements, then remove any one of them.

Examples:

Input: arr[] = {4, 3, 1, 2, 5}
Output: Yes
Explanation:
The order of removing of elements are: 
Middle element of the array = arr[2]. Removing arr[2] modifies the array to {4, 3, 2, 5}. 
Middle elements of the array are arr[1] and arr[2]. Removing arr[2] modifies the array to {4, 3, 5}. 
Middle element of the array is arr[1]. Removing arr[1] modifies the array to {4, 5}. 
Similarly, arr[0] and arr[1] are removed from the array. 
Finally, the sequence of removed array elements are {1, 2, 3, 4, 5}, which is sorted.

Input: arr[] = {5, 4, 1, 2, 3}
Output: No

 
Naive Approach: The simplest approach to solve the given problem is to use recursion to generate every possible combination of removal of array elements. For instances having two middle elements, two recursive calls are required to be made, one considering the N / 2th element and the other considering the (N / 2 + 1)th element. After completing the recursion, check if the array formed by any of the recursive calls is sorted or not. If found to be true, then print “Yes“. Otherwise, print “No”. 



    https://www.geeksforgeeks.org/check-if-sequence-of-removed-middle-elements-from-an-array-is-sorted-or-not/
Time Complexity: O(N*2N)
Auxiliary Space: O(1)

Efficient Approach: The above approach can be optimized based on the observation that the elements at the end of the array need to be greater than all the array elements in order to get an increasingly sorted array. 
Follow the steps below to solve the problem:

Initialize a variable, say ans, with “Yes”, to check if the required sequence can be sorted or not.
Initialize two pointers, say L as 0 and R as (N – 1), to store the starting and the ending indices of the array.
Iterate until L is less than R and perform the following steps:
If the value of arr[L] is greater than or equal to the maximum of arr[L + 1] and arr[R – 1] and the value of arr[R] is greater than or equal to the minimum of arr[L + 1] and arr[R – 1], then increment the value of L by 1 and decrement the value of R by 1.
Otherwise, update the value of ans to “No” and break out of the loop.
After completing the above steps, print the value of ans as the result.
Below is the implementation of the above approach:
    */
    class RemovedMiddle
    {
        static bool isSortedArray(int[] arr, int n)
        {
            // Points to the ends
            // of the array
            int l = 0, r = (n - 1);

            // Iterate l + 1 < r
            while ((l + 1) < r)
            {

                // If the element at index L and
                // R is greater than (L + 1)-th
                // and (R - 1)-th elements
                if (arr[l] >= Math.Max(arr[l + 1],
                                  arr[r - 1])
                    && arr[r] >= Math.Max(arr[r - 1],
                                     arr[l + 1]))
                {

                    // If true, then decrement R
                    // by 1 and increment L by 1
                    l++;
                    r--;
                }

                // Otherwise, return false
                else
                {
                    return false;
                }
            }

            // If an increasing sequence is
            // formed, then return true
            return true;
        }
        static void Main(string[] args)
        {
            int[] arr = { 4, 3, 1, 2, 5 };
            if (isSortedArray(arr, arr.Length)) Console.WriteLine("yes"); else Console.WriteLine("no");
            /*
             Output: 
Yes


Time Complexity: O(N)
Auxiliary Space: O(1)
            */

        }
    }
}
