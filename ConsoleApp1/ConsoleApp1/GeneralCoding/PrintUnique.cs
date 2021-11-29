using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/print-all-unique-elements-present-in-a-sorted-array/
    Print all unique elements present in a sorted array
Difficulty Level : Easy
Last Updated : 26 Jun, 2021
Given a sorted array arr[] of size N, the task is to print all the unique elements in the array.

An array element is said to be unique if the frequency of that element in the array is 1.

Examples:

Input: arr[ ] = {1, 1, 2, 2, 3, 4, 5, 5}
Output: 3 4
Explanation: Since 1, 2, 5 are occurring more than once in the array, the distinct elements are 3 and 4.

Input: arr[ ] = {1, 2, 3, 3, 3, 4, 5, 6}
Output: 1 2 4 5 6



Approach: The simplest approach to solve the problem is to traverse the array arr[] and print only those elements whose frequency is 1. Follow the steps below to solve the problem:

Iterate over the array arr[] and initialize a variable, say cnt = 0,   to count the frequency of the current array element.
Since the array is already sorted, check if the current element is the same as the previous element. If found to be true, then update cnt += 1.
Otherwise, if cnt = 1, then print the element. Otherwise, continue.
Below is the implementation of the above approach:
     */
    public class PrintUnique
    {
        static void RemoveDuplicates(int[] arr, int n)
        {

            int i = 0;

            // Traverse the array
            while (i < n)
            {

                int cur = arr[i];

                // Stores frequency of
                // the current element
                int cnt = 0;

                // Iterate until end of the
                // array is reached or current
                // element is not the same as the
                // previous element
                while (i < n && cur == arr[i])
                {
                    cnt++;
                    i++;
                }

                // If current element is unique
                if (cnt == 1)
                {
                    Console.WriteLine(cur);
                }

            }
        }
        static void Main(string[] args)
        {
            // Given Input
            int[] arr = { 1, 3, 3, 5, 5, 6, 10 };
            int N = 7;

            // Function Call
            RemoveDuplicates(arr, N);
            /*
             Output
1 6 10 
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
    /*
https://www.geeksforgeeks.org/find-duplicates-in-on-time-and-constant-extra-space/?ref=lbp
    Find duplicates in O(n) time and O(1) extra space | Set 1     
Given an array of n elements that contains elements from 0 to n-1, with any of these numbers appearing any number of times. 
    Find these repeating numbers in O(n) and using only constant memory space.
    Input : n = 7 and array[] = {1, 2, 3, 6, 3, 6, 1}
Output: 1, 3, 6

Explanation: The numbers 1 , 3 and 6 appears more
than once in the array.

Input : n = 5 and array[] = {1, 2, 3, 4 ,3}
Output: 3

Explanation: The number 3 appears more than once
in the array.
    */
    public class RemoveDuplicate
    {
        /*
This problem is an extended version of the following problem.        https://www.geeksforgeeks.org/find-the-two-repeating-elements-in-a-given-array/
        Method 1 and Method 2 of the above link are not applicable as the question says O(n) time complexity and O(1) constant space. Also, Method 3 and Method 4 cannot be applied here because there can be more than 2 repeating elements in this problem. Method 5 can be extended to work for this problem. Below is the solution that is similar to Method 5.

Solution 1: 
        Approach:The elements in the array is from 0 to n-1 and all of them are positive. So to find out the duplicate elements, a HashMap is required, but the question is to solve the problem in constant space. There is a catch, the array is of length n and the elements are from 0 to n-1 (n elements). The array can be used as a HashMap. 
Problem in the below approach. This approach only works for arrays having at most 2 duplicate elements i.e It will not work if the array contains more than 2 duplicates of an element. For example: {1, 6, 3, 1, 3, 6, 6} it will give output as : 1 3 6 6.
Note: The above program doesn’t handle 0 cases (If 0 is present in array). The program can be easily modified to handle that also. It is not handled to keep the code simple. (Program can be modified to handle 0 cases by adding plus One(+1) to all the values. also subtracting One from the answer and by writing { arr [abs(arr[i]) – 1] } in code)
In other approaches below, solutions are discussed that prints repeating elements only once.
Algorithm: 
 

Traverse the array from start to end.
For every element,take its absolute value and if the abs(array[i])‘th element is positive, the element has not encountered before, else if negative the element has been encountered before print the absolute value of the current element.
Implementation:  
        */
        static void printRepeating(int[] arr, int size)
        {
            int i;

            Console.Write("The repeating" +
                          " elements are : ");

            for (i = 0; i < size; i++)
            {
                int j = Math.Abs(arr[i]);
                if (arr[j] >= 0)
                    arr[j] = -arr[j];
                else
                    Console.Write(j + " ");
            }
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 1, 3, 6, 6 };
            int arr_size = arr.Length;

            printRepeating(arr, arr_size); Console.WriteLine();
            /*
             Output: 

The repeating elements are:
1  3  6
Complexity Analysis: 

Time Complexity: O(n), only one traversal is needed, so time complexity is O(n)
Auxiliary Space: O(1), no extra space is required, so space complexity is constant.
            */
            /*
             Alternate Solution: 

Approach: The basic idea is to use a HashMap to solve the problem. But there is a catch, the numbers in the array are from 0 to n-1, and the input array has length n. So, the input array can be used as a HashMap. While Traversing the array, if an element ‘a’ is encountered then increase the value of a%n‘th element by n. The frequency can be retrieved by dividing the a % n’th element by n.
Algorithm: 
Traverse the given array from start to end.
For every element in the array increment the arr[i]%n‘th element by n.
Now traverse the array again and print all those indexes i for which arr[i]/n is greater than 1. Which guarantees that the number n has been added to that index
This approach works because all elements are in the range from 0 to n-1 and arr[i] would be greater than n only if a value “i” has appeared more than once.
            */

            int[] numRay = { 0, 4, 3, 2, 7, 8, 2, 3, 1 };

            for (int i = 0; i < numRay.Length; i++)
            {
                numRay[numRay[i] % numRay.Length]
                    = numRay[numRay[i] % numRay.Length]
                    + numRay.Length;
            }
            Console.Write("The repeating elements are : ");
            for (int i = 0; i < numRay.Length; i++)
            {
                if (numRay[i] >= numRay.Length * 2)
                {
                    Console.Write(i + " ");
                }
            }
            /*
             Output: 

The repeating elements are : 
2 
3
Complexity Analysis: 

Time Complexity: O(n). 
Only two traversals are needed. So the time complexity is O(n).
Auxiliary Space: O(1). 
No extra space is needed, so the space complexity is constant.

             */
        }
    }
}
