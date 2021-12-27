using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/convert-alternate-characters-string-upper-case/
    Convert characters of a string to opposite case
    Given a string, convert the characters of the string into opposite case,i.e. if a character is lower case then convert it into upper case and vice-versa. 

Examples: 
    Input : geeksForgEeks
Output : GEEKSfORGeEKS

Input : hello every one
Output : HELLO EVERY ONE

     */
    class OppositeCase
    {
        /*
         ASCII values  of alphabets: A – Z = 65 to 90, a – z = 97 to 122 
Steps: 

Take one string of any length and calculate its length.
Scan string character by character and keep checking the index. 
If a character in an index is in lower case, then subtract 32 to convert it in upper case, else add 32 to convert it in lower case
Print the final string.
        */
        static void convertOpposite(StringBuilder str)
        {
            int ln = str.Length;

            // Conversion according to ASCII values
            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')

                    //Convert lowercase to uppercase
                    str[i] = (char)(str[i] - 32);

                else if (str[i] >= 'A' && str[i] <= 'Z')

                    //Convert uppercase to lowercase
                    str[i] = (char)(str[i] + 32);
            }
        }
        /*
         Output
gEeKsFoRgEeKs
Time Complexity: O(n) 
        */
        static char[] S = "GeKf@rGeek$".ToCharArray();

        /*
         Approach 2: The problem can be solved using letter case toggling. Follow the below steps to solve the problem:

Traverse the given string S.
For each character Si, do Si =  Si ^ (1 << 5).
Si ^ (1 << 5) toggles the 5th bit which means 97 will become 65 and 65 will become 97:
65 ^ 32 = 97
97 ^ 32 = 65 
Print the string after all operations
Below is the implementation of the above approach
        */
        static void toggleChars()
        {
            for (int i = 0; i < S.Length; i++)
            {
                if (char.IsLetter(S[i]))
                {
                    S[i] = (char)((int)(S[i]) ^ (1 << 5));
                }
            }
        }

        // Driver code
        public static void Main()
        {
            StringBuilder str = new StringBuilder("GeEkSfOrGeEkS");
            // Calling the Method
            convertOpposite(str);
            Console.WriteLine(str);
        }
    }
}
