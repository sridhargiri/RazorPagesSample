using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
   public class AnagramCounter
    {
        static int NO_OF_CHARS = 256;
        /* function to check whether two strings 
        are anagram of each other */
        static bool areAnagram(char[] str1, char[] str2)
        {
            // Create 2 count arrays and initialize 
            // all values as 0 
            int[] count1 = new int[NO_OF_CHARS];
            int[] count2 = new int[NO_OF_CHARS];
            int i;

            // For each character in input strings, 
            // increment count in the corresponding 
            // count array 
            for (i = 0; i < str1.Length && i < str2.Length;
                 i++)
            {
                count1[str1[i]]++;
                count2[str2[i]]++;
            }

            // If both strings are of different length. 
            // Removing this condition will make the program 
            // fail for strings like "aaca" and "aca" 
            if (str1.Length != str2.Length)
                return false;

            // Compare count arrays 
            for (i = 0; i < NO_OF_CHARS; i++)
                if (count1[i] != count2[i])
                    return false;

            return true;
        }
        /*
         * Complete the "stringAnagram" function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY dictionary
         *  2. STRING_ARRAY query
         */

        public static List<int> stringAnagram(List<string> dictionary, List<string> query)
        {

            List<int> countarray = new List<int>();
            int c = 0;
            for (int i = 0; i <= query.Count - 1; i++)
            {

                for (int j = 0; j <= dictionary.Count - 1; j++)
                {
                    if (areAnagram(query[i].ToCharArray(), dictionary[j].ToCharArray()))
                        c++;
                }
                countarray.Add(c); c = 0;
            }
            return countarray;
        }
        public static void Main(string[] args)
        {
            //string[] dictionary = { "hack", "a", "rank", "khac", "ackh", "kran", "rankhacker", "a", "ab", "ba", "stairs", "raits" };
            //List<string> d = dictionary.ToList();
            //string[] query = { "a", "nark", "bs", "hack", "stair" }; List<string> q = query.ToList();

            string[] dictionary = { "heater", "cold", "clod", "reheat", "docl" };
            List<string> d = dictionary.ToList();
            string[] query = { "codl", "heater", "abcd" }; List<string> q = query.ToList();
            var op = stringAnagram(d, q);
        }
    }
}
