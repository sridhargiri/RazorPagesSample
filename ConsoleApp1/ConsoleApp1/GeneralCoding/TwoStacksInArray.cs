using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/implement-two-stacks-in-an-array/
    Implement two Stacks in an Array
    Create a data structure twoStacks that represent two stacks. Implementation of twoStacks should use only one array, 
    i.e., both stacks should use the same array for storing elements. 
    Following functions must be supported by twoStacks.

push1(int x) –> pushes x to first stack 
push2(int x) –> pushes x to second stack
pop1() –> pops an element from first stack and return the popped element 
pop2() –> pops an element from second stack and return the popped element
Implementation of twoStack should be space efficient.
    Implement two stacks in an array by Dividing the space into two halves:
The idea to implement two stacks is to divide the array into two halves and assign two halves to two stacks, 
    i.e., use arr[0] to arr[n/2] for stack1, and arr[(n/2) + 1] to arr[n-1] for stack2 where arr[] is the array to be used to implement two stacks and size of array be n. 
    Follow the steps below to solve the problem:

To implement push1():
First, check whether the top1 is greater than 0 
If it is then add an element at the top1 index and decrement top1 by 1
Else return Stack Overflow
To implement push2():
First, check whether top2 is less than n – 1
If it is then add an element at the top2 index and increment the top2 by 1
Else return Stack Overflow
To implement pop1():
First, check whether the top1 is less than or equal to n / 2
If it is then increment the top1 by 1 and return that element.
Else return Stack Underflow
To implement pop2():
First, check whether the top2 is greater than or equal to (n + 1) / 2
If it is then decrement the top2 by 1 and return that element.
Else return Stack Underflow
Below is the implementation of the above approach
     */
    public class TwoStacks
    {
        public int[] arr;
        public int size;
        public int top1, top2;

        // Constructor
        public TwoStacks(int n)
        {
            size = n;
            arr = new int[n];
            top1 = n / 2 + 1;
            top2 = n / 2;
        }

        // Method to push an element x to stack1
        public void push1(int x)
        {

            // There is at least one empty
            // space for new element
            if (top1 > 0)
            {
                top1--;
                arr[top1] = x;
            }
            else
            {
                Console.Write("Stack Overflow"
                              + " By element : " + x + "\n");
                return;
            }
        }

        // Method to push an element
        // x to stack2
        public void push2(int x)
        {

            // There is at least one empty
            // space for new element
            if (top2 < size - 1)
            {
                top2++;
                arr[top2] = x;
            }
            else
            {
                Console.Write("Stack Overflow"
                              + " By element : " + x + "\n");
                return;
            }
        }

        // Method to pop an element from first stack
        public int pop1()
        {
            if (top1 <= size / 2)
            {
                int x = arr[top1];
                top1++;
                return x;
            }
            else
            {
                Console.Write("Stack UnderFlow");
            }
            return 0;
        }

        // Method to pop an element
        // from second stack
        public int pop2()
        {
            if (top2 >= size / 2 + 1)
            {
                int x = arr[top2];
                top2--;
                return x;
            }
            else
            {
                Console.Write("Stack UnderFlow");
            }
            return 1;
        }
    };

    public class TwoStacksInArray
    {

        /* Driver program to test twoStacks class */
        public static void Main(String[] args)
        {
            TwoStacks ts = new TwoStacks(5);
            ts.push1(5);
            ts.push2(10);
            ts.push2(15);
            ts.push1(11);
            ts.push2(7);
            Console.Write("Popped element from stack1 is "
                          + ": " + ts.pop1() + "\n");
            ts.push2(40);
            Console.Write("Popped element from stack2 is "
                          + ": " + ts.pop2() + "\n");
            /*
             Output
    Stack Overflow By element : 7
    Popped element from stack1 is : 11
    Stack Overflow By element : 40
    Popped element from stack2 is : 15
    Time Complexity: 

    Push operation: O(1)
    Pop operation: O(1)
    Auxiliary Space: O(N), Use of array to implement stack.
            */
        }
    }
    /*
     Implement two stacks in an array by Starting from endpoints:
The idea is to start two stacks from two extreme corners of arr[]. 

Follow the steps below to solve the problem:

Stack1 starts from the leftmost element, the first element in stack1 is pushed at index 0. 
Stack2 starts from the rightmost corner, the first element in stack2 is pushed at index (n-1). 
Both stacks grow (or shrink) in opposite directions. 
To check for overflow, all we need to check is for space between top elements of both stacks.
Below is the implementation of above approach:
    */
    public class TwoStacksInArrayEndpoints
    {
        public int size;
        public int top1, top2;
        public int[] arr;

        // Constructor
        public TwoStacksInArrayEndpoints(int n)
        {
            arr = new int[n];
            size = n;
            top1 = -1;
            top2 = size;
        }

        // Method to push an element x to stack1
        public virtual void push1(int x)
        {
            // There is at least one empty
            // space for new element
            if (top1 < top2 - 1)
            {
                top1++;
                arr[top1] = x;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
                Environment.Exit(1);
            }
        }

        // Method to push an element x to stack2
        public virtual void push2(int x)
        {
            // There is at least one empty
            // space for new element
            if (top1 < top2 - 1)
            {
                top2--;
                arr[top2] = x;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
                Environment.Exit(1);
            }
        }

        // Method to pop an element
        // from first stack
        public virtual int pop1()
        {
            if (top1 >= 0)
            {
                int x = arr[top1];
                top1--;
                return x;
            }
            else
            {
                Console.WriteLine("Stack Underflow");
                Environment.Exit(1);
            }
            return 0;
        }

        // Method to pop an element
        // from second stack
        public virtual int pop2()
        {
            if (top2 < size)
            {
                int x = arr[top2];
                top2++;
                return x;
            }
            else
            {
                Console.WriteLine("Stack Underflow");
                Environment.Exit(1);
            }
            return 0;
        }

        // Driver Code
        public static void Main(string[] args)
        {
            TwoStacksInArrayEndpoints ts = new TwoStacksInArrayEndpoints(5);
            ts.push1(5);
            ts.push2(10);
            ts.push2(15);
            ts.push1(11);
            ts.push2(7);
            Console.WriteLine("Popped element from"
                              + " stack1 is " + ts.pop1());
            ts.push2(40);
            Console.WriteLine("Popped element from"
                              + " stack2 is " + ts.pop2());
            /*
             Output
Popped element from stack1 is 11
Popped element from stack2 is 40
Time Complexity: 

Push operation: O(1)
Pop operation: O(1)
Auxiliary Space: O(N), Use of the array to implement stack
            */
        }
    }
}
