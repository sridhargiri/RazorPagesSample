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
    public class MaxNegativePositive
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
    /*
     https://www.geeksforgeeks.org/find-the-only-positive-or-only-negative-number-in-the-given-array/
    Find the only positive or only negative number in the given Array
Last Updated : 25 Nov, 2021
Given an array arr[] of either entirely positive integers or entirely negative integers except for one number. The task is to find that number.

 Examples:
    Input: arr[] = {3, 5, 2, 8, -7, 6, 9}
Output: -7
Explanation: Except -7 all the numbers in arr[] are posisitve integers. 
    Input: arr[] = {-3,  5,  -9}
Output: 5
    Approach: The given problem can be solved by just comparing the first three numbers of arr[]. After that apply Linear Search and find the number. Follow the steps below to solve the problem. 

If the size of arr[] is smaller than 3, then return 0.
Initialize the variable Cp and Cn.
Where Cp = Count of positive integers and Cn = Count of negative integers.
Iterate over the first 3 element
If (arr[i]>0), Increment Cp by 1.
Else Increment Cn by 1.
Cp can be 2 or 3 and similarly Cn can also either 2 or 3.
If Cp<Cn, then the single element is positive, apply linear search and find it.
If Cn<Cp, then the single element is negative, apply linear search and find it.
Below is the implementation of the above approach: 

     */
    public class OnlyNegativePositive
    {
        static int find_OnlyNegativePositive(int[] a, int N)
        {
            // Size can not be smaller than 3
            if (N < 3)
                return 0;

            // Initialize the variable
            int i, Cp = 0, Cn = 0, found = 0;

            // Check the single element is
            // positive or negative
            for (i = 0; i < 3; i++)
            {

                if (a[i] > 0)
                    Cp++;
                else
                    Cn++;
            }

            // Check for positive single element
            if (Cp < Cn)
            {
                for (i = 0; i < N; i++)
                    if (a[i] > 0)
                        found = a[i];
            }

            // Check for negative single element
            else
            {
                for (i = 0; i < N; i++)
                    if (a[i] < 0)
                        found = a[i];
            }
            return found;
        }
        public static void Main(string[] args)
        {
            int[] arr = { 3, 5, 2, 8, -7, 6, 9 };
            Console.WriteLine(find_OnlyNegativePositive(arr, arr.Length));
            /*
             Output -7
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
