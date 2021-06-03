using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/next-greater-element/
     Next Greater Element
Difficulty Level : Medium
Last Updated : 31 May, 2021
Given an array, print the Next Greater Element (NGE) for every element. The Next greater Element for an element x is the first greater element on the right side of x in the array. Elements for which no greater element exist, consider the next greater element as -1. 

Examples: 

For an array, the rightmost element always has the next greater element as -1.
For an array that is sorted in decreasing order, all elements have the next greater element as -1.
For the input array [4, 5, 2, 25], the next greater elements for each element are as follows.
Element       NGE
   4      -->   5
   5      -->   25
   2      -->   25
   25     -->   -1
d) For the input array [13, 7, 6, 12}, the next greater elements for each element are as follows.  

  Element        NGE
   13      -->    -1
   7       -->     12
   6       -->     12
   12      -->     -1
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
Method 1 (Simple) 
Use two loops: The outer loop picks all the elements one by one. The inner loop looks for the first greater element for the element picked by the outer loop. If a greater element is found then that element is printed as next, otherwise, -1 is printed.

Below is the implementation of the above approach:
    */
    class NextGreaterElement
    {

        /* prints element and NGE pair for
        all elements of arr[] of size n */
        static void printNGE(int[] arr, int n)
        {
            int next, i, j;
            for (i = 0; i < n; i++)
            {
                next = -1;
                for (j = i + 1; j < n; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        next = arr[j];
                        break;
                    }
                }
                Console.WriteLine(arr[i] + " -- " + next);
            }
        }

        // driver code
        public static void Main()
        {
            int[] arr = { 11, 13, 21, 3 };
            int n = arr.Length;

            printNGE(arr, n);
            /*
             Output
11 -- 13
13 -- 21
21 -- -1
3 -- -1
Time Complexity: O(N2) 
Auxiliary Space: O(1)
            */
        }
    }
    /*
     Method 2 (Using Stack) 

Push the first element to stack.
Pick rest of the elements one by one and follow the following steps in loop. 
Mark the current element as next.
If stack is not empty, compare top element of stack with next.
If next is greater than the top element, Pop element from stack. next is the next greater element for the popped element.
Keep popping from the stack while the popped element is smaller than next. next becomes the next greater element for all such popped elements.
Finally, push the next in the stack.
After the loop in step 2 is over, pop all the elements from the stack and print -1 as the next element for them.
Below image is a dry run of the above approach: 



Below is the implementation of the above approach: 
    */
    public class NextGreater
    {
        public class stack
        {
            public int top;
            public int[] items = new int[100];

            // Stack functions to be used by printNGE
            public virtual void push(int x)
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

            public virtual int pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Underflow error");
                    return -1;
                }
                else
                {
                    int element = items[top];
                    top--;
                    return element;
                }
            }

            public virtual bool Empty
            {
                get { return (top == -1) ? true : false; }
            }
        }

        /* prints element and NGE pair for
           all elements of arr[] of size n */
        public static void printNGE(int[] arr, int n)
        {
            int i = 0;
            stack s = new stack();
            s.top = -1;
            int element, next;

            /* push the first element to stack */
            s.push(arr[0]);

            // iterate for rest of the elements
            for (i = 1; i < n; i++)
            {
                next = arr[i];

                if (s.Empty == false)
                {

                    // if stack is not empty, then
                    // pop an element from stack
                    element = s.pop();

                    /* If the popped element is smaller than
                       next, then a) print the pair b) keep
                       popping while elements are smaller and
                       stack is not empty */
                    while (element < next)
                    {
                        Console.WriteLine(element + " --> "
                                          + next);
                        if (s.Empty == true)
                        {
                            break;
                        }
                        element = s.pop();
                    }

                    /* If element is greater than next, then
                       push the element back */
                    if (element > next)
                    {
                        s.push(element);
                    }
                }

                /* push next to stack so that we can find next
                   greater for it */
                s.push(next);
            }

            /* After iterating over the loop, the remaining
               elements in stack do not have the next greater
               element, so print -1 for them */
            while (s.Empty == false)
            {
                element = s.pop();
                next = -1;
                Console.WriteLine(element + " -- " + next);
            }
        }

        // Driver Code
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 11, 13, 21, 3 };
            int n = arr.Length;
            printNGE(arr, n);
            /*
             Output
11 --> 13
13 --> 21
3 --> -1
21 --> -1
Time Complexity: O(N) 
Auxiliary Space: O(N)
            */
        }
    }
}
