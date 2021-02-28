using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find a triplet (i, j, k) from an array such that i < j < k and arr[i] < arr[j] > arr[k]

Given an array arr[] which consists of a permutation of first N natural numbers, the task is to find any triplet (i, j, k) from the given array such that 0 ≤ i < j < k ≤ (N – 1) and arr[i] < arr[j] and arr[j] > arr[k]. If no such triplet exists, then print “-1”.

Examples:

Input: arr[] = {4, 3, 5, 2, 1, 6}
Output: 1 2 3
Explanation: For the triplet (1, 2, 3), arr[2] > arr[1]( i.e. 5 > 3) and arr[2] > arr[3]( i.e. 5 > 2).

Input: arr[] = {3, 2, 1}
Output: -1

Naive Approach: The simplest approach is to generate all possible triplets from the given array arr[] and if there exists any such triplet that satisfies the given condition, then print that triplet. Otherwise, print “-1”.
Time Complexity: O(N3)
Auxiliary Space: O(1)

Efficient Approach: The above approach can be optimized by observing the fact that the array contains only distinct elements from the range [1, N]. If there exist any triplet with the given criteria, then that triplet must be adjacent to each other.




Therefore, the idea is to traverse the given array arr[] over the range [1, N – 2] and if there exist any index i such that arr[i – 1] < arr[i] and arr[i] > arr[i + 1], then print the triplet (i – 1, i, i + 1) as the result. Otherwise, print “-1”.

Below is the implementation of the above approach:
     */
    class TripletArray
    {
        static void print_triplet(int[] arr, int n)
        {
            // Traverse the array 
            for (int i = 1; i <= n - 2; i++)
            {

                // Condition to satisfy for 
                // the resultant triplet 
                if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1])
                {

                    Console.WriteLine($"{i - 1} {i} {i + 1}");
                }
            }
            Console.WriteLine(-1);
        }

        // Driver Code 
        public static void Main(string[] args)
        {
            int[] arr = { 4, 3, 5, 2, 1, 6 };
            print_triplet(arr, arr.Length);

        }
        //        Output:
        //1 2 3
        //Time Complexity: O(N)
        //Auxiliary Space: O(1)
    }
}
