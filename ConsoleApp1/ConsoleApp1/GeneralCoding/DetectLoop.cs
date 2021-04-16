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
