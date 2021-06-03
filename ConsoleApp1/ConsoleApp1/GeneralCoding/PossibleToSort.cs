using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/check-if-removal-of-a-subsequence-of-non-adjacent-elements-makes-the-array-sorted/
     Check if removal of a subsequence of non-adjacent elements makes the array sorted
Last Updated : 24 May, 2021
Given a binary array arr[] of size N, the task is to check if the array arr[] can be made sorted by removing any subsequence of non-adjacent array elements. If the array can be made sorted, then print “Yes”. Otherwise, print “No”.

Examples:

Input: arr[] = {1, 0, 1, 0, 1, 1, 0}
Output: Yes
Explanation: 
Remove the element at indices {1, 3, 6} modifies the given array to {1, 1, 1, 1}, which is sorted. Therefore, print Yes.

Input: arr[] = {0, 1, 1, 0, 0}
Output: No

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach: The simplest approach to solve the given problem is to generate all possible subsequences of non-adjacent elements and if there exists any subsequence whose removal sorts the given array, then print “Yes”. Otherwise, print “No”.



Time Complexity: O(2N)
Auxiliary Space: O(1)

Efficient Approach: The above approach can also be optimized based on the observation that the array can’t be sorted if and only if when there exists two consecutive 1s are present at adjacent indexes i and i + 1 and two consecutive 0s are present at adjacent indexes j and j + 1 such that (j > i). Follow the steps below to solve the problem:

Initialize a variable, say idx as -1 that stores the index if there are two consecutive 1s in the array.
Traverse the given array and if there exists any two consecutive 1s are present in the array then store that index in the variable idx and break out of the loop. Otherwise, removing all the 1s from the array and make the array sorted, and print “Yes”.
If the value of idx is “-1”, then print “Yes” as always removing all the 1s from the array makes the array sorted.
Otherwise, traverse the array again from the index idx and if there exist two consecutive 0s, then print and break out of the loop. Otherwise, removing all the 0s from the array and make the array sorted, and print “Yes”.
Below is the implementation of the above approach
    */
    class PossibleToSort
    {

        // Function to check if it is possible
        // to sort the array or not
        static void isPossibleToSort(int[] arr, int N)
        {
            // Stores the index if there are two
            // consecutive 1's in the array
            int idx = -1;

            // Traverse the given array
            for (int i = 1; i < N; i++)
            {

                // Check adjacent same elements
                // having values 1s
                if (arr[i] == 1 && arr[i - 1] == 1)
                {
                    idx = i;
                    break;
                }
            }

            // If there are no two consecutive
            // 1s, then always remove all the
            // 1s from array & make it sorted
            if (idx == -1)
            {
                Console.WriteLine("YES");
                return;
            }

            for (int i = idx + 1; i < N; i++)
            {

                // If two consecutive 0's are
                // present after two conseutive
                // 1's then array can't be sorted
                if (arr[i] == 0 && arr[i - 1] == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            // Otherwise, print Yes
            Console.WriteLine("YES");
        }

        // Driver Code
        public static void main(String[] args)
        {
            int[] arr = { 1, 0, 1, 0, 1, 1, 0 };
            isPossibleToSort(arr, arr.Length);
            /*
             Output: 
YES
 

Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
