using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/write-an-efficient-c-function-to-convert-a-tree-into-its-mirror-tree/
    Convert a Binary Tree into its Mirror Tree
Difficulty Level : Easy
Last Updated : 10 Jul, 2021
Mirror of a Tree: Mirror of a Binary Tree T is another Binary Tree M(T) with left and right children of all non-leaf nodes interchanged. 


Trees in the above figure are mirror of each other

    */
    // Class containing left and right
    // child of current node and key value
    public class BinaryTreeNode
    {
        public int data;
        public BinaryTreeNode left, right;

        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(int item)
        {
            data = item;
            left = right = null;
        }
    }
    public class BinaryTreeMirror
    {
        public BinaryTreeNode root;

        public virtual void mirror()
        {
            root = mirror(root);
        }

        public virtual BinaryTreeNode mirror(BinaryTreeNode node)
        {
            if (node == null)
            {
                return node;
            }

            /* do the subtrees */
            BinaryTreeNode left = mirror(node.left);
            BinaryTreeNode right = mirror(node.right);

            /* swap the left and right pointers */
            node.left = right;
            node.right = left;

            return node;
        }

        public virtual void inOrder()
        {
            inOrder(root);
        }
        /* Helper function to test mirror().
        Given a binary search tree, print out its
        data elements in increasing sorted order.*/
        public virtual void inOrder(BinaryTreeNode node)
        {
            if (node == null)
            {
                return;
            }

            inOrder(node.left);
            Console.Write(node.data + " ");

            inOrder(node.right);
        }

        /* testing for example nodes */
        public static void Main(string[] args)
        {
            /* creating a binary tree and
            entering the nodes */
            BinaryTreeMirror tree = new BinaryTreeMirror();
            tree.root = new BinaryTreeNode(1);
            tree.root.left = new BinaryTreeNode(2);
            tree.root.right = new BinaryTreeNode(3);
            tree.root.left.left = new BinaryTreeNode(4);
            tree.root.left.right = new BinaryTreeNode(5);

            /* print inorder traversal of the input tree */
            Console.WriteLine("Inorder traversal " +
                              "of input tree is :");
            tree.inOrder();
            Console.WriteLine("");

            /* convert tree to its mirror */
            tree.mirror();

            /* print inorder traversal of the minor tree */
            Console.WriteLine("Inorder traversal " +
                            "of binary tree is : ");
            tree.inOrder();
        }
        /*
         Output:  

Inorder traversal of the constructed tree is 
4 2 5 1 3 
Inorder traversal of the mirror tree is 
3 1 5 2 4 
Time & Space Complexities: Worst-case Time complexity is O(n) and for space complexity, If we don’t consider the size of the recursive stack for function calls then O(1) otherwise O(h) where h is the height of the tree.  
        This program is similar to traversal of tree space and time complexities will be the same as Tree traversal more for information Please see our Tree Traversal post for details.
        */
    }

    public class BinaryTreeMirrorIterative
    {

        /* A binary tree node has data, pointer to
        left child and a pointer to right child */


        /* Helper function that allocates a new node
        with the given data and null left and right
        pointers. */
        static BinaryTreeNode newNode(int data)

        {
            BinaryTreeNode node = new BinaryTreeNode();
            node.data = data;
            node.left = node.right = null;
            return (node);
        }

        /* Change a tree so that the roles of the left and
            right pointers are swapped at every node.
        So the tree...
            4
            / \
            2 5
            / \
        1 3

        is changed to...
            4
            / \
            5 2
                / \
            3 1
        */
        static void mirror(BinaryTreeNode root)
        {
            if (root == null)
                return;

            Queue<BinaryTreeNode> q = new Queue<BinaryTreeNode>();
            q.Enqueue(root);

            // Do BFS. While doing BFS, keep swapping
            // left and right children
            while (q.Count > 0)
            {
                // pop top node from queue
                BinaryTreeNode curr = q.Peek();
                q.Dequeue();

                // swap left child with right child
                BinaryTreeNode temp = curr.left;
                curr.left = curr.right;
                curr.right = temp; ;

                // push left and right children
                if (curr.left != null)
                    q.Enqueue(curr.left);
                if (curr.right != null)
                    q.Enqueue(curr.right);
            }
        }


        /* Helper function to print Inorder traversal.*/
        static void inOrder(BinaryTreeNode node)
        {
            if (node == null)
                return;
            inOrder(node.left);
            Console.Write(node.data + " ");
            inOrder(node.right);
        }


        /* Driver code */
        public static void Main(String[] args)
        {
            BinaryTreeNode root = newNode(1);
            root.left = newNode(2);
            root.right = newNode(3);
            root.left.left = newNode(4);
            root.left.right = newNode(5);

            /* Print inorder traversal of the input tree */
            Console.Write("\n Inorder traversal of the"
                    + " coned tree is \n");
            inOrder(root);

            /* Convert tree to its mirror */
            mirror(root);

            /* Print inorder traversal of the mirror tree */
            Console.Write("\n Inorder traversal of the " +
                "mirror tree is \n");
            inOrder(root);
        }
        /*
         Output: 
 

 Inorder traversal of the constructed tree is 
4 2 5 1 3 
 Inorder traversal of the mirror tree is 
3 1 5 2 4 
        */
    }
}
