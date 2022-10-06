using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/count-words-appear-exactly-two-times-array-words/?ref=gcse
    Count words that appear exactly two times in an array of words
    Given an array of n words. Some words are repeated twice, we need to count such words. 

Examples: 

Input : s[] = {"hate", "love", "peace", "love", 
               "peace", "hate", "love", "peace", 
               "love", "peace"};
Output : 1
There is only one word "hate" that appears twice

Input : s[] = {"Om", "Om", "Shankar", "Tripathi", 
                "Tom", "Jerry", "Jerry"};
Output : 2
There are two words "Om" and "Jerry" that appear twice.
     */
    public class TwiceWords
    {
        public static int WordsTwice(string[] arr, int n)
        {
            int res = 0;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    int get = dict[arr[i]];
                    dict.Remove(arr[i]);
                    dict.Add(arr[i], get + 1); ;
                }
                else
                    dict.Add(arr[i], 1);
            }
            foreach (var item in dict)
            {
                if (item.Value == 2)
                    res++;
            }
            return res;
        }
        public static void Main(String[] args)
        {
            String[] a = { "hate", "love", "peace", "love",
                    "peace", "hate", "love", "peace",
                    "love", "peace" };
            int n = a.Length;
            Console.WriteLine(WordsTwice(a, n));
            /*
Output 1
Time Complexity : O(N)
Auxiliary Space: O(N)
            */
        }
    }
}
