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
    class BinaryStringConsecutive
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
}
