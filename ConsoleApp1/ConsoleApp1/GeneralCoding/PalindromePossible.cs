using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Palindrome by swapping only one character
Difficulty Level : Hard
Last Updated : 17 Feb, 2020
Given a string, the task is to check if the string can be made palindrome by swapping a character only once.
[NOTE: only one swap and only one character should be swapped with another character]

Examples:

Input : bbg
Output : true
Explanation: Swap b(1st index) with g.

Input : bdababd
Output : true
Explanation: Swap b(0th index) with d(last index) or
             Swap d(1st index) with b(second index)

Input : gcagac
Output : false

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach:

This algorithm was based on a thorough analysis of the behavior and possibility of the forming string palindrome. By this analysis, I got the following conclusions :
1. Firstly, we will be finding the differences in the string that actually prevents it from being a palindrome.
…..a) To do this, We will start from both the ends and comparing one element from each end at a time, whenever it does match we store the values in a separate array as along with this we keep a count on the number of unmatched items.
 
2. If the number of unmatched items is more than 2, it is never possible to make it a palindrome string by swapping only one character.
 
3. If (number of unmatched items = 2) – it is possible to make the string palindrome iff the characters present in first unmatched set are same as the characters present in second unmatched set. (For example : try this out “bdababd”).
 
4. If (number of unmatched items = 1)
…..a) if (length of string is even) – it is not possible to make a palindrome string out of this.
…..b) if (length of string is odd) – it is possible to make a palindrome string out of this if one of the unmatched character matches with the middle character.
 
5. If (number of unmatched items = 0) – palindrome is possible if we swap the position of any same characters.
    https://www.geeksforgeeks.org/palindrome-by-swapping-only-one-character/
    */
    class PalindromePossible
    {

        public static bool isPalindromePossible(String input)
        {

            // convert the string to character array 
            char[] charStr = input.ToCharArray();
            int len = input.Length, i;

            // counts the number of differences 
            // which prevents the string
            // from being palindrome. 
            int diffCount = 0;

            // keeps a record of the 
            // characters that prevents 
            // the string from being palindrome. 
            char[,] diff = new char[2, 2];

            // loops from the start of a string 
            // till the midpoint of the string 
            for (i = 0; i < len / 2; i++)
            {

                // difference is encountered preventing 
                // the string from being palindrome 
                if (charStr[i] != charStr[len - i - 1])
                {

                    // 3rd differences encountered 
                    // and its no longer possible to
                    // make is palindrome by one swap 
                    if (diffCount == 2)
                        return false;

                    // record the different character 
                    diff[diffCount, 0] = charStr[i];

                    // store the different characters 
                    diff[diffCount++, 1] = charStr[len - i - 1];
                }
            }

            switch (diffCount)
            {

                // its already palindrome 
                case 0:
                    return true;

                // only one difference is found 
                case 1:
                    char midChar = charStr[i];

                    // if the middleChar matches either of the 
                    // difference producing characters, return true 
                    if (len % 2 != 0 &&
                        (diff[0, 0] == midChar ||
                        diff[0, 1] == midChar))
                        return true;
                    break;

                // two differences are found 
                case 2:

                    // if the characters contained in 
                    // the two sets are same, return true 
                    if ((diff[0, 0] == diff[1, 0] &&
                         diff[0, 1] == diff[1, 1]) ||
                         (diff[0, 0] == diff[1, 1] &&
                         diff[0, 1] == diff[1, 0]))
                        return true;
                    break;
            }
            return false;
        }

        // Driver code
        public static void Main(String[] args)
        {
            Console.WriteLine(isPalindromePossible("bbg"));
            Console.WriteLine(isPalindromePossible("bdababd"));
            Console.WriteLine(isPalindromePossible("gcagac"));
            /*
             Output:
true
true
false
Time Complexity : O(n)
Auxiliary Space : O(1)
            */
        }
    }
}
