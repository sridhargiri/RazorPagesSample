using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/find-given-string-can-represented-substring-iterating-substring-n-times/
    Find if a given string can be represented from a substring by iterating the substring “n” times
Difficulty Level : Hard
Last Updated : 12 Apr, 2018
Given a string ‘str’, check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.

Examples:

Input: str = "abcabcabc"
Output: true
The given string is 3 times repetition of "abc"

Input: str = "abadabad"
Output: true
The given string is 2 times repetition of "abad"

Input: str = "aabaabaabaab"
Output: true
The given string is 4 times repetition of "aab"

Input: str = "abcdabc"
Output: false
Source: Google Interview Question

We strongly recommend that you click here and practice it, before moving on to the solution.

There can be many solutions to this problem. The challenging part is to solve the problem in O(n) time. Below is a O(n) algorithm.

Let the given string be ‘str’ and length of given string be ‘n’.




1) Find length of the longest proper prefix of ‘str’ which is also a suffix. Let the length of the longest proper prefix suffix be ‘len’. This can be computed in O(n) time using pre-processing step of KMP string matching algorithm.

2) If value of ‘n – len’ divides n (or ‘n % (n-len)’ is 0), then return true, else return false.

In case of ‘true’ , the substring ‘str[0..n-len-1]’ is the substring that repeats n%(n-len) times.

Let us take few examples.

Input: str = “ABCDABCD”, n = 8 (Number of characters in ‘str’)
The value of len is 4 (“ABCD” is the longest substring which is both prefix and suffix)
Since (n-len) divides n, the answer is true.

Input: str = “ABCDABC”, n = 7 (Number of characters in ‘str’)
The value of len is 3 (“ABC” is the longest substring which is both prefix and suffix)
Since (n-len) doesn’t divides n, the answer is false.

Input: str = “ABCABCABCABCABC”, n = 15 (Number of characters in ‘str’)
The value of len is 12 (“ABCABCABCABC” is the longest substring which is both prefix and suffix)
Since (n-len) divides n, the answer is true.

How does this work?
length of longest proper prefix-suffix (or len) is always between 0 to n-1. If len is n-1, then all characters in string are same. For example len is 3 for “AAAA”. If len is n-2 and n is even, then two characters in string repeat n/2 times. For example “ABABABAB”, length of lps is 6. The reason is if the first n-2 characters are same as last n-2 character, the starting from the first pair, every pair of characters is identical to the next pair. The following diagram demonstrates same for substring of length 4.
  Source https://www.geeksforgeeks.org/forums/topic/google-interview-question-for-software-engineerdeveloper-fresher-about-strings/
    */
    class SubstringRepeat
    {

        // A utility function to fill lps[] or
        // compute prefix funcrion used in KMP 
        // string matching algorithm. Refer
        // https://www.geeksforgeeks.org/archives/11902 
        // for details
        static void computeLPSArray(String str, int M,
                                             int[] lps)
        {

            // lenght of the previous 
            // longest prefix suffix
            int len = 0;

            int i;

            lps[0] = 0; // lps[0] is always 0
            i = 1;

            // the loop calculates lps[i] 
            // for i = 1 to M-1
            while (i < M)
            {
                if (str[i] == str[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else // (pat[i] != pat[len])
                {
                    if (len != 0)
                    {

                        // This is tricky. Consider the 
                        // example AAACAAAA and i = 7.
                        len = lps[len - 1];

                        // Also, note that we do 
                        // not increment i here
                    }
                    else // if (len == 0)
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }

        // Returns true if str is repetition of 
        // one of its substrings else return false.
        static bool isRepeat(String str)
        {

            // Find length of string and create 
            // an array to store lps values used
            // in KMP
            int n = str.Length;
            int[] lps = new int[n];

            // Preprocess the pattern (calculate
            // lps[] array)
            computeLPSArray(str, n, lps);

            // Find length of longest suffix 
            // which is also prefix of str.
            int len = lps[n - 1];

            // If there exist a suffix which is also 
            // prefix AND Length of the remaining
            // substring divides total length, then
            // str[0..n-len-1] is the substring that
            // repeats n/(n-len) times (Readers can 
            // print substring and value of n/(n-len)
            // for more clarity.
            return (len > 0 && n % (n - len) == 0)
                                   ? true : false;
        }

        // Driver program to test above function
        public static void Main()
        {
            String[] txt = {"ABCABC", "ABABAB",
                    "ABCDABCD", "GEEKSFORGEEKS",
                       "GEEKGEEK", "AAAACAAAAC",
                                     "ABCDABC"};
            int n = txt.Length;

            for (int i = 0; i < n; i++)
            {
                if (isRepeat(txt[i]) == true)
                    Console.WriteLine("True");
                else
                    Console.WriteLine("False");
            }
            /*
             Output:

True
True
True
False
True
True
False 
Time Complexity: Time complexity of the above solution is O(n) as it uses KMP preprocessing algorithm which is linear time algorithm.
            https://www.geeksforgeeks.org/searching-for-patterns-set-2-kmp-algorithm/
            */
        }
    }
}
