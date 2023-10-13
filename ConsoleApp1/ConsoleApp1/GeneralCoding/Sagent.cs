using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    Sagent online xobin test taken on 26 aug 2023 saturday
    3 questions were asked 1 is the "Find the last non repeating character in string"
    remaining two are 
    1. find the length of array after removing the given number
    2. return stock amount

     https://www.geeksforgeeks.org/find-the-last-non-repeating-character-in-string/
    Find the last non repeating character in string
    Given a string str, the task is to find the last non-repeating character in it. 
For example, if the input string is “GeeksForGeeks”, then the output should be ‘r’ and if the input string is “GeeksQuiz” then the output should be ‘z’. 
    if there is no non-repeating character then print -1.
    Examples: 

Input: str = “GeeksForGeeks” 
Output: r 
‘r’ is the first character from the end which has frequency 1.
Input: str = “aabbcc” 
Output: -1 
All the characters of the given string have frequencies greater than 1. 

Approach: Create a frequency array that will store the frequency of each of the characters of the given string. Once the frequencies have been updated, 
    start traversing the string from the end character by character and for every character, 
    if the frequency of the current character is 1 then this is the last non-repeating character. 
    If all the characters have a frequency greater than 1 then print -1.
Below is the implementation of the above approach:

     */
    public class Sagent
    {
        // Maximum distinct characters possible
        static readonly int MAX = 256;

        // Function to return the last non-repeating character
        static String LastNonRepeatingUnique(String str, int n)
        {

            // To store the frequency of each of
            // the character of the given string
            int[] freq = new int[MAX];

            // Update the frequencies
            for (int i = 0; i < n; i++)
                freq[str[i]]++;

            // Starting from the last character
            for (int i = n - 1; i >= 0; i--)
            {

                // Current character
                char ch = str[i];

                // If frequency of the current character is 1
                // then return the character
                if (freq[ch] == 1)
                    return ("" + ch);
            }

            // All the characters of the
            // string are repeating
            return "-1";
        }
        // Driver code
        public static void Main(String[] args)
        {
            String str = "GeeksForGeeks";
            int n = str.Length;
            Console.WriteLine(LastNonRepeatingUnique(str, n));
            /*
             Output: r
Time Complexity: O(n), where n is the length of the given string.
Auxiliary Space: O(256) ? O(1), no extra space is required, so it is a constant
            */
        }

    }
}
