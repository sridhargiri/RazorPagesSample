using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
	 Reverse a linked list
Difficulty Level : Medium
 
Given pointer to the head node of a linked list, the task is to reverse the linked list. We need to reverse the list by changing the links between nodes.

Examples: 

Input: Head of following linked list 
1->2->3->4->NULL 
Output: Linked list should be changed to, 
4->3->2->1->NULL

Input: Head of following linked list 
1->2->3->4->5->NULL 
Output: Linked list should be changed to, 
5->4->3->2->1->NULL

Input: NULL 
Output: NULL



Input: 1->NULL 
Output: 1->NULL 
 

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Iterative Method 

Initialize three pointers prev as NULL, curr as head and next as NULL.
Iterate through the linked list. In loop, do following. 
// Before changing next of current, 
// store next node 
next = curr->next
// Now change next of current 
// This is where actual reversing happens 
curr->next = prev 
// Move prev and curr one step forward 
prev = curr 
curr = next


Below is the implementation of the above approach:

	 */
    class ReverseLinkedList
    {

        // Driver Code
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddNode(new LinkedList.Node(85));
            list.AddNode(new LinkedList.Node(15));
            list.AddNode(new LinkedList.Node(4));
            list.AddNode(new LinkedList.Node(20));

            // List before reversal
            Console.WriteLine("Given linked list:");
            list.PrintList();

            // Reverse the list
            list.ReverseList();

            // List after reversal
            Console.WriteLine("Reversed linked list:");
            list.PrintList();
        }
    }

    class LinkedList
    {
        Node head;

        public class Node
        {
            public int data;
            public Node next;

            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        // function to add a new node at
        // the end of the list
        public void AddNode(Node node)
        {
            if (head == null)
                head = node;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        // function to reverse the list
        public void ReverseList()
        {
            Node prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        // function to print the list data
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
    /*
	 Output: 

Given linked list
85 15 4 20 
Reversed Linked list 
20 4 15 85
Time Complexity: O(n) 

Space Complexity: O(1)*/

}
