using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-the-count-of-substrings-in-alphabetic-order/
    Find the count of substrings in alphabetic order
Difficulty Level : Basic
Last Updated : 30 Apr, 2021
Given a string of length N  consisting of lowercase alphabets. The task is to find the number of such substrings whose characters occur in alphabetical order. Minimum allowed length of substring is 2.
Examples: 
 

Input : str = "refjhlmnbv"
Output : 2
Substrings are: "ef", "mn"

Input : str = "qwertyuiopasdfghjklzxcvbnm"
Output : 3
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
For a substring to be in alphabetical order its character is in the same sequence as they occur in English alphabets. Also, the ASCII value of consecutive characters in such substring differs by exactly 1. For finding a total number of substrings that are in alphabetical order traverse the given string and compare two neighboring characters, if they are in alphabetic order increment the result and then find the next character in the string which is not in alphabetic order to its former character.
Algorithm : 
Iterate over string length: 
 

if str[i]+1 == str[i+1] -> increase the result by 1 and iterate the string till next character which is out of alphabetic order
else continue
Below is the implementation of the above approach
     */
    class SubstringAlphabeticalOrder
    {

        // Function to find number of substrings 
        public static int findSubstringCountAlphabeticalOrder(string str)
        {
            int result = 0;
            int n = str.Length;

            // Iterate over string length 
            for (int i = 0; i < n - 1; i++)
            {
                // if any two chars are in alphabetic order 
                if ((char)(str[i] + 1) == str[i + 1])
                {
                    result++;
                    // find next char not in order 
                    while ((char)(str[i] + 1) == str[i + 1])
                    {
                        i++;
                    }
                }
            }

            // return the result 
            return result;
        }

        // Driver function 
        public static void Main(string[] args)
        {
            string str = "alphabet";

            Console.WriteLine(findSubstringCountAlphabeticalOrder(str));
            // op 1
        }

    }
}
