/*
Add one to last element. If sum exceeds nine carry over 1 to previous element. asked in agilysys
1,2,3=1,2,4
1,2,9=1,3,0
9,9,9=1,0,0,0
*/
// C# Program to add 1 to an array 
// representing a number 
using System;
namespace ConsoleApp1
{

    /*
     Given an array which represents a number, add 1 to the array. Suppose an array contain elements [1, 2, 3, 4] then the array represents decimal number 1234 and hence adding 1 to this would result 1235. So new array will be [1, 2, 3, 5].

Examples:

Input :  [1, 2, 3, 4]
Output : [1, 2, 3, 5]

Input :  [1, 2, 9, 9]
Output : [1, 3, 0, 0]

Input:  [9, 9, 9, 9]
Output: [1, 0, 0, 0, 0]
    
     Approach :
1. Add 1 to the last element of the array, if it is less than 9.
2. If it is 9, then make it 0 and recurse for the remaining element of the array.

     */
    public class AddOne
    {

        // function to add one and print the array 
        void sum(int[] arr, int n)
        {

            int i = n;

            // if array element is less than 9, then 
            // simply add 1 to this. 
            if (arr[i] < 9)
            {
                arr[i] = arr[i] + 1;
                return;
            }

            // if array element is greater than 9, 
            // replace it with 0 and decrement i 
            arr[i] = 0;
            i--;

            // recursive function 
            sum(arr, i);
        }

        // driver code 
        static public void Main()
        {
            AddOne obj = new AddOne();

            // number of elements in array 
            int n = 4;

            // array elements, index of array 
            // should be 1 based, hence, 0 is 
            // added here at arr[0] 
            int[] arr = { 0, 1, 9, 3, 9 };

            // function calling 
            obj.sum(arr, n);

            // If 1 was appended at head 
            // of array then, print it 
            if (arr[0] > 0)
                Console.Write(arr[0] + ", ");
            int i;
            // print the array elements 
            // after adding one 
            for (i = 1; i <= n; i++)
            {
                Console.Write(arr[i]);

                if (i < n)
                    Console.Write(", ");
            }

        }
    }
    /*
     Approach : To add one to number represented by digits, follow the below steps :

Parse the given array from end like we do in school addition.
If the last elements 9, make it 0 and carry = 1.
For the next iteration check carry and if it adds to 10, do same as step 2.
After adding carry, make carry = 0 for the next iteration.
If the vectors add and increase the vector size, append 1 in the beginning.
Below is the implementation to add 1 to number represented by digits.
    */
    class AddOneSchoolAddition
    {
        // Driver code 
        static void Main(string[] args)
        {
            int carry = 0;
            int[] array = new int[] { 1, 7, 8, 9 };

            // find the length of the array 
            int n = array.Length;

            // Add 1 to the last digit and find carry  
            array[n - 1] += 1;
            carry = array[n - 1] / 10;
            array[n - 1] = array[n - 1] % 10;

            // Traverse from second last digit  
            for (int i = n - 2; i >= 0; i--)
            {
                if (carry == 1)
                {
                    array[i] += 1;
                    carry = array[i] / 10;
                    array[i] = array[i] % 10;
                }
            }

            // If the carry is 1, we need to add 
            // a 1 at the beginning of the array 
            if (carry == 1)
            {
                Array.Resize(ref array, n + 1);
                array[0] = carry;
            }

            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i] + " ");

        }
    }
    /*
     https://www.geeksforgeeks.org/add-two-numbers-without-using-arithmetic-operators/
    Add two numbers without using arithmetic operators
Difficulty Level : Hard
Last Updated : 22 Apr, 2021
Write a function Add() that returns sum of two integers. The function should not use any of the arithmetic operators (+, ++, –, -, .. etc).
Sum of two bits can be obtained by performing XOR (^) of the two bits. Carry bit can be obtained by performing AND (&) of two bits. 

Above is simple Half Adder logic that can be used to add 2 single bits. We can extend this logic for integers. If x and y don’t have set bits at same position(s), then bitwise XOR (^) of x and y gives the sum of x and y. To incorporate common set bits also, bitwise AND (&) is used. 
    Bitwise AND of x and y gives all carry bits. We calculate (x & y) << 1 and add it to x ^ y to get the required result. 
     */
    public class AdditionWithoutOperator
    {
        static int AddRecurbit(int x, int y)
        {
            if (y == 0)
                return x;
            else
                return Add(x ^ y, (x & y) << 1);
        }
        static int Add(int x, int y)
        {
            // Iterate till there is no carry
            while (y != 0)
            {
                // carry now contains common
                // set bits of x and y
                int carry = x & y;

                // Sum of bits of x and
                // y where at least one
                // of the bits is not set
                x = x ^ y;

                // Carry is shifted by
                // one so that adding it
                // to x gives the required sum
                y = carry << 1;
            }
            return x;
        }

        // Driver code
        public static void Main()
        {
            Console.WriteLine(Add(15, 32));//op 47
        }
    }
}