using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/leaders-in-an-array/
    Leaders in an array
Difficulty Level : Easy
Last Updated : 30 Jun, 2021
Write a program to print all the LEADERS in the array. An element is leader if it is greater than all the elements to its right side. And the rightmost element is always a leader. For example int the array {16, 17, 4, 3, 5, 2}, leaders are 17, 5 and 2. 
Let the input array be arr[] and size of the array be size.
     */
    class LeaderArray
    {
        /*
         Method 1 (Simple) 
Use two loops. The outer loop runs from 0 to size – 1 and one by one picks all elements from left to right. The inner loop compares the picked element to all the elements to its right side. If the picked element is greater than all the elements to its right side, then the picked element is the leader. 
        */
        static void printLeaders_1(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                int j;
                for (j = i + 1; j < size; j++)
                {
                    if (arr[i] <= arr[j])
                        break;
                }

                // the loop didn't break
                if (j == size)
                    Console.Write(arr[i] + " ");
                //Time Complexity: O(n*n) o/p 17 5 2
            }
        }
        /*
         Method 2 (Scan from right) 
Scan all the elements from right to left in an array and keep track of maximum till now. When maximum changes its value, print it.
Below image is a dry run of the above approach:
        */
        static void printLeaders_2(int[] arr, int size)
        {
            int max_from_right = arr[size - 1];

            // Rightmost element is always leader
            Console.Write(max_from_right + " ");

            for (int i = size - 2; i >= 0; i--)
            {
                if (max_from_right < arr[i])
                {
                    max_from_right = arr[i];
                    Console.Write(max_from_right + " ");
                }
            }
            /*
Output:2 5 17
Time Complexity: O(n)
            */
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 16, 17, 4, 3, 5, 2 };
            int n = arr.Length;
            printLeaders_1(arr, n);
        }
    }
}
