using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/find-repeating-element-sorted-array-size-n/
     Find the only repeating element in a sorted array of size n
Difficulty Level : Easy
Last Updated : 28 Jun, 2021
Given a sorted array of n elements containing elements in range from 1 to n-1 i.e. one element occurs twice, the task is to find the repeating element in an array.
Examples : 
 

Input :  arr[] = { 1, 2 , 3 , 4 , 4}
Output :  4

Input :  arr[] = { 1 , 1 , 2 , 3 , 4}
Output :  1
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
A naive approach is to scan the whole array and check if an element occurs twice, then return. This approach takes O(n) time.
An efficient method is to use Binary Search . 
1- Check if the middle element is the repeating one. 
2- If not then check if the middle element is at proper position if yes then start searching repeating element in right. 
3- Otherwise the repeating one will be in left.
    */
    class RepeatingElement
    {
        // Returns index of second appearance of a
        // repeating element. The function assumes that
        // array elements are in range from 1 to n-1.
        static int findRepeatingElement(int[] arr, int low,
                                                  int high)
        {
            // low = 0 , high = n-1;
            if (low > high)
                return -1;

            int mid = (low + high) / 2;

            // Check if the mid element
            // is the repeating one
            if (arr[mid] != mid + 1)
            {
                if (mid > 0 && arr[mid] == arr[mid - 1])
                    return mid;

                // If mid element is not at its position
                // that means the repeated element is in left
                return findRepeatingElement(arr, low, mid - 1);
            }

            // If mid is at proper position
            // then repeated one is in right.
            return findRepeatingElement(arr, mid + 1, high);
        }

        // Driver method
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 3, 4, 5 };
            int index = findRepeatingElement(arr, 0, arr.Length - 1);
            if (index != -1)
                Console.Write(arr[index]);
            /*
             Output : 3
Time Complexity : O(log n)
            */
        }
    }
}
