using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Pangram Checking
    ------------------------

Given a string check if it is Pangram or not. A pangram is a sentence containing every letter in the English Alphabet.

Examples : The quick brown fox jumps over the lazy dog ” is a Pangram [Contains all the characters from ‘a’ to ‘z’]
“The quick brown fox jumps over the dog” is not a Pangram [Doesn’t contains all the characters from ‘a’ to ‘z’, as ‘l’, ‘z’, ‘y’ are missing]

We create a mark[] array of Boolean type. 
We iterate through all the characters of our string and whenever we see a character we mark it. 
Lowercase and Uppercase are considered the same. So ‘A’ and ‘a’ are marked in index 0 and similarly ‘Z’ and ‘z’ are marked in index 25.

After iterating through all the characters we check whether all the characters are marked or not. 
If not then return false as this is not a pangram else return true.
     */
    class Pangram
    {

        // Returns true if the string 
        // is pangram else false 
        public static bool checkPangram(string str)
        {

            // Create a hash table to mark the 
            // characters present in the string 
            // By default all the elements of 
            // mark would be false. 
            bool[] mark = new bool[26];

            // For indexing in mark[] 
            int index = 0;

            // Traverse all characters 
            for (int i = 0; i < str.Length; i++)
            {
                // If uppercase character, subtract 'A' 
                // to find index. 
                if ('A' <= str[i] && str[i] <= 'Z')
                    index = str[i] - 'A';

                // If lowercase character, 
                // subtract 'a' to find 
                // index. 
                else if ('a' <= str[i] && str[i] <= 'z')
                    index = str[i] - 'a';

                // If this character is other than english 
                // lowercase and uppercase characters. 
                else
                    continue;

                mark[index] = true;
            }

            // Return false if any 
            // character is unmarked 
            for (int i = 0; i <= 25; i++)
                if (mark[i] == false)
                    return (false);

            // If all characters 
            // were present 
            return (true);
        }

        /*
          "The quick brown fox jumps over the lazy dog"
 is a pangram
Time Complexity: O(n), where n is the length of our string
Auxiliary Space – O(1).
         */

        public static void Main()
        {
            string str = "The quick brown fox jumps over the lazy dog";

            if (checkPangram(str) == true)
                Console.WriteLine(str + " is a pangram.");
            else
                Console.WriteLine(str + " is not a pangram.");
        }
    }
}
