using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/find-the-smallest-number-whose-sum-of-digits-is-n/ 
    Opentext codility
    Write a function Solution that given integer N returns the smallest non-negative integer whose individual digits sum to N. assume N range [0,50]
Examples
1.	N=16, function should return 79. There are many numbers whose digits sum to 16 (for example : 79, 97, 808, 5551, 22822 etc) smallest out of these is 79
2.	N=19, function should return 199 (the sum of digits is 1+9+19=19)
3.	N=7, function return 7

     */
    class SmallestSumDigit
    {

        static int getSum(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum = sum + n % 10;
                n = n / 10;
            }
            return sum;
        }

        // Function to find the smallest
        // number whose sum of digits is also N
        static void smallestNumber(int N)
        {
            int i = 1;
            while (1 != 0)
            {

                // Checking if number has
                // sum of digits = N
                if (getSum(i) == N)
                {
                    Console.Write(i);
                    break;
                }
                i++;
            }
        }
        /*
         
An efficient approach to this problem is an observation. Let’s see some examples. 
If N = 10, then ans = 19
If N = 20, then ans = 299
If N = 30, then ans = 3999
So, it is clear that the answer will have all digits as 9 except the first one so that we get the smallest number.
So, the Nth term will be =
        (N mod 9+1)*10^N/9-1
         */
        static void smallestNumber_efficient(int N)
        {
            Console.WriteLine((N % 9 + 1) *
                     Math.Pow(10, (N / 9)) - 1);
        }
        // Driver code
        public static void Main(String[] args)
        {
            int N = 10;

            smallestNumber(N);
            //output 19
            //Time Complexity: O(N).
        }
    }
    /*
https://www.lintcode.com/problem/1604/
https://codesandbox.io/s/gkrrd?file=/src/index.js
Given an array A consisting of N integers return the maximum sum of two numbers whose digits add upto an equal sum, return -1 if no such thing is possible

Example
1.	A=[51, 71, 17, 42] , function return 93. There are two pairs of numbers whose digits add upto an equal sum: (51, 42) and (17, 71) – first pair adds up to 93
2.	A=[42,33,60] function return 102. The digits of all numbers in A add up to the same sum, and choosing to add 42 and 60 gives result 102.
3.	A= [ 51, 32, 43 ] function return -1. Since all numbers in A have digits that ass up to different unique sums.


     */
    public class AddToDigits
    {
        static int sumOfDigits(int value)
        {
            int sum = 0;
            while (value > 0)
            {
                sum += value % 10;
                value = (int)Math.Floor((double)(value / 10));
            }
            return sum;
        }

        public static int Solution(int[] arr)
        {
            int max = -1;
            Dictionary<int,int> lookup = new Dictionary<int, int>();
            foreach (var n in arr)
            {
                int sum = sumOfDigits(n);
                if (lookup.ContainsKey(sum))
                {
                    int cmax = n + lookup[sum];
                    if (cmax > max)
                    {
                        max = cmax;
                    }
                }
                else
                {
                    lookup[sum] = n;
                }
            }
            return max;
        }
        public static void Main(string[] args)
        {
            int[] arr = { 51, 71, 17, 42 };
            int a = Solution(arr); Console.WriteLine(a);//output 93
        }
    }
    /*
     https://www.geeksforgeeks.org/program-for-sum-of-the-digits-of-a-given-number/?ref=lbp
    Program for Sum of the digits of a given number
Difficulty Level : Easy
Last Updated : 03 Jun, 2021
Given a number, find sum of its digits.

Examples : 

Take a step-up from those "Hello World" programs. Learn to implement data structures like Heap, Stacks, Linked List and many more! Check out our Data Structures in C course to start learning today.
Input : n = 687
Output : 21

Input : n = 12
Output : 3
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
General Algorithm for sum of digits in a given number: 

Get the number
Declare a variable to store the sum and set it to 0
Repeat the next two steps till the number is not 0
Get the rightmost digit of the number with help of the remainder ‘%’ operator by dividing it by 10 and add it to sum.
Divide the number by 10 with help of ‘/’ operator to remove the rightmost digit.
Print or return the sum
Below are the solutions to get sum of the digits. 
1. Iterative:
     */
    public class SumDigits
    {
        /* Function to get sum of digits */
        static int getSum(int n)
        {
            int sum = 0;

            while (n != 0)
            {
                sum = sum + n % 10;
                n = n / 10;
            }

            return sum;
        }
        /*
         how to compute in a single line? 
The below function has three lines instead of one line, but it calculates the sum in line. It can be made one-line function if we pass the pointer to sum. 
        */
        static int getSumSingleLine(int n)
        {
            int sum;

            /* Single line that calculates sum */
            for (sum = 0; n > 0; sum += n % 10, n /= 10)
                ;

            return sum;
        }
        /* Function to get sum of digits Recursive */
        static int sumDigitsRecursive(int no)
        {
            return no == 0 ? 0 : no % 10 + sumDigitsRecursive(no / 10);
        }

        // Driver code
        public static void Main()
        {
            int n = 687;
            Console.Write(getSum(n));//op 21
        }
    }

}
