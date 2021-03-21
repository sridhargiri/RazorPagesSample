using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if a given string is a comment or not
Last Updated : 15 Mar, 2021
Given a string S, representing a line in a program, the task is to check if the given string is a comment or not.

Types of comments in programs:

Single Line Comment: Comments preceded by a Double Slash (‘//’)
Multi-line Comment: Comments starting with (‘/*’) and ending with */
    /*Examples:

    Input: line = /*GeeksForGeeks GeeksForGeeks*/
    //Output: It is a multi-line comment

    //Input: line = “// GeeksForGeeks GeeksForGeeks”
    //Output: It is a single-line comment



    /*
    Approach: The idea is to check whether the input string is a comment or not.Below are the steps:

    Check if at the first Index(i.e.index 0) the value is ‘/’ then follow below steps else print “It is not a comment”.
    If line[0] == ‘/’:
    If line[1] == ‘/’, then print “It is a single line comment”.
    If line[1] == ‘*’, then traverse the string and if any adjacent pair of ‘*’ & ‘/’ is found then print “It is a multi-line comment”.
    Otherwise, print “It is not a comment”.
    Below is the implementation of the above approach:
            */
    class CommentOrNot
    {
        static void isComment(string line)
        {

            // If two continuous slashes 
            // preceeds the comment 
            if (line[0] == '/' && line[1] == '/'
                && line[2] != '/')
            {

                Console.WriteLine("It is a single-line comment");
                return;
            }

            if (line[line.Length - 2] == '*'
                && line[line.Length - 1] == '/')
            {

                Console.WriteLine("It is a multi-line comment");
                return;
            }

            Console.WriteLine("It is not a comment");
        }
        static void Main(string[] args)
        {
            // Given string 
            string line = "/*GeeksForGeeks GeeksForGeeks*/";

            // Function call to check whether then 
            // given string is a comment or not 
            isComment(line);

        }
        /*
         Output:
It is a multi-line comment
Time Complexity: O(N)
Auxiliary Space: O(1)
        */
    }
}
