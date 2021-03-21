using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SubarrayEven
    {
        /*
         Maximum length of subarray such that sum of the subarray is even
Difficulty Level : Hard
 Last Updated : 04 Mar, 2021
Given an array of N elements. The task is to find the length of the longest subarray such that sum of the subarray is even.
Examples: 
 

Input : N = 6, arr[] = {1, 2, 3, 2, 1, 4}
Output : 5
Explanation: In the example the subarray 
in range [2, 6] has sum 12 which is even, 
so the length is 5.

Input : N = 4, arr[] = {1, 2, 3, 2}
Output : 4
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: First check if the total sum of the array is even. If the total sum of the array is even then the answer will be N.
If the total sum of the array is not even, means it is ODD. So, the idea is to find an odd element from the array such that excluding that element and comparing the length of both parts of the array we can obtain the max length of the subarray with even sum.
It is obvious that the subarray with even sum will exist in range [1, x) or (x, N], 
where 1 <= x <= N, and arr[x] is ODD. 
Below is the implementation of above approach: 
 
         */
        static int maxLength(int[] a, int n)
        {
            int sum = 0, len = 0;

            // Check if sum of complete array is even
            for (int i = 0; i < n; i++)
            {
                sum += a[i];
            }

            if (sum % 2 == 0) // total sum is already even
            {
                return n;
            }

            // Find an index i such the a[i] is odd
            // and compare length of both halfs excluding
            // a[i] to find max length subarray
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 1)
                {
                    len = Math.Max(len, Math.Max(n - i - 1, i));
                }
            }

            return len;
        }

        // Driver Code
        static public void Main()
        {
            int[] a = { 1, 2, 3, 2 };
            int n = a.Length;
            Console.WriteLine(maxLength(a, n));

        }
        /*
         Output: 
4
 

Time Complexity: O(N)
        */
    }
}
