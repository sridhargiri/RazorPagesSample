using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/count-characters-of-a-string-which-when-removed-individually-makes-the-string-equal-to-another-string/
Count characters of a string which when removed individually makes the string equal to another string
Difficulty Level : Hard
Last Updated : 11 Jun, 2021
Given two strings A and B of size N and M respectively, the task is to count characters of the string A, which when removed individually makes both the strings equal. If there exists several such characters, then print their respective positions. Otherwise, print “-1”.

Examples:

Input: A = “abaac”, B = “abac”
Output: 2
             3 4
Explanation: 
Following removals are possible that can make the strings equal:

Removing A[2] modifies A to “abac”, which becomes equal to B.
Removing A[3] modifies A to “abac”, which becomes equal to B.
Therefore, two possible removals satisfy the conditions.

Input: A = “abs”, B = “bkk”
Output: -1



Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The given problem can be solved based on the following observations: 

Suppose, if removing the character at index i, makes both strings equal then the prefix of the string i.e substring over the range [0, i-1] must be equal and the suffix of the string i.e substring over the range [i+1, N-1] must be equal too.
Suppose i is the index satisfying that the substring over the range [0, i-1] is the longest equal prefix string. And j is the index satisfying that the substring over the range [j+1, N-1] is the longest equal suffix string
Then, if i>=j then only, there exist characters removing which makes the both strings equal. And total count of such characters removing which individually makes the strings equal is i-j+1.
Follow the steps below to solve the problem:

Initialize two variables say X as 0 and Y as N-1 to store the ending index of the longest equal prefix string and starting index of the longest equal suffix string.
Iterate the over the characters of the string B and then in each iteration check if the current character is equal to the character at index X of the string A, then increment X by 1. Otherwise, break.
Iterate the over the characters of the string B in reverse and then in each iteration check if the current character is equal to the character at index Y of the string A, then decrement Y by 1. Otherwise, break.
Now if the difference between N and M is equal to 1 and Y is less than the X then:
Print the total count of such characters as X-Y+1.
Then print the indices of the character by iterating over the range [Y+1, X+1].
Otherwise, print “-1”.
Below is the implementation of the above approach:
     */
    class RemoveOneCharacter
    {
        // Function to count characters
        // from string A whose removal
        // makes the strings A and B equal
        static void RemoveOneChar(string A, string B,
                           int N, int M)
        {
            // Stores the index of
            // the longest prefix
            int X = 0;

            // Stores the index of
            // the longest suffix
            int Y = N - 1;

            // Traverse the string B
            for (int i = 0; i < M; i++)
            {
                if (A[X] != B[i])
                    break;
                X++;
            }

            // Traverse the string B
            for (int i = M - 1; i >= 0; i--)
            {
                if (A[Y] != B[i])
                    break;
                Y--;
            }
            // If N - M is equal to 1 and Y
            // is less than or equal to X
            if (N - M == 1 && Y < X)
            {

                // Print the count
                // of characters
                Console.WriteLine(X - Y + 1);

                // Print the positions
                // of the characters
                for (int i = Y; i <= X; i++)
                    Console.WriteLine(i + 1);

            }

            // Otherwise
            else
                Console.WriteLine(-1);
        }
        public static void Main(string[] args)
        {
            string A = "abaac";
            string B = "abac";
            int N = A.Length;
            int M = B.Length;

            RemoveOneChar(A, B, N, M);
            /*
             Output: 
2
3 4
 

Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/maximize-removals-of-balls-of-at-least-two-different-types/
    Maximize removals of balls of at least two different types
Last Updated : 11 Jun, 2021
Given an array arr[] of size 3 denoting the number of balls of type 1, 2, and 3 respectively, the task is to find the maximum number of moves that can be performed if in one move, three balls, out of which at least 2 balls of different types, are removed.

Examples:

Input: arr[] = {2, 3, 3}
Output: 2
Explanation:
Move 1: Remove 1 ball of each type. Therefore, arr[] becomes {1, 2, 2}.
Move 2: Remove 1 ball of each type. Therefore, arr[] becomes {0, 1, 1}.
No further moves can be performed.

Input: arr[] = {100, 1, 2}
Output: 3
Explanation:
Move 1: Remove 1 ball of type 2 and 2 balls of type 1. Therefore, arr[] becomes {98, 0, 2}.
Move 2: Remove 1 ball of type 3 and 2 balls of type 1. Therefore, arr[] becomes {96, 0, 1}.
Move 3: Remove 1 ball of type 3 and 2 balls of type 1. Therefore, arr[] becomes {94, 0, 0}.
No further moves can be performed.

 
Approach: The idea to sort the array in increasing order and then arises two cases:



If arr[2] is smaller than 2 * (arr[0] + arr[1]), the answer will be (arr[0] + arr[1] + arr[2]) / 3.
If arr[2] is greater than 2 * (arr[0] + arr[1]), the answer will be arr[0] + arr[1].
Follow the steps below to solve the problem:

Sort the array in increasing order.
Print the minimum of (arr[0]+arr[1]+arr[2])/3 and arr[0]+arr[1].
Below is the implementation of the above approach:
     */
    public class RemoveBalls
    {
        static void findMoves(int[] arr)
        {
            // Sort the array in increasing order
            Array.Sort(arr);

            // Print the answer
            Console.WriteLine(Math.Min(arr[0] + arr[1],
                         (arr[0] + arr[1] + arr[2]) / 3));
        }
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 3 };

            // Function Call
            findMoves(arr);
            /*
             Output: 
2
 

Time Complexity: O(1)
Auxiliary Space: O(1)
            */
        }
    }
}
