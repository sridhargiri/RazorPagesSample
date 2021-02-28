using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if an array element is concatenation of two elements from another array

Given two arrays arr[] and brr[] consisting of N and M positive integers respectively, the task is to find all the elements from the array brr[] which are equal to the concatenation of any two elements from the array arr[]. If no such element exists, then print “-1”.

Examples:

Input: arr[] = {2, 34, 4, 5}, brr[] = {26, 24, 345, 4, 22}
Output: 24 345 22
Explanation:
The elements from the array brr[] which are concatenation of any two elements from the array arr[] are: 

24 is concatenation of 2 and 4.
345 is concatenation of 34 and 5.
22 is concatenation of 2 and 2.
Input: arr[] = {1, 2, 3}, brr[] = {1, 23}
Output: 23

Naive Approach: The simplest approach to solve the problem is to generate all possible pairs from the given array and check if the concatenation of pairs of elements from the array arr[] is present in the array brr[] or not. If found to be true, then print the concatenated number formed. 




Time Complexity: O(M * N2)
Auxiliary Space: O(N2)

Efficient Approach: The above approach can be optimized by checking for each element in the array brr[], whether brr[i] can be divided into 2 parts left and right such that both the parts exists in the array arr[].

Consider a number, b[i] = 2365
All possible combinations of left and right are:
Left              Right
2                  365
23                  65
236                 5

Follow the steps below to solve the problem:

Initialize a HashMap M and store all elements present in the array arr[].
Traverse the array brr[] and perform the following steps:
Generate all possible combinations of left and right parts, such that their concatenation results to brr[i].
If both the left and the right parts are present in Map M in one of the above combinations, then print the value of brr[i]. Otherwise, continue to the next iteration.
Below is the implementation of the above approach:
    
     */
    class ArrayElementConcatenation
    {
        static void findConcatenatedNumbers(List<int> a, List<int> b)
        {
            // Stores if there doesn't any such
            // element in the array brr[]
            bool ans = true;

            // Stored the size of both the arrays
            int n1 = a.Count;
            int n2 = b.Count;

            // Store the presence of an element
            // of array a[]
            Dictionary<int, int> cnt = new Dictionary<int, int>();

            // Traverse the array a[]
            for (int i = 0; i < n1; i++)
            {
                cnt[a[i]] = 1;
            }

            // Traverse the array b[]
            for (int i = 0; i < n2; i++)
            {

                int left = b[i];
                int right = 0;
                int mul = 1;

                // Traverse over all possible
                // concatenations of b[i]
                while (left > 9)
                {

                    // Update right and left parts
                    right += (left % 10) * mul;
                    left /= 10;
                    mul *= 10;

                    // Check if both left and right
                    // parts are present in a[]
                    if (cnt[left] == 1
                        && cnt[right] == 1)
                    {
                        ans = false;
                        Console.WriteLine(b[i] + " ");
                    }
                }
            }

            if (ans)
                Console.WriteLine(-1);
        }
        public static void Main(string[] args)
        {
            List<int> a = new List<int> { 2, 34, 4, 5 };
            List<int> b = new List<int> { 26, 24, 345, 4, 22 };
            findConcatenatedNumbers(a, b);
        }
        /*
         Output: 
24 345 22
 

Time Complexity: O(M*log(X)), where X is the largest element in the array brr[].
Auxiliary Space: O(N)
        */
    }
}
