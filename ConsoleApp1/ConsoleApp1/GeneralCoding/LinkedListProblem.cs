using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.GeneralCoding
{
    class LinkedListProblem
    {
        Node head;
        // Driver code
        public static void Main(String[] args)
        {
            /*
Check if palindrome using linkedlist
            ---------------------
METHOD 1 (Use a Stack) 

A simple solution is to use a stack of list nodes. This mainly involves three steps.
Traverse the given list from head to tail and push every visited node to stack.
Traverse the list again. For every visited node, pop a node from stack and compare data of popped node with currently visited node.
If all nodes matched, then return true, else false.
             */
            Node one = new Node(1);
            Node two = new Node(2);
            Node three = new Node(3);
            Node four = new Node(4);
            Node five = new Node(3);
            Node six = new Node(2);
            Node seven = new Node(1);

            one.ptr = two;
            two.ptr = three;
            three.ptr = four;
            four.ptr = five;
            five.ptr = six;
            six.ptr = seven;

            bool condition = isPalindrome(one);
            Console.WriteLine("isPalidrome :" + condition);

            /*
             find middle element in linked list

            Given a singly linked list, find the middle of the linked list. 
            For example, if the given linked list is 1->2->3->4->5 then the output should be 3. 
If there are even nodes, then there would be two middle nodes, we need to print the second middle element. 
            For example, if given linked list is 1->2->3->4->5->6 then output should be 4. 

            Method 1: 
Traverse the whole linked list and count the no. of nodes. Now traverse the list again till count/2 and return the node at count/2. 

Method 2: 
Traverse linked list using two pointers. 
Move one pointer by one and the other pointers by two. When the fast pointer reaches the end slow pointer will reach the middle of the linked list.

Below is method two
             */

            LinkedListProblem llist = new LinkedListProblem();
            for (int i = 5; i > 0; --i)
            {
                llist.push(i);
                llist.printList();
                llist.printMiddle();
            }
        }

        static bool isPalindrome(Node head)
        {
            Node slow = head;
            bool ispalin = true;
            Stack<int> stack = new Stack<int>();

            while (slow != null)
            {
                stack.Push(slow.data);
                slow = slow.ptr;
            }

            while (head != null)
            {
                int i = stack.Pop();
                if (head.data == i)
                {
                    ispalin = true;
                }
                else
                {
                    ispalin = false;
                    break;
                }
                head = head.ptr;
            }
            return ispalin;
        }

        /* Function to print middle of linked list */
        void printMiddle()
        {
            Node slow_ptr = head;
            Node fast_ptr = head;
            if (head != null)
            {
                while (fast_ptr != null && fast_ptr.ptr != null)
                {
                    fast_ptr = fast_ptr.ptr.ptr;
                    slow_ptr = slow_ptr.ptr;
                }
                Console.WriteLine("The middle element is [" +
                                    slow_ptr.data + "] \n");
            }
        }

        /* Inserts a new Node at front of the list. */
        public void push(int new_data)
        {
            /* 1 & 2: Allocate the Node & 
                      Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.ptr = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        /* This function prints contents of linked list 
           starting from  the given node */
        public void printList()
        {
            Node tnode = head;
            while (tnode != null)
            {
                Console.WriteLine(tnode.data + "->");
                tnode = tnode.ptr;
            }
            Console.WriteLine("NULL");
        }
    }


    class Node
    {
        public int data;
        public Node ptr;
        public Node(int d)
        {
            ptr = null;
            data = d;
        }
    }
}
