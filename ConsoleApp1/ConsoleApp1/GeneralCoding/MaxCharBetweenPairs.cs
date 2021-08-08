using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MaxCharBetweenPairs
    {
        /*
         https://www.geeksforgeeks.org/maximum-number-characters-two-character-string/
         */

        /*
         Approach 2 (Efficient) : Initialize an array”FIRST” of length 26 in which we have to store the first occurrence of an alphabet in the string and another array “LAST” of length 26 in which we will store the last occurrence of the alphabet in the string. Here, index 0 corresponds to alphabet a, 1 for b and so on . After that, we will take the difference between the last and first arrays to find the max difference if they are not at the same position.  
        */
        static int MAX_CHAR = 256;
        static int maximumChars(string str)
        {
            int n = str.Length;
            int res = -1;

            // Initialize all indexes as -1.
            int[] firstInd = new int[MAX_CHAR];

            for (int i = 0; i < MAX_CHAR; i++)
                firstInd[i] = -1;

            for (int i = 0; i < n; i++)
            {
                int first_ind = firstInd[str[i]];

                // If this is first occurrence
                if (first_ind == -1)
                    firstInd[str[i]] = i;

                // Else find distance from previous
                // occurrence and update result (if
                // required).
                else
                    res = Math.Max(res, Math.Abs(i
                                  - first_ind - 1));
            }

            return res;
        }
        /*
         Maximum number of characters between any two same character in a string
Difficulty Level : Medium
Last Updated : 21 May, 2021
Given a string, find the maximum number of characters between any two characters in the string. If no character repeats, print -1. 

Examples:  

Input : str = "abba"
Output : 2
The maximum number of characters are
between two occurrences of 'a'.

Input : str = "baaabcddc"
Output : 3
The maximum number of characters are
between two occurrences of 'b'.

Input : str = "abc"
Output : -1
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Approach 1 (Simple): Use two nested loops. The outer loop picks characters from left to right, the inner loop finds the farthest occurrence and keeps track of the maximum. 
        */
        static int maximumCharsBetweenSameCharacters(string str)
        {
            int n = str.Length;
            int res = -1;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (str[i] == str[j])
                        res = Math.Max(res,
                             Math.Abs(j - i - 1));

            return res;
        }

        // Driver code
        static public void Main()
        {
            string str = "abba";

            Console.WriteLine(maximumCharsBetweenSameCharacters(str));
            Console.WriteLine(maximumChars(str));
            /*
             Output:  

2
Time Complexity : O(n^2)
            Output:  

2
Time Complexity : O(n)
            */
        }
    }
    /*
     Encora coderbyte
     */
    public class MatchingCharacters
    {
        static int maximumCharsBetweenMatchingPairs(string str)
        {
            int n = str.Length;
            int count = 0;
            Dictionary<char, char> _char = null;

            for (int i = 0; i < str.Length; i++)
            {
                _char = new Dictionary<char, char>();
                int lastIdx = str.LastIndexOf(str[i]);
                if (i == lastIdx) continue;
                for (int j = i + 1; j < lastIdx; j++)
                    if (!_char.ContainsKey(str[j]))
                    {
                        _char[str[j]] = str[i];
                    }
                if (count < _char.Keys.Count) count = _char.Keys.Count;
            }

            return count;
        }
        public static void Main(string[] args)
        {
            int _s = maximumCharsBetweenMatchingPairs("ahyjakh");
            Console.WriteLine(_s);
        }
        //output 4
        /*
      js version https://gist.github.com/Smakar20/a0837ed855fd110d1dc61f2728335bb3
        Have the function MatchingCharacters(str) take the str parameter being passed and determine the largest number of unique characters that exists between a pair of matching letters anywhere in the string. For example: if str is "ahyjakh" then there are only two pairs of matching letters, the two a's and the two h's. Between the pair of a's there are 3 unique characters: h, y, and j. Between the h's there are 4 unique characters: y, j, a, and k. So for this example your program should return 4. 
Another example: if str is "ghececgkaem" then your program should return 5 because the most unique characters exists within the farthest pair of e characters. The input string may not contain any character pairs, and in that case your program should just return 0. The input will only consist of lowercase alphabetic characters. 
        */

    }
}
