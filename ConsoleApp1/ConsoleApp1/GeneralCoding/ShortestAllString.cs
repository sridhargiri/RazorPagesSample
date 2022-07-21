using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     Asked in nagarro, taken test on 21/07/2022
    */
    public class Nagarro_ShortestSubstring
    {
        static int no_of_chars = 256;

        // Function to find smallest
        // window containing
        // all characters of 'pat'

        /*
https://www.geeksforgeeks.org/find-the-smallest-window-in-a-string-containing-all-characters-of-another-string/
        Find the smallest window in a string containing all characters of another string
Given two strings, string1 and string2, the task is to find the smallest substring in string1 containing all characters of string2 efficiently. 

Examples: 
        Input: string = “this is a test string”, pattern = “tist” 
Output: Minimum window is “t stri” 
Explanation: “t stri” contains all the characters of pattern.

Input: string = “geeksforgeeks”, pattern = “ork” 
Output: Minimum window is “ksfor”

         Method 1 ( Brute force solution ) 
1- Generate all substrings of string1 (“this is a test string”) 
2- For each substring, check whether the substring contains all characters of string2 (“tist”) 
3- Finally, print the smallest substring containing all characters of string2.
  
Method 2 ( Efficient Solution ) 

First check if the length of the string is less than the length of the given pattern, if yes then “no such window can exist “.
Store the occurrence of characters of the given pattern in a hash_pat[].
we will be using two pointer technique basically
Start matching the characters of pattern with the characters of string i.e. increment count if a character matches.
Check if (count == length of pattern ) this means a window is found.
If such a window found, try to minimize it by removing extra characters from the beginning of the current window.
delete one character from first and again find this deleted key at right, once found apply step 5 .
Update min_length.
Print the minimum length window.
        */
        static String smallest_string_all_characters_other_string(String str, String pat)
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
        static String smallest_string_all_characters_other_string_sliding_window(char[] s, char[] t)
        {
            int[] m = new int[256];

            // Answer
            // Length of ans
            int ans = int.MaxValue;

            // Starting index of ans
            int start = 0;
            int count = 0, i = 0;

            // Creating map
            for (i = 0; i < t.Length; i++)
            {
                if (m[t[i]] == 0)
                    count++;

                m[t[i]]++;
            }

            // References of Window
            i = 0;
            int j = 0;

            // Traversing the window
            while (j < s.Length)
            {

                // Calculations
                m[s[j]]--;

                if (m[s[j]] == 0)
                    count--;

                // Condition matching
                if (count == 0)
                {
                    while (count == 0)
                    {

                        // Sorting ans
                        if (ans > j - i + 1)
                        {
                            ans = Math.Min(ans, j - i + 1);
                            start = i;
                        }

                        // Sliding I
                        // Calculation for removing I
                        m[s[i]]++;

                        if (m[s[i]] > 0)
                            count++;

                        i++;
                    }
                }
                j++;
            }

            if (ans != int.MaxValue)
                return String.Join("", s).Substring(start, ans);
            else
                return "-1";
        }

        // Driver Method
        public static void Main(String[] args)
        {
            //String str = "this is a test string";
            //String pat = "tist";
            String str = "My Name is Fran";
            String pat = "rim";

            Console.WriteLine("Smallest window is :\n"
                              + smallest_string_all_characters_other_string(str, pat));

            /*Output
Smallest window is : 
            t stri
            Time Complexity  :  O(n) , where n is the length of string str

            to call efficient code
            Console.Write("-->Smallest window that contain all character : ");
            Console.Write(Minimum_Window(s.ToCharArray(), t.ToCharArray()));

             Output:

-->Smallest window that contain all character : 
BANC
Time Complexity  :  O(|s|) , where |s| is the length of string s. 

Space Complexity : O(1)  

Explanation –   Array m  of length 256 is used ,which is constant space, so the Space Complexity is O(1). 
            */
        }
    }
}
