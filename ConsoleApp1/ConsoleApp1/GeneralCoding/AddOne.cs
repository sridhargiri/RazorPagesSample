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
}