
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Given a string str consisting of upper case alphabets, numeric digits and arithmetic operators, the task is to group them into continuous sub-strings of same type.

Examples:

Input: str = “G E E K S 1 2 3 4 5”
Output: GEEKS 12345
All contiguous upper case characters can be grouped together
and all the numeric characters can be grouped together in a separate group.

Input: str = “DEGFT +- * 5 6 7”
Output: DEGFT +-* 567

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: Remove all the spaces from string. After removing all the white spaces, traverse the string one by one and group the characters according to their ASCII values.
    */
    class GroupCharacters
    {

        // Function to return the modified String 
        static String groupCharacters(char[] s, int len)
        {

            // Store original String 
            string temp = "";

            // Remove all white spaces 
            for (int j = 0; j < len; j++)
                if (s[j] != ' ')
                    temp = temp + s[j];

            len = temp.Length;

            // To store the resultant String 
            string ans = "";
            int i = 0;

            // Traverse the String 
            while (i < len)
            {

                // Group upper case characters 
                if (temp[i] >= ('A')
                    && temp[i] <= ('Z'))
                {
                    while (i < len && temp[i] >= ('A')
                        && temp[i] <= ('Z'))
                    {
                        ans = ans + temp[i];
                        i++;
                    }
                    ans = ans + " ";
                }

                // Group numeric characters 
                else if (temp[i] >= ('0')
                        && temp[i] <= ('9'))
                {
                    while (i < len && temp[i] >= ('0')
                        && temp[i] <= ('9'))
                    {
                        ans = ans + temp[i];
                        i++;
                    }
                    ans = ans + " ";
                }

                // Group arithmetic operators 
                else
                {
                    while (i < len && temp[i] >= ('*')
                        && temp[i] <= ('/'))
                    {
                        ans = ans + temp[i];
                        i++;
                    }
                    ans = ans + " ";
                }
            }

            // Return the resultant String 
            return ans;
        }

        // Driver code 
        public static void Main()
        {
            string s = "34FTG234+ +- *";
            int len = s.Length;
            Console.WriteLine(groupCharacters(s.ToCharArray(), len));
        }
    }

    // This code contributed by Ryuga 

}
