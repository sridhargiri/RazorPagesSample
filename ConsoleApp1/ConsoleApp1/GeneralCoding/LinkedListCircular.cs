using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Given a singly linked list, find if the linked list is circular or not. 
    A linked list is called circular if it is not NULL-terminated and all nodes are connected in the form of a cycle. 
    Below is an example of a circular linked list.

    An empty linked list is considered as circular.
Note that this problem is different from cycle detection problem, here all nodes have to be part of cycle.
    
The idea is to store head of the linked list and traverse it. If we reach NULL, linked list is not circular. 
    If reach head again, linked list is circular. 
    
     */
    public class LinkedListCircular
    {

        /* Link list Node */
        public class Node
        {
            public int data;
            public Node next;
        }

        /*This function returns true if given linked 
		list is circular, else false. */
        static bool isCircular(Node head)
        {
            // An empty linked list is circular 
            if (head == null)
                return true;

            // Next of head 
            Node node = head.next;

            // This loop would stop in both cases (1) If 
            // Circular (2) Not circular 
            while (node != null && node != head)
                node = node.next;

            // If loop stopped because of circular 
            // condition 
            return (node == head);
        }

        // Utility function to create a new node. 
        static Node newNode(int data)
        {
            Node temp = new Node();
            temp.data = data;
            temp.next = null;
            return temp;
        }

        /* Driver code*/
        public static void Main(String[] args)
        {
            /* Start with the empty list */
            Node head = newNode(1);
            head.next = newNode(2);
            head.next.next = newNode(3);
            head.next.next.next = newNode(4);

            Console.Write(isCircular(head) ? "Yes\n" :
                            "No\n");

            // Making linked list circular 
            head.next.next.next.next = head;

            Console.Write(isCircular(head) ? "Yes\n" :
                            "No\n");

        }
    }
    // This code has been contributed by 29AjayKumar 

}
