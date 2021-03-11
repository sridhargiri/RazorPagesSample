using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Deepest left leaf node in a binary tree
Difficulty Level : Medium
 Last Updated : 13 Feb, 2020
Given a Binary Tree, find the deepest leaf node that is left child of its parent. For example, consider the following tree. The deepest left leaf node is the node with value 9.
       1
     /   \
    2     3
  /      /  \  
 4      5    6
        \     \
         7     8
        /       \
       9         10
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to recursively traverse the given binary tree and while traversing, maintain “level” which will store the current node’s level in the tree. If current node is left leaf, then check if its level is more than the level of deepest left leaf seen so far. If level is more then update the result. If current node is not leaf, then recursively find maximum depth in left and right subtrees, and return maximum of the two depths. Thanks to Coder011 for suggesting this approach.
    */


    // A C# program to find 
    // the deepest left leaf 
    // in a binary tree 

    // A Binary Tree node 
    public class Node2
    {
        public int data;
        public Node2 left, right;

        // Constructor 
        public Node2(int data)
        {
            this.data = data;
            left = right = null;
        }
    }

    // Class to evaluate pass 
    // by reference 
    public class Level
    {
        // maxlevel: gives the 
        // value of level of 
        // maximum left leaf 
        public int maxlevel = 0;
    }

    public class DeepestLeafNode
    {
        public Node2 root;

        // Node to store resultant 
        // node after left traversal 
        public Node2 result;

        // A utility function to 
        // find deepest leaf node. 
        // lvl: level of current node. 
        // isLeft: A bool indicate 
        // that this node is left child 
        public virtual void deepestLeftLeafUtil(Node2 node, int lvl,
                                            Level level, bool isLeft)
        {
            // Base case 
            if (node == null)
            {
                return;
            }

            // Update result if this node 
            // is left leaf and its level 
            // is more than the maxl level 
            // of the current result 
            if (isLeft != false && node.left == null && node.right == null
                                && lvl > level.maxlevel)
            {
                result = node;
                level.maxlevel = lvl;
            }

            // Recur for left and right subtrees 
            deepestLeftLeafUtil(node.left, lvl + 1, level, true);
            deepestLeftLeafUtil(node.right, lvl + 1, level, false);
        }

        // A wrapper over deepestLeftLeafUtil(). 
        public virtual void deepestLeftLeaf(Node2 node)
        {
            Level level = new Level();
            deepestLeftLeafUtil(node, 0, level, false);
        }

        // Driver program to test above functions 
        public static void Main(string[] args)
        {
            DeepestLeafNode tree = new DeepestLeafNode();
            tree.root = new Node2(1);
            tree.root.left = new Node2(2);
            tree.root.right = new Node2(3);
            tree.root.left.left = new Node2(4);
            tree.root.right.left = new Node2(5);
            tree.root.right.right = new Node2(6);
            tree.root.right.left.right = new Node2(7);
            tree.root.right.right.right = new Node2(8);
            tree.root.right.left.right.left = new Node2(9);
            tree.root.right.right.right.right = new Node2(10);

            tree.deepestLeftLeaf(tree.root);
            if (tree.result != null)
            {
                Console.WriteLine("The deepest left child is " + tree.result.data);
            }
            else
            {
                Console.WriteLine("There is no left leaf in the given tree");
            }
        }
    }

    /*
     Output:

  The deepest left child is 9
  Time Complexity: The function does a simple traversal of the tree, so the complexity is O(n).

  This article is contributed by Abhay Rathi. Please write comments if you find anything incorrect, or you want to share more information about the topic discussed above
    */
}
