using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/last-duplicate-element-sorted-array/
    Last duplicate element in a sorted array
Difficulty Level : Basic
Last Updated : 07 Apr, 2021
We have a sorted array with duplicate elements and we have to find the index of last duplicate element and print index of it and also print the duplicate element. If no such element found print a message. 
Examples: 
 

Input : arr[] = {1, 5, 5, 6, 6, 7}
Output :
Last index: 4
Last duplicate item: 6

Input : arr[] = {1, 2, 3, 4, 5}
Output : No duplicate found
    We simply iterate through the array in reverse order and compare the current and previous element. 
    If a match is found then we print the index and duplicate element. As this is sorted array it will be the last duplicate. If no such element is found we will print the message for it.
 

1- for i = n-1 to 0
     if (arr[i] == arr[i-1])
        Print current element and its index.
        Return
2- If no such element found print a message 
   of no duplicate found.
     */
    public class LastDuplicate
    {

        static void duplicateLast(int[] arr, int n)
        {

            // if array is null or size is less
            // than equal to 0 return
            if (arr == null || n <= 0)
                return;

            // compare elements and return last
            // duplicate and its index
            for (int i = n - 1; i > 0; i--)
            {
                if (arr[i] == arr[i - 1])
                {
                    Console.WriteLine("Last index:" + i);
                    Console.WriteLine("Last duplicate item: "
                                    + arr[i]);
                    return;
                }
            }

            // If we reach here, then no duplicate
            // found.
            Console.WriteLine("no duplicate found");
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 1, 5, 5, 6, 6, 7, 9 };
            int n = arr.Length;

            duplicateLast(arr, n);
            /*
             Output: 
Last index: 4
Last duplicate item: 6
            */
        }
    }
}
