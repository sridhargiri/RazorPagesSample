using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Sherlock
    {
        /// <summary>
        /// Sherlock considers a string to be valid if all characters of the string appear the same number of times. 
        /// It is also valid if he can remove just character at index in the string, and the remaining characters will occur the same number of times. 
        /// Given a string , determine if it is valid. If so, return YES, otherwise return NO.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string IsValid(string s)
        {
            int min_count = 0, max_count = 0;
            Dictionary<char, int> char_dict = new Dictionary<char, int>();
            Dictionary<int, int> myset = new Dictionary<int, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!char_dict.ContainsKey(s[i]))
                    char_dict.Add(s[i], 1);
                else
                    char_dict[s[i]]++;
                min_count = char_dict[s[i]];
                max_count = char_dict[s[i]];
            }
            foreach (var item in char_dict.Values)
            {
                if (!myset.ContainsKey(item))
                    myset.Add(item, 1);
                else
                    myset[item]++;
                if (item < min_count)
                    min_count = item;
                if (item > max_count)
                    max_count = item;
            }
            if (myset.Count == 1)
                return "YES";
            else if (myset.Count == 2)
            {
                if (myset[max_count] == 1 && max_count - min_count == 1)
                    return "YES";
                else if (myset[min_count] == 1 && min_count == 1)
                    return "YES";
            }
            return "NO";

        }
        //not working
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("abbbc"));
        }
    }
}
