using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Maximum length of subarray such that all elements are equal in the subarray
Difficulty Level : Basic
 Last Updated : 23 Jul, 2020
Given an array arr[] of N integers, the task is to find the maximum length subarray that contains similar elements.
    https://www.geeksforgeeks.org/maximum-length-of-subarray-such-that-all-elements-are-equal-in-the-subarray/?ref=rp
Examples:

Input: arr[] = {1, 2, 3, 4, 5, 5, 5, 5, 5, 2, 2, 1, 1}
Output: 5
Explanation:
The subarray {5, 5, 5, 5, 5} has maximum length 5 with identical elements.

Input: arr[] = {1, 2, 3, 4}
Output: 1
Explanation:
All identical element subarray are {1}, {2}, {3}, and {4} which is of length 1.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The idea is to traverse the array store the maximum length and current length of the subarray which has the same elements. Below are the steps:




Traverse the array and check if the current element is equal to the next element then increase the value of the current length variable.
Now, compare the current length with max length to update the maximum length of the subarray.
If the current element is not equal to the next element then reset the length to 1 and continue this for all the elements of the array.
Below is the implementation of the above approach:
    */
    class SubarraySameElements
    {

        // Function to find the longest 
        // subarray with same element 
        static int longest_subarray(int[] arr, int d)
        {
            int i = 0, j = 1, e = 0;

            for (i = 0; i < d - 1; i++)
            {

                // Check if the elements 
                // are same then we can 
                // increment the length 
                if (arr[i] == arr[i + 1])
                {
                    j = j + 1;
                }
                else
                {

                    // Reinitialize j 
                    j = 1;
                }

                // Compare the maximum 
                // length e with j 
                if (e < j)
                {
                    e = j;
                }
            }

            // Return max length 
            return e;
        }

        // Driver Code 
        public static void Main(String[] args)
        {

            // Given array []arr 
            int[] arr = { 1, 2, 3, 4 };
            int N = arr.Length;

            // Function Call 
            Console.Write(longest_subarray(arr, N));
        }
    }
    /*
     Output:
1
Time Complexity: O(N)
Auxiliary Space: O(1)
    */
}
