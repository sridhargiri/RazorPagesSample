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
    /*
     https://www.geeksforgeeks.org/generate-string-by-incrementing-character-of-given-string-by-number-present-at-corresponding-index-of-second-string/
    Generate string by incrementing character of given string by number present at corresponding index of second string
    Given two strings S[] and N[] of the same size, the task is to update string S[] by adding the digit of string N[] of respective indices.
    example
    Input: S = “sun”, N = “966”
Output: bat
    Input: S = “apple”, N = “12580”
Output: brute
    Approach: The idea is to traverse the string S[] from left to right. Get the ASCII value of string N[] and add it to the ASCII value of string S[]. If the value exceeds 122, which is the ASCII value of the last alphabet ‘z’. Then subtract the value by 26, which is the total count of English alphabets. Update string S with the character of ASCII value obtained. Follow the steps below to solve the problem:

Iterate over the range [0, S.size()) using the variable i and perform the following tasks:
Initialize the variables a and b as the integer and ascii value of N[i] and S[i].
If b is greater than 122 then subtract 26 from b.
Set S[i] as char(b).
After performing the above steps, print the value of S[] as the nswer.
Below is the implementation of the above approach.

     */
    public class CharacterReplaceNumber
    {
        static string ReplaceCharAccordingToNumberPresentAtSecondString(string S, string N)
        {
            string ostr = "";
            for (int i = 0; i < S.Length; i++)
            {

                // Get ASCII value
                int a = N[i] - '0';
                int b = S[i] + a;

                if (b > 'z') //'z'=122 last ascii alphabet
                    b -= 26;

                ostr += (char)(b);
            }
            return ostr;
        }
        public static void Main(string[] args)
        {
            string S = "sun";
            string N = "966";
            Console.WriteLine(ReplaceCharAccordingToNumberPresentAtSecondString(S, N));
            /*
             Output bat
Time Complexity: O(|S|)
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/find-nth-term-of-the-series-0-1-1-2-5-29-841/
    Find Nth term of the series 0, 1, 1, 2, 5, 29, 841…
    Given a positive integer N, the task is to find the Nth term in the series 0, 1, 1, 2, 5, 29, 841…

Examples:
    Input: N = 6
Output: 29
Explanation: The 6th term of the given series is 29.

Input: N = 1
Output: 1
    Input: N = 8
Output: 750797

 
Approach: The given problem is a basic maths-based problem where the Ai = Ai-12 + Ai-22. Therefore, create variables a = 0 and b = 1. Iterate using the variable i in the range [2, N], and for each i, calculate the ith term and update the value of a and b to i – 1th and i – 2th term respectivelly.

Below is the implementation of the above approach

     */
    public class NthTerm
    {
        static int getNthTerm(int N)
        {
            if (N < 3)
                return N - 1;

            // Initialize Variables repre-
            // senting 1st and 2nd term
            long a = 0, b = 1;

            // Loop to iterate through the
            // range [3, N] using variable i
            for (int i = 3; i <= N; i++)
            {

                // pow((i - 2)th term, 2) +
                // pow((i - 1)th term, 2)
                long c = a * a + b * b;

                // Update a and b
                a = b;
                b = c;
            }

            // Return Answer
            return (int)b;
        }
        public static void Main()
        {
            int N = 8;
            Console.Write(getNthTerm(N));
            /*
             Output
750797
Time complexity: O(N)
Auxiliary space: O(1)
            */
        }

    }
    /*
     https://www.geeksforgeeks.org/decrypt-message-from-given-code-by-replacing-all-with-prefix-values-of-encoded-string/
    Decrypt message from given code by replacing all * with prefix values of encoded string
    Given a string str of length of N that is in the encoded form with alphabets and * . The task is to find the string from which it was generated. The required string can be generated from the encoded string by replacing all the * with the prefix values of the encoded string. 
    Input: str =  ab*c*d
Output: “ababcababcd”
Explanation: For the first occurrence of  “*”, “ab” is the prefix. So ‘*’ is replaced by “ab” resulting the string  to be “ababc*d”  and for the next ‘*‘ the prefix is “ababc”. So the string will now change from “ababc*d” to “ababcababcd”.
    Input :  str = “z*z*z”
Output:  zzzzzzz
    Approach: The solution is based on greedy approach. Follow the steps mentioned below to solve the problem:

Consider an empty string result.
Iterate over the given coded string.
if the current character in the string is not “*” then add the current character to the result.
Otherwise, if the current character is “*”, add the result string formed till now with itself.
Return the result.
Below is the implementation of the given approach.
     */
    public class CharReplaceWithPrefixSoFar
    {

        // Function to return a string
        // found from the coded string
        static string PrefixSofar(string str)
        {

            // Declaring string to store result
            string result = "";

            // Loop to generate the original string
            for (int i = 0; i < str.Length; i++)
            {

                // If current character in string
                // is '*' add result to itself
                if (str[i] == '*')
                    result += result;

                // Else add current element only
                else
                    result += str[i];
            }

            // Return the result
            return result;
        }

        // Driver code
        public static void Main()
        {
            string str = "ab*c*d";
            Console.Write(PrefixSofar(str));
            /*
             Output
ababcababcd
Time Complexity: O(N)
Auxiliary Space: O(N)
            */
        }
    }
}
