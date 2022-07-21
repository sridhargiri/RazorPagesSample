using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MajorityElement_Nagarro
    {
        /*https://www.geeksforgeeks.org/majority-element/
         Majority Element
Difficulty Level : Medium
Last Updated : 19 Apr, 2021
Write a function which takes an array and prints the majority element (if it exists), otherwise prints “No Majority Element”. 
        A majority element in an array A[] of size n is an element that appears more than n/2 times (and hence there is at most one such element). 

Examples : 

Input : {3, 3, 4, 2, 4, 4, 2, 4, 4}
Output : 4
Explanation: The frequency of 4 is 5 which is greater
than the half of the size of the array size. 

Input : {3, 3, 4, 2, 4, 4, 2, 4}
Output : No Majority Element
Explanation: There is no element whose frequency is
greater than the half of the size of the array size.
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
 
METHOD 1  

Approach: The basic solution is to have two loops and keep track of the maximum count for all different elements. If maximum count becomes greater than n/2 then break the loops and return the element having maximum count. If the maximum count doesn’t become more than n/2 then the majority element doesn’t exist.
Algorithm: 
Create a variable to store the max count, count = 0
Traverse through the array from start to end.
For every element in the array run another loop to find the count of similar elements in the given array.
If the count is greater than the max count update the max count and store the index in another variable.
If the maximum count is greater than the half the size of the array, print the element. Else print there is no majority element.
Below is the implementation of the above idea:
        */

        // Function to find Majority element
        // in an array
        static void findMajority(int[] arr, int n)
        {
            int maxCount = 0;
            int index = -1; // sentinels
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (arr[i] == arr[j])
                        count++;
                }

                // update maxCount if count of
                // current element is greater
                if (count > maxCount)
                {
                    maxCount = count;
                    index = i;
                }
            }

            // if maxCount is greater than n/2
            // return the corresponding element
            if (maxCount > n / 2)
                Console.WriteLine(arr[index]);

            else
                Console.WriteLine("No Majority Element");
        }
        /*
         METHOD 2 (Using Binary Search Tree) 

Approach: Insert elements in BST one by one and if an element is already present then increment the count of the node. At any stage, if the count of a node becomes more than n/2 then return.
Algorithm: 
Create a binary search tree, if same element is entered in the binary search tree the frequency of the node is increased.
traverse the array and insert the element in the binary search tree.
If the maximum frequency of any node is greater than the half the size of the array, then perform a inorder traversal and find the node with frequency greater than half
Else print No majority Element.
Below is the implementation of the above idea
        */

        public class BSTNode
        {
            public int key;
            public int c = 0;
            public BSTNode left, right;

        }

        static int ma = 0;

        // A utility function to create a
        // new BST node
        static BSTNode newNode(int item)
        {
            BSTNode temp = new BSTNode();
            temp.key = item;
            temp.c = 1;
            temp.left = temp.right = null;
            return temp;
        }
        // A utility function to insert a new node
        // with given key in BST
        static BSTNode insert(BSTNode node, int key)
        {

            // If the tree is empty,
            // return a new node
            if (node == null)
            {
                if (ma == 0)
                    ma = 1;

                return newNode(key);
            }

            // Otherwise, recur down the tree
            if (key < node.key)
                node.left = insert(node.left, key);
            else if (key > node.key)
                node.right = insert(node.right, key);
            else
                node.c++;

            // Find the max count
            ma = Math.Max(ma, node.c);

            // Return the (unchanged) node pointer
            return node;
        }

        // A utility function to do inorder
        // traversal of BST
        static void inorder(BSTNode root, int s)
        {
            if (root != null)
            {
                inorder(root.left, s);

                if (root.c > (s / 2))
                    Console.WriteLine(root.key + "\n");

                inorder(root.right, s);
            }
        }
        static public void Main()
        {

            int[] arr = { 1, 1, 2, 1, 3, 5, 1 };
            int n = arr.Length;

            // Function calling
            findMajority(arr, n);
            /*
             Output

1
Complexity Analysis: 

Time Complexity: O(n*n). 
A nested loop is needed where both the loops traverse the array from start to end, so the time complexity is O(n^2).
Auxiliary Space: O(1). 
As no extra space is required for any operation so the space complexity is constant.
            */
            //using method 2

            int[] a = { 1, 3, 3, 3, 2 };
            int size = a.Length;
            BSTNode root = null;

            for (int i = 0; i < size; i++)
            {
                root = insert(root, a[i]);
            }

            // Function call
            if (ma > (size / 2))
                inorder(root, size);
            else
                Console.WriteLine("No majority element\n");
            /*
             output
3
Complexity Analysis: 

Time Complexity: If a Binary Search Tree is used then time complexity will be O(n^2). If a self-balancing-binary-search tree is used then it will be O(nlogn)
Auxiliary Space: O(n). 
As extra space is needed to store the array in tree.
            */
        }
    }
}
