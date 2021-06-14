using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Even numbers at even index and odd numbers at odd index
Difficulty Level : Easy
 Last Updated : 17 Mar, 2021
Given an array of size n containing equal number of odd and even numbers. The problem is to arrange the numbers in such a way that all the even numbers get the even index and odd numbers get the odd index. Required auxiliary space is O(1).
Examples : 
 

Input : arr[] = {3, 6, 12, 1, 5, 8}
Output : 6 3 12 1 8 5 

Input : arr[] = {10, 9, 7, 18, 13, 19, 4, 20, 21, 14}
Output : 10 9 18 7 20 19 4 13 14 21 
Source: https://www.geeksforgeeks.org/amazon-interview-experience-set-410-campus-internship/
    https://www.geeksforgeeks.org/even-numbers-even-index-odd-numbers-odd-index/?ref=rp
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach : 
 

Start from the left and keep two index one for even position and other for odd positions.
Traverse these index from left.
At even position there should be even number and at odd positions, there should be odd number.
Whenever there is mismatch , we swap the values at odd and even index.
Below is the implementation of the above approach :
    */
    class OddEven
    {

        // function to arrange
        // odd and even numbers
        public static void arrangeOddAndEven(int[] arr, int n)
        {
            int oddInd = 1;
            int evenInd = 0;
            while (true)
            {
                while (evenInd < n && arr[evenInd] % 2 == 0)
                    evenInd += 2;

                while (oddInd < n && arr[oddInd] % 2 == 1)
                    oddInd += 2;

                if (evenInd < n && oddInd < n)
                {
                    int temp = arr[evenInd];
                    arr[evenInd] = arr[oddInd];
                    arr[oddInd] = temp;
                }

                else
                    break;
            }
        }

        // function to print the array
        public static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }

        // Driver function
        public static void Main()
        {
            int[] arr = { 3, 6, 12, 1, 5, 8 };
            int n = 6;

            Console.Write("Original Array: ");
            printArray(arr, n);

            arrangeOddAndEven(arr, n);

            Console.Write("\nModified Array: ");
            printArray(arr, n);
        }
    }
    /*
     Output : 

Original Array: 3 6 12 1 5 8 
Modified Array: 6 3 12 1 8 5 
Time Complexity: O(n). 
Auxiliary Space: O(1).
    */
    /*
https://www.geeksforgeeks.org/even-or-odd-without-using-condtional-statement/
Print “Even” or “Odd” without using conditional statement
Difficulty Level : Easy
Last Updated : 31 Mar, 2021
Write a program that accepts a number from the user and prints “Even” if the entered number is even and prints “Odd” if the number is odd. You are not allowed to use any comparison (==, <,>,…etc) or conditional statements (if, else, switch, ternary operator,. Etc).

Method 1 
Below is a tricky code can be used to print “Even” or “Odd” accordingly.
    */
    public class OddOrEven
    {
        static void Main()
        {
            string[] arr = { "Even", "Odd" };

            Console.Write("Enter the number: ");

            string val;
            val = Console.ReadLine();
            int no = Convert.ToInt32(val);

            Console.WriteLine(arr[no % 2]);
        }
    }

}
