using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/flatten-a-binary-tree-into-linked-list/
    Given a binary tree, flatten it into linked list in-place. 
    Usage of auxiliary data structure is not allowed. After flattening, left of each node should point to NULL and right should contain next node in preorder.

Examples: 

Input : 
          1
        /   \
       2     5
      / \     \
     3   4     6

Output :
    1
     \
      2
       \
        3
         \
          4
           \
            5
             \
              6

Input :
        1
       / \
      3   4
         /
        2
         \
          5
Output :
     1
      \
       3
        \
         4
          \
           2
            \ 
             5

    Simple Approach: A simple solution is to use Level Order Traversal using Queue. 
    In level order traversal, keep track of previous node. Make current node as right child of previous and left of previous node as NULL. 
    This solution requires queue, but question asks to solve without additional data structure.
    
    Efficient Without Additional Data Structure Recursively look for the node with no grandchildren and both left and right child in the left sub-tree. 
    Then store node->right in temp and make node->right=node->left. Insert temp in first node NULL on right of node by node=node->right. 
    Repeat until it is converted to linked list. 

For Example, 

     */
    public class BinaryTreeFlattenNode
    {
        public int data;
        public BinaryTreeFlattenNode left, right;

        public BinaryTreeFlattenNode(int key)
        {
            data = key;
            left = right = null;
        }
    }
    public class FlattenBinaryTree
    {
        BinaryTreeFlattenNode root;

        // Function to convert binary tree into
        // linked list by altering the right node
        // and making left node NULL
        public void flatten(BinaryTreeFlattenNode node)
        {

            // Base case - return if root is NULL
            if (node == null)
                return;

            // Or if it is a leaf node
            if (node.left == null &&
                node.right == null)
                return;

            // If root.left children exists then we have
            // to make it node.right (where node is root)
            if (node.left != null)
            {

                // Move left recursively
                flatten(node.left);

                // Store the node.right in
                // Node named tempNode
                BinaryTreeFlattenNode tempNode = node.right;
                node.right = node.left;
                node.left = null;

                // Find the position to insert
                // the stored value
                BinaryTreeFlattenNode curr = node.right;
                while (curr.right != null)
                {
                    curr = curr.right;
                }

                // Insert the stored value
                curr.right = tempNode;
            }

            // Now call the same function
            // for node.right
            flatten(node.right);

        }

        // Function for Inorder traversal
        public void inOrder(BinaryTreeFlattenNode node)
        {

            // Base Condition
            if (node == null)
                return;
            inOrder(node.left);
            Console.Write(node.data + " ");
            inOrder(node.right);
        }

        // Driver code
        public static void Main(string[] args)
        {
            FlattenBinaryTree tree = new FlattenBinaryTree();

            /* 
                 1
                / \
            2     5
            / \     \
            3 4     6 
            */

            tree.root = new BinaryTreeFlattenNode(1);
            tree.root.left = new BinaryTreeFlattenNode(2);
            tree.root.right = new BinaryTreeFlattenNode(5);
            tree.root.left.left = new BinaryTreeFlattenNode(3);
            tree.root.left.right = new BinaryTreeFlattenNode(4);
            tree.root.right.right = new BinaryTreeFlattenNode(6);
            Console.Write("The Inorder traversal after flattening binary tree ");
            tree.flatten(tree.root);
            tree.inOrder(tree.root);
            /*
             Output
The Inorder traversal after flattening binary tree 1 2 3 4 5 6 
Complexity Analysis:

Time Complexity: O(n), traverse the whole tree
Space Complexity: O(1), No Extra Space is used
            */
        }
    }
}
