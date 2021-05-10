using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //https://www.geeksforgeeks.org/implement-stack-using-queue/
    /*
     Implement Stack using Queues
Difficulty Level : Easy
Last Updated : 19 Aug, 2019
The problem is opposite of this post. We are given a Queue data structure that supports standard operations like enqueue() and dequeue(). We need to implement a Stack data structure using only instances of Queue and queue operations allowed on the instances.

Stack and Queue with insert and delete operations

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.


A stack can be implemented using two queues. Let stack to be implemented be ‘s’ and queues used to implement be ‘q1’ and ‘q2’. Stack ‘s’ can be implemented in two ways:

Method 1 (By making push operation costly)
This method makes sure that newly entered element is always at the front of ‘q1’, so that pop operation just dequeues from ‘q1’. ‘q2’ is used to put every new element at front of ‘q1’.

push(s, x) operation’s step are described below:
Enqueue x to q2
One by one dequeue everything from q1 and enqueue to q2.
Swap the names of q1 and q2
pop(s) operation’s function are described below:
Dequeue an item from q1 and return it.
Below is the implementation of the above approach:
    */
    class StackUsingQueue
    {

        public class Stack
        {
            // Two inbuilt queues
            public Queue<int> q1 = new Queue<int>();
            public Queue<int> q2 = new Queue<int>();

            // To maintain current number of
            // elements
            public int curr_size;

            public Stack()
            {
                curr_size = 0;
            }

            public void push(int x)
            {
                curr_size++;

                // Push x first in empty q2
                q2.Enqueue(x);

                // Push all the remaining
                // elements in q1 to q2.
                while (q1.Count > 0)
                {
                    q2.Enqueue(q1.Peek());
                    q1.Dequeue();
                }

                // swap the names of two queues
                Queue<int> q = q1;
                q1 = q2;
                q2 = q;
            }

            public void pop()
            {

                // if no elements are there in q1
                if (q1.Count == 0)
                    return;
                q1.Dequeue();
                curr_size--;
            }

            public int top()
            {
                if (q1.Count == 0)
                    return -1;
                return (int)q1.Peek();
            }

            public int size()
            {
                return curr_size;
            }
        };

        // Driver code
        public static void Main(String[] args)
        {
            Stack s = new Stack();
            s.push(1);
            s.push(2);
            s.push(3);
            Console.WriteLine("current size: " + s.size());
            Console.WriteLine(s.top());
            s.pop();
            Console.WriteLine(s.top());
            s.pop();
            Console.WriteLine(s.top());
            Console.WriteLine("current size: " + s.size());
            /*
             Output :
current size: 3
3
2
1
current size: 1
            */
        }
    }
    /*
     Method 2 (By making pop operation costly)
In push operation, the new element is always enqueued to q1. In pop() operation, if q2 is empty then all the elements except the last, are moved to q2. Finally the last element is dequeued from q1 and returned.

push(s, x) operation:
Enqueue x to q1 (assuming size of q1 is unlimited).
pop(s) operation:
One by one dequeue everything except the last element from q1 and enqueue to q2.
Dequeue the last item of q1, the dequeued item is result, store it.
Swap the names of q1 and q2
Return the item stored in step 2.
    */
    public class StackUsingQueueEff
    {
        public class Stack
        {
            public Queue<int> q1 = new Queue<int>();
            public Queue<int> q2 = new Queue<int>();
            //Just enqueue the new element to q1 
            public void Push(int x) => q1.Enqueue(x);

            //move all elements from q1 to q2 except the rear of q1. 
            //Store the rear of q1 
            //swap q1 and q2 
            //return the stored result 
            public int Pop()
            {
                if (q1.Count == 0)
                    return -1;
                while (q1.Count > 1)
                {
                    q2.Enqueue(q1.Dequeue());
                }
                int res = (int)q1.Dequeue();
                Queue<int> temp = q1;
                q1 = q2;
                q2 = temp;
                return res;
            }

            public int Size() => q1.Count;

            public int Top()
            {
                if (q1.Count == 0)
                    return -1;
                while (q1.Count > 1)
                {
                    q2.Enqueue(q1.Dequeue());
                }
                int res = (int)q1.Dequeue();
                q2.Enqueue(res);
                Queue<int> temp = q1;
                q1 = q2;
                q2 = temp;
                return res;
            }
        };
        public static void Main(String[] args)
        {
            Stack s = new Stack();
            s.Push(1);
            Console.WriteLine("Size of Stack: " + s.Size() + "\tTop : " + s.Top());
            s.Push(7);
            Console.WriteLine("Size of Stack: " + s.Size() + "\tTop : " + s.Top());
            s.Push(9);
            Console.WriteLine("Size of Stack: " + s.Size() + "\tTop : " + s.Top());

            s.Pop();
            Console.WriteLine("Size of Stack: " + s.Size() + "\tTop : " + s.Top());
            s.Pop();
            Console.WriteLine("Size of Stack: " + s.Size() + "\tTop : " + s.Top());

            s.Push(5);
            Console.WriteLine("Size of Stack: " + s.Size() + "\tTop : " + s.Top());
            /*
             Output :

current size: 4
4
3
2
current size: 2
            */
        }
    }
}
