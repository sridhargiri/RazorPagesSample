using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class FindPairOfSum
    {
        // Returns number of pairs 
        // in arr[0..n-1] with sum 
        // equal to 'sum' 
        static void printPairs(int[] arr,
                               int n, int sum)
        {
            // int count = 0; 

            // Consider all possible pairs 
            // and check their sums 
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] + arr[j] == sum)
                        Console.Write("(" + arr[i] + ", " + arr[j] + ")" + "\n");
        }
        static void printPairs(int[] arr, int sum)
        {
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];
                //check condition
                if (s.Contains(temp))
                {
                    Console.Write("Pair with given sum " + sum + " is (" + arr[i] + ", " + temp + ")");
                }
                s.Add(arr[i]);
            }
        }
        static void printPairs_(int[] arr, int sum)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];
                //check condition
                if (arr.Contains(temp))
                {
                    Console.Write("Pair with given sum " + sum + " is (" + arr[i] + ", " + temp + ")");
                }
            }
        }
        /*
         Find all Pairs possible from the given Array
Difficulty Level : Easy
 Last Updated : 01 Apr, 2020
Given an array arr[] of N integers, the task is to find all the pairs possible from the given array.
Note:

(arr[i], arr[i]) is also considered as a valid pair.
(arr[i], arr[j]) and (arr[j], arr[i]) are considered as two different pairs.
Examples:

Input: arr[] = {1, 2}
Output: (1, 1), (1, 2), (2, 1), (2, 2).

Input: arr[] = {1, 2, 3}
Output: (1, 1), (1, 2), (1, 3), (2, 1), (2, 2), (2, 3), (3, 1), (3, 2), (3, 3)
Approach:
In order to find all the possible pairs from the array, we need to traverse the array and select the first element of the pair. Then we need to pair this element with all the elements in the array from index 0 to N-1.
        Below is the step by step approach:

Traverse the array and select an element in each traversal.
For each element selected, traverse the array with help of another loop and form the pair of this element with each element in the array from the second loop.
The array in the second loop will get executed from its first element to its last element, i.e. from index 0 to N-1.
Print each pair formed.
Below is the implementation of the above approach:

         */
        static void printAllPairs(int[] arr, int n)
        {

            // Nested loop for all possible pairs 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("(" + arr[i] + ", "
                         + arr[j] + ")"
                        + ", ");
                }
            }
        }
        /*
         Count of unique pairs (i, j) in an array such that sum of A[i] and reverse of A[j] is equal to sum of reverse of A[i] and A[j]
Last Updated : 12 Feb, 2021
Given an array arr[] consisting of N positive integers, the task is to find the count of unique pairs (i, j) such that the sum of arr[i] and the reverse(arr[j]) is same as the sum of reverse(arr[i]) and arr[j].

Examples:

Input: arr[] = {2, 15, 11, 7}
Output: 3
Explanation:
The pairs are (0, 2), (0, 3) and (2, 3).

(0, 2): arr[0] + reverse(arr[2]) (= 2 + 11 = 211) and reverse(arr[0]) + arr[2](= 2 + 11 = 211).
(0, 3): arr[0] + reverse(arr[3]) (= 2 + 7 = 27) and reverse(arr[0]) + arr[3](= 2 + 7 = 27).
(2, 3): arr[2] + reverse(arr[3]) (= 11 + 7 = 117) and reverse(arr[2]) + arr[3](= 11 + 7 = 117).
Input: A[] = {22, 115, 7, 313, 17, 23, 22}
Output: 6

Naive Approach: The simplest approach is to generate all possible pairs of the given array and if any pair of elements satisfy the given conditions then count these pairs. After completing the above stepsm, print the value of count as the result.
        Time Complexity: O(N2*log M), where M is the maximum element in A[]
Auxiliary Space: O(1)

Efficient Approach: The above approach can be optimized by using Hashing technique and rewriting the equation as:

A[i] + reverse(A[j]) = reverse(A[i]) + A[j]
=> A[i] – reverse(A[i]) = A[j] – reverse(A[j])

Now, the idea is to count the frequency of (A[i] – reverse(A[i])) for every element arr[i] and then count possible number of valid pairs satisfying the given condition. Follow the steps below to solve the problem:

Maintain a Hashmap, say u_map to store the frequency count of A[i] – reverse(A[i]) for any index i.
Initialize a variable pairs to store the number of pairs that satisfy the given condition.
Traverse the given array A[] using the variable i and perform the following operations:
Store the frequency of A[i] – reverse(A[i]) in val.
Increment pairs by val.
Update the frequency of val in u_map.
After completing the above steps, print the value of pairs as the result.
Below is the implementation of the above approach:
        */
        static int reverse(int n)
        {
            int temp = n, rev = 0, r;

            // Iterate until temp is 0 
            while (temp > 0)
            {

                r = temp % 10;
                rev = rev * 10 + r;
                temp /= 10;
            }

            // Return the reversed number 
            return rev;
        }

        // Function to count number of unique 
        // pairs (i, j) from the array A[] 
        // which satisfies the given condition 
        static void countPairs(int[] A, int N)
        {
            // Store the frequency of keys 
            // as A[i] - reverse(A[i]) 
            Dictionary<int, int> u_map = new Dictionary<int, int>();

            // Stores count of desired pairs 
            int pairs = 0;

            // Iterate the array A[] 
            for (int i = 0; i < N; i++)
            {

                int val = A[i] - reverse(A[i]);

                // Add frequency of val 
                // to the required answer 
                pairs += u_map[val];

                // Increment frequency of val 
                u_map[val]++;
            }
            Console.WriteLine(pairs);
        }
        // Driver Code 
        public static void Main()
        {
            int[] arr = { 8, 7, 2, 5, 3, 1 };// { 1, 5, 7, -1, 5 };
            int n = arr.Length;
            int sum = 10;
            printPairs(arr, n, sum);
            Console.WriteLine("---");
            arr = new int[] { 1, 4, 45,
                              6, 10, 8 };
            sum = 16;
            printPairs(arr, sum);
            Console.WriteLine("---");
            printPairs_(arr, sum);
            Console.WriteLine("---");


            arr = new int[2] { 1, 2 };
            printPairs(arr, arr.Length);
            arr = new int[4] { 2, 15, 11, 7 };
            countPairs(arr, arr.Length);
        }
    }
}
