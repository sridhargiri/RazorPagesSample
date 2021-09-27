using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
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

            LinkedListProblem llist = new LinkedListProblem();
            for (int i = 5; i > 0; --i)
            {
                llist.push(i);
            }
            llist.printList();
            llist.printMiddle();
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


        /*
https://www.geeksforgeeks.org/write-a-c-function-to-print-the-middle-of-the-linked-list/
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
        /*
https://www.geeksforgeeks.org/partitioning-a-linked-list-around-a-given-value-and-keeping-the-original-order/
         Partitioning a linked list around a given value and keeping the original order
Difficulty Level : Easy
Last Updated : 05 Jun, 2021
Given a linked list and a value x, partition it such that all nodes less than x come first, then all nodes with a value equal to x, and finally nodes with a value greater than or equal to x. The original relative order of the nodes in each of the three partitions should be preserved. The partition must work in place.
Examples: 
 

Input : 1->4->3->2->5->2->3, 
        x = 3
Output: 1->2->2->3->3->4->5

Input : 1->4->2->10 
        x = 3
Output: 1->2->4->10

Input : 10->4->20->10->3 
        x = 3
Output: 3->10->4->20->10 
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
To solve this problem we can use partition method of Quick Sort but this would not preserve the original relative order of the nodes in each of the two partitions.
Below is the algorithm to solve this problem : 
 

Initialize first and last nodes of below three linked lists as NULL. 
Linked list of values smaller than x.
Linked list of values equal to x.
Linked list of values greater than x.
Now iterate through the original linked list. If a node’s value is less than x then append it at the end of the smaller list. If the value is equal to x, then at the end of the equal list. And if a value is greater, then at the end of the greater list.
Now concatenate three lists.

input: 3 Output: 2 10 4 5 30 50
Below is the implementation of the above idea. 
        */
        static Node partition_linkedlist(Node head, int x)
        {

            /* Let us initialize first and last nodes of
            three linked lists
                1) Linked list of values smaller than x.
                2) Linked list of values equal to x.
                3) Linked list of values greater than x.*/
            Node smallerHead = null, smallerLast = null;
            Node greaterLast = null, greaterHead = null;
            Node equalHead = null, equalLast = null;

            // Now iterate original list and connect nodes
            // of appropriate linked lists.
            while (head != null)
            {
                // If current node is equal to x, append it
                // to the list of x values
                if (head.data == x)
                {
                    if (equalHead == null)
                        equalHead = equalLast = head;
                    else
                    {
                        equalLast.ptr = head;
                        equalLast = equalLast.ptr;
                    }
                }

                // If current node is less than X, append
                // it to the list of smaller values
                else if (head.data < x)
                {
                    if (smallerHead == null)
                        smallerLast = smallerHead = head;
                    else
                    {
                        smallerLast.ptr = head;
                        smallerLast = head;
                    }
                }
                else // Append to the list of greater values
                {
                    if (greaterHead == null)
                        greaterLast = greaterHead = head;
                    else
                    {
                        greaterLast.ptr = head;
                        greaterLast = head;
                    }
                }
                head = head.ptr;
            }

            // Fix end of greater linked list to NULL if this
            // list has some nodes
            if (greaterLast != null)
                greaterLast.ptr = null;

            // Connect three lists

            // If smaller list is empty
            if (smallerHead == null)
            {
                if (equalHead == null)
                    return greaterHead;
                equalLast.ptr = greaterHead;
                return equalHead;
            }

            // If smaller list is not empty
            // and equal list is empty
            if (equalHead == null)
            {
                smallerLast.ptr = greaterHead;
                return smallerHead;
            }

            // If both smaller and equal list
            // are non-empty
            smallerLast.ptr = equalHead;
            equalLast.ptr = greaterHead;
            return smallerHead;
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
                Console.Write(tnode.data + "->");
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
