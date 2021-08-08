using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/string-maximum-number-unique-characters/
    String with maximum number of unique characters
Given a list of strings, find the largest string among all. The largest string is the string with the largest number of unique characters.
 

Example: 

Input : "AN KOW", "LO JO", "ZEW DO RO" 
Output : "ZEW DO RO" 
Explanation : 
"ZEW DO RO" has maximum distinct letters.

Input : "ROMEO", "EMINEM", "RADO"
Output : "ROMEO" 
Explanation : In case of tie, we can print
any of the strings.
 

We iterate over the strings and take a boolean array to check the presence of letters. Also, keep track of the maximum unique letters. Return the string with the maximum number of distinct characters.

     */
    public class MaxUniqueChar
    {

        // Function to find string with maximum
        // number of unique characters.
        public static void LargestString(string[] na)
        {
            int N = na.Length;
            int[] c = new int[N];

            // Index of string with maximum unique
            // characters
            int m = 0;

            // iterate through all strings
            for (int j = 0; j < N; j++)
            {
                // array indicating any alphabet
                // included or not included
                bool[] character = new bool[26];

                // count number of unique alphabets
                // in each string
                for (int k = 0; k < na[j].Length; k++)
                {
                    int x = na[j][k] - 'A';

                    if ((na[j][k] != ' ') &&
                            (character[x] == false))
                    {
                        c[j]++;
                        character[x] = true;
                    }
                }

                // keep track of maximum number of
                // alphabets
                if (c[j] > c[m])
                    m = j;
            }

            // print result
            Console.Write(na[m]);
        }

        // Driver code
        public static void Main()
        {
            string[] na = {"BOB", "A AB C JOHNSON",
           "ANJALI", "ASKRIT", "ARMAN MALLIK"};

            LargestString(na);
            /*
             Output: A AB C JOHNSON
            */
        }
    }
}
