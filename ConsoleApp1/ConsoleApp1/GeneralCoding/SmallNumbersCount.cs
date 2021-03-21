using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Count of smaller or equal elements in sorted array
Difficulty Level : Easy
 Last Updated : 01 Feb, 2021
Given a sorted array of size n. Find number of elements which are less than or equal to given element.
Examples: 
 

Input : arr[] = {1, 2, 4, 5, 8, 10}
        key = 9
Output : 5
Elements less than or equal to 9 are 1, 2, 
4, 5, 8 therefore result will be 5.

Input : arr[] = {1, 2, 2, 2, 5, 7, 9}
        key = 2
Output : 4
Elements less than or equal to 2 are 1, 2, 
2, 2 therefore result will be 4. 
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Naive approach: Search whole array linearly and count elements which are less then or equal to key. 
Efficient approach: As the whole array is sorted we can use binary search to find result. 
Case 1: When key is present in array, the last position of key is the result.
Case 2: When key is not present in array, we ignore left half if key is greater than mid. If key is smaller than mid, we ignore right half. We always end up with case where key is present before middle element. 
    */
    class SmallNumbersCount
    {

        // A binary search function.
        // It returns number of elements
        // less than of equal to given key
        static int binarySearchCount(int[] arr,
                                     int n, int key)
        {
            int left = 0;
            int right = n;

            int mid = 0;
            while (left < right)
            {
                mid = (right + left) / 2;

                // Check if key is
                // present in array
                if (arr[mid] == key)
                {

                    // If duplicates are present
                    // it returns the position
                    // of last element
                    while (mid + 1 < n && arr[mid + 1] == key)
                        mid++;
                    break;
                }

                // If key is smaller,
                // ignore right half
                else if (arr[mid] > key)
                    right = mid;

                // If key is greater,
                // ignore left half
                else
                    left = mid + 1;
            }

            // If key is not found in array
            // then it will be before mid
            while (mid > -1 && arr[mid] > key)
                mid--;

            // Return mid + 1 because of
            // 0-based indexing of array
            return mid + 1;
        }


        /*
         Output
    6
    Although this solution performs better on average, the worst-case time complexity of this solution is still O(n).
    The above program can be implemented using a more simplified binary search. The idea is to check if the middle element is greater than the given element then update right index as mid – 1 but if the middle element is less than or equal to key update answer as mid + 1 and left index as mid + 1.

    Below is the implementation of the above approach:
        */
        static int binarySearchCount_op(int[] arr,
                                 int n, int key)
        {
            int left = 0;
            int right = n - 1;

            int count = 0;

            while (left <= right)
            {
                int mid = (right + left) / 2;

                // Check if middle element is
                // less than or equal to key
                if (arr[mid] <= key)
                {

                    // At least (mid + 1) elements are there
                    // whose values are less than
                    // or equal to key
                    count = mid + 1;
                    left = mid + 1;
                }

                // If key is smaller, 
                // ignore right half
                else
                    right = mid - 1;
            }
            return count;
        }
        //op 5
        static public void Main()
        {
            int[] arr = { 1, 2, 4, 5, 8, 10 };
            int key = 11;
            int n = arr.Length;
            Console.Write(binarySearchCount(arr, n, key));
        }
    }
}
