using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-the-next-non-zero-array-element-to-the-right-of-each-array-element/
    Find the next non-zero Array element to the right of each array element
    Given an array arr[] of N integers, the task is to find the next non-zero array element to the right of every array element. If there doesn’t exist any non-zero element, then print that element itself.

Examples:
    Input: arr[] = {1, 2, 0}
Output: {2, 2, 0}
Explanation:
For each array element the next non-zero elements are:
arr[0] = 1 -> 2
arr[1] = 2 -> 2(as there doesn’t exist any non-zero element)
arr[2] = 0 -> 0(as there doesn’t exist any non-zero element)



Input: arr[] = {1, 0, 0, 3}
Output: {3, 3, 3, 3}

Approach: The simple approach to this problem is to traverse the given array from the end, keep track of the variable for each non-zero element obtained while traversing, and replace the integer in the array with that variable. Follow the below steps to solve the given problem:

Create a variable, say tempValid, to keep track of the valid integer and initialize it to -1.
Create an array result[] that stores the next non-zero array element to the right of every array element.
Iterate the array from the end from index N – 1 to 0 and if the value of tempValid is -1, then assign the next non-zero element for the current index as the number itself i.e., arr[i]. Otherwise, update the value of result[i] as tempValid.
After completing the above steps, print the array result[] as the result.
Below is the implementation of the above approach:
     */
    class RightNext
    {
        static void RightNextValidInteger(int[] arr, int N)
        {

            // Stores the resultant array
            int[] result = new int[N];

            // Keeps the track of next non-zero
            // element for each array element
            int tempValid = -1;

            // Iterate the array from right to left
            // and update tempValid
            for (int i = N - 1; i >= 0; i--)
            {

                // If tempValid is -1, the valid
                // number at current index is the
                // number itself
                if (tempValid == -1)
                {
                    result[i] = arr[i];
                }
                else
                {
                    result[i] = tempValid;
                }

                // Update tempValid if the
                // current element is non-zero
                if (arr[i] != 0)
                {
                    tempValid = arr[i];
                }
            }

            // Print the result
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 0, 2, 4, 5, 0 };
            RightNextValidInteger(arr, arr.Length);
            /*
             Output:
2 2 2 4 5 5 0
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
