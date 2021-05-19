using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/generate-n-bit-gray-codes/
     Generate n-bit Gray Codes
Difficulty Level : Medium
Last Updated : 03 May, 2021
Given a number N, generate bit patterns from 0 to 2^N-1 such that successive patterns differ by one bit. 

Examples:

Input: N = 2
Output: 00 01 11 10

Input: N = 3
Output: 000 001 011 010 110 111 101 100
 
Method-1 

The above sequences are Gray Codes of different widths. Following is an interesting pattern in Gray Codes. 
n-bit Gray Codes can be generated from list of (n-1)-bit Gray codes using following steps. 

Let the list of (n-1)-bit Gray codes be L1. Create another list L2 which is reverse of L1.
Modify the list L1 by prefixing a ‘0’ in all codes of L1.
Modify the list L2 by prefixing a ‘1’ in all codes of L2.
Concatenate L1 and L2. The concatenated list is required list of n-bit Gray codes
For example, following are steps for generating the 3-bit Gray code list from the list of 2-bit Gray code list. 
L1 = {00, 01, 11, 10} (List of 2-bit Gray Codes) 
L2 = {10, 11, 01, 00} (Reverse of L1) 
Prefix all entries of L1 with ‘0’, L1 becomes {000, 001, 011, 010} 
Prefix all entries of L2 with ‘1’, L2 becomes {110, 111, 101, 100} 
Concatenate L1 and L2, we get {000, 001, 011, 010, 110, 111, 101, 100}
To generate n-bit Gray codes, we start from list of 1 bit Gray codes. The list of 1 bit Gray code is {0, 1}. We repeat above steps to generate 2 bit Gray codes from 1 bit Gray codes, then 3-bit Gray codes from 2-bit Gray codes till the number of bits becomes equal to n. 



Below is the implementation of the above approach
    */
    public class GrayCodes
    {

        // This function generates all n bit Gray codes and prints the 
        // generated codes 
        public static void generateGrayarr(int n)
        {
            // base case 
            if (n <= 0)
            {
                return;
            }

            // 'arr' will store all generated codes 
            List<string> arr = new List<string>();

            // start with one-bit pattern 
            arr.Add("0");
            arr.Add("1");

            // Every iteration of this loop generates 2*i codes from previously 
            // generated i codes. 
            int i, j;
            for (i = 2; i < (1 << n); i = i << 1)
            {
                // Enter the prviously generated codes again in arr[] in reverse 
                // order. Nor arr[] has double number of codes. 
                for (j = i - 1; j >= 0; j--)
                {
                    arr.Add(arr[j]);
                }

                // append 0 to the first half 
                for (j = 0; j < i; j++)
                {
                    arr[j] = "0" + arr[j];
                }

                // append 1 to the second half 
                for (j = i; j < 2 * i; j++)
                {
                    arr[j] = "1" + arr[j];
                }
            }

            // print contents of arr[] 
            for (i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        // Driver program to test above function 
        public static void Main(string[] args)
        {
            generateGrayarr(3);
            /*
               // This code is contributed by Shrikant13
Output
000
001
011
010
110
111
101
100
Time Complexity: O(2N) 
Auxiliary Space: O(2N)
            */
        }
    }
    /*
     Method 2: Recursive Approach

 

The idea is to recursively append the bit 0 and 1 each time until the number of bits is not equal to N. 

 

Base Condition: The base case for this problem will be when the value of N = 0 or 1. 



 

If (N == 0)
       return {“0”}
if (N == 1)
     return {“0”, “1”}

 

Recursive Condition: Otherwise, for any value greater than 1, recursively generate the gray codes of the N – 1 bits and then for each of the gray code generated add the prefix 0 and 1.

 

Below is the implementation of the above approach: 
    */
    public class GrayCodesAnother
    {

        // This function generates all n
        // bit Gray codes and prints the
        // generated codes
        static List<String> generateGray(int n)
        {

            // Base case
            if (n <= 0)
            {
                List<String> temp = new List<String>();
                temp.Add("0");
                return temp;
            }
            if (n == 1)
            {
                List<String> temp = new List<String>();
                temp.Add("0");
                temp.Add("1");
                return temp;
            }

            // Recursive case
            List<String> recAns = generateGray(n - 1);
            List<String> mainAns = new List<String>();

            // Append 0 to the first half
            for (int i = 0; i < recAns.Count; i++)
            {
                String s = recAns[i];
                mainAns.Add("0" + s);
            }

            // Append 1 to the second half
            for (int i = recAns.Count - 1; i >= 0; i--)
            {
                String s = recAns[i];
                mainAns.Add("1" + s);
            }
            return mainAns;
        }

        // Function to generate the
        // Gray code of N bits
        static void generateGrayarr(int n)
        {
            List<String> arr = new List<String>();
            arr = generateGray(n);

            // print contents of arr
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            generateGrayarr(3);
            /*
             Output
000
001
011
010
110
111
101
100
Time Complexity: O(2N) 
Auxiliary Space: O(2N)
            */
        }
    }
}
