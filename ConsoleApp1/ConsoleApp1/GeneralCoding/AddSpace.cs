using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/put-spaces-words-starting-capital-letters/
    Put spaces between words starting with capital letters
Difficulty Level : Easy
Last Updated : 22 Oct, 2019
You are given an array of characters which is basically a sentence. However there is no space between different words and the first letter of every word is in uppercase. You need to print this sentence after following amendments:
(i) Put a single space between these words.
(ii) Convert the uppercase letters to lowercase.

Examples:

Input : BruceWayneIsBatman
Output : bruce wayne is batman

Input :  You
Output :  you
We check if the current character is in uppercase then print ” “(space) and convert it into lowercase.
     */
    public class AddSpace
    {

        // Function to amend the sentence
        public static void amendSentence(string sstr)
        {
            char[] str = sstr.ToCharArray();

            // Traverse the string
            for (int i = 0; i < str.Length; i++)
            {

                // Convert to lowercase if its
                // an uppercase character
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    str[i] = (char)(str[i] + 32);

                    // Print space before it
                    // if its an uppercase
                    // character
                    if (i != 0)
                        Console.Write(" ");

                    // Print the character
                    Console.Write(str[i]);
                }

                // if lowercase character
                // then just print
                else
                    Console.Write(str[i]);
            }
        }

        // Driver Code
        public static void Main()
        {
            string str = "BruceWayneIsBatman";

            amendSentence(str);//output -> bruce wayne is batman
        }

    }
}
