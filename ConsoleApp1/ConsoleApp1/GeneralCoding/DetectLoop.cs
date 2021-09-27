using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     detect lop linked list
    https://www.geeksforgeeks.org/detect-loop-in-a-linked-list/
    */
    class DetectLoop
    {
        /*
         Solution 1: Hashing Approach:




Traverse the list one by one and keep putting the node addresses in a Hash Table. At any point, if NULL is reached then return false and if next of current node points to any of the previously stored nodes in Hash then return true
        */


        // head of list
        public Node head;

        /* Linked list Node*/
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
        // Returns true if there is a loop in linked
        // list else returns false.
        public static bool detectLoop(Node h)
        {
            HashSet<Node> s = new HashSet<Node>();
            while (h != null)
            {
                // If we have already has this node
                // in hashmap it means their is a cycle
                // (Because you we encountering the
                // node second time).
                if (s.Contains(h))
                    return true;

                // If we are seeing the node for
                // the first time, insert it in hash
                s.Add(h);

                h = h.next;
            }

            return false;
        }
        /*
         Solution 2: This problem can be solved without hashmap by modifying the linked list data-structure. 
Approach: This solution requires modifications to the basic linked list data structure. 

Have a visited flag with each node.
Traverse the linked list and keep marking visited nodes.
If you see a visited node again then there is a loop. This solution works in O(n) but requires additional information with each node.
A variation of this solution that doesn’t require modification to basic data structure can be implemented using a hash, just store the addresses of visited nodes in a hash and if you see an address that already exists in hash then there is a loop.
         */

        // Link list node
        class Node_no_constructor
        {
            public int data;
            public Node_no_constructor next;
            public int flag;
        };
        static Node_no_constructor push(Node_no_constructor head_ref, int new_data)
        {

            // Allocate node
            Node_no_constructor new_node = new Node_no_constructor();

            // Put in the data
            new_node.data = new_data;

            new_node.flag = 0;

            // Link the old list off the new node
            new_node.next = head_ref;

            // Move the head to point to the new node
            head_ref = new_node;
            return head_ref;
        }

        // Returns true if there is a loop in linked
        // list else returns false.
        static bool detectLoop_1(Node_no_constructor h)
        {
            while (h != null)
            {

                // If this node is already traverse
                // it means there is a cycle
                // (Because you we encountering the
                // node for the second time).
                if (h.flag == 1)
                    return true;

                // If we are seeing the node for
                // the first time, mark its flag as 1
                h.flag = 1;

                h = h.next;
            }
            return false;
        }
        /*
https://www.geeksforgeeks.org/detect-and-remove-loop-in-a-linked-list/
Detect and Remove Loop in a Linked List
Difficulty Level : Medium
Last Updated : 06 Sep, 2021
Write a function detectAndRemoveLoop() that checks whether a given Linked List contains loop and if loop is present then removes the loop and returns true. If the list doesn’t contain loop then it returns false. Below diagram shows a linked list with a loop. detectAndRemoveLoop() must change the below list to 1->2->3->4->5->NULL.
 

We also recommend to read following post as a prerequisite of the solution discussed here. 
Write a C function to detect loop in a linked list
Before trying to remove the loop, we must detect it. Techniques discussed in the above post can be used to detect loop. To remove loop, all we need to do is to get pointer to the last node of the loop. For example, node with value 5 in the above diagram. Once we have pointer to the last node, we can make the next of this node as NULL and loop is gone. 
We can easily use Hashing or Visited node techniques (discussed in the above mentioned post) to get the pointer to the last node. Idea is simple: the very first node whose next is already visited (or hashed) is the last node. 
We can also use Floyd Cycle Detection algorithm to detect and remove the loop. In the Floyd’s algo, the slow and fast pointers meet at a loop node. We can use this loop node to remove cycle. There are following two different ways of removing loop when Floyd’s algorithm is used for Loop detection.

Method 1 (Check one by one) We know that Floyd’s Cycle detection algorithm terminates when fast and slow pointers meet at a common point. We also know that this common point is one of the loop nodes (2 or 3 or 4 or 5 in the above diagram). Store the address of this in a pointer variable say ptr2. After that start from the head of the Linked List and check for nodes one by one if they are reachable from ptr2. Whenever we find a node that is reachable, we know that this node is the starting node of the loop in Linked List and we can get the pointer to the previous of this node.

Output:



Linked List after removing loop 
50 20 15 4 10 
Method 2 (Better Solution)  

This method is also dependent on Floyd’s Cycle detection algorithm.
Detect Loop using Floyd’s Cycle detection algorithm and get the pointer to a loop node.
Count the number of nodes in loop. Let the count be k.
Fix one pointer to the head and another to a kth node from the head.
Move both pointers at the same pace, they will meet at loop starting node.
Get a pointer to the last node of the loop and make next of it as NULL.
Thanks to WgpShashank for suggesting this method.
Below image is a dry run of ‘remove loop’ function in the code : 
        */
        // Function that detects loop in the list
        int detectAndRemoveLoop(Node node)
        {
            Node slow = node, fast = node;
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                // If slow and fast meet at same
                // point then loop is present
                if (slow == fast)
                {
                    removeLoop(slow, node);
                    return 1;
                }
            }
            return 0;
        }

        // Function to print the linked list
        void printList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }

        // Function to remove loop
        void removeLoop(Node loop, Node head)
        {
            Node ptr1 = loop;
            Node ptr2 = loop;

            // Count the number of nodes in loop
            int k = 1, i;
            while (ptr1.next != ptr2)
            {
                ptr1 = ptr1.next;
                k++;
            }

            // Fix one pointer to head
            ptr1 = head;

            // And the other pointer to k nodes after head
            ptr2 = head;
            for (i = 0; i < k; i++)
            {
                ptr2 = ptr2.next;
            }

            /* Move both pointers at the same pace, 
            they will meet at loop starting node */
            while (ptr2 != ptr1)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            // Get pointer to the last node
            while (ptr2.next != ptr1)
            {
                ptr2 = ptr2.next;
            }

            /* Set the next node of the loop ending node 
            to fix the loop */
            ptr2.next = null;
        }

        /* Driver code*/
        public static void Main(String[] args)
        {
            DetectLoop llist = new DetectLoop();

            llist.push(20);
            llist.push(4);
            llist.push(15);
            llist.push(10);

            /*Create loop for testing */
            llist.head.next.next.next.next = llist.head;

            if (detectLoop(llist.head))
                Console.WriteLine("Loop found");
            else
                Console.WriteLine("No Loop");
            /*
             Output
Loop found
Complexity Analysis:  

Time complexity: O(n). 
Only one traversal of the loop is needed.
Auxiliary Space: O(n). 

n is the space required to store the value in hashmap.
            */


            // Start with the empty list
            Node_no_constructor head = null;

            head = push(head, 20);
            head = push(head, 4);
            head = push(head, 15);
            head = push(head, 10);

            // Create a loop for testing
            head.next.next.next.next = head;

            if (detectLoop_1(head))
                Console.Write("Loop found");
            else
                Console.Write("No Loop");
            /*
             Output
Loop found
Complexity Analysis:  

Time complexity:O(n). 
Only one traversal of the loop is needed.
Auxiliary Space:O(1). 

No extra space is needed.*/
        }
    }

}
