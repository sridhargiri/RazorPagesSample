using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
   https://www.geeksforgeeks.org/check-if-a-string-has-all-characters-with-same-frequency-with-one-variation-allowed/
    Check if a string has all characters with same frequency with one variation allowed
Difficulty Level : Medium
Last Updated : 01 Apr, 2021
Given a string of lowercase alphabets, find if it can be converted to a Valid String by removing 1 or 0 characters. A “valid” string is string str such that for all distinct characters in str each such character occurs the same number of times in it.
Examples : 

Input : string str = "abbca"
Output : Yes
We can make it valid by removing "c"

Input : string str = "aabbcd"
Output : No
We need to remove at least two characters
to make it valid.

Input : string str = "abbccd"
Output : No
We are allowed to traverse string only once. 
 
     The idea is to use a frequency array that stores frequencies of all characters. 
    Once we have frequencies of all characters in an array, we check if count of total different and non zero values are not more than 2. 
    Also, one of the counts of two allowed different frequencies must be less than or equal to 2. Below is the implementation of idea.
    */
    class CharSameFrequency
    {

        // Assuming only lower case characters
        static int CHARS = 26;

        /* To check a string S can be converted to a “valid”
    string by removing less than or equal to one
    character. */
        static bool isValidString(String str)
        {
            int[] freq = new int[CHARS];
            int i = 0;
            // freq[] : stores the frequency of each
            // character of a string
            for (i = 0; i < str.Length; i++)
            {
                freq[str[i] - 'a']++;
            }

            // Find first character with non-zero frequency
            int freq1 = 0, count_freq1 = 0;
            for (i = 0; i < CHARS; i++)
            {
                if (freq[i] != 0)
                {
                    freq1 = freq[i];
                    count_freq1 = 1;
                    break;
                }
            }

            // Find a character with frequency different
            // from freq1.
            int j, freq2 = 0, count_freq2 = 0;
            for (j = i + 1; j < CHARS; j++)
            {
                if (freq[j] != 0)
                {
                    if (freq[j] == freq1)
                    {
                        count_freq1++;
                    }
                    else
                    {
                        count_freq2 = 1;
                        freq2 = freq[j];
                        break;
                    }
                }
            }

            // If we find a third non-zero frequency
            // or count of both frequencies become more
            // than 1, then return false
            for (int k = j + 1; k < CHARS; k++)
            {
                if (freq[k] != 0)
                {
                    if (freq[k] == freq1)
                    {
                        count_freq1++;
                    }
                    if (freq[k] == freq2)
                    {
                        count_freq2++;
                    }
                    else // If we find a third non-zero freq
                    {
                        return false;
                    }
                }

                // If counts of both frequencies is more than 1
                if (count_freq1 > 1 && count_freq2 > 1)
                {
                    return false;
                }
            }

            // Return true if we reach here
            return true;
        }

        // Driver code
        public static void Main()
        {
            String str = "abcbc";

            if (isValidString(str))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            /*
             Output: 
 

YES
We traverse string only once. Also the three loops after the first loop run CHARS times in total. 
            */
        }
    }
    /*
     Method 2 (using hashing)
    */
    public class AllCharsWithSameFrequencyWithOneVarAllowed
    {

        // To check a string S can be converted to a variation
        // string
        public static bool checkForVariation(String str)
        {
            if (str == null || str.Length != 0)
            {
                return true;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();

            // Run loop form 0 to length of string
            for (int i = 0; i < str.Length; i++)
            {
                if (map.ContainsKey(str[i]))
                    map[str[i]] = map[str[i]] + 1;
                else
                    map.Add(str[i], 1);
            }

            // declaration of variables
            bool first = true, second = true;
            int val1 = 0, val2 = 0;
            int countOfVal1 = 0, countOfVal2 = 0;

            foreach (KeyValuePair<char, int> itr in map)
            {
                int i = itr.Key;

                // if first is true than countOfVal1 increase
                if (first)
                {
                    val1 = i;
                    first = false;
                    countOfVal1++;
                    continue;
                }

                if (i == val1)
                {
                    countOfVal1++;
                    continue;
                }

                // if second is true than countOfVal2 increase
                if (second)
                {
                    val2 = i;
                    countOfVal2++;
                    second = false;
                    continue;
                }

                if (i == val2)
                {
                    countOfVal2++;
                    continue;
                }

                return false;
            }

            if (countOfVal1 > 1 && countOfVal2 > 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        // Driver code
        public static void Main(String[] args)
        {

            Console.WriteLine(checkForVariation("abcbc"));//output true
        }
    }

}
