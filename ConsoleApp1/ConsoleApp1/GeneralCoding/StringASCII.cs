using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Count pairs of characters in a string whose ASCII value difference is K
Last Updated : 13 Jun, 2019
Given a string str of lower case alphabets and a non-negative integer K. The task is to find the number of pairs of characters in the given string whose ASCII value difference is exactly K.
https://www.geeksforgeeks.org/count-pairs-of-characters-in-a-string-whose-ascii-value-difference-is-k/
Examples:

Input: str = “abcdab”, K = 0
Output: 2
(a, a) and (b, b) are the only valid pairs.

Input: str = “geeksforgeeks”, K = 1
Output: 8
(e, f), (e, f), (f, e), (f, e), (g, f),
(f, g), (s, r) and (r, s) are the valid pairs.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: Store the frequency of each character in an array. Traverse through this frequency array to get the required answer. There exist two cases:

If K = 0 then check if the similar character appears more than once i.e. if freq[i] > 1. If yes then add (freq[i] * (freq[i] – 1)) / 2 to the count.
If K != 0 then check if there exist two characters with ASCII value difference as K say freq[i] and freq[j]. Then add freq[i] * freq[j] to the count.
Below is the implementation of the above approach
    */
    class StringASCII
    {

        static int MAX = 26;

        // Function to return the count of
        // required pairs of characters
        static int countPairs(char[] str, int k)
        {

            // Length of the string
            int n = str.Length;

            // To store the frequency
            // of each character
            int[] freq = new int[MAX];

            // Update the frequency
            // of each character
            for (int i = 0; i < n; i++)
            {
                freq[str[i] - 'a']++;
            }

            // To store the required
            // count of pairs
            int cnt = 0;

            // If ascii value difference is zero
            if (k == 0)
            {

                // If there exists similar characters
                // more than once
                for (int i = 0; i < MAX; i++)
                {
                    if (freq[i] > 1)
                    {
                        cnt += ((freq[i] * (freq[i] - 1)) / 2);
                    }
                }
            }
            else
            {

                // If there exits characters with
                // ASCII value difference as k
                for (int i = 0; i < MAX; i++)
                {
                    if (freq[i] > 0 && i + k < MAX && freq[i + k] > 0)
                    {
                        cnt += (freq[i] * freq[i + k]);
                    }
                }
                ;
            }

            // Return the required count
            return cnt;
        }

        // Driver code
        public static void Main(String[] args)
        {
            String str = "abcdab";
            int k = 0;

            Console.WriteLine(countPairs(str.ToCharArray(), k));//op 2
        }
    }
}
