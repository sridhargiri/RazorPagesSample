using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     Below id the modified version taken from geeksforgeeks , asked in Sage IT (qualify.com)
    First question
     https://www.geeksforgeeks.org/print-the-middle-character-of-a-string/
    Given string str, the task is to print the middle character of a string. 
    If the length of the string is even,print two middle characters, if odd print themiddle character alone.
    Examples:

Input: str = “Java”
Output: v
Explanation: 
The length of the given string is even. 
output is "av", since str ength is even.

Input: str = “GeeksForGeeks”
Output: o
Explanation: 
The length of the given string is odd. 
output is "o", since str length is odd

    Approach:

Get the string whose middle character is to be found.
Calculate the length of the given string.
Finding the middle index of the string.
Now, print the middle character of the string at index middle using function
     */
    public class MiddleCharacter
    {
        public static void printMiddlechar(String str)
        {

            // Finding string length
            int len = str.Length;

            // Finding middle index of string
            int middle = len / 2;

            // Print the middle character
            // of the string
            if (len % 2 == 0)
                Console.Write(str[middle - 1].ToString() + str[middle].ToString());
            else
                Console.Write(str[middle]);
        }
        public static void Main(String[] args)
        {

            // Given string str
            String str = "test";

            // Function call
            printMiddlechar(str);
        }
    }

    /*
     second question
    see both question and answer (java) below link
    https://github.com/RobertKalo/CodeWars/blob/master/src/com/codewars/main/SortColumnsCSV.java
     */
}
