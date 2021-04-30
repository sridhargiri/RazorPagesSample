using System;
namespace ConsoleApp1
{

    public class ReverseStr
    {
        /// <summary>
        /// Reverse str skip special character
        /// Input string: a!!!b.c.d,e'f,ghi
        /// Output string: i!!!h.g.f,e'd,cba
        /// </summary>
        /// <param name="str"></param>
        public static void reverse(char[] str)
        {
            // Initialize left and right pointers  
            int r = str.Length - 1, l = 0;

            // Traverse string from both ends until  
            // 'l' and 'r'  
            while (l < r)
            {
                // Ignore special characters  
                if (!char.IsLetter(str[l]))
                    l++;
                else if (!char.IsLetter(str[r]))
                    r--;

                // Both str[l] and str[r] are not spacial  
                else
                {
                    char tmp = str[l];
                    str[l] = str[r];
                    str[r] = tmp;
                    l++;
                    r--;
                }
            }
        }

        // Driver Code  
        public static void Main()
        {
            String str = "a!!!b.c.d,e'f,gh";
            char[] charArray = str.ToCharArray();

            Console.WriteLine("Input string: " + str);
            reverse(charArray);
            String revStr = new String(charArray);

            Console.WriteLine("Output string: " + revStr);
        }
    }
    /*
     https://www.geeksforgeeks.org/reverse-the-substrings-of-the-given-string-according-to-the-given-array-of-indices/
    Reverse the substrings of the given String according to the given Array of indices
Difficulty Level : Basic
Last Updated : 04 Mar, 2020
Given a string S and an array of indices A[], the task is to reverse the substrings of the given String according to the given Array of indices.

Note: A[i] ≤ length(S), for all i.

Examples:

Input: S = “abcdef”, A[] = {2, 5}
Output: baedcf
Explanation:


Input: S = “abcdefghij”, A[] = {2, 5}
Output: baedcjihgf



Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The idea is to use the concept of reversing the substrings of the given string.

Sort the Array of Indices.
Extract the substring formed for each index in the given array as follows:
For the first index in the array A, the substring formed will be from index 0 to A[0] (exclusive) of the given string, i.e. [0, A[0])
For all other index in the array A (except for last), the substring formed will be from index A[i] to A[i+1] (exclusive) of the given string, i.e. [A[i], A[i+1])
For the last index in the array A, the substring formed will be from index A[i] to L (inclusive) where L is the length of the string, i.e. [A[i], L]
Reverse each substring found in the given string
Below is the implementation of the above approach

     */
    public class ReverseStrIndices
    {

        static String s;

        // Function to reverse a String
        static void reverseStr(int l, int h)
        {
            int n = h - l;

            // Swap character starting
            // from two corners
            for (int i = 0; i < n / 2; i++)
            {
                s = swap(i + l, n - i - 1 + l);
            }
        }

        // Function to reverse the String
        // with the given array of indices
        static void reverseString(int[] A, int n)
        {

            // Reverse the String from 0 to A[0]
            reverseStr(0, A[0]);

            // Reverse the String for A[i] to A[i+1]
            for (int i = 1; i < n; i++)
                reverseStr(A[i - 1], A[i]);

            // Reverse String for A[n-1] to length
            reverseStr(A[n - 1], s.Length);
        }

        static String swap(int i, int j)
        {
            char[] ch = s.ToCharArray();
            char temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
            return String.Join("", ch);
        }

        // Driver Code
        public static void Main(String[] args)
        {
            s = "abcdefgh";
            int[] A = { 2, 4, 6 };
            int n = A.Length;

            reverseString(A, n);
            Console.Write(s);//output : badcfehg
        }
    }
}
