using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ArrayLeftRotate
    {
        /*
         Rotate all odd numbers right and all even numbers left in an Array of 1 to N
        Difficulty Level : Easy
         Last Updated : 04 Aug, 2020
        Given a permutation arrays A[] consisting of N numbers in range [1, N], the task is to left rotate all the even numbers and right rotate all the odd numbers of the permutation and print the updated permutation. 
        Note: N is always even.
        Examples: 

        Input: A = {1, 2, 3, 4, 5, 6, 7, 8} 
        Output: {7, 4, 1, 6, 3, 8, 5, 2} 
        Explanation: 
        Even element = {2, 4, 6, 8} 
        Odd element = {1, 3, 5, 7} 
        Left rotate of even number = {4, 6, 8, 2} 
        Right rotate of odd number = {7, 1, 3, 5} 
        Combining Both odd and even number alternatively.
        Input: A = {1, 2, 3, 4, 5, 6} 
        Output: {5, 4, 1, 6, 3, 2} 


        Approach:

        It is clear that the odd elements are always on even index and even elements are always laying on odd index.
        To do left rotation of even number we choose only odd indices.
        To do right rotation of odd number we choose only even indices.
        Print the updated array.
        Below is the implementation of the above approach:
        */
        static void left_rotate(int[] arr)
        {
            int last = arr[1];
            for (int i = 3;
                    i < arr.Length;
                    i = i + 2)
            {
                arr[i - 2] = arr[i];
            }
            arr[arr.Length - 1] = last;
        }

        // Function to right rotate 
        static void right_rotate(int[] arr)
        {
            int start = arr[arr.Length - 2];
            for (int i = arr.Length - 4;
                    i >= 0; i = i - 2)
            {
                arr[i + 2] = arr[i];
            }
            arr[0] = start;
        }

        // Function to rotate the array 
        public static void rotate(int[] arr)
        {
            left_rotate(arr);
            right_rotate(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        // Driver code 
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            rotate(arr);
        }
    }
    /*
     * https://www.geeksforgeeks.org/rotate-all-odd-numbers-right-and-all-even-numbers-left-in-an-array-of-1-to-n/?ref=rp
     Output:
5 4 1 6 3 2
Time Complexity: O(N) 
Auxiliary Space: O(1)
    */
}
