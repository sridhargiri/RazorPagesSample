using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find the smallest window in a string containing all characters of another string
Difficulty Level : Hard


Given two strings string1 and string2, the task is to find the smallest substring in string1 containing all characters of string2 efficiently. 
Examples: 

Input: string = “this is a test string”, pattern = “tist” 
Output: Minimum window is “t stri” 
Explanation: “t stri” contains all the characters of pattern.
Input: string = “geeksforgeeks”, pattern = “ork” 
Output: Minimum window is “ksfor”

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
Method 1 ( Brute force solution ) 
1- Generate all substrings of string1 (“this is a test string”) 
2- For each substring, check whether the substring contains all characters of string2 (“tist”) 
3- Finally, print the smallest substring containing all characters of string2.
  
Method 2 ( Efficient Solution ) 

First check if the length of the string is less than the length of the given pattern, if yes then “no such window can exist “.
Store the occurrence of characters of the given pattern in a hash_pat[].
Start matching the characters of pattern with the characters of string i.e. increment count if a character matches.
Check if (count == length of pattern ) this means a window is found.
If such a window found, try to minimize it by removing extra characters from the beginning of the current window.
Update min_length.
Print the minimum length window.
A diagram to explain the stated algorithm:https://media.geeksforgeeks.org/wp-content/cdn-uploads/smallest-window.png
    https://www.geeksforgeeks.org/find-the-smallest-window-in-a-string-containing-all-characters-of-another-string/
    */
    class SmallestWindow
    {
        static int no_of_chars = 256;

        // Function to find smallest 
        // window containing
        // all characters of 'pat'
        static String findSubString(String str,
                                    String pat)
        {
            int len1 = str.Length;
            int len2 = pat.Length;

            // Check if string's length is 
            // less than pattern's
            // length. If yes then no such 
            // window can exist
            if (len1 < len2)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            int[] hash_pat = new int[no_of_chars];
            int[] hash_str = new int[no_of_chars];

            // Store occurrence ofs characters 
            // of pattern
            for (int i = 0; i < len2; i++)
                hash_pat[pat[i]]++;

            int start = 0, start_index = -1,
                min_len = int.MaxValue;

            // Start traversing the string
            // Count of characters
            int count = 0;
            for (int j = 0; j < len1; j++)
            {

                // Count occurrence of characters 
                // of string
                hash_str[str[j]]++;

                // If string's char matches 
                // with pattern's char
                // then increment count
                if (hash_str[str[j]] <= hash_pat[str[j]])
                    count++;

                // if all the characters are matched
                if (count == len2)
                {

                    // Try to minimize the window 
                    while (hash_str[str[start]]
                               > hash_pat[str[start]]
                           || hash_pat[str[start]] == 0)
                    {

                        if (hash_str[str[start]]
                            > hash_pat[str[start]])
                            hash_str[str[start]]--;
                        start++;
                    }

                    // update window size
                    int len_window = j - start + 1;
                    if (min_len > len_window)
                    {
                        min_len = len_window;
                        start_index = start;
                    }
                }
            }

            // If no window found
            if (start_index == -1)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            // Return substring starting from start_index
            // and length min_len
            return str.Substring(start_index, min_len);
        }

        // Driver Method
        public static void Main(String[] args)
        {
            String str = "this is a test string";
            String pat = "tist";

            Console.WriteLine("Smallest window is :\n "
                              + findSubString(str, pat));
            /*
             Output
Smallest window is : 
t stri
            */
        }
    }
}
