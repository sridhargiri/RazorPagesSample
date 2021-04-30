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
}
