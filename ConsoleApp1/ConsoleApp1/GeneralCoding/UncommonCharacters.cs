using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find uncommon characters of the two strings
    Find and print the uncommon characters of the two given strings in sorted order. Here uncommon character means that either the character is present in one string or it is present in other string but not in both. The strings contain only lowercase characters and can contain duplicates.

Source: https://www.geeksforgeeks.org/amazon-interview-experience-set-355-1-year-experienced/ Amazon Interview Experience | Set 355 (For 1 Year Experienced)

Examples:

Input: str1 = “characters”, str2 = “alphabets”
Output: b c l p r

Input: str1 = “geeksforgeeks”, str2 = “geeksquiz”
Output: f i o q r u z
    Naive Approach: Using two loops, for each character of 1st string check whether it is present in the 2nd string or not. Likewise, for each character of 2nd string check whether it is present in the 1st string or not.

Time Complexity: O(n^2) and extra would be required to handle duplicates.

Efficient Approach: An efficient approach is to use hashing.

Use a hash table of size 26 for all the lowercase characters.
Initially, mark presence of each character as ‘0’ (denoting that the character is not present in both the strings).
Traverse the 1st string and mark presence of each character of 1st string as ‘1’ (denoting 1st string) in the hash table.
Now, traverse the 2nd string. For each character of 2nd string, check whether its presence in the hash table is ‘1’ or not. If it is ‘1’, then mark its presence as ‘-1’ (denoting that the character is common to both the strings), else mark its presence as ‘2’ (denoting 2nd string).
Below image is a dry run of the above approach:



     */
    class UncommonCharacters
    {

        // size of the hash table 
        static int MAX_CHAR = 26;

        // function to find the uncommon 
        // characters of the two strings 
        static void findAndPrintUncommonChars(String str1,
                                        String str2)
        {
            // mark presence of each character as 0 
            // in the hash table 'present[]' 
            int[] present = new int[MAX_CHAR];
            for (int i = 0; i < MAX_CHAR; i++)
            {
                present[i] = 0;
            }

            int l1 = str1.Length;
            int l2 = str2.Length;

            // for each character of str1, mark its 
            // presence as 1 in 'present[]' 
            for (int i = 0; i < l1; i++)
            {
                present[str1[i] - 'a'] = 1;
            }

            // for each character of str2 
            for (int i = 0; i < l2; i++)
            {

                // if a character of str2 is also present 
                // in str1, then mark its presence as -1 
                if (present[str2[i] - 'a'] == 1
                    || present[str2[i] - 'a'] == -1)
                {
                    present[str2[i] - 'a'] = -1;
                }

                // else mark its presence as 2 
                else
                {
                    present[str2[i] - 'a'] = 2;
                }
            }

            // print all the uncommon characters 
            for (int i = 0; i < MAX_CHAR; i++)
            {
                if (present[i] == 1 || present[i] == 2)
                {
                    Console.Write((char)(i + 'a') + " ");
                }
            }
        }
        /*
         Find uncommon characters of the two strings | Set 2
Difficulty Level : Medium
 Last Updated : 10 Jun, 2019
Given two strings str1 and str2, the task is to find and print the uncommon characters of the two given strings in sorted order without using extra space. Here uncommon character means that either the character is present in one string or it is present in the other string but not in both. The strings contain only lowercase characters and can contain duplicates.

Examples:

Input: str1 = “characters”, str2 = “alphabets”
Output: b c l p r

Input: str1 = “geeksforgeeks”, str2 = “geeksquiz”
Output: f i o q r u z


Approach: An approach that uses hashing has been discussed here. This problem can also be solved using bit operations.
The approach uses 2 variables that store the bit-wise OR of left shift of 1 with each character’s ascii code – 97 i.e. 0 for ‘a’, 1 for ‘b’ and so on. For both the strings we get an integer after performing these bit-wise operations. Now the XOR of these two integers will give the binary bit as 1 at only those positions that denote uncommon characters. Print the character values for those positions.



Below is the implementation of the above approach:
        */
        static void printUncommon(string str1, string str2)
        {
            int a1 = 0, a2 = 0;
            for (int i = 0; i < str1.Length; i++)
            {

                // Converting character to ASCII code 
                int ch = (str1[i] - 'a');

                // Bit operation 
                a1 = a1 | (1 << ch);
            }
            for (int i = 0; i < str2.Length; i++)
            {

                // Converting character to ASCII code 
                int ch = (str2[i] - 'a');

                // Bit operation 
                a2 = a2 | (1 << ch);
            }

            // XOR operation leaves only uncommon 
            // characters in the ans variable 
            int ans = a1 ^ a2;

            int j = 0;
            while (j < 26)
            {
                if (ans % 2 == 1)
                {
                    Console.Write((char)('a' + j));
                }
                ans = ans / 2;
                j++;
            }
        }
        /*
         Concatenated string with uncommon characters of two strings
Difficulty Level : Medium
 Last Updated : 02 Dec, 2019
Two strings are given and you have to modify 1st string such that all the common characters of the 2nd strings have to be removed and the uncommon characters of the 2nd string have to be concatenated with uncommon characters of the 1st string.

Examples:

Input : S1 = "aacdb"
        S2 = "gafd"
Output : "cbgf"

Input : S1 = "abcs";
        S2 = "cxzca";
Output : "bsxz"

The idea is to use hash map where key is character and value is number of strings in which character is present. If a character is present in one string, then count is 1, else if character is present in both strings, count is 2.

Initialize result as empty string.
Push all characters of 2nd string in map with count as 1.
Traverse first string and append all those characters to result that are not present in map. Characters that are present in map, make count 2.
Traverse second string and append all those characters to result whose count is 1.
        */

        public static String concatenatedString(String s1,
                                                String s2)
        {
            // Result 
            String res = "";
            int i;

            // creating a hashMap to add characters 
            // in string s2 
            Dictionary<char,
                       int> m = new Dictionary<char,
                                               int>();
            for (i = 0; i < s2.Length; i++)
                if (!m.ContainsKey(s2[i]))
                    m.Add(s2[i], 1);

            // Find characters of s1 that are not 
            // present in s2 and append to result 
            for (i = 0; i < s1.Length; i++)
                if (!m.ContainsKey(s1[i]))
                    res += s1[i];
                else
                    m[s1[i]] = 2;

            // Find characters of s2 that are not 
            // present in s1. 
            for (i = 0; i < s2.Length; i++)
                if (m[s2[i]] == 1)
                    res += s2[i];

            return res;
        }
        static int ASCII_SIZE = 256;
        /*
         Return maximum occurring character in an input string

Write an efficient function to return maximum occurring character in the input string e.g., if input string is “test” then function should return ‘t’.


Algorithm:
One obvious approach to solve this problem would be to sort the input string and then traverse through the sorted string to find the character which is occurring maximum number of times. Let us see if we can improve on this. 
        So we will use a technique called ‘Hashing’. In this, when we traverse through the string, we would hash each character into an array of ASCII characters.

Input string = “test”
1: Construct character count array from the input string.
  count['e'] = 1
  count['s'] = 1
  count['t'] = 2

2: Return the index of maximum value in count array (returns ‘t’).
Typically, ASCII characters are 256, so we use our Hash array size as 256. But if we know that our input string will have characters with value from 0 to 127 only, we can limit Hash array size as 128. Similarly, based on extra info known about input string, the Hash array size can be limited to 26.
        
         */
        static char getMaxOccuringChar(String str)
        {
            // Create array to keep the count of 
            // individual characters and  
            // initialize the array as 0 
            int[] count = new int[ASCII_SIZE];

            // Construct character count array 
            // from the input string. 
            int len = str.Length;
            for (int i = 0; i < len; i++)
                count[str[i]]++;

            int max = -1; // Initialize max count 
            char result = ' '; // Initialize result 

            // Traversing through the string and  
            // maintaining the count of each character 
            for (int i = 0; i < len; i++)
            {
                if (max < count[str[i]])
                {
                    max = count[str[i]];
                    result = str[i];
                }
            }

            return result;
        }
        // Driver code 
        public static void Main(String[] args)
        {
            String str1 = "characters";
            String str2 = "alphabets";
            findAndPrintUncommonChars(str1, str2);

            str1 = "geeksforgeeks";
            str2 = "geeksquiz";

            printUncommon(str1, str2);

            String s1 = "abcs";
            String s2 = "cxzca";
            Console.WriteLine(concatenatedString(s1, s2));
        }
    }

    //Output:
    //b c l p r
    //Time Complexity: O(m + n), where m and n are the sizes of the two strings respectively.

}
