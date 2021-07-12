using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/maximum-number-formed-from-the-digits-of-given-three-numbers/
    Maximum number formed from the digits of given three numbers
Last Updated : 02 Jul, 2021
Geek-O-Lympics
Given 3 four-digit integers A, B, and C, the task is to print the number formed by taking the maximum digit from all the digits at the same positions in the given numbers.

Examples:

Input: A = 3521, B = 2452, C = 1352
Output: 3552
Explanation:

The maximum of the digits that are at 1th place is equal to max(A[3] = 1, B[3] = 2, C[3] = 2) 2.
The maximum of the digits that are at 10th place is equal to max(A[2] = 2, B[2] = 5, C[2] = 5) 5.
The maximum of the digits that are at 100th place is equal to max(A[1] = 5, B[1] = 4, C[1] = 3) 5.
The maximum of the digits that are at 1000th place is equal to max(A[0] = 3, B[0] = 3, C[0] = 1) 3.
Therefore, the number formed is 3552.

Input: A = 11, B = 12, C = 22
Output: 22



Approach: The problem can be solved by iterating over the digits of the given integers. Follow the steps below to solve the problem:

Initialize a variable, say ans as 0 and P as 1 to store the maximum number possible and the position value of a digit.
Iterate until A, B and C are greater than 0 and perform the following steps:
Find the digits at the unit places of the numbers A, B, and C and store them in variables say a, b and c respectively.
Update A to A/10, B to B/10, and C to C/10.
Increment ans by the P*max(a, b, c) and then update P to P*10.
Finally, after completing the above steps, print the answer stored in ans.
Below is the implementation of the above approach:
    */
    public class MaximumNumber
    {
        static int max_digit_from_three_numbers(int A, int B, int C)
        {
            // Stores the result
            int ans = 0;

            // Stores the position value of a
            // digit
            int cur = 1;

            while (A > 0)
            {

                // Stores the digit at the unit
                // place
                int a = A % 10;
                // Stores the digit at the unit
                // place
                int b = B % 10;
                // Stores the digit at the unit
                // place
                int c = C % 10;

                // Update A, B and C
                A = A / 10;
                B = B / 10;
                C = C / 10;

                // Stores the maximum digit
                int m = Math.Max(a, Math.Max(c, b));

                // Increment ans cur*a
                ans += cur * m;

                // Update cur
                cur = cur * 10;
            }
            // Return ans
            return ans;
        }
        public static void Main(string[] args)
        {
            int A = 3521, B = 2452, C = 1352;
            Console.WriteLine(max_digit_from_three_numbers(A, B, C));
            /*
             Output
3552
Time Complexity: O(log(N))
Auxiliary Space: O(1)
            */
        }
    }
}
