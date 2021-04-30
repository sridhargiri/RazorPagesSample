using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class FindSecondLarge
    {
        /*
         https://www.geeksforgeeks.org/find-second-largest-element-array/
        Given an array of integers, our task is to write a program that efficiently finds the second largest element present in the array. 
Example:

Input: arr[] = {12, 35, 1, 10, 34, 1}
Output: The second largest element is 34.
Explanation: The largest element of the 
array is 35 and the second 
largest element is 34

Input: arr[] = {10, 5, 10}
Output: The second largest element is 5.
Explanation: The largest element of 
the array is 10 and the second 
largest element is 5

Input: arr[] = {10, 10, 10}
Output: The second largest does not exist.
Explanation: Largest element of the array 
is 10 there is no second largest element
        */
        public static void Main(string[] args)
        {
            int[] arr = { 12, 35, 1, 10, 34, 1 };
            int n = arr.Length;
            print3largest(arr, n);
        }
        public static void print2largest(int[] arr, int arr_size)
        {
            int i = 0, first = int.MinValue, second = int.MinValue;
            if (arr_size < 2)
            {
                Console.WriteLine("invalid"); return;
            }
            for (i = 0; i < arr_size; i++)
            {
                if (arr[i] > first)
                {
                    second = first;
                    first = arr[i];
                }
                else if (arr[i] > second)
                {
                    second = arr[i];
                }
            }
            Console.WriteLine(second);
        }
        public static void print3largest(int[] arr, int arr_size)
        {
            int i = 0, first = int.MinValue, second = int.MinValue, third = int.MinValue;
            if (arr_size < 2)
            {
                Console.WriteLine("invalid"); return;
            }
            for (i = 0; i < arr_size; i++)
            {
                if (arr[i] > first)
                {
                    third = second;
                    second = first;
                    first = arr[i];
                }
                else if (arr[i] > second)
                {
                    third = second; second = arr[i];
                }
                else if (arr[i] > third)
                {
                    third = arr[i];
                }
            }
            Console.WriteLine(third);
        }
    }
}
