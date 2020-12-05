using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
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
            List<string> w = findLongestWordsInSentence.FindLongestWords("the geeksforgeeks geeksforgeekt is a computer science portal");
            foreach (var item in w)
            {
                Console.WriteLine(item);

            }
        }
    }
}
