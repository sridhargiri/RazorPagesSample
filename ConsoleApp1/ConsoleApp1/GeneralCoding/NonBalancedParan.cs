using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class NonBalancedParantheses
    {
        /*
         Have the function RemoveBrackets(str) take the str string parameter being passed, which will contain only the characters "(" and ")", and determine the minimum number of brackets that need to be removed to create a string of correctly matched brackets.

For example:

If str is "(()))" then your program should return the number 1.

The answer could potentially be 0, and there will always be at least one set of matching brackets in the string.

Examples

Input: "(())()((("
Output: 3

Input: "(()("
Output: 2
        */
        static int RemoveBrackets(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                if (stack.Count == 0)
                {
                    stack.Push(c);
                }
                else
                {
                    if (c == '(') stack.Push(c);
                    else if (c == ')') stack.Pop();
                }
            }
            return stack.Count;
        }
        //own implementation - just by counters
        static int RemoveBrackets___(string str)
        {
            int op = 0;
            int cl = 0;
            int number = 0;
            foreach (char ch in str)
            {
                if (ch == '(') op++;
                else if (ch == ')') cl++;
            }
            if (op > cl)
            {
                number = op - cl;
            }
            else
            {
                number = cl - op;
            }
            return number;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(RemoveBrackets___("(())((((("));
        }
    }
}
