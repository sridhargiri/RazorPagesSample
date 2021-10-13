using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class KthSmallestElement
    {
        /*
        https://www.geeksforgeeks.org/kth-smallestlargest-element-unsorted-array/
        Method 1 (Simple Solution) 
        A simple solution is to sort the given array using a O(N log N) sorting algorithm like Merge Sort, Heap Sort, etc and return the element at index k-1 in the sorted array. 
        Time Complexity of this solution is O(N Log N) 
        */
        public static int KthSmallest_1(int[] arr,
                                      int k)
        {

            // Sort the given array
            Array.Sort(arr);

            // Return k'th element in
            // the sorted array
            return arr[k - 1];
        }
        /*
         Method 4 (QuickSelect) 
This is an optimization over method 1 if QuickSort is used as a sorting algorithm in first step. 
        In QuickSort, we pick a pivot element, then move the pivot element to its correct position and partition the array around it. 
        The idea is, not to do complete quicksort, but stop at the point where pivot itself is k’th smallest element. Also, not to recur for both left and right sides of pivot, but recur for one of them according to the position of pivot. The worst case time complexity of this method is O(n2), but it works in O(n) on average.
        */

        public static int partition(int[] arr,
                                    int l, int r)
        {
            int x = arr[r], i = l;
            int temp = 0;
            for (int j = l; j <= r - 1; j++)
            {

                if (arr[j] <= x)
                {
                    // Swapping arr[i] and arr[j]
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    i++;
                }
            }

            // Swapping arr[i] and arr[r]
            temp = arr[i];
            arr[i] = arr[r];
            arr[r] = temp;

            return i;
        }

        // This function returns k'th smallest
        // element in arr[l..r] using QuickSort
        // based method. ASSUMPTION: ALL ELEMENTS
        // IN ARR[] ARE DISTINCT
        public static int kthSmallest(int[] arr, int l,
                                      int r, int k)
        {
            // If k is smaller than number
            // of elements in array
            if (k > 0 && k <= r - l + 1)
            {
                // Partition the array around last
                // element and get position of pivot
                // element in sorted array
                int pos = partition(arr, l, r);

                // If position is same as k
                if (pos - l == k - 1)
                    return arr[pos];

                // If position is more, recur for
                // left subarray
                if (pos - l > k - 1)
                    return kthSmallest(arr, l, pos - 1, k);

                // Else recur for right subarray
                return kthSmallest(arr, pos + 1, r,
                                   k - pos + l - 1);
            }

            // If k is more than number
            // of elements in array
            return int.MaxValue;
        }
        public static void Main()
        {
            int[] arr = { 12, 3, 5, 7, 4, 19, 26 };
            int k = 3;
            Console.Write("K'th smallest element is " + kthSmallest(arr, 0, arr.Length - 1, k));
            //Output: 
            //K'th smallest element is 5
        }
    }
    /*
     https://www.geeksforgeeks.org/to-find-smallest-and-second-smallest-element-in-an-array/
    Find the smallest and second smallest elements in an array
Difficulty Level : Basic
Last Updated : 08 Apr, 2021
Write an efficient C program to find smallest and second smallest element in an array.
Example: 
 



Input:  arr[] = {12, 13, 1, 10, 34, 1}
Output: The smallest element is 1 and 
        second Smallest element is 10
 

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
A Simple Solution is to sort the array in increasing order. The first two elements in sorted array would be two smallest elements. Time complexity of this solution is O(n Log n).
A Better Solution is to scan the array twice. In first traversal find the minimum element. Let this element be x. In second traversal, find the smallest element greater than x. Time complexity of this solution is O(n).
The above solution requires two traversals of input array. 
An Efficient Solution can find the minimum two elements in one traversal. Below is complete algorithm.
Algorithm: 
 

1) Initialize both first and second smallest as INT_MAX
   first = second = INT_MAX
2) Loop through all the elements.
   a) If the current element is smaller than first, then update first 
       and second. 
   b) Else if the current element is smaller than second then update 
    second
Implementation: 
     */
    public class SecondSmallest
    {

        /* Function to print first smallest
         and second smallest elements */
        static void print2Smallest(int[] arr)
        {
            int first, second, arr_size = arr.Length;

            /* There should be atleast two elements */
            if (arr_size < 2)
            {
                Console.Write(" Invalid Input ");
                return;
            }

            first = second = int.MaxValue;

            for (int i = 0; i < arr_size; i++)
            {
                /* If current element is smaller than first
                then update both first and second */
                if (arr[i] < first)
                {
                    second = first;
                    first = arr[i];
                }

                /* If arr[i] is in between first and second
                then update second */
                else if (arr[i] < second && arr[i] != first)
                    second = arr[i];
            }
            if (second == int.MaxValue)
                Console.Write("There is no second" +
                                "smallest element");
            else
                Console.Write("The smallest element is " +
                                first + " and second Smallest" +
                                " element is " + second);
        }

        /* Driver program to test above functions */
        public static void Main()
        {
            int[] arr = { 12, 13, 1, 10, 34, 1 };
            print2Smallest(arr);
            /*
             Output : 

The smallest element is 1 and second Smallest element is 10
The same approach can be used to find the largest and second largest elements in an array.
Time Complexity: O(n)
            */
        }
    }
}
