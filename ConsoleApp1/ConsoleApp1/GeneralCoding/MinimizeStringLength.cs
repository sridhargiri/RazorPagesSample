using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Minimize length of a string by removing suffixes and prefixes of same characters
Last Updated : 07 Apr, 2021
Given a string S of length N consisting only of characters ‘a’, ‘b’, and ‘c’, the task is to minimize the length of the given string by performing the following operations only once:

Divide the string into two non-empty substrings and then, append the left substring to the end of the right substring.
While appending, if the suffix of the right substring and prefix of the left substring contains the same character, then remove those characters from the suffix and prefix of the right and left substrings respectively. Repeat this step until no substrings are non-removable.
Examples:

Input: S = “aabcccabba”
Output: 4
Explanation:
Divide the given string S in two parts as “aabcc” and “cabba”. Below are the operations performed on the above two substrings:

Remove the prefixes and suffixes of the same characters, i.e. ‘a’. The string becomes “bcc” and “cabb”.
Remove the suffixes and prefixes of the same characters, i.e. ‘b’. The string becomes “cc” and “ca”.
Now, after concatenating the right and left substrings, the string obtained is “cacc”, which is of the shortest length, i.e. 4.

Input: S = “aacbcca”
Output: 1
    https://www.geeksforgeeks.org/minimize-length-of-a-string-by-removing-suffixes-and-prefixes-of-same-characters/


 
Approach: The given problem can be solved by using Two Pointers by finding similar characters present in the suffix of the string and the prefix of the string. 
Follow the steps below to solve the problem:

Initialize two variables, say i as 0 and j as (N – 1).
Iterate a loop until i < j and the characters S[i] and S[j] are the same, and perform the following steps:
Initialize a variable, say d with S[i], and shift pointer i towards the right while i is at most j and d = S[i].
Shift pointer j towards the left until i is at most j and d = S[j].
After completing the above steps, the value of (j – i + 1) is the minimum possible length of the string.

Below is the implementation of the above approach:*/
    class MinimizeStringLength
    {

        // Function to find the minimum length
        // of the string after removing the same
        // characters from the end and front of the
        // two strings after dividing into 2 substrings
        static int minLength(String s)
        {
            // Initialize two pointers
            int i = 0, j = s.Length - 1;

            // Traverse the string S
            for (; i < j
                   && s[i] == s[j];)
            {

                // Current char on left pointer
                char d = s[i];

                // Shift i towards right
                while (i <= j
                       && s[i] == d)
                    i++;

                // Shift j towards left
                while (i <= j
                       && s[j] == d)
                    j--;
            }

            // Return the minimum possible
            // length of string
            return j - i + 1;
        }

        // Driver Code
        public static void main(String[] args)
        {
            String S = "aacbcca";
            Console.WriteLine(minLength(S));
            /*
             Output: 
            1


            Time Complexity: O(N)
            Auxiliary Space: O(N)
            */
        }
    }
}
