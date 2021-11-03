using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/check-if-a-given-string-is-a-valid-hexadecimal-color-code-or-not/
    Check if a given string is a valid Hexadecimal Color Code or not
Last Updated : 01 Nov, 2021
Given a string str, the task is to check whether the given string is an HTML Hex Color Code or not. Print Yes if it is, otherwise print No.

Examples: 

Input: str = “#1AFFa1”
Output: Yes

Input: str = “#F00”
Output: Yes



Input: str = “123456”
Output: No

 
Approach:  An HTML Hex Color Code follows the below-mentioned set of rules: 

It starts with the ‘#’ symbol.
Then it is followed by the letters from a-f, A-F and/or digits from 0-9.
The length of the hexadecimal color code should be either 6 or 3, excluding ‘#’ symbol.
For example: #abc, #ABC, #000, #FFF, #000000, #FF0000, #00FF00, #0000FF, #FFFFFF are all valid Hexadecimal color codes.
Now, to solve the above problem follow the below steps:

Check the string str for the following conditions:
If the first character is not #, return false.
If the length is not 3 or 6. If not, return false.
Now, check for all characters other than the first character that are 0-9, A-F or a-f.
If all the conditions mentioned above are satisfied, then return true.
Print answer according to the above observation.
Below is the implementation of the above approach:
    */
    public class HexaCode
    {
        static bool isValidHexaCode(string str)
        {
            if (str[0] != '#')
                return false;

            if (!(str.Length == 4 || str.Length == 7))
                return false;

            for (int i = 1; i < str.Length; i++)
                if (!((str[i] >= '0' && str[i] <= 9)
                      || (str[i] >= 'a' && str[i] <= 'f')
                      || (str[i] >= 'A' || str[i] <= 'F')))
                    return false;

            return true;
        }
        public static void Main(string[] args)
        {
            string str = "#abcd";
            if (isValidHexaCode(str))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");

            }
            /*
             Output:Yes 

Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
