using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Length of the longest alternating even odd subarray
Difficulty Level : Easy
Last Updated : 18 Mar, 2021
GeeksforGeeks - Summer Carnival Banner
Given an array a[] of N integers, the task is to find the length of the longest Alternating Even Odd subarray present in the array. 
Examples: 
 

Input: a[] = {1, 2, 3, 4, 5, 7, 9} 
Output: 5 
Explanation: 
The subarray {1, 2, 3, 4, 5} has alternating even and odd elements.
Input: a[] = {1, 3, 5} 
Output: 0 
Explanation: 
There is no such alternating sequence possible. 
 
https://www.geeksforgeeks.org/length-of-the-longest-alternating-even-odd-subarray/
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: To solve the problem mentioned above we have to observe that the Sum of two even numbers is even, Sum of two odd numbers is even but sum of one even and one odd number is odd.
 

Initially initialize cnt a counter to store the length as 1.
Iterate among the array elements, check if consecutive elemnts has an odd sum.
Increase the cnt by 1 if it has a odd sum.
If it does not has a odd sum, then re-initialize cnt by 1.
Below is the implementation of the above approach: 
    */
    class EvenOddSubarray
    {

        // Function to find the longest subarray
        static int longestEvenOddSubarray(int[] a, int n)
        {

            // Length of longest
            // alternating subarray
            int longest = 1;
            int cnt = 1;

            // Iterate in the array
            for (int i = 0; i < n - 1; i++)
            {

                // Increment count if consecutive
                // elements has an odd sum
                if ((a[i] + a[i + 1]) % 2 == 1)
                {
                    cnt++;
                }
                else
                {

                    // Store maximum count in longest
                    longest = Math.Max(longest, cnt);

                    // Reinitialize cnt as 1 consecutive
                    // elements does not have an odd sum
                    cnt = 1;
                }
            }

            // Length of 'longest' can never be 1
            // since even odd has to occur in pair
            // or more so return 0 if longest = 1
            if (longest == 1)
                return 0;
            return Math.Max(cnt, longest);
        }

        // Driver code
        static void Main()
        {

            int[] a = { 1, 2, 3, 4, 5, 7, 8 };
            int n = a.Length;

            Console.WriteLine(longestEvenOddSubarray(a, n));//output 5
        }
    }
}
