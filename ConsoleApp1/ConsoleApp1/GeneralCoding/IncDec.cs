using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if an array is increasing or decreasing

Given an array arr[] of N elements where N ≥ 2, the task is to check the type of array whether it is:

Increasing.
Decreasing.
Increasing then decreasing.
Decreasing then increasing.
Note that the given array is definitely one of the given types.

Examples:

Input: arr[] = {1, 2, 3, 4, 5}
Output: Increasing

Input: arr[] = {1, 2, 4, 3}
Output: Increasing then decreasing




Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The following conditions must satitisfy for:

Increasing array: The first two and the last two elements must be in increasing order.
Decreasing array: The first two and the last two elements must be in decreasing order.
Increasing then decreasing array: The first two elements must be in increasing order and the last two elements must be in decreasing order.
Decreasing then increasing array: The first two elements must be in decreasing order and the last two elements must be in increasing order.
Below is the implementation of the above approach:
    */
    class IncDec
    {

        // Function to check the type of the array  
        public static void checkType(int[] arr, int n)
        {

            // If the first two and the last two elements  
            // of the array are in increasing order  
            if (arr[0] <= arr[1] &&
                arr[n - 2] <= arr[n - 1])
                Console.Write("Increasing");

            // If the first two and the last two elements  
            // of the array are in decreasing order  
            else if (arr[0] >= arr[1] &&
                     arr[n - 2] >= arr[n - 1])
                Console.Write("Decreasing");

            // If the first two elements of the array are in  
            // increasing order and the last two elements  
            // of the array are in decreasing order  
            else if (arr[0] <= arr[1] &&
                     arr[n - 2] >= arr[n - 1])
                Console.Write("Increasing then decreasing");

            // If the first two elements of the array are in  
            // decreasing order and the last two elements  
            // of the array are in increasing order  
            else
                Console.Write("Decreasing then increasing");
        }

        // Driver code  
        static public void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };

            int n = arr.Length;

            checkType(arr, n);
            //output Increasing
        }
    }
    /*
     https://www.geeksforgeeks.org/find-whether-subarray-form-mountain-not/
    Find whether a subarray is in form of a mountain or not
Difficulty Level : Hard
Last Updated : 29 May, 2021
We are given an array of integers and a range, we need to find whether the subarray which falls in this range has values in the form of a mountain or not. All values of the subarray are said to be in the form of a mountain if either all values are increasing or decreasing or first increasing and then decreasing. 
More formally a subarray [a1, a2, a3 … aN] is said to be in form of a mountain if there exist an integer K, 1 <= K <= N such that, 
a1 <= a2 <= a3 .. <= aK >= a(K+1) >= a(K+2) …. >= aN 

Examples: 

Input : Arr[]  = [2 3 2 4 4 6 3 2], Range = [0, 2]
Output :  Yes

Explanation: The output is yes , subarray is [2 3 2], 
so subarray first increases and then decreases

Input:  Arr[] = [2 3 2 4 4 6 3 2], Range = [2, 7]
Output: Yes

Explanation: The output is yes , subarray is [2 4 4 6 3 2], 
so subarray first increases and then decreases


Input: Arr[]= [2 3 2 4 4 6 3 2], Range = [1, 3]
Output: no

Explanation: The output is no, subarray is [3 2 4], 
so subarray is not in the form above stated
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Solution: 

Approach: The problem has multiple queries so for each query the solution should be calculated with least possible time complexity. So create two extra spaces of the length of the original array. For every element find the last index on the left side which is increasing i.e. greater than its previous element and find the element on the right side will store the first index on the right side which is decreasing i.e. greater than its next element. If these value can be calculated for every index in constant time then for every given range the answer can be given in constant time.
Algorithm: 
Create two extra spaces of length n,left and right and a extra variable lastptr
Initialize left[0] = 0 and lastptr = 0
Traverse the original array from second index to the end
For every index check if it is greater than the pervious element, if yes then update the lastptr with the current index.
For every index store the lastptr in left[i]
initialize right[N-1] = N-1 and lastptr = N-1
Traverse the original array from second last index to the start
For every index check if it is greater than the next element, if yes then update the lastptr with the current index.
For every index store the lastptr in right[i]
Now process the queries
for every query l, r, if right[l] >= left[r] then print yes else no
Implementation:
     */
    public class MountainArray
    {

        // Utility method to construct
        // left and right array
        static void preprocess(int[] arr, int N,
                               int[] left, int[] right)
        {
            // initialize first left
            // index as that index only
            left[0] = 0;
            int lastIncr = 0;

            for (int i = 1; i < N; i++)
            {
                // if current value is
                // greater than previous,
                // update last increasing
                if (arr[i] > arr[i - 1])
                    lastIncr = i;
                left[i] = lastIncr;
            }

            // initialize last right
            // index as that index only
            right[N - 1] = N - 1;
            int firstDecr = N - 1;

            for (int i = N - 2; i >= 0; i--)
            {
                // if current value is
                // greater than next,
                // update first decreasing
                if (arr[i] > arr[i + 1])
                    firstDecr = i;
                right[i] = firstDecr;
            }
        }

        // method returns true if
        // arr[L..R] is in mountain form
        static bool isSubarrayMountainForm(int[] arr, int[] left,
                                           int[] right, int L, int R)
        {
            // return true only if right at
            // starting range is greater
            // than left at ending range
            return (right[L] >= left[R]);
        }


        // Driver Code
        static public void Main()
        {
            int[] arr = {2, 3, 2, 4,
                     4, 6, 3, 2};
            int N = arr.Length;
            int[] left = new int[N];
            int[] right = new int[N];
            preprocess(arr, N, left, right);

            int L = 0;
            int R = 2;

            if (isSubarrayMountainForm(arr, left,
                                       right, L, R))
                Console.WriteLine("Subarray is in " +
                                    "mountain form");
            else
                Console.WriteLine("Subarray is not " +
                                  "in mountain form");

            L = 1;
            R = 3;

            if (isSubarrayMountainForm(arr, left,
                                       right, L, R))
                Console.WriteLine("Subarray is in " +
                                    "mountain form");
            else
                Console.WriteLine("Subarray is not " +
                                  "in mountain form");
            /*
             Output: 
Subarray is in mountain form
Subarray is not in mountain form
Complexity Analysis: 
Time Complexity:O(n). 
Only two traversals are needed so the time complexity is O(n).
Space Complexity:O(n). 
Two extra space of length n is required so the space complexity is O(n)
            */
        }
    }
}
