using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
Techiedelight ->  Count occurrences of a number in a sorted array with duplicates


Input:  A[] = [2, 5, 5, 5, 6, 6, 8, 9, 9, 9]
target = 5
 
Output: Element 5 occurs 3 times
 
 
Input:  A[] = [2, 5, 5, 5, 6, 6, 8, 9, 9, 9]
target = 6
 
Output: Element 6 occurs 2 times
O(n logn) no extra space




     */
    class BinarySearchVariety
    {
        // Function to find the first or last occurrence of a given number in
        // a sorted integer array. If `searchFirst` is true, return the
        // first occurrence of the number; otherwise, return its last occurrence.
        public static int binarySearch(int[] A, int x, Boolean searchFirst)
        {
            // search space is `A[left…right]`
            int left = 0;
            int right = A.Length - 1;

            // initialize the result by -1
            int result = -1;

            // loop till the search space is exhausted
            while (left <= right)
            {
                // find the mid-value in the search space and compares it with the target
                int mid = (left + right) / 2;

                // if the target is found, update the result
                if (x == A[mid])
                {
                    result = mid;

                    // go on searching towards the left (lower indices)
                    if (searchFirst)
                    {
                        right = mid - 1;
                    }
                    // go on searching towards the right (higher indices)
                    else
                    {
                        left = mid + 1;
                    }
                }

                // if the target is less than the middle element, discard the right half
                else if (x < A[mid])
                {
                    right = mid - 1;
                }
                // if the target is more than the middle element, discard the left half
                else
                {
                    left = mid + 1;
                }
            }

            // return the found index or -1 if the element is not found
            return result;
        }

        public static void main(String[] args)
        {
            int[] A = { 2, 5, 5, 5, 6, 6, 8, 9, 9, 9 };
            int key = 5;

            // pass true for the first occurrence
            int first = binarySearch(A, key, true);

            // pass false for the last occurrence
            int last = binarySearch(A, key, false);

            int c = last - first + 1;

            if (first != -1)
            {
                Console.WriteLine("Element " + key + " occurs " + c + " times");
            }
            else
            {
                Console.WriteLine("Element not found in the array");
            }
        }
    }
    /*
     https://www.geeksforgeeks.org/count-of-elements-that-are-binary-searchable-in-the-given-array/
    Count of elements that are binary searchable in the given array
    Given an array arr[] consisting of N integers, the task is to find the maximum count of integers that are binary searchable in the given array.

Examples:

Input: arr[] = {1, 3, 2}
Output: 2
Explanation: arr[0], arr[1] can be found.

Input: arr[] = {3, 2, 1, 10, 23, 22, 21}
Output: 3
Explanation: arr[1], arr[3], arr[5] can be found using binary search irrespective of whether the array is sorted or not.
    Approach: The given problem can be solved by searching for each element separately in the array using the Binary Search approach and increment the count of those integers that exist in the array. Follow the below steps to solve the problem:



Make a variable count = 0, that will store the count of elements that are binary searchable.
For each element perform the binary search in the range [0, N) as:
Initialize the variable l as 0 and r as N-1 and perform the binary search for arr[i].
For each iteration of the while loop till l is less than equal to r, calculate the mid-value denoted by (l + r)/2.
If arr[mid] equals arr[i] then increment count by 1.
If arr[mid] is less than arr[i], then change l as mid + 1.
Otherwise, change r as mid – 1.
The final answer will be stored in the variable count.
Below is the implementation of the above approach:
     */
    public class BinarySeacrhable
    {
        static int totalBinarySearchable(List<int> arr)
        {

            // Stores the count of element that
            // are binary searchable
            int count = 0;
            int N = arr.Count;

            // For each element check if it can
            // be found by doing a binary search
            for (int i = 0; i < N; i++)
            {

                // Binary search range
                int l = 0, r = N - 1;

                // Do a binary Search
                while (l <= r)
                {
                    int mid = (l + r) / 2;

                    // Array element found
                    if (arr[mid] == arr[i])
                    {
                        count++;
                        break;
                    }
                    if (arr[mid] < arr[i])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
            }

            // Return the total count
            return count;
        }
        public static void Main(string[] args)
        {
            List<int> arr = new List<int>() { 3, 2, 1, 10,
                        23, 22, 21 };
            Console.WriteLine(totalBinarySearchable(arr));
            /*
             Output: 3

Time Complexity: O(N*log(N))
Auxiliary Space: O(1)
            */
        }

    }
}
