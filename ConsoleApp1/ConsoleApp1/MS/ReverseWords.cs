
using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    /*
	  C# program to reverse individual  words in a sentence
	https://www.geeksforgeeks.org/reverse-individual-words/?ref=gcse
	Given a string str, we need to print reverse of individual words.

Examples: 

Input : Hello World
Output : olleH dlroW
 
Input :  Geeks for Geeks
Output : skeeG rof skeeG
Method 1 (Simple): Generate all words separated by space. One by one reverse words and print them separated by space. 
Method 2 (Space Efficient): We use a stack to push all words before space. As soon as we encounter a space, we empty the stack. 

	*/

    public class ReverseWords
    {

        // reverses individual words 
        // of a string 
        public static void ReverseIndividualWords(string str)
        {
            Stack<char> st = new Stack<char>();

            // Traverse given string and push 
            // all characters to stack until 
            // we see a space. 
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    st.Push(str[i]);
                }

                // When we see a space, we 
                // print contents of stack. 
                else
                {
                    while (st.Count > 0)
                    {
                        Console.Write(st.Pop());

                    }
                    Console.Write(" ");
                }
            }

            // Since there may not be 
            // space after last word. 
            while (st.Count > 0)
            {
                Console.Write(st.Pop());
            }
        }

        // Driver Code 
        public static void Main(string[] args)
        {
            string str = "Geeks for Geeks";
            ReverseIndividualWords(str);
            //			Output
            //skeeG rof skeeG
        }
    }
    /*
         https://www.geeksforgeeks.org/reverse-individual-words-with-o1-extra-space/?ref=gcse
        Reverse individual words with O(1) extra space
        Given a string str, the task is to reverse all the individual words.

Examples: 

Input: str = “Hello World” 
Output: olleH dlroW

Input: str = “Geeks for Geeks” 
Output: skeeG rof skeeG 
        Approach: A solution to the above problem has been discussed in this post. It has a time complexity of O(n) and uses O(n) extra space. In this post, we will discuss a solution which uses O(1) extra space.  

Traverse through the string until we encounter a space.
After encountering the space, we use two variables ‘start’ and ‘end’ pointing to the first and last character of the word and we reverse that particular word.
Repeat the above steps until the last word.
Below is the implementation of the above approach:  
         */
    public class ReverseWords_NoExtraSpace
    {

        // Function to return the string after
        // reversing the individual words
        static String reverseWords(String str)
        {

            // Pointer to the first character
            // of the first word
            int start = 0;
            for (int i = 0; i < str.Length; i++)
            {

                // If the current char is space or the current word has ended
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    // Pointer to the last character of the current word
                    int end;
                    if (i == str.Length - 1)
                        end = i;
                    else
                        end = i - 1;

                    // Reverse the current word
                    while (start < end)
                    {
                        str = SwapWord(str, start, end);
                        start++;
                        end--;
                    }

                    // Pointer to the first character
                    // of the next word
                    start = i + 1;
                }
            }

            return str;
        }
        static String SwapWord(String str, int i, int j)
        {
            char[] ch = str.ToCharArray();
            char temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
            return String.Join("", ch);
        }

        // Driver code
        public static void Main(String[] args)
        {
            String str = "Geeks for Geeks";
            Console.WriteLine(reverseWords(str));

            /*
             Output: skeeG rof skeeG
Time Complexity: O(n) 
Auxiliary Space: O(1)
            */
        }
    }
}

// This code is contributed 
// by Shrikant13 
