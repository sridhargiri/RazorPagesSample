using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SubarrayContigousEven
    {
        /*
         Length of the longest Subarray with only Even Elements
Difficulty Level : Easy
Last Updated : 24 Apr, 2020
Given an array arr[]. The task is to find the length of the longest subarray of arr[] such that it contains only even elements.

Examples:

Input : arr[] = { 5, 2, 4, 7 }
Output : Length = 2
subArr[] = {2, 4}

Input : arr[] = {9, 8, 5, 4, 4, 4, 2, 4, 1}
Output : Length 5
subArr[] = {4, 4, 4, 2, 4}
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to observe that the largest subarray with only even elements is the maximum number of contiguous even elements in the array. Therefore, the task now reduces to find the maximum number of contiguous even elements in the array.

To do this, traverse the array using two variables, ans and current_count. The variable ans stores the final answer and current_count stores the length of subarray with only even numbers.

Now whenever an even element is found, keep incrementing the current_count and whenever an ODD element is found take the maximum of ans and current_count and reset current_count to zero.




At the end, ans will store the length of largest subarray with only even elements.

Below is the implementation of the above approach:
        */
        static int maxEvenSubarray(int[] array, int N)
        {
            int ans = 0;
            int count = 0;

            // Iterate the loop
            for (int i = 0; i < N; i++)
            {
                // Check whether the element is
                // even in continuous fashion
                if (array[i] % 2 == 0)
                {
                    count++;
                    ans = Math.Max(ans, count);
                }
                else
                {
                    // If element are not even in
                    // continuous fashion,
                    // Reinitialize the count
                    count = 0;
                }
            }

            // Check for the last 
            // element in the array
            ans = Math.Max(ans, count);
            return ans;
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 9, 8, 5, 4, 4, 4, 2, 4, 1 };

            int N = arr.Length;

            Console.WriteLine(maxEvenSubarray(arr, N));
            /*
             Output:
5
Time Complexity: O(n)
            */
        }
    }
}
