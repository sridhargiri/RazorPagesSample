using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /**
 Given N lists of strings, return a single list of unique values,
 and a second list of all the duplicate values with the counts of each item.
 Input: [["foo bar", "bazz"], ["foo Bar"]]
 Output: ["foo bar", "bazz"]
         {"foo bar": 2}
 */
    public class Viasat
    {
        public static void Main(string[] args)
        {
            List<List<string>> valueLists = new List<List<string>>();
            // Your functions here
            valueLists.Add(new List<string> { "foo bar", "bazz", });
            valueLists.Add(new List<string> { "foo bar" });
            var merged = new List<String>();
            foreach (var item in valueLists)
            {
                merged.AddRange(item);
            }
            var g = merged.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => new { Element = x.Key, Count = x.Count() }).First();
            var d = merged.Distinct();
            Console.WriteLine(string.Join(",", d));
            Console.WriteLine(g.Element + ":" + g.Count);
        }
    }

    public class PigLatinExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ToPigLatin("testing one translation"));
        }
        public static string ToPigLatin(string sentence)
        {
            const string vowels = "AEIOUaeio";
            List<string> newWords = new List<string>();

            foreach (string word in sentence.Split(' '))
            {
                string firstLetter = word.Substring(0, 1);
                string restOfWord = word.Substring(1, word.Length - 1);
                int currentLetter = vowels.IndexOf(firstLetter);

                if (currentLetter == -1)
                {
                    newWords.Add(restOfWord + firstLetter + "ay");
                }
                else
                {
                    newWords.Add(word + "way");
                }
            }
            return string.Join(" ", newWords);
        }
    }

    public class PigLatin2
    {
        public static void Main(string[] args)
        {
            string str = "test test test hello world pig latin";
            Console.WriteLine(MakePigLatin(str));
            /*
             i/p testing one translation
             o/p estingtay neoay ranslationtay

             i/p test test test hello world pig latin
             o/p esttay esttay esttay ellohay orldway igpay atinlay
             */
        }

        public static string MakePigLatin(string str)
        {
            string[] words = str.Split(' ');
            str = String.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length <= 1) continue;
                string output = new String(words[i].ToCharArray());
                output = output.Substring(1, output.Length - 1) + output.Substring(0, 1) + "ay ";
                str += output;
            }
            return str.Trim();
        }
    }
}
