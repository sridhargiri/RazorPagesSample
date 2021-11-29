using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if a binary string contains consecutive same or not
Difficulty Level : Basic
 Last Updated : 01 Feb, 2019
Given a binary string str consisting of characters ‘0’ and ‘1’. The task is to find whether the string is valid or not. A string is valid only if the characters are alternating i.e. no two consecutive characters are same.

Examples:

Input: str[] = “010101”
Output: Valid

Input: str[] = “010010”
Output: Invalid


Approach: Start traversing the string character by character and if there are any two consecutive characters that are equal then print Invalid else print Valid in the end.
    */
    public class BinaryStringConsecutive
    {

        // Function that returns true is str is valid 
        static bool isValid(string str, int len)
        {

            // Assuming the string is binary 
            // If any two consecutive  
            // characters are equal 
            // then the string is invalid 
            for (int i = 1; i < len; i++)
            {
                if (str[i] == str[i - 1])
                    return false;
            }

            // If the string is alternating 
            return true;
        }

        // Driver code 
        public static void Main()
        {
            string str = "0110";
            int len = str.Length;

            if (isValid(str, len))
                Console.Write("Valid");
            else
                Console.Write("Invalid");//op invalid
        }
    }
    /*
     https://www.geeksforgeeks.org/given-binary-string-count-number-substrings-start-end-1/
    Given a binary string, count number of substrings that start and end with 1
    Given a binary string, count number of substrings that start and end with 1. For example, if the input string is “00100101”, then there are three substrings “1001”, “100101” and “101”.


     */
    public class BinaryStringBeginEndWithOne
    {
        /*
         A Simple Solution is to run two loops. Outer loops picks every 1 as starting point and inner loop searches for ending 1 and increments count whenever it finds 1.
        */
        public static int countSubStrWithBeginEndOne(char[] str, int n)
        {
            int res = 0; // Initialize result

            // Pick a starting point
            for (int i = 0; i < n; i++)
            {
                if (str[i] == '1')
                {
                    // Search for all possible
                    // ending point
                    for (int j = i + 1; j < n; j++)
                    {
                        if (str[j] == '1')
                        {
                            res++;
                        }
                    }
                }
            }
            return res;
            /*
             Output: 3
            O(n*n)
            */
        }
        /*
Time Complexity of the above solution is O(n2). We can find count in O(n) using a single traversal of input string. Following are steps. 
a) Count the number of 1’s. Let the count of 1’s be m. 
b) Return m(m-1)/2 
The idea is to count total number of possible pairs of 1’s.
        asked in JP Morga chase
        */

        static int countSubStrWithBeginEndOne1(char[] str, int n)
        {
            int m = 0; // Count of 1's in
                       // input string

            // Traverse input string and
            // count of 1's in it
            for (int i = 0; i < n; i++)
            {
                if (str[i] == '1')
                    m++;
            }

            // Return count of possible
            // pairs among m 1's
            return m * (m - 1) / 2;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            GFG count = new GFG();
            String strings = "00100101";
            char[] str = strings.ToCharArray();
            int n = str.Length;
            Console.Write(countSubStrWithBeginEndOne1(str, n));//op 3
        }
    }
}
