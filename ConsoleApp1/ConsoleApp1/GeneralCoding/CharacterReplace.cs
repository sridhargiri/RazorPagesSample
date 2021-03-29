using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Modify string by replacing characters by alphabets whose distance from that character is equal to its frequency
Last Updated : 25 Mar, 2021
Given a string S consisting of N lowercase alphabets, the task is to modify the string S by replacing each character by the alphabet whose circular distance from the character is equal to the frequency of the character in S.

Examples:

Input: S = “geeks”
Output: hgglt
Explanation:
Following modifications are performed on the string S:

Frequency of ‘g’ in the string is 1. Therefore, ‘g’ is replaced by ‘h’.
Frequency of ‘e’ in the string is 2. Therefore, ‘e’ is replaced by ‘g’.
Frequency of ‘e’ in the string is 2. Therefore, ‘e’ is replaced by ‘g’.
Frequency of ‘k’ in the string is 1. Therefore, ‘k’ is converted to ‘k’ + 1 = ‘l’.
Frequency of ‘s’ in the string is 1. Therefore, ‘s’ is converted to ‘s’ + 1 = ‘t’.
Therefore, the modified string S is “hgglt”.

Input: S = “jazz”
Output: “kbbb”

https://www.geeksforgeeks.org/modify-string-by-replacing-characters-by-alphabets-whose-distance-from-that-character-is-equal-to-its-frequency/


Approach: The given problem can be solved by maintaining the frequency array that stores the occurrences of each character in the string. Follow the steps below to solve the problem:

Initialize an array, freq[26] initially with all elements as 0 to store the frequency of each character of the string.
Traverse the given string S and increment the frequency of each character S[i] by 1in the array freq[].
Traverse the string S using the variable i and perform the following steps:
Store the value to be added to S[i] in a variable, add as (freq[i] % 26).
If after adding the value of add to S[i], S[i] does not exceed the character z, then update S[i] to S[i] + add.
Otherwise, update the value of add to (S[i] + add – z) and then set S[i] to (a + add – 1).
After completing the above steps, print the modified string S.
Below is the implementation of the above approach:
    */
    class CharacterReplace
    {
        static void addFrequencyToCharacter(string s)
        {
            // Stores frequency of characters
            int[] frequency = new int[26]; char[] s1 = new char[s.Length];

            // Stores length of the string
            int n = s.Length;

            // Traverse the given string S
            for (int i = 0; i < n; i++)
            {

                // Increment frequency of
                // current character by 1
                frequency[s[i] - 'a'] += 1;
            }

            // Traverse the string
            for (int i = 0; i < n; i++)
            {

                // Store the value to be added
                // to the current character
                int add = frequency[s[i] - 'a'] % 26;

                // Check if after adding the
                // frequency, the character is
                // less than 'z' or not
                if (s[i] + add <= (int)('z'))
                    s1[i] = (char)((int)(s[i]) + add);

                // Otherwise, update the value of
                // add so that s[i] doesn't exceed 'z'
                else
                {
                    add = (s[i]) + add - ((int)('z'));
                    s1[i] = (char)((int)('a') + add - 1);
                }
            }
            Console.WriteLine(s1);
        }
        static void Main(string[] args)
        {
            string str = "geeks";
            addFrequencyToCharacter(str);
            /*
             Output:
hgglt
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
