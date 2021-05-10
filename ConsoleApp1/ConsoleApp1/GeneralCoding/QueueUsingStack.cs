using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/queue-using-stacks/
Queue using Stacks
Difficulty Level : Medium
Last Updated : 09 Nov, 2020
The problem is opposite of this post. We are given a stack data structure with push and pop operations, the task is to implement a queue using instances of stack data structure and operations on them.

Stack and Queue with insert and delete operations

A queue can be implemented using two stacks. Let queue to be implemented be q and stacks used to implement q be stack1 and stack2. q can be implemented in two ways:

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.


Method 1 (By making enQueue operation costly) This method makes sure that oldest entered element is always at the top of stack 1, so that deQueue operation just pops from stack1. To put the element at top of stack1, stack2 is used.

enQueue(q, x):



While stack1 is not empty, push everything from stack1 to stack2.
Push x to stack1 (assuming size of stacks is unlimited).
Push everything back to stack1.
Here time complexity will be O(n)

deQueue(q):

If stack1 is empty then error
Pop an item from stack1 and return it
Here time complexity will be O(1)

Below is the implementation of the above approach:
    */
    class QueueUsingStack
    {

        public class Queue
        {
            public Stack<int> s1 = new Stack<int>();
            public Stack<int> s2 = new Stack<int>();

            public void enQueue(int x)
            {
                // Move all elements from s1 to s2 
                while (s1.Count > 0)
                {
                    s2.Push(s1.Pop());
                    //s1.Pop(); 
                }

                // Push item into s1 
                s1.Push(x);

                // Push everything back to s1 
                while (s2.Count > 0)
                {
                    s1.Push(s2.Pop());
                    //s2.Pop(); 
                }
            }

            // Dequeue an item from the queue 
            public int deQueue()
            {
                // if first stack is empty 
                if (s1.Count == 0)
                {
                    Console.WriteLine("Q is Empty");

                }

                // Return top of s1 
                int x = (int)s1.Peek();
                s1.Pop();
                return x;
            }
        };

        // Driver code 
        public static void Main()
        {
            Queue q = new Queue();
            q.enQueue(1);
            q.enQueue(2);
            q.enQueue(3);

            Console.Write(q.deQueue() + " ");
            Console.Write(q.deQueue() + " ");
            Console.Write(q.deQueue());
        }
        /*
         Output:
    1
    2
    3

    Complexity Analysis:

    Time Complexity:
    Push operation: O(N).
    In the worst case we have empty whole of stack 1 into stack 2.
    Pop operation: O(1).
    Same as pop operation in stack.
    Auxiliary Space: O(N).

    Use of stack for storing values
        */
    }
    /*
     Method 2 (By making deQueue operation costly)In this method, in en-queue operation, the new element is entered at the top of stack1. In de-queue operation, if stack2 is empty then all the elements are moved to stack2 and finally top of stack2 is returned.



enQueue(q,  x)
  1) Push x to stack1 (assuming size of stacks is unlimited).
Here time complexity will be O(1)

deQueue(q)
  1) If both stacks are empty then error.
  2) If stack2 is empty
       While stack1 is not empty, push everything from stack1 to stack2.
  3) Pop the element from stack2 and return it.
Here time complexity will be O(n)
Method 2 is definitely better than method 1.
Method 1 moves all the elements twice in enQueue operation, while method 2 (in deQueue operation) moves the elements once and moves elements only if stack2 empty. So, the amortized complexity of the dequeue operation becomes  \Theta (1) .
Implementation of method 2:
    */
    public class QueueUsingStackEff
    {
        /* class of queue having two stacks */
        public class Queue
        {
            public Stack<int> stack1;
            public Stack<int> stack2;
        }

        /* Function to push an item to stack*/
        static void push(Stack<int> top_ref, int new_data)
        {
            // Push the data onto the stack
            top_ref.Push(new_data);
        }

        /* Function to pop an item from stack*/
        static int pop(Stack<int> top_ref)
        {
            /*If stack is empty then error */
            if (top_ref.Count == 0)
            {
                Console.WriteLine("Stack Underflow");
                Environment.Exit(0);
            }

            // pop the data from the stack
            return top_ref.Pop();
        }

        // Function to enqueue an item to the queue
        static void enQueue(Queue q, int x)
        {
            push(q.stack1, x);
        }

        /* Function to deQueue an item from queue */
        static int deQueue(Queue q)
        {
            int x;

            /* If both stacks are empty then error */
            if (q.stack1.Count == 0 && q.stack2.Count == 0)
            {
                Console.WriteLine("Q is empty");
                Environment.Exit(0);
            }

            /* Move elements from stack1 to stack 2 only if
            stack2 is empty */
            if (q.stack2.Count == 0)
            {
                while (q.stack1.Count != 0)
                {
                    x = pop(q.stack1);
                    push(q.stack2, x);
                }
            }
            x = pop(q.stack2);
            return x;
        }

        /* Driver code */
        public static void Main(String[] args)
        {
            /* Create a queue with items 1 2 3*/
            Queue q = new Queue();
            q.stack1 = new Stack<int>();
            q.stack2 = new Stack<int>();
            enQueue(q, 1);
            enQueue(q, 2);
            enQueue(q, 3);

            /* Dequeue items */
            Console.Write(deQueue(q) + " ");
            Console.Write(deQueue(q) + " ");
            Console.WriteLine(deQueue(q) + " ");
            /*
             Output:
1 2 3 
Complexity Analysis:

Time Complexity:
Push operation: O(1).
Same as pop operation in stack.
Pop operation: O(N).
In the worst case we have empty whole of stack 1 into stack 2
Auxiliary Space: O(N).
Use of stack for storing values
            */
        }
    }
}
