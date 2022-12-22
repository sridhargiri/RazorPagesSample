using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    /*
	 https://www.geeksforgeeks.org/check-whether-two-strings-can-be-made-equal-by-copying-their-characters-with-the-adjacent-ones/?ref=rp
	Check whether two strings can be made equal by copying their characters with the adjacent ones
Last Updated : 15 Oct, 2019
Given two strings str1 and str2, the task is to check whether both of the string can be made equal by copying any character of the string with its adjacent character. Note that this operation can be performed any number of times.

Examples:

Input: str1 = “abc”, str2 = “def”
Output: No
As all the characters in both the string are different.
So, there is no way they can be made equal.

Input: str1 = “abc”, str2 = “fac”
Output: Yes
str1 = “abc” -> “aac”
str2 = “fac” -> “aac”

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: In order for the strings to be made equal with the given operation, they have to be of equal lengths and there has to be at least one character which is common in both the strings. To check that, create a frequency array freq[] which will store the frequency of all the characters of str1 and then for every character of str2 if its frequency in str1 is greater than 0 then it is possible to make both the strings equal.

Below is the implementation of the above approach:
	 */
    class StringEqual
    {
        static int MAX = 26;

        // Function that returns true if both
        // the strings can be made equal
        // with the given operation
        static Boolean canBeMadeEqual(String str1,
                                    String str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;

            // Lengths of both the strings
            // have to be equal
            if (len1 == len2)
            {

                // To store the frequency of the
                // characters of str1
                int[] freq = new int[MAX];

                for (int i = 0; i < len1; i++)
                {
                    freq[str1[i] - 'a']++;
                }

                // For every character of str2
                for (int i = 0; i < len2; i++)
                {

                    // If current character of str2
                    // also appears in str1
                    if (freq[str2[i] - 'a'] > 0)
                        return true;
                }
            }
            return false;
        }
        /*
https://www.geeksforgeeks.org/check-if-two-strings-can-be-made-equal-by-swapping-one-character-among-each-other/

Asked in Wolters kluwers mettl online test on 22/12/2022

Check if two strings can be made equal by swapping one character among each other
Difficulty Level : Basic
Last Updated : 28 Nov, 2019
Given two strings A and B of length N, the task is to check whether the two strings can be made equal by swapping any character of A with any other character of B only once.

Examples:

Input: A = “SEEKSFORGEEKS”, B = “GEEKSFORGEEKG”
Output: Yes
“SEEKSFORGEEKS” and “GEEKSFORGEEKG”
can be swapped to make both the strings equal.

Input: A = “GEEKSFORGEEKS”, B = “THESUPERBSITE”
Output: No

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: First omit the elements which are the same and have the same index in both the strings. Then if the new strings are of length two and both the elements in each string are the same then only the swap is possible.

Below is the implementation of the above approach:
        */

        // Function that returns true if the string
        // can be made equal after one swap
        static Boolean canBeEqual(char[] a,
                                  char[] b, int n)
        {
            // A and B are new a and b
            // after we omit the same elements
            List<char> A = new List<char>();
            List<char> B = new List<char>();

            // Take only the characters which are
            // different in both the strings
            // for every pair of indices
            for (int i = 0; i < n; i++)
            {

                // If the current characters differ
                if (a[i] != b[i])
                {
                    A.Add(a[i]);
                    B.Add(b[i]);
                }
            }

            // The strings were already equal
            if (A.Count == B.Count &&
                B.Count == 0)
                return true;

            // If the lengths of the
            // strings are two
            if (A.Count == B.Count &&
                B.Count == 2)
            {

                // If swapping these characters
                // can make the strings equal
                if (A[0] == A[1] &&
                    B[0] == B[1])
                    return true;
            }
            return false;
        }
        public static void Main(String[] args)
        {
            String str1 = "abc", str2 = "defa";

            if (canBeMadeEqual(str1, str2))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            // op - No
            char[] A = "SEEKSFORGEEKS".ToCharArray();
            char[] B = "GEEKSFORGEEKG".ToCharArray();

            if (canBeEqual(A, B, A.Length))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");//op yes
        }
    }
    /*
     https://www.geeksforgeeks.org/distinct-strings-odd-even-changes-allowed/
    Distinct strings with odd and even changes allowed
    Given an array of lower case strings, the task is to find the number of strings that are distinct. Two strings are distinct if, on applying the following operations on one string, the second string cannot be formed.  

A character on the odd index can be swapped with another character on the odd index only.
A character on even index can be swapped with another character on even index only.
Examples:  

Input  : arr[] = {"abcd", "cbad", "bacd"}
Output : 2
The 2nd string can be converted to the 1st by swapping 
the first and third characters. So there are 2 distinct 
strings as the third string cannot be converted to the 
first.

Input  : arr[] = {"abc", "cba"}
Output : 1 
    A simple solution is to run two loops. 
    The outer loop picks a string and the inner loop checks if there is a previously string which can be converted to a current string by doing allowed transformations. 
    This solution requires O(n2m) time where n is the number of strings and m is the maximum number of characters in any string.

An efficient solution generates an encoded string for every input string. The encoded has counts of even and odd positioned characters separated by a separator. 
    Two strings are considered same if their encoded strings are the same, then else not. 
    Once we have a way to encode strings, the problem is reduced to counting distinct encoded strings. This is a typical problem of hashing. We create a hash set and, one by one, store encodings of strings. If an encoding already exists, we ignore the string. 
    Otherwise, we store encoding in hash and increment count of distinct strings. 

     */
    public class PasswordStringDistinct
    {
        static int MAX_CHAR = 26;

        static String encodeString(char[] str)
        {
            // hashEven stores the count of even
            // indexed character for each string
            // hashOdd stores the count of odd
            // indexed characters for each string
            int[] hashEven = new int[MAX_CHAR];
            int[] hashOdd = new int[MAX_CHAR];

            // creating hash for each string
            for (int i = 0; i < str.Length; i++)
            {
                char m = str[i];

                // If index of current character is odd
                if ((i & 1) != 0)
                    hashOdd[m - 'a']++;
                else
                    hashEven[m - 'a']++;
            }

            // For every character from 'a' to 'z',
            // we store its count at even position
            // followed by a separator,
            // followed by count at odd position.
            String encoding = "";
            for (int i = 0; i < MAX_CHAR; i++)
            {
                encoding += (hashEven[i]);
                encoding += ('-');
                encoding += (hashOdd[i]);
                encoding += ('-');
            }
            return encoding;
        }

        // This function basically uses a hashing based set
        // to store strings which are distinct according
        // to criteria given in question.
        static int countDistinct(int input1, String[] input2)
        {
            int countDist = 0; // Initialize result

            // Create an empty set and store all distinct
            // strings in it.
            HashSet<String> s = new HashSet<String>();
            for (int i = 0; i < input1; i++)
            {
                // If this encoding appears first time,
                // increment count of distinct encodings.
                if (!s.Contains(encodeString(input2[i].ToCharArray())))
                {
                    s.Add(encodeString(input2[i].ToCharArray()));
                    countDist++;
                }
            }

            return countDist;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            String[] input = { "abcd", "bcad" };
            int n = input.Length;
            Console.WriteLine(countDistinct(n, input));
            /*
             input  "abcd", "bcad"  output  2
             input  "abcd", "cdab"  output  1
             input  "abcd", "acbd", "adcb", "cdba", "bcda", "badc"  output  4
             */
        }
    }

}
