using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/sliding-window-maximum-maximum-of-all-subarrays-of-size-k-using-stack-in-on-time/
Sliding Window Maximum (Maximum of all subarrays of size k) using stack in O(n) time
Difficulty Level : Medium
Last Updated : 30 Oct, 2020
Give an array arr[] of N integers and another integer k ≤ N. The task is to find the maximum element of every sub-array of size k.

Examples:

Input: arr[] = {9, 7, 2, 4, 6, 8, 2, 1, 5}
 k = 3
Output: 9 7 6 8 8 8 5
Explanation:
Window 1: {9, 7, 2}, max = 9
Window 2: {7, 2, 4}, max = 7
Window 3: {2, 4, 6}, max = 6
Window 4: {4, 6, 8}, max = 8
Window 5: {6, 8, 2}, max = 8
Window 6: {8, 2, 1}, max = 8
Window 7: {2, 1, 5}, max = 5

Input: arr[] = {6, 7, 5, 2, 1, 7, 2, 1, 10}
 k = 2
Output: 7 7 5 2 7 7 2 10
Explanation:
Window 1: {6, 7}, max = 7
Window 2: {7, 5}, max = 7
Window 3: {5, 2}, max = 5
Window 4: {2, 1}, max = 2
Window 5: {1, 7}, max = 7
Window 6: {7, 2}, max = 7
Window 7: {2, 1}, max = 2
Window 8: {1, 10}, max = 10
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Prerequisite: Next greater element

Approach:
For every index calculate the index upto which the current element is maximum when the subarray starts from this index, i.e For every index i an index j ≥ i such that max(a[i], a[i + 1], … a[j]) = a[i]. Lets call it max_upto[i].
Then the maximum element in the sub-array of length k starting from ith index, can be found by checking every index starting from i to i + k – 1 for which max_upto[i] ≥ i + k – 1 (last index of that window).
Stack data-structure can be used to store the values in an window, i.e. the last visited or the previous inserted element will be at the top (element with closest index to current element).

Algorithm:



Create an array max_upto and a stack to store indices. Push 0 in the stack.
Run a loop from index 1 to index n-1.
Pop all the indices from the stack, which elements (array[s.top()]) is less than the current element and update max_upto[s.top()] = i – 1 and then insert i in the stack.
Pop all the indices from the stack and assign max_upto[s.top()] = n – 1.
Create a variable j = 0
Run a loop from 0 to n – k, loop counter is i
Run a nested loop until j < i or max_upto[j] < i + k – 1, increment j in every iteration.
Print the jth array element.
Implementation
    */
    class SlidingWindowMaximum
    {

        // Function to print the maximum for
        // every k size sub-array
        static void print_max(int[] a, int n, int k)
        {
            // max_upto array stores the index
            // upto which the maximum element is a[i]
            // i.e. max(a[i], a[i + 1], ... a[max_upto[i]]) = a[i]

            int[] max_upto = new int[n];

            // Update max_upto array similar to
            // finding next greater element
            Stack<int> s = new Stack<int>();
            s.Push(0);
            for (int i = 1; i < n; i++)
            {
                while (s.Count != 0 && a[s.Peek()] < a[i])
                {
                    max_upto[s.Peek()] = i - 1;
                    s.Pop();
                }
                s.Push(i);
            }
            while (s.Count != 0)
            {
                max_upto[s.Peek()] = n - 1;
                s.Pop();
            }
            int j = 0;
            for (int i = 0; i <= n - k; i++)
            {

                // j < i is to check whether the
                // jth element is outside the window
                while (j < i || max_upto[j] < i + k - 1)
                {
                    j++;
                }
                Console.Write(a[j] + " ");
            }
            Console.WriteLine();
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] a = { 9, 7, 2, 4, 6, 8, 2, 1, 5 };
            int n = a.Length;
            int k = 3;
            print_max(a, n, k);
            /*
             Output:
9 7 6 8 8 8 5
Complexity Analysis:

Time Complexity: O(n).
Only two traversal of the array is needed. So Time Complexity is O(n).
Space Complexity: O(n).
Two extra space of size n is required
            */
        }
    }
}
