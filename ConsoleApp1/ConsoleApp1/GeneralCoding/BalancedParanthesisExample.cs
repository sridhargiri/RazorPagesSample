using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BalancedParan
    {
        public class stack
        {
            public int top = -1;
            public char[] items = new char[100];

            public void push(char x)
            {
                if (top == 99)
                {
                    Console.WriteLine("Stack full");
                }
                else
                {
                    items[++top] = x;
                }
            }

            char pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Underflow error");
                    return '\0';
                }
                else
                {
                    char element = items[top];
                    top--;
                    return element;
                }
            }

            Boolean isEmpty()
            {
                return (top == -1) ? true : false;
            }
        }

        // Returns true if character1 and character2 
        // are matching left and right Parenthesis */ 
        static Boolean isMatchingPair(char character1,
                                      char character2)
        {
            if (character1 == '(' && character2 == ')')
                return true;
            else if (character1 == '{' && character2 == '}')
                return true;
            else if (character1 == '[' && character2 == ']')
                return true;
            else
                return false;
        }

        // Return true if expression has balanced 
        // Parenthesis  
        static Boolean areParenthesisBalanced(char[] exp)
        {
            // Declare an empty character stack */ 
            Stack<char> st = new Stack<char>();

            // Traverse the given expression to 
            //   check matching parenthesis 
            for (int i = 0; i < exp.Length; i++)
            {
                // If the exp[i] is a starting 
                // parenthesis then push it 
                if (exp[i] == '{' || exp[i] == '('
                    || exp[i] == '[')
                    st.Push(exp[i]);

                //  If exp[i] is an ending parenthesis 
                //  then pop from stack and check if the 
                //   popped parenthesis is a matching pair 
                if (exp[i] == '}' || exp[i] == ')'
                    || exp[i] == ']')
                {

                    // If we see an ending parenthesis without 
                    //   a pair then return false 
                    if (st.Count == 0)
                    {
                        return false;
                    }

                    // Pop the top element from stack, if 
                    // it is not a pair parenthesis of 
                    // character then there is a mismatch. This 
                    // happens for expressions like {(}) 
                    else if (!isMatchingPair(st.Pop(),
                                             exp[i]))
                    {
                        return false;
                    }
                }
            }

            // If there is something left in expression 
            // then there is a starting parenthesis without 
            // a closing parenthesis  

            if (st.Count == 0)
                return true; // balanced 
            else
            { // not balanced 
                return false;
            }
        }


        // Driver code 
        public static void Main(String[] args)
        {
            char[] exp = { '{', '(', ')', '}', '[', ']' };

            // Function call 
            if (areParenthesisBalanced(exp))
                Console.WriteLine("Balanced ");
            else
                Console.WriteLine("Not Balanced ");
        }
    }

    /*
     https://www.geeksforgeeks.org/maximum-balanced-string-partitions/
    Maximum Balanced String Partitions
Last Updated : 20 Jul, 2021
Given a balanced string str of size N with an equal number of L and R, the task is to find a maximum number X, such that a given string can be partitioned into X balanced substring. A string called to be balanced if the number of ‘L’s in the string equals the number of ‘R’s. 
Examples: 
 

Input : str = “LRLLRRLRRL” 
Output : 4 
Explanation: { “LR”, “LLRR”, “LR”, “RL”} are the possible partitions.
Input : “LRRRRLLRLLRL” 
Output : 3 
Explanation: {“LR”, “RRRLLRLL”, “RL”} are the possible partitions. 
 

 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The approach to solving this problem is to loop through the string and keep incrementing the count of L and R whenever encountered. Any instant when the respective counts of L and R become equal, a balanced parenthesis is formed. Thus the count of such instances gives the desired maximum possible partitions.
Below is the implementation of the above approach:
     */
    public class BalancedPartition
    {

        // Function to find a maximum number X, such
        // that a given String can be partitioned
        // into X subStrings that are each balanced
        static int MaxBalancedPartition(string str, int n)
        {

            // If the size of the String is 0,
            // then answer is zero
            if (n == 0)
                return 0;

            // Variable that represents the
            // number of 'R's and 'L's
            int r = 0, l = 0;

            // To store maximum number of
            // possible partitions
            int ans = 0;
            for (int i = 0; i < n; i++)
            {

                // Increment the variable r if the
                // character in the String is 'R'
                if (str[i] == 'R')
                {
                    r++;
                }

                // Increment the variable l if the
                // character in the String is 'L'
                else if (str[i] == 'L')
                {
                    l++;
                }

                // If r and l are equal,
                // then increment ans
                if (r == l)
                {
                    ans++;
                }
            }

            // Return the required answer
            return ans;
        }

        // Driver code
        public static void Main()
        {
            string str = "LLRRRLLRRL";
            int n = str.Length;

            // Function call
            Console.Write(MaxBalancedPartition(str, n) + "\n");
            /*
             Output 4
Time Complexity: O(N) 
Space Complexity: O(1)*/
        }
    }
}
