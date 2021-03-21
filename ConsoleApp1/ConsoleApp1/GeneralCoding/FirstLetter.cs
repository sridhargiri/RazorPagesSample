using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     String containing first letter of every word in a given string with spaces
Difficulty Level : Easy
 Last Updated : 25 Jan, 2021
A String str is given which contains lowercase English letters and spaces. It may contain multiple spaces. Get the first letter of every word and return the result as a string. The result should not contain any space.
Examples: 

Input : str = "geeks for geeks"
Output : gfg

Input : str = "happy   coding"
Output : hc
Source : https://www.geeksforgeeks.org/amazon-interview-set-8-2/
    https://www.geeksforgeeks.org/string-containing-first-letter-every-word-given-string-spaces/
    
     The idea is to traverse each character of string str and maintain a boolean variable, which was initially set as true. 
    Whenever we encounter space we set the boolean variable as true. And if we encounter any character other than space, we will check boolean variable, if it was set as true then copy that charter to output string and set the boolean variable as false. 
    If the boolean variable is set false, do nothing. 
Algorithm: 

1. Traverse string str. And initialize a variable v as true.
2. If str[i] == ' '. Set v as true.
3. If str[i] != ' '. Check if v is true or not.
   a) If true, copy str[i] to output string and set v as false.
   b) If false, do nothing.
    */
    class FirstLetter
    {

        // Function to find string which has first 
        // character of each word. 
        static String firstLetterWord(String str)
        {
            String result = "";

            // Traverse the string. 
            bool v = true;
            for (int i = 0; i < str.Length; i++)
            {
                // If it is space, set v as true. 
                if (str[i] == ' ')
                {
                    v = true;
                }

                // Else check if v is true or not. 
                // If true, copy character in output 
                // string and set v as false. 
                else if (str[i] != ' ' && v == true)
                {
                    result += (str[i]);
                    v = false;
                }
            }
            return result;
        }

        // Driver code 
        public static void Main()
        {
            String str = "geeks for geeks";
            Console.WriteLine(firstLetterWord(str));
            //Output:

            //    gfg
            //    Time Complexity: O(n)
        }
    }
}
