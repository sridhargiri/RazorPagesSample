using System;
using System.Collections.Generic;
using System.Text;
/*
https://www.geeksforgeeks.org/find-maximum-path-sum-in-a-binary-tree/
Given a binary tree, find the maximum path sum. The path may start and end at any node in the tree.

Example:

Input: Root of below tree
       1
      / \
     2   3
Output: 6

See below diagram for another example.
1+2+3

 For each node there can be four ways that the max path goes through the node:
1. Node only
2. Max path through Left Child + Node
3. Max path through Right Child + Node
4. Max path through Left Child + Node + Max path through Right Child

The idea is to keep trace of four paths and pick up the max one in the end. 
An important thing to note is, root of every subtree need to return maximum path sum such that at most one child of root is involved. 
This is needed for parent function call. In below code, this sum is stored in ‘max_single’ and returned by the recursive function.
 */
namespace ConsoleApp1
{


    /* Class containing left and 
	right child of current 
	node and key value*/
    public class Node1
    {

        public int data;
        public Node1 left, right;

        public Node1(int item)
        {
            data = item;
            left = right = null;
        }
    }

    // An object of Res is passed 
    // around so that the same value 
    // can be used by multiple recursive calls. 
    class Res
    {
        public int val;
    }

    public class BinaryTree
    {

        // Root of the Binary Tree 
        Node1 root;

        // This function returns overall 
        // maximum path sum in 'res' And 
        // returns max path sum going through root. 
        int findMaxUtil(Node1 node, Res res)
        {

            // Base Case 
            if (node == null)
                return 0;

            // l and r store maximum path 
            // sum going through left and 
            // right child of root respectively 
            int l = findMaxUtil(node.left, res);
            int r = findMaxUtil(node.right, res);

            // Max path for parent call of root. 
            // This path must include 
            // at-most one child of root 
            int max_single = Math.Max(Math.Max(l, r) +
                                node.data, node.data);


            // Max Top represents the sum 
            // when the Node under 
            // consideration is the root 
            // of the maxsum path and no 
            // ancestors of root are there 
            // in max sum path 
            int max_top = Math.Max(max_single,
                            l + r + node.data);

            // Store the Maximum Result. 
            res.val = Math.Max(res.val, max_top);

            return max_single;
        }

        int findMaxSum()
        {
            return findMaxSum(root);
        }

        // Returns maximum path 
        // sum in tree with given root 
        int findMaxSum(Node1 node)
        {

            // Initialize result 
            // int res2 = int.MinValue; 
            Res res = new Res();
            res.val = int.MinValue;

            // Compute and return result 
            findMaxUtil(node, res);
            return res.val;
        }
        /*
         Write a Program to Find the Maximum Depth or Height of a Tree


Given a binary tree, find height of it. Height of empty tree is 0 and height of below tree is 2. 
         1
        / \
       /   \
      2     3
     /\
    /  \
   4    5
        Recursively calculate height of left and right subtrees of a node and assign height to the node as max of the heights of two children plus 1. See below pseudo code and program for details.
Algorithm: 
 

 maxDepth()
1. If tree is empty then return 0
2. Else
     (a) Get the max depth of left subtree recursively  i.e., 
          call maxDepth( tree->left-subtree)
     (a) Get the max depth of right subtree recursively  i.e., 
          call maxDepth( tree->right-subtree)
     (c) Get the max of max depths of left and right 
          subtrees and add 1 to it for the current node.
         max_depth = max(max dept of left subtree,  
                             max depth of right subtree) 
                             + 1
     (d) Return max_depth
See the below diagram for more clarity about execution of the recursive function maxDepth() for above example tree. 
 

            maxDepth('1') = max(maxDepth('2'), maxDepth('3')) + 1
                               = 1 + 1
                                  /    \
                                /         \
                              /             \
                            /                 \
                          /                     \
               maxDepth('2') = 1                maxDepth('3') = 0
= max(maxDepth('4'), maxDepth('5')) + 1
= 1 + 0   = 1         
                   /    \
                 /        \
               /            \
             /                \
           /                    \
 maxDepth('4') = 0     maxDepth('5') = 0

         */
        int maxDepth(Node1 node)
        {
            if (node == null)
                return -1;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = maxDepth(node.left);
                int rDepth = maxDepth(node.right);

                /* use the larger one */
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
        /* Driver code */
        public static void Main(String[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node1(10);
            tree.root.left = new Node1(2);
            tree.root.right = new Node1(10);
            tree.root.left.left = new Node1(20);
            tree.root.left.right = new Node1(1);
            tree.root.right.right = new Node1(-25);
            tree.root.right.right.left = new Node1(3);
            tree.root.right.right.right = new Node1(4);
            Console.WriteLine("maximum path sum is : " +
                                tree.findMaxSum());
            Console.WriteLine("Height of tree is : " +
                                    tree.maxDepth(tree.root));
            //Output
            //Height of tree is 2
            //https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
            //http://cslibrary.stanford.edu/110/BinaryTrees.html
            //https://www.geeksforgeeks.org/write-a-c-program-to-find-the-maximum-depth-or-height-of-a-tree/
            //try all below for AMZ binary tree
            //https://www.geeksforgeeks.org/amazon-interview-experience-for-sde-off-campus/
            /*
             Output: Max path sum is 42
             Time Complexity: O(n) where n is number of nodes in Binary Tree.
            */
        }
    }

    // This code is contributed Rajput-Ji. 

}
