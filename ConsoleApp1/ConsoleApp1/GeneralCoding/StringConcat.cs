using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/c-program-to-concatenate-two-strings-without-using-strcat/?ref=gcse
 Input: str1 = "hello", str2 = "world"
Output: helloworld

Input: str1 = "Geeks", str2 = "World"
Output: GeeksWorld
    Approach:

Get the two Strings to be concatenated
Declare a new Strings to store the concatenated String
Insert the first string in the new string
Insert the second string in the new string
Print the concatenated string
Below is the implementation of the above approach:
     */
    class StringConcat
    {
        public static string ConcatTwoString(string str1, string str2)
        {
            string str3 = "";
            int i = 0;

            // Insert the first string in the new string
            while (i < str1.Length)
            {
                str3 += str1[i];
                i++;
            }

            // Insert the second string in the new string
            i = 0;
            while (i < str2.Length)
            {
                str3 += str2[i];
                i++;
            }
            return str3;
        }
        public static void Main(string[] args)
        {
            string st = ConcatTwoString("abc", "def");
            Console.WriteLine(st);
            //output abcdef
        }
    }
}
