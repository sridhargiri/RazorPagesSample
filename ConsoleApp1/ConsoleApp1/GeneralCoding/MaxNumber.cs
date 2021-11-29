using System;
using System.Collections.Generic;
using System.Text;

/*
 Find maximum number that can be formed using digits of a given number

Given a number, write a program to find a maximum number that can be formed using all of the digits of this number.

Examples:

Input : 38293367
Output : 98763332

Input : 1203465
Output: 6543210

Simple approach
The simple method to solve this problem is to extract and store the digits of the given number in an integer array and sort this array in descending order. After sorting the array, print the elements of the array.
Time Complexity: O( N log N ), where N is the number of digits in the given number.

Efficient approach : We know that the digits in a number will range from 0-9, so the idea is to create a hashed array of size 10 and store the count of every digit in the hashed array that occurs in the number. 
Then traverse the hashed array from index 9 to 0 and calculate the number accordingly.

 */
namespace ConsoleApp1
{
    class MaxNumber
    {


        // Function to print the maximum number 
        static int printMaxNum(int num)
        {
            // hashed array to store  
            // count of digits 
            int[] count = new int[10];

            // Converting given number  
            // to string 
            String str = num.ToString();

            // Updating the count array 
            for (int i = 0; i < str.Length; i++)
                count[str[i] - '0']++;

            // result is to store the  
            // final number 
            int result = 0, multiplier = 1;

            // Traversing the count array 
            // to calculate the maximum number 
            for (int i = 0; i <= 9; i++)
            {
                while (count[i] > 0)
                {
                    result = result + (i * multiplier);
                    count[i]--;
                    multiplier = multiplier * 10;
                }
            }

            // return the result 
            return result;
        }

        // Driver Code 
        public static void Main()
        {
            int num = 38293367;
            Console.Write(printMaxNum(num));
            //Output : 98763332 O(n) time
        }
    }
    /*
     https://www.geeksforgeeks.org/find-the-largest-number-that-can-be-formed-with-the-given-digits/
    Find the largest number that can be formed with the given digits
Difficulty Level : Basic
Last Updated : 13 Apr, 2021
Given an array of integers arr[] representing digits of a number. The task is to write a program to generate the largest number possible using these digits.
Note: The digits in the array are in between 0 and 9. That is, 0<arr[i]<9.
Examples: 
 

Input : arr[] = {4, 7, 9, 2, 3}
Output : Largest number: 97432 

Input : arr[] = {8, 6, 0, 4, 6, 4, 2, 7}
Output : Largest number: 87664420 
    Naive Approach: The naive approach is to sort the given array of digits in descending order and then form the number using the digits in array keeping the order of digits in the number same as that of the sorted array.
Time Complexity: O(N logN), where N is the number of digits.
Below is the implementation of above idea: 
    //see findMaxNum code
 Efficient Approach: An efficient approach is to observe that we have to form the number using only digits from 0-9. Hence we can create a hash of size 10 to store the number of occurrences of the digits in the given array into the hash table. Where the key in the hash table will be digits from 0 to 9 and their values will be the count of their occurrences in the array.
Finally, print the digits the number of times they occur in descending order starting from the digit 9.
Below is the implementation of above approach: 
     */
    public class LargestNumber
    {

        static int findMaxNum(int[] arr, int n)
        {
            // sort the given array in
            // ascending order and then
            // traverse into descending
            Array.Sort(arr);

            int num = arr[0];

            // generate the number
            for (int i = n - 1; i >= 0; i--)
            {
                num = num * 10 + arr[i];
            }

            return num;
        }
        // Function to generate
        // largest possible number
        // with given digits
        static void findLargestNumberDigits(int[] arr,
                               int n)
        {
            // Declare a hash array of
            // size 10 and initialize
            // all the elements to zero
            int[] hash = new int[10];

            // store the number of
            // occurrences of the
            // digits in the given
            // array into the hash table
            for (int i = 0; i < n; i++)
            {
                hash[arr[i]]++;
            }

            // Traverse the hash in
            // descending order to
            // print the required number
            for (int i = 9; i >= 0; i--)
            {
                // Print the number of
                // times a digits occurs
                for (int j = 0; j < hash[i]; j++)
                    Console.Write(i);
            }
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 0 };

            int n = arr.Length;

            findLargestNumberDigits(arr, n);//output 543210
        }
    }
    /*
     https://www.geeksforgeeks.org/given-an-array-of-numbers-arrange-the-numbers-to-form-the-biggest-number/
    Arrange given numbers to form the biggest number | Set 1
    Given an array of numbers, arrange them in a way that yields the largest value. For example, if the given numbers are {54, 546, 548, 60}, the arrangement 6054854654 gives the largest value. And if the given numbers are {1, 34, 3, 98, 9, 76, 45, 4}, then the arrangement 998764543431 gives the largest value.
    A simple solution that comes to our mind is to sort all numbers in descending order, but simply sorting doesn’t work. For example, 548 is greater than 60, but in output 60 comes before 548. As a second example, 98 is greater than 9, but 9 comes before 98 in output.
    So how do we go about it? The idea is to use any comparison based sorting algorithm. 
In the used sorting algorithm, instead of using the default comparison, write a comparison function myCompare() and use it to sort numbers. 

Given two numbers X and Y, how should myCompare() decide which number to put first – we compare two numbers XY (Y appended at the end of X) and YX (X appended at the end of Y). If XY is larger, then X should come before Y in output, else Y should come before. For example, let X and Y be 542 and 60. To compare X and Y, we compare 54260 and 60542. Since 60542 is greater than 54260, we put Y first.
Following is the implementation of the above approach. 
To keep the code simple, numbers are considered as strings, the vector is used instead of a normal array. 

Below is the implementation of the above approach
     */
    public class BiggestNumber
    {
        // Given a list of non-negative
        // integers,
        // arrange them such that they
        // form the largest number.
        // Note: The result may be very
        // large, so you need to
        // return a string instead
        // of an integer.
        public static void LargestNumberMethod(List<int> inputList)
        {
            string output = string.Empty;

            List<string> newList = inputList.ConvertAll<string>(
                delegate (int i) { return i.ToString(); });

            newList.Sort(MyCompare);

            for (int i = 0; i < inputList.Count; i++)
            {
                output = output + newList[i];
            }

            if (output[0] == '0' && output.Length > 1)
            {
                Console.Write("0");
            }
            Console.Write(output);
        }

        internal static int MyCompare(string X, string Y)
        {
            // first append Y at the end of X
            string XY = X + Y;

            // then append X at the end of Y
            string YX = Y + X;

            // Now see which of the two
            // formed numbers is greater
            return XY.CompareTo(YX) > 0 ? -1 : 1;
        }



        // Driver code
        static void Main(string[] args)
        {
            List<int> inputList
                = new List<int>() { 54, 546, 548, 60 };
            LargestNumberMethod(inputList);
            /*
             Output
6054854654
Time Complexity:  O(nlogn) ,sorting is considered to have running time complexity of O(nlogn) and the for loop runs in O(n) time.
Auxiliary Space: O(1).
            */
        }
    }

}
//below link to check if same site open in multi tabs
//https://pretagteam.com/question/possible-to-detect-if-a-user-has-multiple-tabs-of-your-site-open