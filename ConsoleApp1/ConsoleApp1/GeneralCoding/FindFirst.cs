// C# program to find first non-repeating character 
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class FindFirst
    {

        static int NO_OF_CHARS = 256;
        static char[] count = new char[NO_OF_CHARS];

        /* calculate count of characters  
        in the passed string */
        static void getCharCountArray(string str)
        {
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;
        }

        /* The method returns index of first non-repeating 
        character in a string. If all characters are  
        repeating then returns -1 */
        static int firstNonRepeating(string str)
        {
            getCharCountArray(str);
            int index = -1, i;

            for (i = 0; i < str.Length; i++)
            {
                if (count[str[i]] == 1)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        // Driver code 
        public static void Main()
        {
            string str = "geeksforgeeks";
            int index = firstNonRepeating(str);

            Console.WriteLine(index == -1 ? "Either " +
            "all characters are repeating or string " +
            "is empty" : "First non-repeating character"
            + " is " + str[index]);
        }
    }
}
