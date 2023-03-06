using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
Asked in SafeSend on 24/02/2023
https://www.geeksforgeeks.org/remove-invalid-parentheses/
Remove Invalid Parentheses

    An expression will be given which can contain open and close parentheses and optionally some characters, 
    No other operator will be there in string. We need to remove minimum number of parentheses to make the input string valid. 
    If more than one valid output are possible removing same number of parentheses then print all such output.
Examples:

Input  : str = “()())()” -
Output : ()()() (())()
There are two possible solutions
"()()()" and "(())()"

Input  : str = (v)())()
Output : (v)()()  (v())()
As we need to generate all possible output we will backtrack among all states by removing one opening or closing bracket and check if they are valid,
    if invalid then add the removed bracket back and go for next state. 
    We will use BFS for moving through states, use of BFS will assure removal of minimal number of brackets 
    because we traverse into states level by level and each level corresponds to one extra bracket removal. 
    Other than this BFS involve no recursion so overhead of passing parameters is also saved.
Below code has a method isValidString to check validity of string, it counts open and closed parenthesis at each index ignoring non-parenthesis character. 
    If at any instant count of close parenthesis becomes more than open then we return false else we keep update the count variable.
     */
    // C# program to remove invalid parenthesis 


    class InvalidParantheses
    {

        // method checks if character is parenthesis(open or closed) 
        static bool isParenthesis(char c)
        {
            return (c == '(') || (c == ')');
        }

        // method returns true if string contains valid parenthesis 
        static bool isValidString(String str)
        {
            int cnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    cnt++;
                else if (str[i] == ')')
                    cnt--;
                if (cnt < 0)
                    return false;
            }
            return (cnt == 0);
        }

        // method to remove invalid parenthesis 
        static void removeInvalidParenthesis(String str)
        {
            if (str == null || str == "")
                return;

            // visit set to ignore already visited string 
            HashSet<String> visit = new HashSet<String>();

            // queue to maintain BFS 
            Queue<String> q = new Queue<String>();
            String temp;
            bool level = false;

            // pushing given string as 
            // starting node into queue 
            q.Enqueue(str);
            visit.Add(str);
            while (q.Count != 0)
            {
                str = q.Peek(); q.Dequeue();
                if (isValidString(str))
                {
                    Console.WriteLine(str);

                    // If answer is found, make level true 
                    // so that valid string of only that level 
                    // are processed. 
                    level = true;
                }

                if (level)
                    continue;
                for (int i = 0; i < str.Length; i++)
                {
                    if (!isParenthesis(str[i]))
                        continue;

                    // Removing parenthesis from str and 
                    // pushing into queue,if not visited already 
                    temp = str.Substring(0, i) +
                        str.Substring(i + 1);
                    if (!visit.Contains(temp))
                    {
                        q.Enqueue(temp);
                        visit.Add(temp);
                    }
                }
            }
        }

        // Driver Code 
        public static void Main(String[] args)
        {
            String expression = "()())()";
            removeInvalidParenthesis(expression);

            expression = "()v)";
            removeInvalidParenthesis(expression);
        }
    }

    /*
	 Output:
(())()
()()()

(v)
()v
	*/

}
