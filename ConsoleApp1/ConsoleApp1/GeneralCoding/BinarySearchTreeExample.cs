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
    
The above properties of Binary Search Tree provides an ordering among keys so that the operations like search, minimum and maximum can be done fast. 
If there is no ordering, then we may have to compare every key to search for a given key.

Searching a key 
For searching a value, if we had a sorted array we could have performed a binary search. 
Let’s say we want to search a number in the array what we do in binary search is we first define the complete list as our search space, the number can exist only within the search space. 
Now we compare the number to be searched or the element to be searched with the mid element of the search space or the median and if the record being searched is lesser we go searching in the left half else we go searching in the right half, 
in case of equality we have found the element. 
In binary search we start with ‘n’ elements in search space and then if the mid element is not the element that we are looking for, we reduce the search space to ‘n/2’ and we go on reducing the search space till we either find the record that we are looking for or we get to only one element in search space and be done with this whole reduction. 
Search operation in binary search tree will be very similar. 
Let’s say we want to search for the number, what we’ll do is we’ll start at the root, and then we will compare the value to be searched with the value of the root if it’s equal we are done with the search if it’s lesser we know that we need to go to the left subtree because in a binary search tree all the elements in the left subtree are lesser and all the elements in the right subtree are greater. 
Searching an element in the binary search tree is basically this traversal in which at each step we will go either towards left or right and hence in at each step we discard one of the sub-trees. 
If the tree is balanced, we call a tree balanced if for all nodes the difference between the heights of left and right subtrees is not greater than one, we will start with a search space of ‘n’nodes and when we will discard one of the sub-trees we will discard ‘n/2’ nodes so our search space will be reduced to ‘n/2’ and then in the next step we will reduce the search space to ‘n/4’ and we will go on reducing like this till we find the element or till our search space is reduced to only one node. The search here is also a binary search and that’s why the name binary search tree.
    
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
A new key is always inserted at the leaf. We start searching a key from the root until we hit a leaf node. 
Once a leaf node is found, the new node is added as a child of the leaf node. 
 

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

    public class NodeClass
    {
        public int data;
        public NodeClass left;
        public NodeClass right;
    }
    /*
     https://www.geeksforgeeks.org/print-cousins-of-a-given-node-in-binary-tree/?ref=gcse
    Print cousins of a given node in Binary Tree
    Given a binary tree and a node, print all cousins of given node. Note that siblings should not be printed.
Example: 
 

Input : root of below tree 
             1
           /   \
          2     3
        /   \  /  \
       4    5  6   7
       and pointer to a node say 5.

Output : 6, 7
The idea to first find level of given node using the approach discussed here. Once we have found level, we can print all nodes at a given level using the approach discussed here. The only thing to take care of is, sibling should not be printed. To handle this, we change the printing function to first check for sibling and print node only if it is not sibling.

Below is the implementation of above idea
     */
    public class BSTCousin
    {

        // A utility function to create 
        // a new Binary Tree Node
        static NodeClass newNodeClass(int item)
        {
            NodeClass temp = new NodeClass();
            temp.data = item;
            temp.left = null;
            temp.right = null;
            return temp;
        }

        /* It returns level of the NodeClass
        if it is present in tree,
         otherwise returns 0.*/
        static int getLevel(NodeClass root,
                    NodeClass NodeClass, int level)
        {
            // base cases
            if (root == null)
                return 0;
            if (root == NodeClass)
                return level;

            // If NodeClass is present in left subtree
            int downlevel = getLevel(root.left, NodeClass, level + 1);
            if (downlevel != 0)
                return downlevel;

            // If NodeClass is not present in left subtree
            return getLevel(root.right, NodeClass, level + 1);
        }

        /* Print NodeClasss at a given level
        such that sibling of NodeClass is
         not printed if it exists */
        static void printGivenLevel(NodeClass root,
                            NodeClass NodeClass, int level)
        {
            // Base cases
            if (root == null || level < 2)
                return;

            // If current NodeClass is parent of a NodeClass with
            // given level
            if (level == 2)
            {
                if (root.left == NodeClass || root.right == NodeClass)
                    return;
                if (root.left != null)
                    Console.Write(root.left.data + " ");
                if (root.right != null)
                    Console.Write(root.right.data + " ");
            }

            // Recur for left and right subtrees
            else if (level > 2)
            {
                printGivenLevel(root.left, NodeClass, level - 1);
                printGivenLevel(root.right, NodeClass, level - 1);
            }
        }

        // This function prints cousins of a given NodeClass
        static void printCousins(NodeClass root, NodeClass NodeClass)
        {
            // Get level of given NodeClass
            int level = getLevel(root, NodeClass, 1);

            // Print NodeClasss of given level.
            printGivenLevel(root, NodeClass, level);
        }

        // Driver code
        public static void Main(String[] args)
        {
            NodeClass root = newNodeClass(1);
            root.left = newNodeClass(2);
            root.right = newNodeClass(3);
            root.left.left = newNodeClass(4);
            root.left.right = newNodeClass(5);
            root.left.right.right = newNodeClass(15);
            root.right.left = newNodeClass(6);
            root.right.right = newNodeClass(7);
            root.right.left.right = newNodeClass(8);

            printCousins(root, root.left.right);
            /*
             Output
6 7
Time Complexity : O(n)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/print-cousins-of-a-given-node-in-binary-tree-single-traversal/
    Print cousins of a given node in Binary Tree | Single Traversal
    Given a binary tree and a node, print all cousins of given node. Note that siblings should not be printed.

Examples: 

Input : root of below tree 
             1
           /   \
          2     3
        /   \  /  \
       4    5  6   7
       and pointer to a node say 5.

Output : 6, 7
    Note that it is the same problem as given at Print cousins of a given node in Binary Tree which consists of two traversals recursively. In this post, a single level traversal approach is discussed.
The idea is to go for level order traversal of the tree, as the cousins and siblings of a node can be found in its level order traversal. Run the traversal till the level containing the node is not found, and if found, print the given level.

How to print the cousin nodes instead of siblings and how to get the nodes of that level in the queue? 
During the level order, when for the parent node, if parent->left == Node_to_find, or parent->right == Node_to_find, then the children of this parent must not be pushed into the queue (as one is the node and other will be its sibling). 
    Push the remaining nodes at the same level in the queue and then exit the loop. 
    The current queue will have the nodes at the next level (the level of the node being searched, except the node and its sibling). 
    Now, print the queue.
    Following is the implementation of the above algorithm.

     */
    public class BSTCousin2
    {

        static NodeClass newNodeClass(int item)
        {
            NodeClass temp = new NodeClass();
            temp.data = item;
            temp.left = null;
            temp.right = null;
            return temp;
        }

        // function to print
        // cousins of the node
        static void printCousins(NodeClass root,
                                 NodeClass node_to_find)
        {
            // if the given node
            // is the root itself,
            // then no nodes would
            // be printed
            if (root == node_to_find)
            {
                Console.Write("Cousin Nodes :" +
                                   " None" + "\n");
                return;
            }

            Queue<NodeClass> q = new Queue<NodeClass>();
            bool found = false;
            int size_ = 0;
            NodeClass p = null;
            q.Enqueue(root);

            // the following loop runs
            // until found is not true,
            // or q is not empty. if
            // found has become true => we
            // have found the level in
            // which the node is present
            // and the present queue will
            // contain all the cousins of
            // that node
            while (q.Count != 0 &&
                         found == false)
            {

                size_ = q.Count;
                while (size_-- > 0)
                {
                    p = q.Peek();
                    q.Dequeue();

                    // if current node's left
                    // or right child is the
                    // same as the node to find,
                    // then make found = true,
                    // and don't push any of them
                    // into the queue, as we don't
                    // have to print the siblings
                    if ((p.left == node_to_find ||
                         p.right == node_to_find))
                    {
                        found = true;
                    }
                    else
                    {
                        if (p.left != null)
                            q.Enqueue(p.left);
                        if (p.right != null)
                            q.Enqueue(p.right);
                    }

                }
            }

            // if found == true then the
            // queue will contain the
            // cousins of the given node
            if (found == true)
            {
                Console.Write("Cousin Nodes : ");
                size_ = q.Count;

                // size_ will be 0 when
                // the node was at the
                // level just below the
                // root node.
                if (size_ == 0)
                    Console.Write("None");

                for (int i = 0; i < size_; i++)
                {
                    p = q.Peek();
                    q.Dequeue();

                    Console.Write(p.data + " ");
                }
            }
            else
            {
                Console.Write("Node not found");
            }

            Console.WriteLine("");
            return;
        }

        // Driver code
        public static void Main(String[] args)
        {
            NodeClass root = newNodeClass(1);
            root.left = newNodeClass(2);
            root.right = newNodeClass(3);
            root.left.left = newNodeClass(4);
            root.left.right = newNodeClass(5);
            root.left.right.right = newNodeClass(15);
            root.right.left = newNodeClass(6);
            root.right.right = newNodeClass(7);
            root.right.left.right = newNodeClass(8);

            NodeClass x = newNodeClass(43);

            printCousins(root, x);
            printCousins(root, root);
            printCousins(root, root.right);
            printCousins(root, root.left);
            printCousins(root, root.left.right);
            /*
             Output
Node not found
Cousin Nodes : None
Cousin Nodes : None
Cousin Nodes : None
Cousin Nodes : 6 7 
Time Complexity : This is a single level order traversal, hence time complexity = O(n), and Auxiliary space = O(n)
            */
        }
    }

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
