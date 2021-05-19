
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-the-missing-number/
    https://cses.fi/problemset/
    Find the Missing Number
Difficulty Level : Easy
Last Updated : 11 May, 2021
You are given a list of n-1 integers and these integers are in the range of 1 to n. There are no duplicates in the list. One of the integers is missing in the list. Write an efficient code to find the missing integer.
Example: 

Input: arr[] = {1, 2, 4, 6, 3, 7, 8}
Output: 5
Explanation: The missing number from 1 to 8 is 5

Input: arr[] = {1, 2, 3, 5}
Output: 4
Explanation: The missing number from 1 to 5 is 4
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
Method 1: This method uses the technique of the summation formula. 

Approach: The length of the array is n-1. So the sum of all n elements, i.e sum of numbers from 1 to n can be calculated using the formula n*(n+1)/2. Now find the sum of all the elements in the array and subtract it from the sum of first n natural numbers, it will be the value of the missing element.
Algorithm: 
Calculate the sum of first n natural numbers as sumtotal= n*(n+1)/2
Create a variable sum to store the sum of array elements.
Traverse the array from start to end.
Update the value of sum as sum = sum + array[i]
Print the missing number as sumtotal – sum
Implementation:
     */
    class MissingNo
    {
        // Function to ind missing number 
        static int getMissingNo(int[] a, int n)
        {
            int total = (n + 1) * (n + 2) / 2;

            for (int i = 0; i < n; i++)
                total -= a[i];

            return total;
        }

        /*
         Modification for Overflow  

Approach: The approach remains the same but there can be overflow if n is large. In order to avoid integer overflow, pick one number from known numbers and subtract one number from given numbers. This way there won’t have Integer Overflow ever.
Algorithm: 
Create a variable sum = 1 to which will store the missing number and a counter c = 2.
Traverse the array from start to end.
Update the value of sum as sum = sum – array[i] + c and update c as c++.
Print the missing number as a sum.
        */

        // a represents the array
        // n : Number of elements in array a
        static int getMissingNo_another(int[] a, int n)
        {
            int i, total = 1;

            for (i = 2; i <= (n + 1); i++)
            {
                total += i;
                total -= a[i - 2];
            }
            return total;
        }
        /* program to test above function */
        public static void Main()
        {
            int[] a = { 1,4, 2, 5, 6 };
            int miss = getMissingNo(a, 5);
            Console.Write(miss);
            /*
             Output
3
Complexity Analysis: 
Time Complexity: O(n). 
Only one traversal of the array is needed.
Space Complexity: O(1). 
No extra space is needed
            */
        }
    }

}
