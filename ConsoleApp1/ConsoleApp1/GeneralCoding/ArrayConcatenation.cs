using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/sum-of-the-first-m-elements-of-array-formed-by-infinitely-concatenating-given-array/
Sum of the first M elements of Array formed by infinitely concatenating given array
Difficulty Level : Easy
Last Updated : 28 Jun, 2021
Given an array arr[] consisting of N integers and a positive integer M, the task is to find the sum of the first M elements of the array formed by the infinite concatenation of the given array arr[].

Examples:

Input: arr[] = {1, 2, 3}, M = 5
Output: 9
Explanation:
The array formed by the infinite concatenation of the given array arr[] is of the form {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, … }.
The sum of the first M(= 5) elements of the array is 1 + 2 + 3 + 1 + 2 = 9.

Input: arr[] = {1}, M = 7
Output: 7

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The given problem can be solved by using the Modulo Operator (%) and consider the given array as the circular array and find the sum of the first M elements accordingly. Follow the steps below to solve this problem:



Initialize a variable, say sum as 0 to store the resultant sum of the first M elements of the new array.
Iterate over the range [0, M – 1] using the variable i and increment the value of sum by arr[i%N].
After completing the above steps, print the value of the sum as the result.
Below is the implementation of the above approach:
    */
    class ArrayConcatenation
    {
        static int sumOfFirstM(int[] A, int N, int M)
        {
            // Stores the resultant sum
            int sum = 0;

            // Iterate over the range [0, M - 1]
            for (int i = 0; i < M; i++)
            {

                // Add the value A[i%N] to sum
                sum = sum + A[i % N];
            }

            // Return the resultant sum
            return sum;
        }
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            int n = sumOfFirstM(arr, arr.Length, 5);
            Console.WriteLine(n);
            /*
             Output:
9
Time Complexity: O(M)
Auxiliary Space: O(1)
            b*/
        }
    }
}
