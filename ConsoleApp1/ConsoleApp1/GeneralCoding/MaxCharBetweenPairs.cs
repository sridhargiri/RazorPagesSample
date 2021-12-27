using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MaxCharBetweenPairs
    {
        /*
         https://www.geeksforgeeks.org/maximum-number-characters-two-character-string/
         */

        /*
         Approach 2 (Efficient) : Initialize an array”FIRST” of length 26 in which we have to store the first occurrence of an alphabet in the string and another array “LAST” of length 26 in which we will store the last occurrence of the alphabet in the string. Here, index 0 corresponds to alphabet a, 1 for b and so on . After that, we will take the difference between the last and first arrays to find the max difference if they are not at the same position.  
        */
        static int MAX_CHAR = 256;
        static int maximumChars(string str)
        {
            int n = str.Length;
            int res = -1;

            // Initialize all indexes as -1.
            int[] firstInd = new int[MAX_CHAR];

            for (int i = 0; i < MAX_CHAR; i++)
                firstInd[i] = -1;

            for (int i = 0; i < n; i++)
            {
                int first_ind = firstInd[str[i]];

                // If this is first occurrence
                if (first_ind == -1)
                    firstInd[str[i]] = i;

                // Else find distance from previous
                // occurrence and update result (if
                // required).
                else
                    res = Math.Max(res, Math.Abs(i
                                  - first_ind - 1));
            }

            return res;
        }
        /*
         Maximum number of characters between any two same character in a string
Difficulty Level : Medium
Last Updated : 21 May, 2021
Given a string, find the maximum number of characters between any two characters in the string. If no character repeats, print -1. 

Examples:  

Input : str = "abba"
Output : 2
The maximum number of characters are
between two occurrences of 'a'.

Input : str = "baaabcddc"
Output : 3
The maximum number of characters are
between two occurrences of 'b'.

Input : str = "abc"
Output : -1
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Approach 1 (Simple): Use two nested loops. The outer loop picks characters from left to right, the inner loop finds the farthest occurrence and keeps track of the maximum. 
        */
        static int maximumCharsBetweenSameCharacters(string str)
        {
            int n = str.Length;
            int res = -1;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (str[i] == str[j])
                        res = Math.Max(res, Math.Abs(j - i - 1));

            return res;
        }

        // Driver code
        static public void Main()
        {
            string str = "abba";

            Console.WriteLine(maximumCharsBetweenSameCharacters(str));
            Console.WriteLine(maximumChars(str));
            /*
             Output:  

2
Time Complexity : O(n)
            Output:  

2
Time Complexity : O(n^2)
            */
        }
    }
    //https://www.geeksforgeeks.org/fastenal-interview-experience-on-campus/
    public class Fastenal
    {
        /*
         1. String Letter Search: You are given a String X and a string containing single character Y. Your task is to find the largest distance between any two occurrences of the character Y in string X.

The Distance is defined by the no of distinct characters between any two occurrences of char Y in string X (Exclude whitespaces).

If there is no occurrences or only one occurrences of the given character, the function should return -1.

Example:

Input1: my name is ranary

Input2: a

Output: 7
        */
        public static void SameChar(String str)
        {
            int n = str.Length, count = -1, max_count = -1;
            for (int i = 0; i < n; i++)
            {

                // Count occurrences of current character
                if (str[i] == 'a')
                {
                    while (i < n - 1)
                    {
                        i++;
                        if (str[i] == ' ' && i < n - 1) continue;
                        count++;
                        if (str[i] == 'a' && i < n - 1) max_count = Math.Max(max_count, count);
                    }
                }
            }


            // Print character and its count
            Console.Write(max_count);
        }
        static void Main(string[] args)
        {
            SameChar("my name is rankkkkkary");
        }

    }
    /*
     Encora coderbyte
     */
    public class MatchingCharacters
    {
        static int maximumCharsBetweenMatchingPairs(string str)
        {
            int n = str.Length;
            int count = 0;
            Dictionary<char, char> _char = null;

            for (int i = 0; i < str.Length; i++)
            {
                _char = new Dictionary<char, char>();
                int lastIdx = str.LastIndexOf(str[i]);
                if (i == lastIdx) continue;
                for (int j = i + 1; j < lastIdx; j++)
                    if (!_char.ContainsKey(str[j]))
                    {
                        _char[str[j]] = str[i];
                    }
                if (count < _char.Keys.Count) count = _char.Keys.Count;
            }

            return count;
        }
        public static void Main(string[] args)
        {
            int _s = maximumCharsBetweenMatchingPairs("ahyjakh");
            Console.WriteLine(_s);
        }
        //output 4
        /*
      js version https://gist.github.com/Smakar20/a0837ed855fd110d1dc61f2728335bb3
        Have the function MatchingCharacters(str) take the str parameter being passed and determine the largest number of unique characters that exists between a pair of matching letters anywhere in the string. For example: if str is "ahyjakh" then there are only two pairs of matching letters, the two a's and the two h's. Between the pair of a's there are 3 unique characters: h, y, and j. Between the h's there are 4 unique characters: y, j, a, and k. So for this example your program should return 4. 
Another example: if str is "ghececgkaem" then your program should return 5 because the most unique characters exists within the farthest pair of e characters. The input string may not contain any character pairs, and in that case your program should just return 0. The input will only consist of lowercase alphabetic characters. 
        */

    }
    /*
     https://www.geeksforgeeks.org/count-strings-that-does-not-contain-any-alphabets-both-uppercase-and-lowercase/
    Count Strings that does not contain any alphabet’s both uppercase and lowercase
    Given an array of strings arr[], containing N strings, the task is to count the number of strings that do not contain both the uppercase and the lowercase character of an alphabet.
    Input: arr[]={ “abcdA”, “abcd”, “abcdB”, “abc” }
Output: 2
Explanation: The first string contains both the uppercase and the lowercase character for alphabet ‘a’. Similarly 3rd string also contains the uppercase and the lowercase character for alphabet ‘b’. Hence the count of valid strings is 3.
    Input: arr[]={ “xyz”, “abc”, “nmo” }
Output: 3
    Approach: The given problem can be solved using a greedy approach by iterating through all the given strings and for each alphabet check if the given string contains both its uppercase and the lowercase counterparts. Follow the below steps to solve this problem:

Create a variable count to store the required count. Initialize it with 0.
Now, traverse on each string in array arr[] and for each string store the frequency of its lowercase characters in an unordered map, M.
Now traverse on that string, and for each uppercase letter check if the frequency of its lowercase counterpart is greater than zero. if it is, then increment the value of count by 1.
Return count as the final answer.
Below is the implementation of the above approach:

     */
    public class SameCharUpperLower
    {

        static int SameLetterUpperLower(List<string> arr)
        {
            // Variable to store the answer
            int count = 0;

            // Loop to iterate through
            // the array arr[]
            foreach (var x in arr)
            {
                bool isAllowed = true;

                // Vector to store the frequency
                // of lowercase characters
                Dictionary<char, int> M = new Dictionary<char, int>();

                // Iterater through the
                // current string
                foreach (var y in x)
                {
                    if (y - 'a' >= 0 && y - 'a' < 26)
                    {
                        M[y]++;
                    }
                }

                foreach (var y in x)
                {

                    // Check if any uppercase letter
                    // have its lowercase version
                    if (y - 'A' >= 0 && y - 'A' < 26 && M[char.ToLower(y)] > 0)
                    {
                        isAllowed = false;
                        break;
                    }
                }

                // If current string is not a valid
                // string, increment the count
                if (isAllowed)
                {
                    count += 1;
                }
            }

            // Return Answer
            return count;
        }
        static void Main(string[] args)
        {
            List<string> arr = new List<string> { "abcdA", "abcd", "abcdB", "abc" };
            Console.WriteLine(SameLetterUpperLower(arr));
            /*
             Output
2
Time Complexity: O(N * M), where M is the length of the longest string
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/remove-characters-from-the-first-string-which-are-present-in-the-second-string/
    Remove characters from the first string which are present in the second string
    Algorithm: Let the first input string be a ”test string” and the string which has characters to be removed from the first string be a “mask”

    Initialize:  res_ind = 0 // index to keep track of the processing of each character in i/p string 
    ip_ind = 0  // index to keep track of the processing of each character in the resultant string 
Construct count array from mask_str.The count array would be: 
(We can use a Boolean array here instead of an int count array because we don’t need a count, we need to know only if the character is present in a mask string) 
count[‘a’] = 1 
count[‘k’] = 1 
count[‘m’] = 1 
count[‘s’] = 1
Process each character in the input string and if the count of that character is 0, then only add the character to the resultant string. 
str = “tet tringng” // ’s’ has been removed because ’s’ was present in mask_str, but we have got two extra characters “ng” 
ip_ind = 11 
res_ind = 9
Put a ‘\0′ at the end of the string?

     */
    public class ExceptStringTwo
    {
        static int NO_OF_CHARS = 256;

        /* Returns an array of size
        256 containing count of
        characters in the passed
        char array */
        static int[] getCharCountArray(String str)
        {
            int[] count = new int[NO_OF_CHARS];
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;

            return count;
        }

        /* removeDirtyChars takes two
        string as arguments: First
        string (str) is the one from
        where function removes dirty
        characters. Second string is
        the string which contain all
        dirty characters which need
        to be removed from first string */
        static String removeDirtyChars(String str,
                                       String mask_str)
        {
            int[] count = getCharCountArray(mask_str);
            int ip_ind = 0, res_ind = 0;

            char[] arr = str.ToCharArray();

            while (ip_ind != arr.Length)
            {
                char temp = arr[ip_ind];
                if (count[temp] == 0)
                {
                    arr[res_ind] = arr[ip_ind];
                    res_ind++;
                }
                ip_ind++;
            }

            str = new String(arr);

            /* After above step string
            is ngring. Removing extra
            "iittg" after string*/
            return str.Substring(0, res_ind);
        }

        // Driver Code
        public static void Main()
        {
            String str = "geeksforgeeks";
            String mask_str = "mask";
            Console.WriteLine(removeDirtyChars(str, mask_str));
            /*
             output
            geeforgee
Time Complexity: O(m+n) Where m is the length of the mask string and n is the length of the input string. 
            */
        }
    }

}
