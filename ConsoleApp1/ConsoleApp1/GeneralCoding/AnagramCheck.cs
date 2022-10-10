using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/cpp-program-to-check-whether-two-strings-are-anagram-of-each-other/
    Program To Check Whether Two Strings Are Anagram Of Each Other
    Write a function to check whether two given strings are anagram of each other or not. An anagram of a string is another string that contains the same characters, only the order of characters can be different. 
    For example, “abcd” and “dabc” are an anagram of each other
     LISTEN     SILENT
    TRAINGLE    Integral
    these are anagrams
    Method 1 (Use Sorting):  

Sort both strings
Compare the sorted strings
    Method 2
    Method 2 (Count characters): 
This method assumes that the set of possible characters in both strings is small. In the following implementation, it is assumed that the characters are stored using 8 bit and there can be 256 possible characters. 

Create count arrays of size 256 for both strings. Initialize all values in count arrays as 0.
Iterate through every character of both strings and increment the count of character in the corresponding count arrays.
Compare count arrays. If both count arrays are same, then return true.
Below is the implementation of the above idea:
     */
    public class AnagramCheck
    {

        static int NO_OF_CHARS = 256;

        /* function to check whether two strings 
        are anagram of each other */
        static bool areAnagram(char[] str1, char[] str2)
        {
            // Create 2 count arrays and initialize 
            // all values as 0 
            int[] count1 = new int[NO_OF_CHARS];
            int[] count2 = new int[NO_OF_CHARS];
            int i;

            // For each character in input strings, 
            // increment count in the corresponding 
            // count array 
            for (i = 0; i < str1.Length && i < str2.Length;i++)
            {
                count1[str1[i]]++;
                count2[str2[i]]++;
            }

            // If both strings are of different length. 
            // Removing this condition will make the program 
            // fail for strings like "aaca" and "aca" 
            if (str1.Length != str2.Length)
                return false;

            // Compare count arrays 
            for (i = 0; i < NO_OF_CHARS; i++)
                if (count1[i] != count2[i])
                    return false;

            return true;
        }

        /* Driver program to test to print printDups*/
        public static void Main()
        {
            List<int> countarray = new List<int>();
            char[] str1 = ("geeksforgeeks").ToCharArray();
            char[] str2 = "forgeeksgeeks".ToCharArray();

            if (areAnagram(str1, str2))
                Console.WriteLine("The two strings are"
                                  + "anagram of each other");
            else
                Console.WriteLine("The two strings are not"
                                  + " anagram of each other");
            /*
             Output:

The two strings are anagram of each other
Time Complexity: O(n)

Auxiliary space: O(n)
            */
        }
    }
}
