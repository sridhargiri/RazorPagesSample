using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-the-maximum-among-the-count-of-positive-or-negative-integers-in-the-array/
    Find the maximum among the count of positive or negative integers in the array
Last Updated : 07 Oct, 2021
Given a sorted array arr[] consisting of N integers, the task is to find the maximum among the count of positive or negative integers in the array arr[].

Examples:

Attention reader! Don’t stop learning now. Get hold of all the important DSA concepts with the DSA Self Paced Course at a student-friendly price and become industry ready.  To complete your preparation from learning a language to DS Algo and many more,  please refer Complete Interview Preparation Course.

In case you wish to attend live classes with experts, please refer DSA Live Classes for Working Professionals and Competitive Programming Live for Students.

Input: arr[] = {-9, -7, -4, 1, 5, 8, 9}
Output: 4
Explanation:
The count of positive numbers is 4 and the count of negative numbers is 3. So, the maximum among 4, 3 is 4. Therefore, print 4.

Input: arr[] = {-8, -6, 10, 15}
Output: 2

Approach: The given problem can be solved by using Binary Search, the idea is to find the first index whose value is positive and then print the maximum of idx and (N – idx) as the result. Follow the steps below to solve the given problem:

Initialize two variables, say low as 0 and high as (N – 1).
Perform the Binary Search on the given array arr[] by iterating until low <= high and follow the below steps:
Find the value of mid as (low + high) / 2.
If the value of arr[mid] is positive, then skip the right half by updating the value of high to (mid – 1). Otherwise, skip the left half by updating the value of low to (mid + 1).
After completing the above steps, print the maximum of low and (N – low) as the result.
 Below is the implementation of the above approach
     */
    class MaxNegativePositive
    {
        static int findMaximumOfNegativePositive(int[] arr, int size)
        {

            // Initialize the pointers
            int i = 0, j = size - 1, mid;

            while (i <= j)
            {

                // Find the value of mid
                mid = i + (j - i) / 2;

                // If element is negative then
                // ignore the left half
                if (arr[mid] < 0)
                    i = mid + 1;

                // If element is positive then
                // ignore the right half
                else if (arr[mid] > 0)
                    j = mid - 1;
            }

            // Return maximum among the count
            // of positive & negative element
            return Math.Max(i, size - i);
        }
        public static void Main(string[] args)
        {
            int[] arr = { -9, -7, -4, 1, 5, 8, 9 };
            Console.WriteLine(findMaximumOfNegativePositive(arr, arr.Length));
            /*
             Output:
4
Time Complexity: O(log N)
Auxiliary Space: O(1)
            */
        }
    }
}
