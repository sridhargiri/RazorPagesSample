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

        // Function to print the
        // second largest elements
        static void Nagarro_print_second_largest(int[] arr,
                                  int arr_size)
        {
            int i;

            // There should be
            // atleast two elements
            if (arr_size < 2)
            {
                Console.Write(" Invalid Input ");
                return;
            }

            // Sort the array
            Array.Sort(arr);

            // Start from second last element
            // as the largest element is at last
            for (i = arr_size - 2; i >= 0; i--)
            {

                // If the element is not
                // equal to largest element
                if (arr[i] != arr[arr_size - 1])
                {
                    Console.Write("The second largest " +
                                  "element is {0}\n", arr[i]);
                    return;
                }
            }

            Console.Write("There is no second " +
                          "largest element\n");
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
