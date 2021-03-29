using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StringMirrorReflect
    {
        /*
         Check if the given string is the same as its reflection in a mirror
Last Updated : 19 Mar, 2019
Given a string S containing only uppercase English characters. The task is to find whether S is the same as its reflection in a mirror.

Examples:

Input: str = "AMA"
Output: YES
AMA is same as its reflection in the mirror.

Input: str = "ZXZ"
Output: NO
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The string obviously has to be a palindrome, but that alone is not enough. All characters in the string should be symmetric so that their reflection is also the same. The symmetric characters are AHIMOTUVWXY.

Store the symmetric characters in an unordered_set.
Traverse the string and check if there is any non-symmetric character present in the string. If yes then return false.
Else check if the string is palindrome or not. If the string is palindrome also then return true else return false.
Below is the implementation of the above approach:
        https://www.geeksforgeeks.org/check-if-the-given-string-is-the-same-as-its-reflection-in-a-mirror/
        */
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // Function to check reflection 
        static bool isReflectionEqual(string s)
        {
            HashSet<char> symmetric = new HashSet<char>();

            // Symmetric characters 
            symmetric.Add('A');
            symmetric.Add('H');
            symmetric.Add('I');
            symmetric.Add('M');
            symmetric.Add('O');
            symmetric.Add('T');
            symmetric.Add('U');
            symmetric.Add('V');
            symmetric.Add('W');
            symmetric.Add('X');
            symmetric.Add('Y');

            int n = s.Length;

            for (int i = 0; i < n; i++)

                // If any non-symmetric character is 
                // present, the answer is NO 
                if (symmetric.Contains(s[i]) == false)
                    return false;

            string rev = s;
            s = Reverse(s);

            // Check if the string is a palindrome 
            if (rev == s)
                return true;
            else
                return false;
        }

        // Driver code 
        static public void Main()
        {
            string s = "MYTYM";
            if (isReflectionEqual(s))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
    /*
     Output:
YES
Time Complexity: O(N)
    */
}
