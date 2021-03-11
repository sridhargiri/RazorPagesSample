using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find the player who wins the game of placing alternate + and – signs in front of array elements
Last Updated : 10 Mar, 2021
Given an array arr[] of length, N, the task is to find the winner of a game played by two players A and B optimally, by performing the following operations:

Player A makes the first move.
Players need to alternately place + and – sign in front of array elements in their turns.
After having placed signs in front of all array elements, player A wins if the difference of all the elements is even.
Otherwise, player B wins.
Examples:

Input: arr[] = {1, 2}
Output: B
Explanation:
All possible ways the game can be played out are:
(+1) – (+2) = -1 
(−1) – (+2) = -3 
(+1) – (-2) = 3 
(-1) – (-2) = 1
Since the differences are odd in all the possibilities, B wins.

Input: arr[] = {1, 1, 2}
Output: A
Explanation: 
All possible ways the game can be played out are:
(1) – (1) – (2) = -2 
(1) – (1) – (-2) = 2
(1) – (-1) – (2) = 0
(1) – (-1) – (-2) = 4
(-1) – (1) – (2) = -4
(-1) – (1) – (-2) = 0
(-1) – (-1) – (2) = -2
(-1) – (-1) – (-2) = 4
Since the differences are even in all the possibilities, A wins.

Naive Approach: The simplest approach is to generate all the possible 2N combinations in which the signs can be placed in the array and check for each combination, check if player A can win or not. If found to be true for any permutation, then print A. Otherwise, player B wins.
Time Complexity: O(2N * N)
Auxiliary Space: O(1)

Efficient Approach: Follow the steps below to optimize the above approach:




Initialize a variable, say diff, to store the sum of the array elements.
Traverse the array arr[], over the range of indices [1, N], and update diff by subtracting arr[i] to it. 
If diff % 2 is found to be equal to 0, then print ‘A’. Otherwise, print ‘B’.
Below is the implementation of the above approach:
    */
    class WinnerPlusMinus
    {
        static void checkWinner(int[] arr, int N)
        {
            // Stores the difference between 
            // +ve and -ve array elements 
            int diff = 0;

            // Traverse the array 
            for (int i = 0; i < N; i++)
            {
                // Update diff 
                diff -= arr[i];
            }

            // Checks if diff is even 
            if (diff % 2 == 0)
            {
                Console.WriteLine("A");
            }
            else
            {
                Console.WriteLine("B");
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2 }; checkWinner(arr, arr.Length);
        }
        /*
         Output:
B
Time Complexity: O(N)
Auxiliary Space: O(1)
        */
    }
}
