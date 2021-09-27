using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimum-number-of-manipulations-required-to-make-two-strings-anagram-without-deletion-of-character/
    Minimum Number of Manipulations required to make two Strings Anagram Without Deletion of Character
Difficulty Level : Easy
Last Updated : 17 Feb, 2021
Given two strings s1 and s2, we need to find the minimum number of manipulations required to make two strings anagram without deleting any character. 
Note:- The anagram strings have same set of characters, sequence of characters can be different. 
If deletion of character is allowed and cost is given, refer to Minimum Cost To Make Two Strings Identical
    https://www.geeksforgeeks.org/minimum-cost-make-two-strings-identical/
Question Source: https://www.geeksforgeeks.org/yatra-com-interview-experience-set-7/
Examples: 

Input : 
       s1 = "aba"
       s2 = "baa"
Output : 0
Explanation: Both String contains identical characters

Input :
       s1 = "ddcf"
       s2 = "cedk"
Output : 2
Explanation : Here, we need to change two characters
in either of the strings to make them identical. We 
can change 'd' and 'f' in s1 or 'e' and 'k' in s2.
Assumption: Length of both the Strings is considered similar 
     */
    class AnagramManipulate
    {
        /*
         1. Anagram Difference
        An anagram is a word whose characters can be rearranged to create another word. Given two strings, determine the minimum number of characters in either string that must be modified to make the two strings anagrams . If it is not possible to make the two strings anagrams, return -1.

        Example:
        a = ['tea', 'tea', 'act']
        b = ['ate', 'toe', 'acts']

        •	a[0] = tea and b[0] = ate are anagrams, so 0 characters need to be modified.
        •	a[1] = tea and b[1] = toe are not anagrams.  Modify 1 character in either string (o → a or a → o) to make them anagrams.
        •	a[2] = act and b[2] = acts are not anagrams and cannot be converted to anagrams because they contain different numbers of characters. 
        •	The return array is [0, 1, -1]

        Function Description 
        Complete the function getMinimumDifference in the editor below.

        getMinimumDifference has the following parameter(s):
            string a[n]:  an array of strings
            string b[n]:  an array of strings
        Return
            int[n]:  an array of integers which denote the minimum number of characters in either string that need to be modified to make the two strings anagrams. If it is not possible, return -1.

        Constraints
        •	Each string consists of lowercase characters [a-z].
        •	1 ≤ n ≤ 100
        •	0 ≤ |a[i]|, |b[i]| ≤ 104
        •	1 ≤ |a[i]| + |b[i]| ≤ 104

        Input Format for Custom TestingSample Case 0

        Sample Input For Custom Testing

        STDIN    Function
        -----    --------
        5    →   a[] size n = 5
        a    →   a = ['a', 'jk', 'abb', 'mn', 'abc']
        jk
        abb
        mn
        abc
        5    →   b[] size n = 5
        bb   →   b = ['bb', 'kj', 'bbc', 'op', 'def']
        kj
        bbc
        op
        def
        Sample Output
        -1
        0
        1
        2
        3

        Explanation
        Perform the following n = 5 calculations:
        •	Index 0: a and bb cannot be anagrams because they contain different numbers of characters.
        •	Index 1: jk and kj are already anagrams because they both contain the same characters at the same frequencies.
        •	Index 2: abb and bbc differ by one character.
        •	Index 3: mn and op differ by two characters.
        •	Index 4: abc and def differ by three characters.
        After checking each pair of strings, return the array [-1, 0, 1, 2, 3] as the answer.
        
•	5
•	a
•	jk
•	abb
•	mn
•	abc
•	5
•	bb
•	kj
•	bbc
•	op
•	def
Your Output (stdout)
•	-1
•	0
•	1
•	2
•	3
Expected Output
Download
•	-1
•	0
•	1
•	2
•	3

         */
        static int countManipulations_to_make_anagram(string s1,
                                      string s2)
        {
            int count = 0;
            if (s1.Length != s2.Length) return -1;

            // store the count of character
            int[] char_count = new int[26];

            // iterate though the first String
            // and update count
            for (int i = 0; i < s1.Length; i++)
                char_count[s1[i] - 'a']++;

            // iterate through the second string
            // update char_count.
            // if character is not found in
            // char_count then increase count
            for (int i = 0; i < s2.Length; i++)
                char_count[s2[i] - 'a']--;

            for (int i = 0; i < 26; ++i)
            {
                if (char_count[i] > 0)
                {
                    count += Math.Abs(char_count[i]);
                }
            }

            return count;
        }
        /*
         https://www.geeksforgeeks.org/remove-minimum-number-characters-two-strings-become-anagram/
        Remove minimum number of characters so that two strings become anagram
Difficulty Level : Easy
Last Updated : 12 Apr, 2021
Given two strings in lowercase, the task is to make them anagram. The only allowed operation is to remove a character from any string. Find minimum number of characters to be deleted to make both the strings anagram? 
If two strings contains same data set in any order then strings are called Anagrams. 

Examples :  

Input : str1 = "bcadeh" str2 = "hea"
Output: 3
We need to remove b, c and d from str1.

Input : str1 = "cddgk" str2 = "gcd"
Output: 2

Input : str1 = "bca" str2 = "acb"
Output: 0
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
The idea is to make character count arrays for both the strings and store frequency of each character. 
        Now iterate the count arrays of both strings and difference in frequency of any character abs(count1[str1[i]-‘a’] – count2[str2[i]-‘a’]) in both the strings is the number of character to be removed in either string. 
         */
        // to make two strings anagram
        static int removeCharToMakeAnagram(string str1,
                              string str2)
        {
            // make hash array for both
            // string and calculate frequency
            // of each character
            int[] count1 = new int[26];
            int[] count2 = new int[26];

            // count frequency of each
            // character in first string
            for (int i = 0; i < str1.Length; i++)
                count1[str1[i] - 'a']++;

            // count frequency of each 
            // character in second string
            for (int i = 0; i < str2.Length; i++)
                count2[str2[i] - 'a']++;

            // traverse count arrays to
            // find number of characters
            // to be removed
            int result = 0;
            for (int i = 0; i < 26; i++)
                result += Math.Abs(count1[i] -
                                   count2[i]);
            return result;
        }
        readonly static int CHARS = 26;
        /*
         Output : 3
Time Complexity : O(n) 
Auxiliary space : O(ALPHABET-SIZE)
The above solution can be optimized to work with single count array.  
        */
        static int countDeletionsToMakeAnagram(String str1, String str2)
        {
            int[] arr = new int[CHARS];
            for (int i = 0; i < str1.Length; i++)
            {
                arr[str1[i] - 'a']++;
            }

            for (int i = 0; i < str2.Length; i++)
            {
                arr[str2[i] - 'a']--;
            }

            int ans = 0;
            for (int i = 0; i < CHARS; i++)
            {
                ans += Math.Abs(arr[i]);
            }
            return ans;
        }
        // Driver code
        public static void Main()
        {

            //string s1 = "ddcf";
            //string s2 = "cedk";
            string s1 = "mn";
            string s2 = "op";
            Console.WriteLine(
                countManipulations_to_make_anagram(s1, s2));//op 2. Time Complexity: O(n), where n is the length of the string
        }
    }
}
