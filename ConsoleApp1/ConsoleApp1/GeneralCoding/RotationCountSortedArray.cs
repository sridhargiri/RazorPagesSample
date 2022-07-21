using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-rotation-count-rotated-sorted-array/
    Tekion
    */
    public class RotationCountSortedArray
    {
        // Returns count of rotations for an
        // array which is first sorted in
        // ascending order, then rotated

        /*
         Method 1 (Using linear search)
If we take closer look at examples, we can notice that the number of rotations is equal to index of minimum element. A simple linear solution is to find minimum element and returns its index. 

Below is implementation of the above idea.
        Output
2
Time Complexity : O(n) 
Auxiliary Space : O(1) 
        */
        static int countRotations_linearsearch(int[] arr, int n)
        {
            // We basically find index of minimum
            // element
            int min = arr[0], min_index = 0;
            for (int i = 0; i < n; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                    min_index = i;
                }
            }
            return min_index;
        }
        /*
         Method 2 (Efficient Using Binary Search) 
Here also we find the index of minimum element, but using Binary Search. The idea is based on the below facts : 
 

The minimum element is the only element whose previous is greater than it. If there is no previous element, then there is no rotation (first element is minimum). We check this condition for middle element by comparing it with (mid-1)’th and (mid+1)’th elements.
If the minimum element is not at the middle (neither mid nor mid + 1), then minimum element lies in either left half or right half. 
If middle element is smaller than last element, then the minimum element lies in left half
Else minimum element lies in right half.
Below is the implementation taken from here. 
        https://www.geeksforgeeks.org/find-minimum-element-in-a-sorted-and-rotated-array/
        Output
2
Time Complexity : O(Log n) 
Auxiliary Space : O(Log n) 
        */
        static int countRotations_binarysearch(int[] arr, int low, int high)
        {
            // This condition is needed to handle
            // the case when array is not rotated
            // at all
            if (high < low)
                return 0;

            // If there is only one element left
            if (high == low)
                return low;

            // Find mid
            // /*(low + high)/2;*/
            int mid = low + (high - low) / 2;

            // Check if element (mid+1) is minimum
            // element. Consider the cases like
            // {3, 4, 5, 1, 2}
            if (mid < high && arr[mid + 1] < arr[mid])
                return (mid + 1);

            // Check if mid itself is minimum element
            if (mid > low && arr[mid] < arr[mid - 1])
                return mid;

            // Decide whether we need to go to left
            // half or right half
            if (arr[high] > arr[mid])
                return countRotations_binarysearch(arr, low, mid - 1);

            return countRotations_binarysearch(arr, mid + 1, high);
        }

        // Returns count of rotations
        // for an array which is first sorted
        // in ascending order, then rotated

        // Observation: We have to return
        // index of the smallest element
        static int countRotations_Iterative(int[] arr, int n)
        {
            int low = 0, high = n - 1;
            while (low <= high)
            {

                // if first element is mid or
                // last element is mid
                // then simply use modulo so it
                // never goes out of bound.
                int mid = low + (high - low) / 2;
                int prev = (mid - 1 + n) % n;
                int next = (mid + 1) % n;

                if (arr[mid] <= arr[prev]
                    && arr[mid] <= arr[next])
                    return mid;
                else if (arr[mid] <= arr[high])
                    high = mid - 1;
                else if (arr[mid] >= arr[low])
                    low = mid + 1;
            }
            return 0;
        }
        // Driver program to test above functions
        public static void Main()
        {
            int[] arr = { 15, 18, 2, 3, 6, 12 };
            int n = arr.Length;

            Console.WriteLine(countRotations_linearsearch(arr, n));
        }
    }
}
