using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     Check if a string consists only of special characters
     https://www.geeksforgeeks.org/check-if-a-string-consists-only-of-special-characters/?ref=lbp
    Given string str of length N, the task is to check if the given string contains only special characters or not. 
    If the string contains only special characters, then print “Yes”. Otherwise, print “No”.
    Examples:

Input: str = “@#$&%!~”
Output: Yes
Explanation: 
Given string contains only special characters. 
Therefore, the output is Yes.

Input: str = “Geeks4Geeks@#”
Output: No
Explanation: 
Given string contains alphabets, number, and special characters. 
Therefore, the output is No

    Naive Approach: Iterate over the string and check if the string contains only special characters or not. Follow the steps below to solve the problem:

Traverse the string and for each character, check if its ASCII value lies in the ranges [32, 47], [58, 64], [91, 96] or [123, 126]. If found to be true, it is a special character.
Print Yes if all characters lie in one of the aforementioned ranges. Otherwise, print No.
Time Complexity: O(N)
Auxiliary Space: O(1)

Space-Efficient Approach: The idea is to use Regular Expression to optimize the above approach. Follow the steps below:

Create the following regular expression to check if the given string contains only special characters or not.
regex = “[^a-zA-Z0-9]+”

where,

[^a-zA-Z0-9] represents only special characters.
+ represents one or more times.
Match the given string with the Regular Expression using Pattern.matcher() in Java
Print Yes if the string matches with the given regular expression. Otherwise, print No.
Below is the implementation of the above approach:

    */
    class OnlySpecialCharacter
    {

        // Function to check if a string
        // contains only special characters
        public static void onlySpecialchars(String str)
        {

            // If the string is empty
            // then print No
            if (str == null)
            {
                Console.WriteLine("No");
                return;
            }
            // Regex to check if a string
            // contains only special
            // characters
            String regex = "[^a-zA-Z0-9]+";

            // Compile the ReGex
            Regex rgex = new Regex(regex);

            // Find match between given
            // string & regular expression
            MatchCollection matchedAuthors = rgex.Matches(str);

            // Print Yes If the string matches
            // with the Regex
            if (matchedAuthors.Count != 0)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }

        // Driver Code
        public static void Main(String[] args)
        {
            // Given string str
            String str = "@#$&%!~";

            // Function Call
            onlySpecialchars(str);
            /*
             Output: Yes
 

Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
