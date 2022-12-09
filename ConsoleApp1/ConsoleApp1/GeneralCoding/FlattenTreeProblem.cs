using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/flatten-binary-tree-in-order-of-post-order-traversal/
    Flatten binary tree in order of post-order traversal
    Given a binary tree, the task is to flatten it in order of its post-order traversal. In the flattened binary tree, the left node of all the nodes must be NULL.

Examples: 

Input: 
          5 
        /   \ 
       3     7 
      / \   / \ 
     2   4 6   8
Output: 2 4 3 6 8 7 5

Input:
      1
       \
        2
         \
          3
           \
            4
             \
              5
Output: 5 4 3 2 1

A simple approach will be to recreate the Binary Tree from its post-order traversal. This will take O(N) extra space were N is the number of nodes in BST.

A better solution is to simulate post-order traversal of the given binary tree.  


Create a dummy node.
Create variable called ‘prev’ and make it point to the dummy node.
Perform post-order traversal and at each step. 
Set prev -> right = curr
Set prev -> left = NULL
Set prev = curr
This will improve the space complexity to O(H) in the worst case as post-order traversal takes O(H) extra space.

Below is the implementation of the above approach:  
     */
    public class FlattenTreeProblem
    {

        // Node of the binary tree
        public class node
        {
            public int data;
            public node left;
            public node right;
            public node(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        };
        static node prev;

        // Function to print the flattened
        // binary Tree
        static void print(node parent)
        {
            node curr = parent;
            while (curr != null)
            {
                Console.Write(curr.data + " ");
                curr = curr.right;
            }
        }

        // Function to perform post-order traversal
        // recursively
        static void postorder(node curr)
        {
            // Base case
            if (curr == null)
                return;
            postorder(curr.left);
            postorder(curr.right);
            prev.left = null;
            prev.right = curr;
            prev = curr;
        }

        // Function to flatten the given binary tree
        // using post order traversal
        static node flatten(node parent)
        {
            // Dummy node
            node dummy = new node(-1);

            // Pointer to previous element
            prev = dummy;

            // Calling post-order traversal
            postorder(parent);

            prev.left = null;
            prev.right = null;
            node ret = dummy.right;

            // Delete dummy node
            dummy = null;
            return ret;
        }

        // Driver code
        public static void Main(String[] args)
        {
            node root = new node(5);
            root.left = new node(3);
            root.right = new node(7);
            root.left.left = new node(2);
            root.left.right = new node(4);
            root.right.left = new node(6);
            root.right.right = new node(8);

            print(flatten(root));
            /*
             Output: 2 4 3 6 8 7 5
 

Time complexity: O(N)
Auxiliary Space: O(N).   since N extra space has been taken
            */
        }
    }
}
