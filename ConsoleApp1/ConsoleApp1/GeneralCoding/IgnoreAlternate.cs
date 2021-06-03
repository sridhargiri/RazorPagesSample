using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/print-string-ignoring-alternate-occurrences-character/   
Print the string by ignoring alternate occurrences of any character
Difficulty Level : Easy
Last Updated : 20 May, 2021
Given a string of both uppercase and lowercase alphabets, the task is to print the string with alternate occurrences of any character dropped(including space and consider upper and lowercase as same).
Examples: 
 

Input : It is a long day Dear.
Output : It sa longdy ear.
Print first I and then ignore next i.
Similarly print first space then 
ignore next space.


Input : Geeks for geeks
Output : Geks fore
Asked in: Microsoft
 

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
As we have to print characters in an alternate manner, so start traversing the string and perform following two steps:- 
 

Increment the count of occurrence of current character in a hash table.
Check if the count becomes odd, then print the current character, else not. 
    */
    class IgnoreAlternate
    {

        // Function to print the string
        static void printStringAlternate(String str)
        {
            int[] occ = new int[122];

            // Convert uppercase to lowercase
            string s = str.ToLower();


            // Start traversing the string
            for (int i = 0; i < str.Length; i++)
            {

                char temp = s[i];

                // Increment occurrence count
                occ[temp]++;

                // If count is odd then print
                // the character
                if (occ[temp] % 2 != 0)
                    Console.Write(str[i]);
            }
            Console.WriteLine();
        }

        // Driver Code
        public static void Main()
        {
            string str1 = "Geeks for geeks";
            string str2 = "It is a long day Dear";
            printStringAlternate(str1);
            printStringAlternate(str2);
            /*
             Output:  

Geks fore
It sa longdy ear
             */
        }
    }
}
