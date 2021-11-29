using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/check-string-isogram-not/
Check if a string is Isogram or not
Difficulty Level : Basic
Last Updated : 13 Nov, 2020
Given a word or phrase, check if it is isogram or not. An Isogram is a word in which no letter occurs more than once.

Examples:

Input : Machine
Output : True
"Machine" does not have any character repeating, 
it is an Isogram

Input : Geek
Output : False
"Geek" has 'e' as repeating character, 
it is not an Isogram
     Efficient approach : In this, count of characters of string are stored in hashmap, and wherever it is found to be greater than 1 for any char, return false else return true. 
     */
    class IsogramProblem
    {
        static bool check_isogram(String str)
        {

            int length = str.Length;
            int[] mapHash = new int[26];

            // loop to store count of chars and 
            // check if it is greater than 1 
            for (int i = 0; i < length; i++)
            {
                mapHash[str[i] - 'a']++;

                // if count > 1, return false 
                if (mapHash[str[i] - 'a'] > 1)
                {
                    return false;
                }
            }

            return true;
        }

        // Driver code 
        public static void Main(String[] args)
        {
            String str = "geeks";
            String str2 = "computer";

            // checking str as isogram 
            if (check_isogram(str))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");

            // checking str2 as isogram 
            if (check_isogram(str2))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            //Output:

            //False
            //True
        }
    }
}
