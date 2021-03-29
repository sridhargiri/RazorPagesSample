using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Return maximum occurring character in an input string
Difficulty Level : Easy
Last Updated : 22 Mar, 2021
 
Write an efficient function to return maximum occurring character in the input string e.g., if input string is “test” then function should return ‘t’.
 

 
Algorithm: 
One obvious approach to solve this problem would be to sort the input string and then traverse through the sorted string to find the character which is occurring maximum number of times. Let us see if we can improve on this. So we will use a technique called ‘Hashing’. In this, when we traverse through the string, we would hash each character into an array of ASCII characters. 
 

Input string = “test”
1: Construct character count array from the input string.
  count['e'] = 1
  count['s'] = 1
  count['t'] = 2

2: Return the index of maximum value in count array (returns ‘t’).
Typically, ASCII characters are 256, so we use our Hash array size as 256. But if we know that our input string will have characters with value from 0 to 127 only, we can limit Hash array size as 128. Similarly, based on extra info known about input string, the Hash array size can be limited to 26.
https://www.geeksforgeeks.org/return-maximum-occurring-character-in-the-input-string/
Implementation:
    */
    class MaxOccuringCharacter
    {
        static int ASCII_SIZE = 256;

        static char getMaxOccuringChar(String str)
        {
            // Create array to keep the count of
            // individual characters and
            // initialize the array as 0
            int[] count = new int[ASCII_SIZE];

            // Construct character count array
            // from the input string.
            int len = str.Length;
            for (int i = 0; i < len; i++)
                count[str[i]]++;

            int max = -1; // Initialize max count
            char result = ' '; // Initialize result

            // Traversing through the string and
            // maintaining the count of each character
            for (int i = 0; i < len; i++)
            {
                if (max < count[str[i]])
                {
                    max = count[str[i]];
                    result = str[i];
                }
            }

            return result;
        }

        // Driver Method
        public static void Main()
        {
            String str = "sample string";
            Console.Write("Max occurring character is " +
                                getMaxOccuringChar(str));
            /*
             Output: 
 

Max occurring character is s
Time Complexity: O(n) 
Space Complexity: O(1) — Because we are using fixed space (Hash array) irrespective of input string size.
            */
        }
    }
}
