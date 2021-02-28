using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Print all repeating digits present in a given number in sorted order
Last Updated : 26 Feb, 2021
Given an integer N, the task is to print all the repeating digits present in N in sorted order.

Examples:

Input: N = 45244336543
Output: 3 4 5
Explanation: The duplicate digits are 3 4 5

Input: N = 987065467809
Output: 0 6 7 8 9

Approach: The idea is to use Hashing to store the frequency of digits of N and print those digits whose frequency exceeds 1.




Initialize a HashMap, to store frequency of digits 0-9.
Convert the integer to its equivalent string.
Iterate over the characters of the string, and for each character, perform the following steps:
Convert the current character to an integer using typecasting
Increment the count of that digit in a HashMap.
Traverse the HashMap and print the digits whose count exceeds 1.
     
     */
    class RepeatingDigits
    {
        static void findRepeatingDigits(long n)
        {
            string input = n.ToString();
            int[] freq = new int[127];
            for (int i = 0; i < input.Length; i++)
            {
                freq[input[i]]++;
            }
            for (int j = 0; j < freq.Length; j++)
            {
                if (freq[j] > 1)
                    Console.Write((j - 48) + " ");
            }
        }
        /*
         Count of repeating digits in a given Number

Given a number N, the task is to count the total number of repeating digits in the given number.

Examples:

Input: N = 99677  
Output: 2
Explanation:
In the given number only 9 and 7 are repeating, hence the answer is 2.

Input: N = 12
Output: 0
Explanation:
In the given number no digits are repeating, hence the answer is 0.

 
Naive Approach: The idea is to use two nested loops. In the first loop, traverse from the first digit of the number to the last, one by one. Then for each digit in the first loop, run a second loop and search if this digit is present anywhere else as well in the number. If yes, then increase the required count by 1. In the end, print the calculated count.



Time Complexity: O(N2)
Auxiliary Space: O(1)

Efficient Approach: The idea is to use Hashing to store the frequency of the digits and then count the digits with a frequency equal to more than 1. Follow the steps below to solve the problem:

Create an array of size 10 to store the count of digits 0 – 9. Initially store each index as 0.
Now for each digit of number N, increment the count of that index in the array.
Traverse the array and count the indices that have value more than 1.
In the end, print this count.
Below is the implementation of the above approach:
         
         */
        static int countRepeatingDigits(int N)
        {
            // Initialize a variable to store
            // count of Repeating digits
            int res = 0;

            // Initialize cnt array to
            // store digit count
            int[] cnt = new int[10];

            // Iterate through the digits of N
            while (N > 0)
            {

                // Retrieve the last digit of N
                int rem = N % 10;

                // Increase the count of digit
                cnt[rem]++;

                // Remove the last digit of N
                N = N / 10;
            }

            // Iterate through the cnt array
            for (int i = 0; i < 10; i++)
            {

                // If frequency of digit
                // is greater than 1
                if (cnt[i] > 1)
                {

                    // Increment the count
                    // of Repeating digits
                    res++;
                }
            }

            // Return count of repeating digit
            return res;
        }
        public static void Main(string[] args)
        {
            findRepeatingDigits(987065467809);
            // Function Call
            Console.WriteLine(countRepeatingDigits(12));
        }
    }
}
