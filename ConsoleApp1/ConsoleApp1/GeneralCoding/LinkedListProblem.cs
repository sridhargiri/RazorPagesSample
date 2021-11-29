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
    /*
     https://www.geeksforgeeks.org/sum-of-two-linked-lists/
    Add two numbers represented by linked lists | Set 2
Difficulty Level : Hard
Last Updated : 12 Oct, 2021
Given two numbers represented by two linked lists, write a function that returns the sum list. The sum list is linked list representation of the addition of two input numbers. It is not allowed to modify the lists. Also, not allowed to use explicit extra space (Hint: Use Recursion).

Example :
Input:
  First List: 5->6->3  
  Second List: 8->4->2 
Output
  Resultant list: 1->4->0->5
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
We have discussed a solution here which is for linked lists where a least significant digit is the first node of lists and the most significant digit is the last node. In this problem, the most significant node is the first node and the least significant digit is the last node and we are not allowed to modify the lists. Recursion is used here to calculate sum from right to left.



Following are the steps. 
1) Calculate sizes of given two linked lists. 
2) If sizes are same, then calculate sum using recursion. Hold all nodes in recursion call stack till the rightmost node, calculate the sum of rightmost nodes and forward carry to the left side. 
3) If size is not same, then follow below steps: 
….a) Calculate difference of sizes of two linked lists. Let the difference be diff 
….b) Move diff nodes ahead in the bigger linked list. Now use step 2 to calculate the sum of the smaller list and right sub-list (of the same size) of a larger list. Also, store the carry of this sum. 
….c) Calculate the sum of the carry (calculated in the previous step) with the remaining left sub-list of a larger list. Nodes of this sum are added at the beginning of the sum list obtained the previous step.

Below is a dry run of the above approach
     */
    public class LinkedListSum
    {
        // Function to print linked list
        void printlist(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + " ");
                head = head.ptr;
            }
        }
        void push(int val, int list)
        {
            Node newnode = new Node(val);

            if (list == 1)
            {
                newnode.ptr = head1;
                head1 = newnode;
            }
            else if (list == 2)
            {
                newnode.ptr = head2;
                head2 = newnode;
            }
            else
            {
                newnode.ptr = result;
                result = newnode;
            }

        }

        // Adds two linked lists of same size represented by
        // head1 and head2 and returns head of the resultant
        // linked list. Carry is propagated while returning
        // from the recursion
        void addsamesize(Node n, Node m)
        {

            // Since the function assumes linked
            // lists are of same size, check any
            // of the two head pointers
            if (n == null)
                return;

            // Recursively add remaining nodes
            // and get the carry
            addsamesize(n.ptr, m.ptr);

            // Add digits of current nodes
            // and propagated carry
            int sum = n.data + m.data + carry;
            carry = sum / 10;
            sum = sum % 10;

            // Push this to result list
            push(sum, 3);
        }

        Node cur;

        // This function is called after the smaller
        // list is added to the bigger lists's sublist
        // of same size. Once the right sublist is added,
        // the carry must be added to the left side of
        // larger list to get the final result.
        void propogatecarry(Node head1)
        {

            // If diff. number of nodes are
            // not traversed, add carry
            if (head1 != cur)
            {
                propogatecarry(head1.ptr);
                int sum = carry + head1.data;
                carry = sum / 10;
                sum %= 10;

                // Add this node to the front
                // of the result
                push(sum, 3);
            }
        }

        int getsize(Node head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.ptr;
            }
            return count;
        }

        // The main function that adds two linked
        // lists represented by head1 and head2.
        // The sum of two lists is stored in a
        // list referred by result
        void addlists()
        {

            // First list is empty
            if (head1 == null)
            {
                result = head2;
                return;
            }

            // Second list is empty
            if (head2 == null)
            {
                result = head1;
                return;
            }

            int size1 = getsize(head1);
            int size2 = getsize(head2);

            // Add same size lists
            if (size1 == size2)
            {
                addsamesize(head1, head2);
            }
            else
            {

                // First list should always be
                // larger than second list.
                // If not, swap pointers
                if (size1 < size2)
                {
                    Node temp = head1;
                    head1 = head2;
                    head2 = temp;
                }

                int diff = Math.Abs(size1 - size2);

                // Move diff. number of nodes in
                // first list
                Node tmp = head1;

                while (diff-- >= 0)
                {
                    cur = tmp;
                    tmp = tmp.ptr;
                }

                // Get addition of same size lists
                addsamesize(cur, head2);

                // Get addition of remaining
                // first list and carry
                propogatecarry(head1);
            }
            // If some carry is still there,
            // add a new node to the front of
            // the result list. e.g. 999 and 87
            if (carry > 0)
                push(carry, 3);
        }
        Node head1, head2, result;
        int carry;
        // Driver code
        public static void Main(string[] args)
        {
            LinkedListSum list = new LinkedListSum();
            list.head1 = null;
            list.head2 = null;
            list.result = null;
            list.carry = 0;

            int[] arr1 = { 9, 9, 9 };
            int[] arr2 = { 1, 8 };

            // Create first list as 9->9->9
            for (int i = arr1.Length - 1; i >= 0; --i)
                list.push(arr1[i], 1);

            // Create second list as 1->8
            for (int i = arr2.Length - 1; i >= 0; --i)
                list.push(arr2[i], 2);

            list.addlists();

            list.printlist(list.result);
            /*
             Output
1 0 1 7
Time Complexity: O(m+n) where m and n are the sizes of given two linked lists.
            */
        }
    }
    public class LinkedListDeleteAltNode
    {
        Node head;
        /// <summary>
        /// iterative method
        /// </summary>
        void deleteAlt()
        {
            if (head == null)
                return;

            Node prev = head;
            Node now = head.ptr;

            while (prev != null && now != null)
            {
                /* Change next link of previous node */
                prev.ptr = now.ptr;

                /* Free node */
                now = null;

                /*Update prev and now */
                prev = prev.ptr;
                if (prev != null)
                    now = prev.ptr;
            }
        }
        /// <summary>
        /// recursive method time complexity O(n)
        /// </summary>
        Node deleteAlt(Node head)
        {
            if (head == null)
                return null;

            Node node = head.ptr;

            if (node == null)
                return null;

            /* Change the next link of head */
            head.ptr = node.ptr;


            /* Recursively call for the new next of head */
            head.ptr = deleteAlt(head.ptr);
            return head.ptr;
        }

        /* Utility functions */

        /* Inserts a new Node at front of the list. */
        void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
                    Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.ptr = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }
        void printList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.ptr;
            }
            Console.WriteLine();
        }

        /* Driver code*/
        public static void Main(String[] args)
        {
            LinkedListDeleteAltNode llist = new LinkedListDeleteAltNode();

            /* Constructed Linked List is
            1->2->3->4->5->null */
            llist.push(5);
            llist.push(4);
            llist.push(3);
            llist.push(2);
            llist.push(1);

            Console.WriteLine("Linked List before" +
                                "calling deleteAlt() ");
            llist.printList();

            llist.deleteAlt();

            Console.WriteLine("Linked List after" +
                                "calling deleteAlt() ");
            llist.printList();
            /*
output
List before calling deleteAlt() 
1 2 3 4 5 
List after calling deleteAlt() 
1 3 5 
Time Complexity: O(n) where n is the number of nodes in the given Linked List.
            */
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
