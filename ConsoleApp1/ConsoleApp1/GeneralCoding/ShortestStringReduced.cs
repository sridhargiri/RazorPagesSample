using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Shortest string possible after removal of all pairs of similar adjacent characters
Difficulty Level : Medium
 Last Updated : 26 Feb, 2021
Given a string S, the task is to find the resultant smallest string possible, formed by repeatedly removing pairs of adjacent characters which are equal.

Examples:

Input: S = “aaabccddd”
Output: abd
Explanation: Following sequence of removal of pairs of adjacent characters minimizes the length of the string: 
aaabccddd → abccddd → abddd → abd.

Input: S = aa
Output: Empty String
Explanation: Following sequence of removal of pairs of adjacent characters minimizes the length of the string: 
aa → “”.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The main idea to solve the given problem is to recursively delete all pairs of adjacent characters which are equal, one by one. Follow the steps to solve the given problem:




Initialize an empty string, say ans, to store the string of minimum length after deleting all pairs of equal adjacent characters.
Initialize a string, say pre, to store the updated string after every removal of equal adjacent characters.
Now, iterate until the string ans and pre are unequal and perform the following steps:
Update the value of the string ans by removing the first adjacent same character using the function removeAdjacent().
If the value of the string ans is the same as the string pre, then break out of the loop. Otherwise, update the value of string pre as the string ans.
After completing the above steps, print the string ans as the resultant string.
Below is the implementation of the above approach:
    */
    class ShortestStringReduced
    {
        // Function to delete pair of adjacent
        // characters which are equal
        static String removeAdjacent(String s)
        {
            // Base Case
            if (s.Length == 1)
                return s;

            // Stores the update string
            StringBuilder sb = new StringBuilder("");

            // Traverse the string s
            for (int i = 0;
                 i < s.Length - 1; i++)
            {
                char c = s[i];
                char d = s[i + 1];

                // If two unequal pair of
                // adjacent characters are found
                if (c != d)
                {
                    sb.Append(c);

                    if (i == s.Length - 2)
                    {
                        sb.Append(d);
                    }
                }

                // If two equal pair of adjacent
                // characters are found
                else
                {
                    for (int j = i + 2;
                         j < s.Length; j++)

                        // Append the remaining string
                        // after removing the pair
                        sb.Append(s[j]);

                    return sb.ToString();
                }
            }

            // Return the final String
            return sb.ToString();
        }

        // Function to find the shortest string
        // after repeatedly removing pairs of
        // adjacent characters which are equal
        public static void reduceString(String s)
        {
            // Stores the resultant String
            String result = "";

            // Keeps track of previously
            // iterated string
            String pre = s;

            while (true)
            {
                // Update the result after
                // deleting adjacent pair of
                // characters which are similar
                result = removeAdjacent(pre);

                // Termination Conditions
                if (result.Equals(pre))
                    break;

                // Update pre variable with
                // the value of result
                pre = result;
            }

            if (result.Length != 0)
                Console.WriteLine(result);

            // Case for "Empty String"
            else
                Console.WriteLine("Empty String");
        }

        // Driver Code
        public static void main(String[] args)
        {
            String S = "aaabccddd";
            reduceString(S);
        }
    }
}
