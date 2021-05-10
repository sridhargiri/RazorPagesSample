using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/remove-trailing-zeros-from-the-sum-of-two-numbers-using-stack/
Remove trailing zeros from the sum of two numbers ( Using Stack )
Last Updated : 30 Apr, 2021
Given two numbers A and B, the task is to remove the trailing zeros present in the sum of the two given numbers using a stack.

Examples:

Input: A = 124, B = 186
Output: 31
Explanation: Sum of A and B is 310. Removing the trailing zeros modifies the sum to 31.

Input: A=130246, B= 450164
Output : 58041

Approach: The given problem can be solved using the string and stack data structures. Follow the steps below to solve the problem:



Calculate A + B and store it in a variable, say N.
Initialize a stack < char > , say S, to store the digits of N.
Convert the integer N to string and then push the characters into the stack S.
Iterate while S is not empty(), If the top element of the stack is ‘0’, then pop it out of the stack. Otherwise, break.
Initialize a string, say res, to store the resultant string.
Iterate while S is not empty(), and push all the characters in res and, then pop the top element.
Reverse the string res and print the res as the answer.
Below is the implementation of the above approach:
    */
    class RemoveTrailingZeroes
    {
        static string removeTailing(int A, int B)
        {
            // Stores the sum of A and B
            int N = A + B;

            // Stores the digits
            Stack<int> s=new Stack<int> ();

            // Stores the equivalent
            // string of integer N
            string strsum =N.ToString();

            // Traverse the string
            for (int i = 0; i < strsum.Length; i++)
            {

                // Push the digit at i
                // in the stack
                s.Push(strsum[i]);
            }

            // While top element is '0'
            while (s.Peek() == '0')

                // Pop the top element
                s.Pop();

            // Stores the resultant number
            // without tailing 0's
            string res = "";

            // While s is not empty
            while (s.Count!=0)
            {

                // Append top elemnt of S in res
                res = res + (char)(s.Peek());

                // Pop the top element of S
                s.Pop();
            }
            // Reverse the string res
            string t = "";
            for (int k = res.Length-1; k >=0; k--)
            {
                t += res[k];
            }
            return t;
        }
        public static void Main(string[] args)
        {
            // Input
            int A = 130246, B = 450164; Console.WriteLine(removeTailing(A, B));
            /*
             Output:
58041
Time Complexity: O(len(A + B))
Auxiliary Space: O(len(A + B))
            */
        }
    }
}
