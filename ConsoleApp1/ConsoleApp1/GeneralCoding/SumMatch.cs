using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if sum of array can be made equal to X by removing either the first or last digits of every array element
Last Updated : 23 Mar, 2021
Given an array arr[] consisting of N positive integers and a positive integer X, the task is to check if the sum of the given array can be made equal to X by removing either the first or last digit of every array element. If it is possible to make the sum of array elements equal to X, then print “Yes”. Otherwise, print “No”.

Examples:

Input: arr[] = {545, 433, 654, 23}, X = 134
Output: Yes
Explanation:
Following removal of digits makes the sum of array equal to X:

Removing the first digit of arr[0] modifies arr[0] to 45.
Removing the first digit of arr[1] modifies to 33.
Removing the first digit of arr[2] modifies arr[2] to 54.
Removing the last digit of arr[3] modifies arr[3] to 2.
The modified array is {45, 33, 54, 2}. Therefore, sum of the modified array = 45 + 33 + 54 + 2 = 134(= X).

    
Input: arr[] = {234, 102, 75, 4101}, X = 150
    explanation:
    234 becomes 34 - remove last digit
    102 becomes 10 - remove last digit
    75 becomes 5 - remove first digit
    4101 becomes 101 - remove first digit
    Therefore, 34+10+5+101=150 (=X)

Input: arr[] = {54, 22, 76, 432}, X = 48
Output: No




Approach: The given problem can be solved using recursion by generating all possible ways to remove the first or the last digit for every array element. Follow the steps below to solve the given problem.

Define a recursive function, say makeSumX(arr, S, i, X) that takes the array arr[], the current sum S, the current index i, and the required sum X as the parameters and perform the following operations:
If the current index is equals to the length of the array and the current sum S is equal the required sum X, then return true. Otherwise, return false.
Convert the integer arr[i] to a string.
Remove the last digit of the integer arr[i] and store it in a variable say L.
Remove the first digit of the integer arr[i] and store it in a variable say R.
Return the value from the function as the Bitwise OR of makeSumX(arr, S + L, i + 1, X) and makeSumX(arr, S + R, i + 1, X).
If the value returned by the function makeSumX(arr, 0, 0, X) is true, then print “Yes”. Otherwise, print “No”.
Below is the implementation of the above approach:
    
   
    https://www.geeksforgeeks.org/check-if-sum-of-array-can-be-made-equal-to-x-by-removing-either-the-first-or-last-digits-of-every-array-element/
     below is  the c# code for python - worked on 24 march 2021
    */
    class SumMatch
    {
        static bool makeSumX(int[] arr, int sum, int current_sum, int i)
        {
            int l, r;
            bool x, y;
            //base case
            if (i == arr.Length)
                return sum == current_sum;
            string current_element_string = arr[i].ToString();
            //Remove last digit
            l = int.Parse(current_element_string.Substring(0, current_element_string.Length - 1));
            //Remove 1st digit
            r = int.Parse(current_element_string.Substring(1, current_element_string.Length - 1));
            //Recursive function call
            x = makeSumX(arr, sum, current_sum + l, i + 1);
            y = makeSumX(arr, sum, current_sum + r, i + 1);


            return x | y;
        }
        static void Main(string[] args)
        {
            int[] arr = { 234, 102, 75, 4101 }; int sum = 150;
            if (makeSumX(arr, sum, 0, 0)) Console.WriteLine("yes"); else Console.WriteLine("no");
            /*
             Output:
Yes
Time Complexity: O(2N)
Auxiliary Space: O(1)
            */
        }
    }
}
