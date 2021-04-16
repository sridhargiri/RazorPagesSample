using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimum-number-swaps-required-sort-array/
    Minimum number of swaps required to sort an array
    given an array of n distinct elements, find the minimum number of swaps required to sort the array.

Examples: 

Input : {4, 3, 2, 1}
Output : 2
Explanation : Swap index 0 with 3 and 1 with 2 to 
              form the sorted array {1, 2, 3, 4}.

Input : {1, 5, 4, 3, 2}
Output : 2

     */
    class MinswapsSortArray
    {

        /*
         Straight forward solution


While iterating over the array, check the current element, and if not in the correct place, replace that element with the index of the element which should have come in this place.
        */

        static int minSwaps(int[] arr, int N)
        {
            int ans = 0;
            int[] temp = new int[N];
            Array.Copy(arr, temp, N);
            Array.Sort(temp);
            for (int i = 0; i < N; i++)
            {

                // This is checking whether
                // the current element is
                // at the right place or not
                if (arr[i] != temp[i])
                {
                    ans++;

                    // Swap the current element
                    // with the right index
                    // so that arr[0] to arr[i] is sorted
                    swap(arr, i, indexOf(arr, temp[i]));
                }
            }
            return ans;
        }

        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        static int indexOf(int[] arr, int ele)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ele)
                {
                    return i;
                }
            }
            return -1;
        }

        // Driver program to test
        // the above function
        static public void Main()
        {
            int[] a
                = { 101, 758, 315, 730, 472,
                         619, 460, 479 };
            int n = a.Length;
            // Output will be 5
            Console.WriteLine(minSwaps(a, n));
            /*
             Output:

5
Time Complexity: O(n*n) 
Auxiliary Space: O(n)
             */
        }
    }
}
