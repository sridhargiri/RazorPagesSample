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
    /*
     https://www.geeksforgeeks.org/concatenate-given-array-twice/
    Concatenate given array twice
Last Updated : 26 Jan, 2022
Given an array arr[] of N elements, the task is to concatenate it twice, i.e. create an array of size 2*N by appending the copy of the given array to itself.

Example:

Input: arr[] = {1, 2, 1}
Output: 1 2 1 1 2 1
Explantation: The given array arr[] = {1, 2, 1}, can be appended to itself resulting in arr[] = {1, 2, 1, 1, 2, 1}.

Input: arr[] = {1, 3, 2, 1}
Output: 1 3 2 1 1 3 2 1

Approach: The given problem is an implementation-based problem. It can be solved by creating a array newArr[] of size 2*N. 
    Iterate the given array arr[] using a variable i in the range [0, N) and append the assign newArr[i] = arr[i] and newArr[i + N] = arr[i].

Below is the implementation of the above approach
     */
    public class AppendArray
    {

        static void ConcatArrayTwice(int[] arr, int N)
        {
            // Stores array after
            // concatination
            int[] newArr = new int[2 * N];

            // Loop to iterate arr[]
            for (int i = 0; i < N; i++)
            {
                newArr[i] = arr[i];
                newArr[i + N] = arr[i];
            }

            // Print Answer
            for (int i = 0; i < 2 * N; i++)
            {
                Console.WriteLine(newArr[i]);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 }; ConcatArrayTwice(arr, arr.Length);
            /*
             Output
1 2 3 1 2 3 
Time Complexity: O(N)
Auxiliary Space: O(N)
            */
        }
    }
}
