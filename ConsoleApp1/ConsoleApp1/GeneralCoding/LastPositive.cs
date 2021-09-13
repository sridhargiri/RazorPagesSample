using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-the-last-positive-element-remaining-after-repeated-subtractions-of-smallest-positive-element-from-all-array-elements/
    Find the last positive element remaining after repeated subtractions of smallest positive element from all Array elements
Last Updated : 10 Sep, 2021
Given an array arr[] consisting of N positive integers, the task is to find the last positive array element remaining after repeated subtractions of the smallest positive array element from all array elements.

Examples:
Input: arr[] = {3, 5, 4, 7}
Output: 2
Explanation: 
Subtract the smallest positive element from the array, i.e. 3, the new array is arr[] = {0, 2, 1, 4}
Subtract the smallest positive element from the array, i.e. 1, the new array is arr[] = {0, 1, 0, 3}
Subtract the smallest positive element from the array, i.e. 1, the new array is arr[] = {0, 0, 0, 2}
The last remaining element is 2.

Input: arr[] = {2, 6, 7}
Output: 1

Naive Approach: The simplest approach to solve the given problem is to traverse the given array arr[] and find the smallest positive element in the array and subtract it from all the elements. Perform this operation until there is only one positive element left in the array. After completing the above steps, print the remaining positive array element.

Time Complexity: O(N2)
Auxiliary Space: O(1)

Efficient Approach: The above approach can be optimized by observing that the last positive element will be the difference between the largest array element and the second-largest array element. Follow the steps below to solve the problem:

If N = 1, print the first element of the array.
Otherwise print the difference between the largest and second-largest array elements.
Below is the implementation of the above approach
     */
    public class LastPositive
    {
        static int lastPositiveElement(List<int> arr)
        {
            // Return the first element if N = 1
            if (arr.Count == 1)
                return arr[0];

            // Stores the greatest and the second
            // greatest element
            int greatest = -1, secondGreatest = -1;

            // Traverse the array A[]
            foreach (int x in arr)
            {
                // If current element is greater
                // than the greatest element
                if (x >= greatest)
                {
                    secondGreatest = greatest;
                    greatest = x;
                }

                // If current element is greater
                // than second greatest element
                else if (x >= secondGreatest)
                {
                    secondGreatest = x;
                }
            }

            // Return the final answer
            return greatest - secondGreatest;
        }
        static void Main(string[] args)
        {
            List<int> arr = new List<int> { 3, 5, 4, 7 };
            Console.WriteLine(lastPositiveElement(arr));
            /*
             Output:2
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
