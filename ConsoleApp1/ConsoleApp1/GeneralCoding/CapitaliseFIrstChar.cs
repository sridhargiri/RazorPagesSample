using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/capitalize-1st-character-of-all-words-having-at-least-k-characters/
Capitalize 1st character of all words having at least K characters
Difficulty Level : Easy
Last Updated : 04 Feb, 2022
Given string str representing a sentence, and an integer K, the task is to capitalize all the words in the given sentence having at least K characters.

Example:

Input: str = “geeks for geeks”, K = 4
Output: Geeks for Geeks
Explanation: The word “for” does not contain 4 characters, hence its 1st character is not capitalize.

Input: str = “geeksforgeeks is the best”, K = 0
Output: Geeksforgeeks Is The Best

Approach: This is an implementation-based problem.

The idea is to calculate the character count of each word and,
if the count of characters is greater than K,
change the case of the 1st character of the word to the upper case
Below is the implementation of the above approach:
    */
    public class CapitaliseFirstChar
    {
        public static void Capitalise_First_Letter_If_Exceeds_Count(string str, int k)
        {
            int ptr = 0;
            char[] strarray = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                // If the current word
                // ends at index i
                if (str[i] == ' ')
                {

                    // Update ptr
                    ptr = i + 1;
                }
                // Count of characters
                // is at least K
                else if (i - ptr + 1 >= k)
                {
                    strarray[ptr] = char.ToUpper(str[ptr]);
                }
            }
            Console.WriteLine(new string(strarray));
        }
        static void Main(string[] args)
        {
            string str = "geeksforgeeks is the best";
            int k = 3;
            Capitalise_First_Letter_If_Exceeds_Count(str, k);
            /*
             Output
Geeksforgeeks is The Best
Time Complexity: O(N), where N is the count of characters in string str.
Auxiliary space: O(1)
            */
        }
    }
}
