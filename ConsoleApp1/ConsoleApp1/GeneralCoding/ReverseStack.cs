using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/reversing-a-stack-with-the-help-of-another-empty-stack/
    Reversing a Stack with the help of another empty Stack
Difficulty Level : Easy
Last Updated : 03 May, 2021
Given a Stack consisting of N elements, the task is to reverse the Stack using an extra stack.

Examples:

Input: stack = {1, 2, 3, 4, 5}
Output:
1
2
3
4
5
Explanation:
Input Stack:
5
4
3
2
1
Reversed Stack:
1
2
3
4
5

Input: stack = {1, 3, 5, 4, 2}
Output:
1
3
5
4
2

Approach: Follow the steps below to solve the problem:



Initialize an empty stack.
Pop the top element of the given stack S and store it in a temporary variable.
Transfer all the elements of the given stack to the stack initialized above.
Push the temporary variable into the original stack.
Transfer all the elements present in the new stack into the original stack.
Below is the implementation of the above approach
     */
    class ReverseStack
    {
        static void transfer(Stack<int> s1,
              Stack<int> s2, int n)
        {
            for (int i = 0; i < n; i++)
            {

                // Store the top element
                // in a temporary variable
                int temp = s1.Peek();

                // Pop out of the stack
                s1.Pop();

                // Push it into s2
                s2.Push(temp);
            }
        }

        // Function to reverse a stack using another stack
        static void reverse_stack_by_using_extra_stack(Stack<int> s, int n)
        {
            Stack<int> s2 = new Stack<int>();

            for (int i = 0; i < n; i++)
            {

                // Store the top element
                // of the given stack
                int x = s.Peek();

                // Pop that element
                // out of the stack
                s.Pop();

                transfer(s, s2, n - i - 1);
                s.Push(x);
                transfer(s2, s, n - i - 1);
            }
        }
        static void Main(string[] args)
        {

            int n = 5;

            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            reverse_stack_by_using_extra_stack(s, n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(s.Peek() + " ");
                s.Pop();
            }
            /*
             Output:
1 2 3 4 5
Time Complexity: O(N2)
Auxiliary Space: O(N)
            */
        }
    }
}
