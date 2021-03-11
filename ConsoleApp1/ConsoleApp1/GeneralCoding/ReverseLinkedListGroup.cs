using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Reverse a Linked List in groups of given size | Set 1
Difficulty Level : Medium
 Last Updated : 05 Feb, 2021
Given a linked list, write a function to reverse every k nodes (where k is an input to the function). 
https://www.geeksforgeeks.org/reverse-a-list-in-groups-of-given-size/
Example: 

Input: 1->2->3->4->5->6->7->8->NULL, K = 3 
Output: 3->2->1->6->5->4->8->7->NULL 
Input: 1->2->3->4->5->6->7->8->NULL, K = 5 
Output: 5->4->3->2->1->8->7->6->NULL 

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Algorithm: reverse(head, k) 

Reverse the first sub-list of size k. While reversing keep track of the next node and previous node. Let the pointer to the next node be next and pointer to the previous node be prev. See this post for reversing a linked list.
head->next = reverse(next, k) ( Recursively call for rest of the list and link the two sub-lists )
Return prev ( prev becomes the new head of the list (see the diagrams of iterative method of this post) )
Below is image shows how the reverse function works: 






Below is the implementation of the above approach:
    */
    public class ReverseLinkedListGroup
    {
        Node head; // head of list

        /* Linked list Node*/
        class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        Node reverse(Node head, int k)
        {
            if (head == null)
                return null;
            Node current = head;
            Node next = null;
            Node prev = null;

            int count = 0;

            /* Reverse first k nodes of linked list */
            while (count < k && current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                count++;
            }

            /* next is now a pointer to (k+1)th node
				Recursively call for the list starting from
			current. And make rest of the list as next of
			first node */
            if (next != null)
                head.next = reverse(next, k);

            // prev is now head of input list
            return prev;
        }

        /* Utility functions */

        /* Inserts a new Node at front of the list. */
        public void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
					Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        /* Function to print linked list */
        void printList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        /* Driver code*/
        public static void Main(String[] args)
        {
            ReverseLinkedListGroup llist = new ReverseLinkedListGroup();

            /* Constructed Linked List is 1->2->3->4->5->6->
			7->8->8->9->null */
            llist.push(9);
            llist.push(8);
            llist.push(7);
            llist.push(6);
            llist.push(5);
            llist.push(4);
            llist.push(3);
            llist.push(2);
            llist.push(1);

            Console.WriteLine("Given Linked List");
            llist.printList();

            llist.head = llist.reverse(llist.head, 3);

            Console.WriteLine("Reversed list");
            llist.printList();
        }
    }
    /*
	 Output: 

	Given Linked List
	1 2 3 4 5 6 7 8 9 
	Reversed list
	3 2 1 6 5 4 9 8 7 
	Complexity Analysis: 

	Time Complexity: O(n). 
	Traversal of list is done only once and it has ‘n’ elements.
	Auxiliary Space: O(n/k). 
	For each Linked List of size n, n/k or (n/k)+1 calls will be made during the recursion.
	*/
}
