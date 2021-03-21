using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Minimize difference after changing all odd elements to even
Last Updated : 09 Jul, 2020
Given an array arr[] of N positive integers. We have to perform one operation on every odd element in the given array i.e., multiply every odd element by 2 in the given array, the task is to find the minimum difference between any two elements in the array after performing the given operation.

Examples:

Input: arr[] = {2, 8, 15, 29, 40}
Output: 1
Explanation:
Multiply the third element 15 by 2 so it will become 30.
Now you have 30 and 29, so the minimum difference will become 1.

Input: arr[] = { 3, 8, 13, 30, 50 }
Output : 2
Explanation:
Multiply 3 by 2 so it will become 6.
Now you have 6 and 8, so the minimum difference will become 2.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach:
https://www.geeksforgeeks.org/minimize-difference-after-changing-all-odd-elements-to-even/?ref=rp


Convert every odd number in the given array to even by multiplying it by 2.
Sort the given array in increasing order.
Find the minimum difference between any two consecutive element in the above sorted array.
The difference calculated above is the minimum difference between any two elements in the array after performing the given operation.
Below is the implementation of the above approach:
    */
    class MinDiffEven
    {

        // Function to minimize the difference  
        // between two elements of array  
        public static void minDiff(long[] a, int n)
        {

            // Find all the element which are  
            // possible by multiplying  
            // 2 to odd numbers  
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 1)
                    a[i] *= 2;
            }

            // Sort the array  
            Array.Sort(a);

            long mindifference = a[1] - a[0];

            // Find the minimum difference  
            // Iterate and find which adjacent  
            // elements have the minimum difference  
            for (int i = 1; i < a.Length; i++)
            {
                mindifference = Math.Min(mindifference,
                                         a[i] - a[i - 1]);
            }

            // Print the minimum difference  
            Console.Write(mindifference);
        }

        // Driver Code  
        public static void Main()
        {

            // Given array  
            long[] arr = { 3, 8, 13, 30, 50 };

            int n = arr.Length;

            // Function call  
            minDiff(arr, n);
        }
    }
    /*
     Output:
2
Time Complexity: O(N*log2N)
    */
}
