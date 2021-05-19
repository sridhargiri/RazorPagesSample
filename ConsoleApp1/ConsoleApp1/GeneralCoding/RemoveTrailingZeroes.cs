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
    /*
https://cses.fi/problemset/task/1618
https://www.geeksforgeeks.org/count-trailing-zeroes-factorial-number/
    Count trailing zeroes in factorial of a number
Difficulty Level : Medium
Last Updated : 26 Feb, 2021
Given an integer n, write a function that returns count of trailing zeroes in n!. 
Examples : 

Input: n = 5
Output: 1 
Factorial of 5 is 120 which has one trailing 0.

Input: n = 20
Output: 4
Factorial of 20 is 2432902008176640000 which has
4 trailing zeroes.

Input: n = 100
Output: 24
We strongly recommend that you click here and practice it, before moving on to the solution.
Approach:
A simple method is to first calculate factorial of n, then count trailing 0s in the result (We can count trailing 0s by repeatedly dividing the factorial by 10 till the remainder is 0).
 
The above method can cause overflow for slightly bigger numbers as the factorial of a number is a big number (See factorial of 20 given in above examples). The idea is to consider prime factors of a factorial n. A trailing zero is always produced by prime factors 2 and 5. If we can count the number of 5s and 2s, our task is done. Consider the following examples.
n = 5: There is one 5 and 3 2s in prime factors of 5! (2 * 2 * 2 * 3 * 5). So a count of trailing 0s is 1.
n = 11: There are two 5s and eight 2s in prime factors of 11! (2 8 * 34 * 52 * 7). So the count of trailing 0s is 2.
 
We can easily observe that the number of 2s in prime factors is always more than or equal to the number of 5s. So if we count 5s in prime factors, we are done. How to count the total number of 5s in prime factors of n!? A simple way is to calculate floor(n/5). For example, 7! has one 5, 10! has two 5s. It is not done yet, there is one more thing to consider. Numbers like 25, 125, etc have more than one 5. For example, if we consider 28! we get one extra 5 and the number of 0s becomes 6. Handling this is simple, first, divide n by 5 and remove all single 5s, then divide by 25 to remove extra 5s, and so on. Following is the summarized formula for counting trailing 0s.
Trailing 0s in n! = Count of 5s in prime factors of n!
                  = floor(n/5) + floor(n/25) + floor(n/125) + ....
Following is a program based on the above formula: 
     */
    public class CountTrailingZeros
    {

        // Function to return trailing
        // 0s in factorial of n
        static int findTrailingZeros(int n)
        {
            // Initialize result
            int count = 0;

            // Keep dividing n by powers
            // of 5 and update count
            for (int i = 5; n / i >= 1; i *= 5)
                count += n / i;

            return count;
        }

        // Driver Code
        public static void Main()
        {
            int n = 100;
            Console.WriteLine("Count of trailing 0s in " +
                                               n + "! is " +
                                    findTrailingZeros(n));
            //Output : 

            //Count of trailing 0s in 100! is 24
        }
    }
}
