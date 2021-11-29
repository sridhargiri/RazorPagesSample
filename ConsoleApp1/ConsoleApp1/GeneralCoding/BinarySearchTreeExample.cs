using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/binary-search-tree-set-1-search-and-insertion/
    Binary Search Tree | Set 1 (Search and Insertion)
Difficulty Level : Easy
Last Updated : 15 Feb, 2021
The following is the definition of Binary Search Tree(BST) according to Wikipedia
Binary Search Tree is a node-based binary tree data structure which has the following properties:  
           8            
        /   \       
      3     10    
     /  \     \      
    1   6     14
         /\    /
        4 7   13

The left subtree of a node contains only nodes with keys lesser than the node’s key.
The right subtree of a node contains only nodes with keys greater than the node’s key.
The left and right subtree each must also be a binary search tree. 
There must be no duplicate nodes.
    
     The above properties of Binary Search Tree provides an ordering among keys so that the operations like search, minimum and maximum can be done fast. If there is no ordering, then we may have to compare every key to search for a given key.

Searching a key 
For searching a value, if we had a sorted array we could have performed a binary search. Let’s say we want to search a number in the array what we do in binary search is we first define the complete list as our search space, the number can exist only within the search space. Now we compare the number to be searched or the element to be searched with the mid element of the search space or the median and if the record being searched is lesser we go searching in the left half else we go searching in the right half, in case of equality we have found the element. In binary search we start with ‘n’ elements in search space and then if the mid element is not the element that we are looking for, we reduce the search space to ‘n/2’ and we go on reducing the search space till we either find the record that we are looking for or we get to only one element in search space and be done with this whole reduction. 
Search operation in binary search tree will be very similar. Let’s say we want to search for the number, what we’ll do is we’ll start at the root, and then we will compare the value to be searched with the value of the root if it’s equal we are done with the search if it’s lesser we know that we need to go to the left subtree because in a binary search tree all the elements in the left subtree are lesser and all the elements in the right subtree are greater. Searching an element in the binary search tree is basically this traversal in which at each step we will go either towards left or right and hence in at each step we discard one of the sub-trees. If the tree is balanced, we call a tree balanced if for all nodes the difference between the heights of left and right subtrees is not greater than one, we will start with a search space of ‘n’nodes and when we will discard one of the sub-trees we will discard ‘n/2’ nodes so our search space will be reduced to ‘n/2’ and then in the next step we will reduce the search space to ‘n/4’ and we will go on reducing like this till we find the element or till our search space is reduced to only one node. The search here is also a binary search and that’s why the name binary search tree.
    
     C#
    
public Node search(Node root,
                   int key)
{
    // Base Cases: root is null
    // or key is present at root
    if (root == null ||
        root.key == key)
        return root;
 
   // Key is greater than root's key
    if (root.key < key)
       return search(root.right, key);
 
    // Key is smaller than root's key
    return search(root.left, key);
}
    
     Illustration to search 6 in below tree: 
1. Start from the root. 
2. Compare the searching element with root, if less than root, then recurse for left, else recurse for right. 
3. If the element to search is found anywhere, return true, else return false. 
 Insertion of a key 
