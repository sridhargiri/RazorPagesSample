using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
   https://www.geeksforgeeks.org/check-whether-second-string-can-formed-first-string-using-count-array/  
     Check whether second string can be formed from characters of first string
Difficulty Level : Easy
Last Updated : 12 May, 2021
Given two strings str1 and str2, check if str2 can be formed from str1
Example : 
 

Input : str1 = geekforgeeks, str2 = geeks
Output : Yes
Here, string2 can be formed from string1.

Input : str1 = geekforgeeks, str2 = and
Output :  No
Here string2 cannot be formed from string1.

Input : str1 = geekforgeeks, str2 = geeeek
Output :  Yes
Here string2 can be formed from string1
as string1 contains 'e' comes 4 times in
string2 which is present in string1. 
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to count frequencies of characters of str1 in a count array. Then traverse str2 and decrease frequency of characters of str2 in the count array. If frequency of a characters becomes negative at any point, return false.
Below is the implementation of above approach
     */
    class SecondString
    {

        static int MAX = 256;

        static bool canMakeStr2(string str1, string str2)
        {
            // Create a count array and count frequencies
            // characters in str1.
            int[] count = new int[MAX];
            for (int i = 0; i < str1.Length; i++)
                count[str1[i]]++;

            // Now traverse through str2 to check
            // if every character has enough counts
            for (int i = 0; i < str2.Length; i++)
            {
                if (count[str2[i]] == 0)
                    return false;
                count[str2[i]]--;
            }
            return true;
        }

        // Driver Code
        static public void Main()
        {
            string str1 = "geekforgeeks";
            string str2 = "for";
            if (canMakeStr2(str1, str2))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");//output yes
        }
    }

}
