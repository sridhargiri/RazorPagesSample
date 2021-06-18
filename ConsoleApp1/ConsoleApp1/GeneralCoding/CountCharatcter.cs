using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Count characters Asked in brimmatech, here it is my own implementation

    Input: “AABBCCDDAAAAABBBBBBBCEFZZ”
Output: "A2B2C2D2A5B7CEFZ2"

In:AABBCCDDEEFF out:A2B2C2D2E2F2

     */
    class CountCharacter
    {
        public static void Main(string[] args)
        {
            string s = "AABBCCDDAAAAABBBBBBBCEFZZ";
            int temp = 1;
            string output = "";
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    temp++;
                    if (i == s.Length - 1)
                    {
                        output += s[i - 1].ToString();
                        if (temp > 1)
                            output += temp.ToString();
                    }
                }
                else
                {
                    output += s[i - 1].ToString();
                    if (temp > 1)
                        output += temp.ToString();
                    temp = 1;
                }
            }
            Console.WriteLine(output);
        }
    }

    /*
     Run Length Encoding
    Last Updated: 02-11-2020
    Given an input string, write a function that returns the Run Length Encoded string for the input string.
    For example, if the input string is “wwwwaaadexxxxxx”, then the function should return “w4a3d1e1x6”

    Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
    a) Pick the first character from the source string. 
    b) Append the picked character to the destination string. 
    c) Count the number of subsequent occurrences of the picked character and append the count to the destination string. 
    d) Pick the next character and repeat steps b) c) and d) if the end of the string is NOT reached.
     */


    public class RunLength_Encoding
    {
        public static void printRLE(String str)
        {
            int n = str.Length;
            for (int i = 0; i < n; i++)
            {

                // Count occurrences of current character
                int count = 1;
                while (i < n - 1 && str[i] == str[i + 1])
                {
                    count++;
                    i++;
                }

                // Print character and its count
                Console.Write(str[i]);
                if (count > 1) Console.Write(count);
            }
        }

        public static void Main(String[] args)
        {
            //String str = "wwwwaaadexxxxxxywww";
            String str = "AABBCCDDAAAAABBBBBBBCEFZZ";
            printRLE(str);
        }
    }
    /*
     https://www.geeksforgeeks.org/remove-all-occurrences-of-a-character-in-a-string/
    Remove all occurrences of a character in a string
Difficulty Level : Easy
Last Updated : 12 May, 2021
Given a string. Write a program to remove all the occurrences of a character in the string.

Examples: 

Input : s = "geeksforgeeks"
        c = 'e'
Output : s = "gksforgks"


Input : s = "geeksforgeeks"
        c = 'g'
Output : s = "eeksforeeks"
The idea is to maintain an index of the resultant string.  
     */
    public class RemoveAllCharacter
    {
        static void removeChar(string s,
                               char c)
        {
            int j, count = 0, n = s.Length;
            char[] t = s.ToCharArray();
            for (int i = j = 0; i < n; i++)
            {
                if (s[i] != c)
                    t[j++] = s[i];
                else
                    count++;
            }

            while (count > 0)
            {
                t[j++] = '\0';
                count--;
            }

            Console.Write(t);
        }

        // Driver Code
        public static void Main()
        {
            string s = "geeksforgeeks";
            removeChar(s, 'g');
            //Output: 
            //eeksforeeks
        }
    }
}