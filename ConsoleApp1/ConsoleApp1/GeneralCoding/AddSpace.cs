using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/put-spaces-words-starting-capital-letters/
    Put spaces between words starting with capital letters
Difficulty Level : Easy
Last Updated : 22 Oct, 2019
You are given an array of characters which is basically a sentence. However there is no space between different words and the first letter of every word is in uppercase. You need to print this sentence after following amendments:
(i) Put a single space between these words.
(ii) Convert the uppercase letters to lowercase.

Examples:

Input : BruceWayneIsBatman
Output : bruce wayne is batman

Input :  You
Output :  you
We check if the current character is in uppercase then print ” “(space) and convert it into lowercase.
     */
    public class AddSpace
    {

        // Function to amend the sentence
        public static void amendSentence(string sstr)
        {
            char[] str = sstr.ToCharArray();

            // Traverse the string
            for (int i = 0; i < str.Length; i++)
            {

                // Convert to lowercase if its
                // an uppercase character
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    str[i] = (char)(str[i] + 32);

                    // Print space before it
                    // if its an uppercase
                    // character
                    if (i != 0)
                        Console.Write(" ");

                    // Print the character
                    Console.Write(str[i]);
                }

                // if lowercase character
                // then just print
                else
                    Console.Write(str[i]);
            }
        }

        // Driver Code
        public static void Main()
        {
            string str = "BruceWayneIsBatman";

            amendSentence(str);//output -> bruce wayne is batman
        }

    }

    /*
     https://www.geeksforgeeks.org/move-spaces-front-string-single-traversal/
    Move spaces to front of string in single traversal
Difficulty Level : Easy
Last Updated : 03 Jun, 2021
Given a string that has set of words and spaces, write a program to move all spaces to front of string, by traversing the string only once.

Examples: 

Input  : str = "geeks for geeks"
Output : ste = "  geeksforgeeks"

Input  : str = "move these spaces to beginning"
Output : str = "    movethesespacestobeginning"
There were four space characters in input,
all of them should be shifted in front. 
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Method 1 (Using Swap) 
Idea is to maintain two indices i and j. Traverse from end to beginning. If the current index contains space, swap chars in index i with index j. This will bring all spaces to beginning of the array.
     */
    public class MoveSpacesFront
    {

        // Function to find spaces and move to beginning
        static void moveSpaceInFront(char[] str)
        {

            // Traverse from end and swap spaces
            int i = str.Length - 1;
            for (int j = i; j >= 0; j--)
                if (str[j] != ' ')
                {
                    char c = str[i];
                    str[i] = str[j];
                    str[j] = c;
                    i--;
                }
        }

        // Driver code
        public static void Main()
        {
            char[] str = "Hey there, it's GeeksforGeeks".ToCharArray();
            moveSpaceInFront(str);
            Console.WriteLine(String.Join("", str));
            /*
             Output: 

   Heythere,it'sGeeksforGeeks
Time complexity-: O(n) 
Auxiliary Space-: O(1)
            */
        }
    }
    //Method 2 (Without using swap) 
    //The idea is to copy all non-space characters to end.Finally copy spaces.
    public class MoveSpacesFrontNoSwap
    {

        // Function to find spaces and move to beginning
        static void moveSpaceToFront(char[] str)
        {
            // Keep copying non-space characters
            int i = str.Length - 1;

            for (int j = i; j >= 0; j--)
                if (str[j] != ' ')
                    str[i--] = str[j];

            // Move spaces to be beginning
            while (i >= 0)
                str[i--] = ' ';
        }

        // Driver code
        public static void Main(String[] args)
        {
            char[] str = "Hey there, it's GeeksforGeeks".
                                            ToCharArray();
            moveSpaceToFront(str);
            Console.WriteLine(String.Join("", str));
            /*
             Output: 

   Heythere,it'sGeeksforGeeks
Time complexity-: O(n) 
Auxiliary Space -:O(1)
            */
        }
    }
    /*
https://www.geeksforgeeks.org/remove-spaces-from-a-given-string/
     Remove spaces from a given string
Difficulty Level : Easy
Last Updated : 31 May, 2021
Given a string, remove all spaces from the string and return it. 

Input:  "g  eeks   for ge  eeks  "
Output: "geeksforgeeks"
Expected time complexity is O(n) and only one traversal of string. 
 

We strongly recommend that you click here and practice it, before moving on to the solution.
Below is a Simple Solution 

1) Iterate through all characters of given string, do following
   a) If current character is a space, then move all subsequent
      characters one position back and decrease length of the 
      result string.
Time complexity of above solution is O(n2).
A Better Solution can solve it in O(n) time. The idea is to keep track of count of non-space character seen so far. 

1) Initialize 'count' = 0 (Count of non-space character seen so far)
2) Iterate through all characters of given string, do following
     a) If current character is non-space, then put this character
        at index 'count' and increment 'count'
3) Finally, put '\0' at index 'count'
Below is the implementation of above algorithm. 
    */
    public class RemoveSpaces
    {

        // Function to remove all spaces
        // from a given string
        static int removeSpaces(char[] str)
        {
            // To keep track of non-space
            // character count
            int count = 0;

            // Traverse the given string. If current
            // character is not space, then place
            // it at index 'count++'
            for (int i = 0; i < str.Length; i++)
                if (str[i] != ' ')
                    str[count++] = str[i]; // here count is
                                           // incremented

            return count;
        }

        // Driver code
        public static void Main(String[] args)
        {
            char[] str = "g eeks for ge eeks ".ToCharArray();
            int i = removeSpaces(str);
            Console.WriteLine(String.Join("", str).Substring(0, i));
            /*
             Output: 

geeksforgeeeks
Time complexity of above solution is O(n) and it does only one traversal of string. 
            */
        }
    }
}
