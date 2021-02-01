using System;
using System.Collections.Generic;
using System.Text;
/*
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
        }
    }

    // This code is contributed Rajput-Ji. 

}
