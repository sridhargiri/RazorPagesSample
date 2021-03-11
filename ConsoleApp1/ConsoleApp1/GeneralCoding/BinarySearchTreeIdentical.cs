using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check whether the two Binary Search Trees are Identical or Not
Difficulty Level : Easy
 Last Updated : 02 Jan, 2020
Given the root nodes of the two binary search trees. The task is to print 1 if the two Binary Search Trees are identical else print 0. Two trees are identical if they are identical structurally and nodes have the same values.


Tree 1
        5
        /\
       /   \
      3     8
    / \
   /   \
  2     4



Tree 2
     5
        /\
       /   \
      3     8
    / \
   /   \
  2     4


In the above images, both Tree1 and Tree2 are identical.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
To identify if two trees are identical, we need to traverse both trees simultaneously, and while traversing we need to compare data and children of the trees.

Below is the step by step algorithm to check if two BSTs are identical:

If both trees are empty then return 1.
Else If both trees are non -empty
Check data of the root nodes (tree1->data == tree2->data)
Check left subtrees recursively i.e., call sameTree(tree1->left_subtree, tree2->left_subtree)
Check right subtrees recursively i.e., call sameTree(tree1->right_subtree, tree2->right_subtree)
If the values returned in the above three steps are true then return 1.
Else return 0 (one is empty and other is not).
Below is the implementation of the above approach:
    */
    class BinarySearchTreeIdentical
    {

        // BST node 
        class Node
        {
            public int data;
            public Node left;
            public Node right;
        };

        // Utility function to create a new Node 
        static Node newNode(int data)
        {
            Node node = new Node();
            node.data = data;
            node.left = null;
            node.right = null;

            return node;
        }

        // Function to perform inorder traversal 
        static void inorder(Node root)
        {
            if (root == null)
                return;

            inorder(root.left);

            Console.Write(root.data + " ");

            inorder(root.right);
        }

        // Function to check if two BSTs 
        // are identical 
        static int isIdentical(Node root1,
                               Node root2)
        {
            // Check if both the trees are empty 
            if (root1 == null && root2 == null)
                return 1;

            // If any one of the tree is non-empty 
            // and other is empty, return false 
            else if (root1 != null &&
                     root2 == null)
                return 0;
            else if (root1 == null &&
                     root2 != null)
                return 0;
            else
            {
                // Check if current data of both trees equal 
                // and recursively check for left and right subtrees 
                if (root1.data == root2.data &&
                    isIdentical(root1.left, root2.left) == 1 &&
                    isIdentical(root1.right, root2.right) == 1)
                    return 1;
                else
                    return 0;
            }
        }

        // Driver code 
        public static void Main(String[] args)
        {
            Node root1 = newNode(5);
            Node root2 = newNode(5);
            root1.left = newNode(3);
            root1.right = newNode(8);
            root1.left.left = newNode(2);
            root1.left.right = newNode(4);

            root2.left = newNode(3);
            root2.right = newNode(8);
            root2.left.left = newNode(2);
            root2.left.right = newNode(4);

            if (isIdentical(root1, root2) == 1)
                Console.Write("Both BSTs are identical");
            else
                Console.Write("BSTs are not identical");
            //Output:
            //Both BSTs are identical
            //https://www.geeksforgeeks.org/check-whether-the-two-binary-search-trees-are-identical-or-not/
        }
    }
}
