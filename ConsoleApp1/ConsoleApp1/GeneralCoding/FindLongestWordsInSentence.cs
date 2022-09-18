using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// Find longest word in a sentence
    /// input = the geeksforgeeks is a computer science portal
    /// output = geeksforgeeks
    /// </summary>
    public class FindLongestWordsInSentence
    {
        char[] delimiter = new char[] { ' ' };
        public List<string> FindLongestWords(string sentence)
        {
            List<string> longestWords = new List<string>();
            int currentLongestLength = 0;
            string[] words = sentence.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            if (words != null && words.Length > 0)
            {
                foreach (string word in words)
                {
                    // Duplicate check.
                    if (!longestWords.Contains(word.ToLower()))
                    {
                        // If word is longer than the current longest. We clear our word list and add only this one.
                        if (word.Length > currentLongestLength)
                        {
                            longestWords.Clear();
                            longestWords.Add(word.ToLower());
                            currentLongestLength = word.Length;
                        }
                        // If word's length equals currentLongest, we just add it to the list.
                        else if (word.Length == currentLongestLength)
                        {
                            longestWords.Add(word);
                        }
                    }
                }
            }
            return longestWords;
        }
        public static void Main(string[] args)
        {
            FindLongestWordsInSentence findLongestWordsInSentence = new FindLongestWordsInSentence();
            List<string> w = findLongestWordsInSentence.FindLongestWords("the geeksforgeeks is a computer science portal");
            foreach (var item in w)
            {
                Console.WriteLine(item);

            }
        }
    }

    /*
     https://www.geeksforgeeks.org/program-find-smallest-largest-word-string/?ref=gcse
Given a string, find the minimum and the maximum length words in it.
    Program to find Smallest and Largest Word in a String
Examples: 

Input : "This is a test string"
Output : Minimum length word: a
         Maximum length word: string

Input : "GeeksforGeeks A computer Science portal for Geeks"
Output : Minimum length word: A
         Maximum length word: GeeksforGeeks
Approach

The idea is to keep a starting index si and an ending index ei.

si points to the starting of a new word and we traverse the string using ei.
Whenever a space or ‘\0’ character is encountered,we compute the length of the current word using (ei – si) and compare it with the minimum and the maximum length so far.
If it is less, update the min_length and the min_start_index(which points to the starting of the minimum length word).
If it is greater, update the max_length and the max_start_index(which points to the starting of the maximum length word).
Finally update minWord and maxWord which are output strings that have been sent by reference with the substrings starting at min_start_index and max_start_index of length min_length and max_length respectively.
Implementation:
    */
    public class LongestSmallestWord
    {


        static String minWord = "", maxWord = "";

        static void minMaxLengthWords(String input)
        {
            // minWord and maxWord are received by reference
            // and not by value
            // will be used to store and return output
            int len = input.Length;
            int si = 0, ei = 0;
            int min_length = len, min_start_index = 0,
                max_length = 0, max_start_index = 0;

            // Loop while input string is not empty
            while (ei <= len)
            {
                if (ei < len && input[ei] != ' ')
                {
                    ei++;
                }
                else
                {
                    // end of a word
                    // find curr word length
                    int curr_length = ei - si;

                    if (curr_length < min_length)
                    {
                        min_length = curr_length;
                        min_start_index = si;
                    }

                    if (curr_length > max_length)
                    {
                        max_length = curr_length;
                        max_start_index = si;
                    }
                    ei++;
                    si = ei;
                }
            }

            // store minimum and maximum length words
            minWord = input.Substring(min_start_index, min_length);
            maxWord = input.Substring(max_start_index, max_length);
        }

        // Driver code
        public static void Main(String[] args)
        {
            String a = "GeeksforGeeks A Computer Science portal for Geeks";

            minMaxLengthWords(a);

            // to take input in string use getline(cin, a);
            Console.Write("Minimum length word: "
                    + minWord
                    + "\nMaximum length word: "
                    + maxWord);
            /*
             Output
Minimum length word: A
Maximum length word: GeeksforGeeks
Time Complexity: O(n), where n is the length of string.
Auxiliary Space: O(n), where n is the length of string.

This is because when string is passed in the function it creates a copy of itself in stack.
            */
        }
    }
}
