using System;
using System.Collections.Generic;

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
    /*
    A string is given and we have to reverse the string in such a way that each word are at the same position and it should be reversed.
    For example if input string is ”do coding from geeksforgeeks” then the output string will be “od gnidoc morf skeegrofskeeg”
    */
    public class ReverseWordsSentence
    {

        // Reverse the letters
        // of the word
        static void reverse_words_only(char[] str,
                            int start,
                            int end)
        {

            // Temporary variable
            // to store character
            char temp;

            while (start <= end)
            {

                // Swapping the first
                // and last character
                temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }
        }

        // Function to reverse words
        static char[] reverseWords(char[] s)
        {

            // Reversing individual words as
            // explained in the first step

            int start = 0;
            for (int end = 0; end < s.Length; end++)
            {

                // If we see a space, we
                // reverse the previous
                // word (word between
                // the indexes start and end-1
                // i.e., s[start..end-1]
                if (s[end] == ' ')
                {
                    if(end-start>1)reverse_words_only(s, start, end-1);
                    start = end + 1;
                }
            }

            // Reverse the last word
            reverse_words_only(s, start, s.Length - 1);
            return s;
        }
        public static void Main(String[] args)
        {
            String s = "do coding from geeksforgeeks";
            char[] p = reverseWords(s.ToCharArray());
            Console.Write(p);
            //output
            //od gnidoc morf skeegrofskeeg
        }
    }
    /*
     https://www.geeksforgeeks.org/write-a-program-to-reverse-an-array-or-string/?ref=leftbar-rightbar
    Write a program to reverse an array or string
Difficulty Level : Basic
Last Updated : 08 Sep, 2020
 
Given an array (or string), the task is to reverse the array/string.
Examples : 
 

Input  : arr[] = {1, 2, 3}
Output : arr[] = {3, 2, 1}

Input :  arr[] = {4, 5, 1, 2}
Output : arr[] = {2, 1, 5, 4}



 

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
 

 
Iterative way :
 

1) Initialize start and end indexes as start = 0, end = n-1 
2) In a loop, swap arr[start] with arr[end] and change start and end as follows : 
start = start +1, end = end – 1




 
 

reverse-a-number

Another example to reverse a string:
 

reverse-a-string

Below is the implementation of the above approach : 
    */
    public class ReverseArray
    {
        /* Function to reverse arr[]
        from start to end*/
        static void rvereseArray(int[] arr, int start,
                                            int end)
        {
            int temp;
            if (start >= end)
                return;

            temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;

            rvereseArray(arr, start + 1, end - 1);
        }

        /* Utility that prints out an
        array on a line */
        static void printArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine("");
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            printArray(arr, 6);
            rvereseArray(arr, 0, 5);

            Console.WriteLine("Reversed array is ");
            printArray(arr, 6);
            /*
             Output : 

1 2 3 4 5 6 
Reversed array is 
6 5 4 3 2 1 


Time Complexity : O(n)
            */
        }
    }
    /*
https://www.geeksforgeeks.org/reverse-words-in-a-given-string/
    Reverse words in a given string
Difficulty Level : Medium
Last Updated : 30 Mar, 2021
Example: Let the input string be “i like this program very much”. The function should change the string to “much very program this like i”

reverse-words

Examples: 

Input: s = “geeks quiz practice code” 
Output: s = “code practice quiz geeks”

Input: s = “getting good at coding needs a lot of practice” 
Output: s = “practice of lot a needs coding at good getting” 




Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 

Algorithm:  

Initially, reverse the individual words of the given string one by one, for the above example, after reversing individual words the string should be “i ekil siht margorp yrev hcum”.
Reverse the whole string from start to end to get the desired output “much very program this like i” in the above example.
Below is the implementation of the above approach

     */
    public class ReverseWordsInSentence
    {

        // Reverse the letters
        // of the word
        static void reverse_words_only(char[] str,
                            int start,
                            int end)
        {

            // Temporary variable
            // to store character
            char temp;

            while (start <= end)
            {

                // Swapping the first
                // and last character
                temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }
        }

        // Function to reverse words
        static char[] reverseWords(char[] s)
        {

            // Reversing individual words as
            // explained in the first step

            int start = 0;
            for (int end = 0; end < s.Length; end++)
            {

                // If we see a space, we
                // reverse the previous
                // word (word between
                // the indexes start and end-1
                // i.e., s[start..end-1]
                if (s[end] == ' ')
                {
                    reverse_words_only(s, start, end);
                    start = end + 1;
                }
            }

            // Reverse the last word
            reverse_words_only(s, start, s.Length - 1);

            // Reverse the entire String
            reverse_words_only(s, 0, s.Length - 1);
            return s;
        }
        /*Another Approach:

we can do the above task by splitting and saving the string in a reverse manner. 

Below is the implementation of the above approach:


         */
        static void ReverseWordsSentence()
        {
            string[] s = "i like this program very much".
                                             Split(' ');
            string ans = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                ans += s[i] + " ";
            }
            Console.Write("Reversed String:\n");
            Console.Write(ans.Substring(0,
                                        ans.Length - 1));
        }
        public static void Main(String[] args)
        {
            String s = "i like this program very much";
            char[] p = reverseWords(s.ToCharArray());
            Console.Write(p);
        }

    }
    /*
https://www.geeksforgeeks.org/reverse-string-according-number-words/
    Reverse String according to the number of words
Difficulty Level : Easy
Last Updated : 24 Jan, 2020
Given a string containing a number of words. If the count of words in string is even then reverse its even position’s words else reverse its odd position, push reversed words at the starting of a new string and append the remaining words as it is in order.

Examples:

Input:  Ashish Yadav Abhishek Rajput Sunil Pundir
Output: ridnuP tupjaR vadaY Ashish Abhishek Sunil

Input:  Ashish Yadav Abhishek Rajput Sunil Pundir Prem
Output: merP linuS kehsihbA hsihsA Yadav Rajput Pundir
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach : If number of words are even then even position’s words come first and also reverse that particular word, and if number of words are odd then odd position’s words come first and also reverse that particular word, after then the remaining words are appended in order. For e.g.

Ashish Yadav Abhishek Rajput Sunil Pundir.
In the above string, the number of words is even then “Yadav Rajput Pundir” comes at the even position and then the final output will be:
ridnuP tupjaR vadaY Ashish Abhishek Sunil
     */
    public class ReverseAtEvenOdd
    {

        // Reverse the letters of the word 
        static void reverse(char[] str,
                           int start, int end)
        {

            // Temporary variable to store character 
            char temp;
            while (start <= end)
            {
                // Swapping the first and last character 
                temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }
        }

        // This function forms the required string 
        static void reverseletter(char[] str,
                                int start, int end)
        {

            int wstart, wend;
            for (wstart = wend = start; wend < end; wend++)
            {

                if (str[wend] == ' ')
                {
                    continue;
                }

                // Checking the number of words 
                // present in string to reverse 
                while (wend <= end && str[wend] != ' ')
                {
                    wend++;
                }
                wend--;

                // Reverse the letter 
                // of the words 
                reverse(str, wstart, wend);
            }
        }

        // Driver Code 
        public static void Main(String[] args)
        {
            char[] str = "Ashish Yadav Abhishek Rajput Sunil Pundir".ToCharArray();
            reverseletter(str, 0, str.Length - 1);
            Console.Write("{0}", String.Join("", str));
            //Output:
            //ridnuP tupjaR vadaY Ashish Abhishek Sunil
        }
    }
}
