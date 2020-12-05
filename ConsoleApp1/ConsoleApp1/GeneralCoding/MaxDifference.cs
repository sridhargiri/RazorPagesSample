using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MaxDifference
    {
        /*
         Examples :

Input : arr = {2, 3, 10, 6, 4, 8, 1}
Output : 8
Explanation : The maximum difference is between 10 and 2.

Input : arr = {7, 9, 5, 6, 3, 2}
Output : 2
Explanation : The maximum difference is between 9 and 7.
         */
        /*
         Method 1 (Simple)
Use two loops. 
In the outer loop, pick elements one by one and in the inner loop calculate the difference of the picked element with every other element in the array 
        and compare the difference with the maximum difference calculated so far. 
Below is the implementation of the above approach :
         */
        // The function assumes that there  
        // are at least two elements in array. 
        // The function returns a negative  
        // value if the array is sorted in  
        // decreasing order. Returns 0 if 
        // elements are equal  
        //Time Complexity : O(n^2)
        //Auxiliary Space : O(1)

        static int maxDiff(int[] arr, int arr_size)
        {
            int max_diff = arr[1] - arr[0];
            int i, j;
            for (i = 0; i < arr_size; i++)
            {
                for (j = i + 1; j < arr_size; j++)
                {
                    if (arr[j] - arr[i] > max_diff)
                        max_diff = arr[j] - arr[i];
                }
            }
            return max_diff;
        }
        //Method 2 (Tricky and Efficient)
        // In this method, instead of taking difference of the picked element with every other element, we take the difference with the minimum element found so far.
        //So we need to keep track of 2 things:
        //1) Maximum difference found so far (max_diff).
        //2) Minimum number visited so far(min_element).
        //Time Complexity : O(n)
        //Auxiliary Space : O(1)

        /* The function assumes that there are  
        at least two elements in array. The  
        function returns a negative value if the 
        array is sorted in decreasing order and  
        returns 0 if elements are equal */
        static int maxDiff1(int[] arr, int n)
        {
            // Initialize Result 
            int maxDiff = -1;

            // Initialize max element from right side 
            int maxRight = arr[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] > maxRight)
                    maxRight = arr[i];
                else
                {
                    int diff = maxRight - arr[i];
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }
            }
            return maxDiff;
        }
        /*
         Method 3 (Another Tricky Solution)
First find the difference between the adjacent elements of the array and store all differences in an auxiliary array diff[] of size n-1. 
        Now this problems turns into finding the maximum sum subarray of this difference array.Thanks to Shubham Mittal for suggesting this solution. 
        Below is the implementation :
         */

        static int maxDiff2(int[] arr, int n)
        {

            // Create a diff array of size n-1. 
            // The array will hold the 
            // difference of adjacent elements 
            int[] diff = new int[n - 1];
            for (int i = 0; i < n - 1; i++)
                diff[i] = arr[i + 1] - arr[i];

            // Now find the maximum sum 
            // subarray in diff array 
            int max_diff = diff[0];
            for (int i = 1; i < n - 1; i++)
            {
                if (diff[i - 1] > 0)
                    diff[i] += diff[i - 1];
                if (max_diff < diff[i])
                    max_diff = diff[i];
            }
            return max_diff;
        }
        /*
         We can modify the above method to work in O(1) extra space.
        Instead of creating an auxiliary array, we can calculate diff and max sum in same loop.
        Following is the space optimized version.
         */


        /* The function assumes that there 
        are at least two elements in array.  
        The function returns a negative  
        value if the array is sorted in  
        decreasing order and returns 0 if 
        elements are equal */
        static int maxDiff3(int[] arr, int n)
        {
            // Initialize diff, current  
            // sum and max sum  
            int diff = arr[1] - arr[0];
            int curr_sum = diff;
            int max_sum = curr_sum;

            for (int i = 1; i < n - 1; i++)
            {
                // Calculate current diff  
                diff = arr[i + 1] - arr[i];

                // Calculate current sum  
                if (curr_sum > 0)
                    curr_sum += diff;
                else
                    curr_sum = diff;

                // Update max sum, if needed  
                if (curr_sum > max_sum)
                    max_sum = curr_sum;
            }

            return max_sum;
        }
        public static void Main(string[] args)
        {

            int[] arr = { 1, 2, 90, 10, 110 };
            int size = arr.Length;
            Console.Write("MaximumDifference is " +
                                   maxDiff(arr, size));

            arr = new int[] { 80, 2, 6, 3, 100 };
            size = arr.Length;
            Console.Write(maxDiff2(arr, size));
        }
    }
}
