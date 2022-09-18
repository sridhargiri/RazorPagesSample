using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     String formed with middle character of every right substring followed by left sequentially
     https://www.geeksforgeeks.org/string-formed-with-middle-character-of-every-right-substring-followed-by-left-sequentially/
   Given a string str of length N, the task is to decrypt it using a given set of decryption rules and print the decrypted string. 
The decryption rules are as follows: 
 

Start with the middle character of the string str and print it.
Repetitively traverse the right substring and print its middle character.
Repeat the same procedure for the left substring too.
Examples: 
    Input: N = 4, str = "abcd" 
Output: bcda
Explanation:
              abcd  ------ b
              / \
             a   cd ------ c
            /     \
           a       d ----- d
          /
         a --------------- a
Hence, the final string is "bcda".

Input: N = 6, str = "gyuitp"
Output: utpigy
Explanation:
            gyuitp ------- u
             / \
           gy  itp ------- t
          /    /\
         gy   i  p ------ p
         /   /
        gy  i ----------- i
        /
       gy --------------- g
       \
        y  -------------- y
Hence, the final string is "utpigy".
    Approach: 
The main idea is to use recursion. Keep on dividing the whole string into left and right substrings and print the middle element of every such substring, until the string is left with a single character and can not be further divided.
Detailed steps for this approach are as follows: 
 

Initialize start = 0, end = N -1, denoting the first and last character of the string.
Print the character at the middle of the string, that is mid = (start + end) / 2.
Recursively traverse its right substring (start = mid +1, end) followed by its left substring (start, mid – 1).
Repeat the above steps for each substring traversed. Continue until the entire string is traversed and print the given string.
Below is the implementation of the above approach: 

     */
    public class MiddleCharacterEveryRight
    {

        // Function to decrypt and
        // print the new String
        static void string_formed_with_middle_character_of_every_right_substring_followed_by_left_sequentially(String Str,
                    int Start, int End)
        {
            // If the whole String
            // has been traversed
            if (Start > End)
            {
                return;
            }

            // To calculate middle
            // index of the String
            int mid = (Start + End) >> 1;

            // Print the character
            // at middle index
            Console.Write(Str[mid]);

            // Recursively call
            // for right-subString
            string_formed_with_middle_character_of_every_right_substring_followed_by_left_sequentially(Str, mid + 1, End);

            // Recursive call
            // for left-subString
            string_formed_with_middle_character_of_every_right_substring_followed_by_left_sequentially(Str, Start, mid - 1);
        }

        // Driver Code
        public static void Main()
        {
            int N = 4;
            String Str = "abcd";
            string_formed_with_middle_character_of_every_right_substring_followed_by_left_sequentially(Str, 0, N - 1);
            Console.Write("\n");

            N = 6;
            Str = "gyuitp";
            string_formed_with_middle_character_of_every_right_substring_followed_by_left_sequentially(Str, 0, N - 1);
            /*
Output: 
bcda
utpigy

Time complexity: O(N) 
Auxiliary Space: O(1) 
            */
        }
    }
}
