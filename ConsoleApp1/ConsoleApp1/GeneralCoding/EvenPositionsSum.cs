using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Sum of even numbers at even position
Difficulty Level : Basic
 Last Updated : 17 Mar, 2021
Given an array of size n. The problem is to find the sum of numbers which are even and are at even index.
Examples: 
 

Input :  arr[] = {5, 6, 12, 1, 18, 8}
Output : 30
Explanation: Here, n = 6 
Now here are index and numbers as: index->arr[index]
0->5, 1->6, 2->12, 3->1, 4->18, 5->8
so, number which are even and are at even indices 
are: 2->12, 4->18
sum = 12+18 = 30

Input  : arr[] = {3, 20, 17, 9, 2, 10, 
                        18, 13, 6, 18}
Output : 26
Explanation: Here, n = 10
Now here are index and numbers as: index->arr[index]
0->3, 1->20, 2->17, 3->9, 4->2, 5->10, 
6->18, 7->13, 8->6, 9->18 
So, number which are even and are at even indices are: 
4->2, 6->18, 8->6
sum = 2+18+6 = 26
    */
    class EvenPositionsSum
    {

        // Function to calculate sum 
        // of even numbers at even indices
        static int sum_even_and_even_index(
                        int[] arr, int n)
        {

            int i = 0, sum = 0;

            // calculating sum of even
            // number at even index
            for (i = 0; i < n; i += 2)
            {

                if (arr[i] % 2 == 0)
                {

                    sum += arr[i];
                }
            }

            // required sum
            return sum;
        }

        // Driver program to test above
        public static void Main()
        {

            int[] arr = { 5, 6, 12, 1, 18, 8 };
            int n = arr.Length;
            Console.WriteLine("Sum of even numbers"
                        + " at even indices is " +
                +sum_even_and_even_index(arr, n));
        }
    }
    /*
     * https://www.geeksforgeeks.org/sum-even-numbers-even-position/
     Output: 


     Sum of even numbers at even indices is 30
    */
}
