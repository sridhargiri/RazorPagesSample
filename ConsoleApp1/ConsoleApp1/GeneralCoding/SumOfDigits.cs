using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class pro
    {

        public int sum(int num)
        {
            if (num != 0)
            {
                return (num % 10 + sum(num / 10));
            }
            else
            {
                return 0;
            }
        }
    }
    /*
     Count array elements having sum of digits equal to K

Given an array arr[] of size N, the task is to count the number of array elements whose sum of digits is equal to K.

Examples:

Input: arr[] = {23, 54, 87, 29, 92, 62}, K = 11
Output: 2
Explanation: 
29 = 2 + 9 = 11
92 = 9 + 2 = 11

Input: arr[]= {11, 04, 57, 99, 98, 32}, K = 18
Output: 1

Approach: Follow the steps below to solve the problem:

Initialize a variable, say N, to store the size of the array.
Initialize a variable, say count, to store the elements having sum of digits equal to K.
Declare a function, sumOfDigits() to calculate the sum of digits of a number.
Traverse the array arr[] and for each array element, check if the sum of digits is equal to K or not. If found to be true, then increment count by 1.
Print the value of count as the required answer.
Below is the implementation of the above approach:
    */
    public class SumOfDigits
    {
        public static int sumOfDigits(int num)
        {
            int sum = 0;
            int r = 0;
            while (num > 0)
            {
                r = num % 10;
                sum = sum + r;
                num = num / 10;
            }
            return sum;
        }
        // Function to count array elements 
        static void elementsHavingDigitSumK(int[] arr, int N, int K)
        {
            // Store the count of array 
            // elements having sum of digits K 
            int count = 0;

            // Traverse the array 
            for (int i = 0; i < N; ++i)
            {

                // If sum of digits is equal to K 
                if (sumOfDigits(arr[i]) == K)
                {

                    // Increment the count 
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        public static void Main(string[] args)
        {

            // Given array 
            int[] arr = { 23, 54, 87, 29, 92, 62 };

            // Given value of K 
            int K = 11;
            elementsHavingDigitSumK(arr, arr.Length, K);
            int num, result;
            pro pg = new pro();
            Console.WriteLine("Enter the Number : ");
            num = int.Parse(Console.ReadLine());
            result = pg.sum(num);
            Console.WriteLine("Sum of Digits in {0} is {1}", num, result);
            Console.ReadLine();
        }
    }
    // convergint online coderpad test taken at 18/04/2023 at 3pm
    public class CountWords
    {
        public static void Main(string[] args)
        {
            string[] words =
        {
            "which",
            "wristwatches",
            "are",
            "swiss",
            "wristwatches"
        };
            Array.Sort(words);
            var counts = words

    .GroupBy(w => w)
    .Select(g => new { Word = g.Key, Count = g.Count() })
    .ToList();
            
            int[] arr = new int[counts.Count];
            for (int i = 0; i < counts.Count; i++)
            {
                arr[i] = counts[i].Count;
            }
        }
    }
}
