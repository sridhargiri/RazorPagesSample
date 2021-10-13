using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/print-all-combinations-of-balanced-parentheses/
    Print all combinations of balanced parentheses
Difficulty Level : Hard
Last Updated : 08 Oct, 2021
Write a function to generate all possible n pairs of balanced parentheses. 

Examples: 

Input: n=1
Output: {}
Explanation: This the only sequence of balanced 
parenthesis formed using 1 pair of balanced parenthesis. 

Input : n=2
Output: 
{}{}
{{}}
Explanation: This the only two sequences of balanced 
parenthesis formed using 2 pair of balanced parenthesis. 
 
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Approach: To form all the sequences of balanced bracket subsequences with n pairs. So there are n opening brackets and n closing brackets. 
So the subsequence will be of length 2*n. There is a simple idea, the i’th character can be ‘{‘ if and only if the count of ‘{‘ till i’th is less than n and i’th character can be ‘}’ if and only if the count of ‘{‘ is greater than the count of ‘}’ till index i. If these two cases are followed then the resulting subsequence will always be balanced. 
So form the recursive function using the above two cases.

Algorithm:  

Create a recursive function that accepts a string (s), count of opening brackets (o) and count of closing brackets (c) and the value of n.
if the value of opening bracket and closing bracket is equal to n then print the string and return.
If the count of opening bracket is greater than count of closing bracket then call the function recursively with the following parameters String s + “}”, count of opening bracket o, count of closing bracket c + 1, and n.
If the count of opening bracket is less than n then call the function recursively with the following parameters String s + “{“, count of opening bracket o + 1, count of closing bracket c, and n.
Implementation: 
     */
    class PossibleBalancedParentheses
    {
        // Function that print all combinations of
        // balanced parentheses
        // open store the count of opening parenthesis
        // close store the count of closing parenthesis
        static void _printParenthesis(char[] str,
                int pos, int n, int open, int close)
        {
            if (close == n)
            {
                // print the possible combinations
                for (int i = 0; i < str.Length; i++)
                    Console.Write(str[i]);

                Console.WriteLine();
                return;
            }
            else
            {
                if (open > close)
                {
                    str[pos] = '}';
                    _printParenthesis(str, pos + 1,
                                    n, open, close + 1);
                }
                if (open < n)
                {
                    str[pos] = '{';
                    _printParenthesis(str, pos + 1,
                                    n, open + 1, close);
                }
            }
        }

        // Wrapper over _printParenthesis()
        static void printParenthesis(char[] str, int n)
        {
            if (n > 0)
                _printParenthesis(str, 0, n, 0, 0);
            return;
        }
        /*
         Output for n=3
{{{}}}
{{}{}}
{{}}{}
{}{{}}
{}{}{}
Thanks to Shekhu for providing the above code.
Complexity Analysis: 

Time Complexity: O(2^n). 
For every index there can be two options ‘{‘ or ‘}’. So it can be said that the upper bound of time complexity is O(2^n) or it has exponential time complexity.
Space Complexity: O(n). 
The space complexity can be reduced to O(n) if global variable or static variable is used to store the output string.
        */
        static void generateParenthesis(int n, int open, int close, string s, List<string> ans)
        {
            //if the count of both open and close parentheses reaches n, it means we have generated a valid parentheses.
            //So, we add the currently generated string s to the final ans and return.
            if (open == n && close == n)
            {
                ans.Add(s);
                return;
            }
            //At any index i in the generation of the string s, we can put an open parentheses only if its count until that time is less than n.
            if (open < n)
            {
                generateParenthesis(n, open + 1, close, s + "{", ans);
            }
            //At any index i in the generation of the string s, we can put a closed parentheses only if its count until that time is less than the count of open parentheses.
            if (close < open)
            {
                generateParenthesis(n, open, close + 1, s + "}", ans);
            }

        }
        // driver program
        public static void Main()
        {
            int n = 3;
            char[] str = new char[2 * n];
            printParenthesis(str, n);
            /*
             Output
{{}}
{}{}
            */
        }
    }
}
