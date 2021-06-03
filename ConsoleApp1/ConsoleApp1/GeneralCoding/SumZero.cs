using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/find-the-element-whose-multiplication-with-1-makes-array-sum-0/?ref=rp
     Find the element whose multiplication with -1 makes array sum 0
Last Updated : 04 May, 2021
Given an array of N integers. The task is to find the smallest index of an element such that when multiplied by -1 the sum of whole array becomes 0. If there is no such index return -1.
Examples: 
 

Input : arr[] = {1, 3, -5, 3, 4}
Output : 2

Input : arr[] = {5, 3, 6, -7, -4}
Output : -1
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach :
The simple solution will be to take each element, multiply it by -1 and check if the new sum is 0. This algorithm works in O(N2).
Efficient Approach :
If we take S as our initial sum of the array and we multiply current element Ai by -1 then the new sum will become S – 2*Ai and this should be equal to 0. So when for the first time S = 2*Ai then the current index is our required and if no element satisfies the condition then our answer will be -1. The time complexity of this algorithm is O(N).
Below is the implementation of the above idea :
    */
    class SumZero
    {

        // Function to find minimum index
        // such that sum becomes 0 when the
        // element is multiplied by -1
        static int minIndex(int[] arr, int n)
        {
            // Find array sum
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            // Find element with value equal to sum/2
            for (int i = 0; i < n; i++)
            {

                // when sum is equal to 2*element
                // then this is our required element
                if (2 * arr[i] == sum)
                    return (i + 1);
            }

            return -1;
        }

        // Driver code


        public static void Main()
        {
            int[] arr = { 1, 3, -5, 3, 4 };
            int n = arr.Length;
            Console.Write(minIndex(arr, n));//op 2
        }
    }
}
