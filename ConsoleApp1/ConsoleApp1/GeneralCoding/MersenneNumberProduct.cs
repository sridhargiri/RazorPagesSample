using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Program to find the product of a number with a Mersenne Number
Last Updated : 05 Mar, 2021
Given an integer N and a Mersenne number M, the task is to print their product without using the ‘*’ operator.
Note: Mersenne numbers are those numbers which are one less than a power of two.

Examples:

Input: N = 4, M = 15
Output: 60

Input: N = 9, M = 31
Output: 279

Approach: The given problem can be solved based on the following observations: 

Suppose M can be represented as 2X – 1, then the product of N with M can be represented as N · 2X – N.




Therefore, product of any Mersenne number with any number N can be represented as (N << log2(M+1)) – N.

Below is the implementation of the above approach
    */
    class MersenneNumberProduct
    {
        static long multiplyByMersenne(int N, int M)
        {
            // Stores the power of 
            // 2 of integer M + 1 
            int x = (int)Math.Log((M + 1), 2);

            // Return the product 
            return ((N << x) - N);
        }
        static void Main(string[] args)
        {
            multiplyByMersenne(4, 15);
        }
        /*
         Output:
60
Time Complexity: O(1)
Auxiliary Space: O(1)
        */
    }
}
