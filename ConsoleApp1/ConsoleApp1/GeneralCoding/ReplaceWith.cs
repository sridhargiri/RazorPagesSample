using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Replace all occurrences of character X with character Y in given string
Difficulty Level : Medium
Last Updated : 19 May, 2021
Given a string str and two characters X and Y, the task is to write a recursive function to replace all occurrences of character X with character Y.

Examples: 

Input: str = abacd, X = a, Y = x 
Output: xbxcd

Input: str = abacd, X = e, Y = y 
Output: abacd  

 
Iterative Approach: The idea is to iterate over the given string and if any character X is found then replace that character with Y.



Time Complexity: O(N)
Auxiliary Space: O(1) 

Recursive Approach: The idea is to recursively traverse the given string and replace the character with value X with Y. Below are the steps:

Get the string str, character X, and Y.
Recursively Iterate from index 0 to string length.
Base Case: If we reach the end of the string the exit from the function. 
 
if(str[0]=='\0')
   return ;
Recursive Call: If the base case is not met, then check for the character at 0th index if it is X then replace that character with Y and recursively iterate for next character. 
 
if(str[0]==X) 
  str[0] = Y
Return Statement: At each recursive call(except the base case), return the recursive function for the next iteration. 
 
return recursive_function(str + 1, X, Y)
Below is the recursive implementation
    */
    class ReplaceWith
    {

        // Function to replace all occurrences
        // of character c1 with character c2
        static void replaceCharacter(string str,
                                     char c1, char c2)
        {
            char[] input = str.ToCharArray();

            // If the character at starting
            // of the given string is equal
            // to c1, replace it with c2
            for (int i = 0; i < str.Length; i++)
            {
                if (input[i] == c1)
                {
                    input[i] = c2;
                }

                // Print the string
                Console.Write(input[i]);
            }
        }

        // Driver Code
        public static void Main()
        {

            // Given string
            string str = "abacd";
            char c1 = 'a';
            char c2 = 'x';

            // Function call
            replaceCharacter(str, c1, c2);
            /*
             Output
xbxcd
Time Complexity: O(N), where N is the length of the string
Auxiliary Space: O(1)
            */
        }
    }
    /*
https://www.geeksforgeeks.org/replace-every-character-of-string-by-character-whose-ascii-value-is-k-times-more-than-it/?ref=rp
Replace every character of string by character whose ASCII value is K times more than it
Difficulty Level : Easy
Last Updated : 12 May, 2021
Given string str consisting of lowercase letters only and an integer k, the task is to replace every character of the given string with a character whose ASCII value is k times more than it. If the ASCII value exceeds ‘z’, then start checking from ‘a’ in a cyclic manner.

Examples:  

Input: str = “abc”, k = 2 
Output: cde 
a is moved by 2 times which results in character c 
b is moved by 2 times which results in character d 
c is moved by 2 times which results in character e
Input: str = “abc”, k = 28 
Output: cde 
a is moved 25 times, z is reached. Then 26th character will be a, 27-th b and 28-th c. 
b is moved 24 times, z is reached. 28-th is d. 
b is moved 23 times, z is reached. 28-th is e. 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: Iterate for every character in the string and perform the below steps for each character:  

Add k to the ASCII value of character str[i].
If it exceeds 122, then perform a modulus operation of k with 26 to reduce the number of steps, as 26 is the maximum number of shifts that can be performed in a rotation.
To find the character, add k to 96. Hence, the character with ASCII value k+96 will be a new character.
Repeat the above steps for every character of the given string.



Below is the implementation of the above approach
    */
    public class ReplaceWithKTimesMore
    {

        // Function to move string character
        static void encode(String s, int k)
        {

            // changed string
            String newS = "";

            // iterate for every characters
            for (int i = 0; i < s.Length; ++i)
            {
                // ASCII value
                int val = s[i];
                // store the duplicate
                int dup = k;

                // if k-th ahead character exceed 'z'
                if (val + k > 122)
                {
                    k -= (122 - val);
                    k = k % 26;

                    newS += (char)(96 + k);
                }
                else
                {
                    newS += (char)(96 + k);
                }

                k = dup;
            }

            // print the new string
            Console.Write(newS);
        }

        // Driver Code
        public static void Main()
        {
            String str = "abc";
            int k = 28;

            // function call
            encode(str, k);
            /*
             Output:  

cde
Time Complexity: O(N), where N is the length of the string.
            */
        }
    }
    /*
https://www.geeksforgeeks.org/modify-the-string-such-that-every-character-gets-replaced-with-the-next-character-in-the-keyboard/?ref=rp
Modify the string such that every character gets replaced with the next character in the keyboard
Last Updated : 14 May, 2021
Given a string str consisting of lowercase English alphabets. The task is to change each character of the string with the next letter (in a circular fashion) key in the keyboard. For example, ‘a’ gets replaced with ‘s’, ‘b’ gets replaced with ‘n’, ….., ‘l’ gets replaced with ‘z’, ….., ‘m’ gets replaced with ‘q’.
Examples: 
 

Input: str = “geeks” 
Output: hrrld
Input: str = “plmabc” 
Output: azqsnv 
 

 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: For every lowercase character of the English alphabet, insert the character next to it in the keyboard in an unordered_map. Now traverse the given string character by character, and update every character with the map created earlier.
Below is the implementation of the above approach: 
    */
    public class ReplaceWithNextKeyboard
    {

        static String CHARS = "qwertyuiopasdfghjklzxcvbnm";
        static int MAX = 26;

        // Function to return the modified String
        static String getString(char[] str, int n)
        {

            // Map to store the next character
            // on the keyboard for every
            // possible lowercase character
            Dictionary<char,
                       char> uMap = new Dictionary<char,
                                                   char>();
            for (int i = 0; i < MAX; i++)
            {
                if (!uMap.ContainsKey(CHARS[i]))
                    uMap.Add(CHARS[i], CHARS[(i + 1) % MAX]);
                else
                    uMap[CHARS[i]] = CHARS[(i + 1) % MAX];
            }

            // Update the String
            for (int i = 0; i < n; i++)
            {
                str[i] = uMap[str[i]];
            }
            return String.Join("", str);
        }

        // Driver code
        public static void Main(String[] args)
        {
            String str = "geeks";
            int n = str.Length;

            Console.WriteLine(getString(str.ToCharArray(), n));
            //Output: 
            //hrrld
        }
    }
}
