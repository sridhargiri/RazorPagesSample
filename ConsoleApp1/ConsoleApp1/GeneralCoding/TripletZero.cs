using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TripleZero
    {
        /*
         Find all triplets with zero sum
Difficulty Level : Medium
 Last Updated : 30 Mar, 2020
Given an array of distinct elements. The task is to find triplets in the array whose sum is zero.

Examples :

Input : arr[] = {0, -1, 2, -3, 1}
Output : (0 -1 1), (2 -3 1)

Explanation : The triplets with zero sum are
0 + -1 + 1 = 0 and 2 + -3 + 1 = 0  

Input : arr[] = {1, -2, 1, 0, 5}
Output : 1 -2  1
Explanation : The triplets with zero sum is
1 + -2 + 1 = 0   

Method 1: This is a simple method that takes O(n3) time to arrive at the result.

Approach: The naive approach run three loops and check one by one that sum of three elements is zero or not.
        If the sum of three elements is zero then print elements otherwise print not found.
Algorithm:
Run three nested loops with loop counter i, j, k
The three loops will run from 0 to n-3 and second loop from i+1 to n-2 and the third loop from j+1 to n-1. The loop counter represents the three elements of the triplet.
check if the sum of elements at i’th, j’th, k’th is equal to zero or not. If yes print the sum else continue.
Implementation:
        */
        static void findTriplets(int[] arr, int n)
        {
            bool found = true;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == 0)
                        {
                            Console.WriteLine(arr[i] + " "
                                 + arr[j] + " "
                                 + arr[k]);
                            found = true;
                        }
                    }
                }
            }

            // If no triplet with 0 sum found in array 
            if (found == false)
                Console.WriteLine(" not exist ");

        }
        /*
         
         Method 2: The second method uses the process of Hashing to arrive at the result and is solved at a lesser time of O(n2).

Approach: This involves traversing through the array. For every element arr[i], find a pair with sum “-arr[i]”. 
        This problem reduces to pairs sum and can be solved in O(n) time using hashing.
Algorithm:
Create a hashap to store a key value pair.
Run a nested loop with two loops, outer loop from 0 to n-2 and the inner loop from i+1 to n-1
Check if the sum of ith and jth element multiplied with -1 is present in the hashmap or not
If the element is present in the hashmap, print the triplet else insert the j’th element in the hashmap.
        */
        static void findTriplets1(int[] arr, int n)
        {
            bool found = false;

            for (int i = 0; i < n - 1; i++)
            {
                // Find all pairs with sum equals to 
                // "-arr[i]" 
                HashSet<int> s = new HashSet<int>();
                for (int j = i + 1; j < n; j++)
                {
                    int x = -(arr[i] + arr[j]);
                    if (s.Contains(x))
                    {
                        Console.Write("{0} {1} {2}\n", x, arr[i], arr[j]);
                        found = true;
                    }
                    else
                    {
                        s.Add(arr[j]);
                    }
                }
            }

            if (found == false)
            {
                Console.Write(" No Triplet Found\n");
            }
        }

        // Driver code 
        public static void Main(String[] args)
        {
            int[] arr = { 0, -1, 2, -3, 1 };
            int n = arr.Length;
            findTriplets(arr, n);
            findTriplets1(arr, n);
        }
    }
}
