using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * https://www.geeksforgeeks.org/count-smaller-elements-present-in-the-array-for-each-array-element/
     * Count smaller elements present in the array for each array element
Last Updated : 17 Mar, 2021
Given an array arr[] consisting of N integers, the task is for each array element, say arr[i], is to find the number of array elements that are smaller than arr[i].

Examples:

Input: arr[] = {3, 4, 1, 1, 2}
Output: 3 4 0 0 2
Explanation:
The elements which are smaller than arr[0](= 3) are {1, 1, 2}. Hence, the count is 3.
The elements which are smaller than arr[1](= 4) are {1, 1, 2, 3}. Hence, the count is 4.
The elements arr[2](= 1) and arr[3](= 1) are the smallest possible. Hence, the count is 0.
The elements which are smaller than arr[4](= 2) are {1, 1}. Hence, the count is 2.

Input: arr[] = {1, 2, 3, 4}
Output: 0 1 2 3

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach: The simplest approach is to traverse the array and for each array element, count the number of array elements that are smaller than them and print the counts obtained.




Below is the implementation of the above approach:
    */
    class SmallerNumber
    {
        // Function to count for each array
        // element, the number of elements
        // that are smaller than that element
        static void smallerNumbers(int[] arr, int N)
        {

            // Traverse the array
            for (int i = 0; i < N; i++)
            {

                // Stores the count
                int count = 0;

                // Traverse the array
                for (int j = 0; j < N; j++)
                {

                    // Increment count
                    if (arr[j] < arr[i])
                    {
                        count++;
                    }
                }

                // Print the count of smaller
                // elements for the current element
                Console.WriteLine(count + " ");
            }
        }
        /*
         Output: 
3 4 0 0 2
 

Time Complexity: O(N2)
Auxiliary Space: O(1)

Efficient Approach: The above approach can be optimized by using Hashing. Follow the steps below to solve the problem:

Initialize an auxiliary array hash[] of size 105 and initialize all array elements with 0 to store the frequency of each array element.
Traverse the given array arr[] and increment the frequency of arr[i] by 1 in the array hash[] as hash[arr[i]]++.
Find the prefix sum of the array hash[].
Again, traverse the given array and for each array element arr[], print the value of hash[arr[i] – 1] as the count of smaller elements.
Below is the implementation of the above approach:
        */
        static void smallerNumbers_optim(int[] arr, int N)
        {

            // Stores the frequencies
            // of array elements
            int[] hash = new int[100000];

            // Traverse the array
            for (int i = 0; i < N; i++)

                // Update frequency of arr[i]
                hash[arr[i]]++;

            // Initialize sum with 0
            int sum = 0;

            // Compute prefix sum of the array hash[]
            for (int i = 1; i < 100000; i++)
            {
                hash[i] += hash[i - 1];
            }

            // Traverse the array arr[]
            for (int i = 0; i < N; i++)
            {

                // If current element is 0
                if (arr[i] == 0)
                {
                    Console.WriteLine("0");
                    continue;
                }

                // Print the resultant count
                Console.WriteLine(hash[arr[i] - 1] + " ");
            }
        }
        /*
         Output: 
3 4 0 0 2
 

Time Complexity: O(N)
Auxiliary Space: O(105)
        */
        public static void main(String[] args)
        {
            int[] arr = { 3, 4, 1, 1, 2 };
            int N = arr.Length;

            smallerNumbers(arr, N);
        }
    }
}

