using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/count-characters-at-same-position-as-in-english-alphabet/
    Count characters at same position as in English alphabet
Difficulty Level : Basic
Last Updated : 29 Apr, 2021
Given a string of lower and uppercase characters, the task is to find that how many characters are at same position as in English alphabet.
Examples: 
 

Input:  ABcED 
Output :  3
First three characters are at same position
as in English alphabets.

Input:  geeksforgeeks 
Output :  1
Only 'f' is at same position as in English
alphabet

Input :  alphabetical 
Output :  3
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
For this we can have simple approach: 
 

1) Initialize result as 0.
2) Traverse input string and do following for every 
   character str[i]
     a) If 'i' is same as str[i] - 'a' or same as 
        str[i] - 'A', then do result++
3) Return result
     */
    public class AlphabetCorrectOrder
    {
        static int findCount(string str)
        {
            int result = 0;

            // Traverse input string
            for (int i = 0; i < str.Length; i++)

                // Check that index of characters
                // of string is same as of English
                // alphabets by using ASCII values
                // and the fact that all lower case
                // alphabetic characters come together
                // in same order in ASCII table. And
                // same is true for upper case.
                if (i == (str[i] - 'a') ||
                    i == (str[i] - 'A'))
                    result++;

            return result;
        }

        // Driver code
        public static void Main()
        {
            string str = "AbgdeF";
            Console.Write(findCount(str));//output 5
        }
    }
    public class VowelConsonant
    {
        static String remVowel(String str)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            List<char> al = vowels.OfType<char>().ToList(); ;

            StringBuilder sb = new StringBuilder(str);

            for (int i = 0; i < sb.Length; i++)
            {

                if (al.Contains(sb[i]))
                {
                    sb.Replace(sb[i].ToString(), "");
                    ///i--;
                }
            }


            return sb.ToString();
        }


        // Function that returns true
        // if the character is an alphabet

        static bool isAlphabet(char ch)
        {

            if (ch >= 'a' && ch <= 'z')

                return true;

            if (ch >= 'A' && ch <= 'Z')

                return true;



            return false;
        }

        // Function to return the string after
        // removing all the consonants from it

        static string remConsonants(string str)
        {

            char[] vowels = { 'a', 'e', 'i', 'o', 'u',

                      'A', 'E', 'I', 'O', 'U' };



            string sb = "";


            for (int i = 0; i < str.Length; i++)

            {

                bool present = false;

                for (int j = 0; j < vowels.Length; j++)

                {

                    if (str[i] == vowels[j])

                    {

                        present = true;

                        break;

                    }

                }



                if (!isAlphabet(str[i]) || present)

                {

                    sb += str[i];

                }

            }

            return sb;
        }
        /*
Rearrange vowels -> Modify string by rearranging vowels in alphabetical order at their respective indices
Given a string S of length N, the task is to sort the vowels of the given string in alphabetical order at place them accordingly in their respective indices.

Examples:

Input: S = “geeksforgeeks”
Output: geeksfergeoks
Explanation:
The vowels in the string are: e, e, o, e, e
Sort in alphabetical order: e, e, e, e, o and replace with the vowels present in original string.

Input: S = “people”
Output: peeplo

Approach: The idea is to store all the vowels present in the string S in another string, say vow. Sort the string vow in alphabetical order. Traverse the string S from the start and replace S[i] with vow[j] if S[i] is a vowel, and incrementing j by 1. Follow the steps below to solve the problem:

https://www.geeksforgeeks.org/modify-string-by-rearranging-vowels-in-alphabetical-order-at-their-respective-indices/


Initialize a string vow to store all the vowels present in the string, S.
Traverse the string S and check if the current character S[i] is a vowel or not, If found to be true, then push S[i] to vow.
Sort the string vow in alphabetical order and initialize a variable, say j as 0.
Again traverse the string S using the variable i and if the current character S[i] is a vowel, then replace S[i] with vow[j] and increment j by 1.
After the above steps, print the string S as the result.
Below is the implementation of the above approach.
        */
        public static void sortVowels(string S)
        {
            char[] chararray = S.ToCharArray();

            // Stores vowels of string S 
            string vow = "";

            // Traverse the string, S and push 
            // all the vowels to string vow 
            for (int i = 0; i < chararray.Length; i++)
            {

                if (S[i] == 'a' || S[i] == 'e'
                    || S[i] == 'i' || S[i] == 'o'
                    || S[i] == 'u')
                {
                    vow += S[i];
                }
            }
            // If vow is empty, then print S 
            // and return 
            if (vow.Length == 0)
            {
                Console.WriteLine(S);
                return;
            }
            char[] vowcopy = vow.ToCharArray();
            Array.Sort(vowcopy); int j = 0;

            // Traverse the string, S 
            for (int i = 0; i < chararray.Length; i++)
            {

                // Replace S[i] with vow[j] iif S[i] 
                // is a vowel, and increment j by 1 
                if (S[i] == 'a' || S[i] == 'e' || S[i] == 'i'
                    || S[i] == 'o' || S[i] == 'u')
                {
                    chararray[i] = vowcopy[j++];
                }
            }
            Console.WriteLine(new string(chararray));
        }
        // Driver method to test the above function 
        //i/p - GeeeksforGeeks - A Computer Science Portal for Geeks
        //o/p GksfrGks - Cmptr Scnc Prtl fr Gks
        public static void Main()
        {
            string S = "geeksforgeeks";
            sortVowels(S);
            /*
             Output:
geeksfergeoks
Time Complexity: O(N*log N)
Auxiliary Space: O(N)
            */
            String str = "GeeeksforGeeks - A Computer Science Portal for Geeks";

            Console.Write(remVowel(str));

            str = "GeeeksforGeeks - A Computer Science Portal for Geeks";
            //Output: 
            //eeeoee - A oue iee oa o ee

            Console.Write(remConsonants(str));
        }
    }

    public class LongestWithoutVowel
    {
        static bool vowel(char ch)
        {
            if (ch == 'a' || ch == 'e'
                || ch == 'i' || ch == 'o'
                || ch == 'u' || ch == 'A'
                || ch == 'E' || ch == 'I'
                || ch == 'O' || ch == 'U')
            {
                return true;
            }
            return false;
        }
        static int maxLengthString(string s)
        {
            // Stores the length of
            // the longest substring
            int maximum = 0;

            int count = 0;

            // Traverse the string, S
            for (int i = 0; i < s.Length; i++)
            {

                // If the current character
                // is vowel, set count as 0
                if (vowel(s[i]))
                {
                    count = 0;
                }

                // If the current
                // character is a consonant
                else
                {

                    // Increment count by 1
                    count++;
                }

                // Update the maximum length
                maximum = Math.Max(maximum, count);
            }

            // Return the result
            return maximum;
        }
        public static void Main(string[] args)
        {
            int S = maxLengthString("geeksforgeeks"); Console.WriteLine(S);
            /*
             Output:
3
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