A new key is always inserted at the leaf. We start searching a key from the root until we hit a leaf node. Once a leaf node is found, the new node is added as a child of the leaf node. 
 

         100                               100
        /   \        Insert 40            /    \
      20     500    --------->          20     500 
     /  \                              /  \  
    10   30                           10   30
                                              \   
                                              40
     */
    class BinarySearchTreeExample
    {

        // Class containing left and
        // right child of current node
        // and key value
        public class Node
        {
            public int key;
            public Node left, right;

            public Node(int item)
            {
                key = item;
                left = right = null;
            }
        }

        // Root of BST
        Node root;

        // Constructor
        BinarySearchTreeExample()
        {
            root = null;
        }

        // This method mainly calls insertRec()
        void insert(int key)
        {
            root = insertRec(root, key);
        }

        // A recursive function to insert
        // a new key in BST
        Node insertRec(Node root, int key)
        {

            // If the tree is empty,
            // return a new node
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            // Otherwise, recur down the tree
            if (key < root.key)
                root.left = insertRec(root.left, key);
            else if (key > root.key)
                root.right = insertRec(root.right, key);

            // Return the (unchanged) node pointer
            return root;
        }

        // This method mainly calls InorderRec()
        void inorder()
        {
            inorderRec(root);
        }

        // A utility function to
        // do inorder traversal of BST
        void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.WriteLine(root.key);
                inorderRec(root.right);
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            BinarySearchTreeExample tree = new BinarySearchTreeExample();

            /* Let us create following BST
                  50
               /     \
              30      70
             /  \    /  \
           20   40  60   80 */
            tree.insert(50);
            tree.insert(30);
            tree.insert(20);
            tree.insert(40);
            tree.insert(70);
            tree.insert(60);
            tree.insert(80);

            // Print inorder traversal of the BST
            tree.inorder();
            /*
             Output
20 
30 
40 
50 
60 
70 
80
            */
        }
        /*
         Illustration to insert 2 in below tree: 
1. Start from the root. 
2. Compare the inserting element with root, if less than root, then recurse for left, else recurse for right. 
3. After reaching the end, just insert that node at left(if less than current) else right. 
        Time Complexity: The worst-case time complexity of search and insert operations is O(h) where h is the height of the Binary Search Tree. In the worst case, we may have to travel from root to the deepest leaf node. The height of a skewed tree may become n and the time complexity of search and insert operation may become O(n). 

Some Interesting Facts:  

Inorder traversal of BST always produces sorted output.
We can construct a BST with only Preorder or Postorder or Level Order traversal. Note that we can always get inorder traversal by sorting the only given traversal.
        https://www.geeksforgeeks.org/total-number-of-possible-binary-search-trees-using-catalan-number/
        see this also https://www.geeksforgeeks.org/binary-search-tree-set-2-delete/
        */
    }
    /*
    https://www.geeksforgeeks.org/remove-leaf-nodes-binary-search-tree/
    Remove all leaf nodes from the binary search tree
    We have given a binary search tree and we want to delete the leaf nodes from the binary search tree. 
Examples: 
 

Input : 20 10 5 15 30 25 35
Output : Inorder before Deleting the leaf node
         5 10 15 20 25 30 35
         Inorder after Deleting the leaf node
         10 20 30

        This is the binary search tree where we
        want to delete the leaf node.
              20
           /     \
          10      30
         /  \    /  \
       5     15 25   35 

      After deleting the leaf node the binary 
      search tree looks like
              20
           /     \
          10      30
     
    We traverse given Binary Search Tree in inorder way. During traversal, we check if current node is leaf, if yes, we delete it. Else we recur for left and right children. An important thing to remember is, we must assign new left and right children if there is any modification in roots of subtrees. 
    */
    public class BSTDeleteLeafNode
    {

        class Node
        {
            public int data;
            public Node left;
            public Node right;
        }

        // Create a newNode in binary search tree.
        static Node newNode(int data)
        {
            Node temp = new Node();
            temp.data = data;
            temp.left = null;
            temp.right = null;
            return temp;
        }

        // Insert a Node in binary search tree.
        static Node insert(Node root, int data)
        {
            if (root == null)
                return newNode(data);
            if (data < root.data)
                root.left = insert(root.left, data);
            else if (data > root.data)
                root.right = insert(root.right, data);
            return root;
        }

        // Function for inorder traversal in a BST.
        static void inorder(Node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.Write(root.data + " ");
                inorder(root.right);
            }
        }

        // Delete leaf nodes from binary search tree.
        static Node leafDelete(Node root)
        {
            if (root == null)
            {
                return null;
            }
            if (root.left == null && root.right == null)
            {
                return null;
            }

            // Else recursively delete in
            // left and right subtrees.
            root.left = leafDelete(root.left);
            root.right = leafDelete(root.right);

            return root;
        }

        // Driver code
        public static void Main(String[] args)
        {
            Node root = null;
            root = insert(root, 20);
            insert(root, 10);
            insert(root, 5);
            insert(root, 15);
            insert(root, 30);
            insert(root, 25);
            insert(root, 35);
            Console.WriteLine("Inorder before Deleting"
                              + "the leaf Node. ");
            inorder(root);
            Console.WriteLine();
            leafDelete(root);
            Console.WriteLine("INorder after Deleting"
                              + "the leaf Node. ");
            inorder(root);
            /*
             Output:  

Inorder before Deleting the leaf node.
5 10 15 20 25 30 35
INorder after Deleting the leaf node.
10 20 30
            */
        }
    }
}
