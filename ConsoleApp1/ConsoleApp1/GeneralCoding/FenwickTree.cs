using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Binary Indexed Tree or Fenwick Tree
Difficulty Level : Medium
 Last Updated : 31 Aug, 2020
Let us consider the following problem to understand Binary Indexed Tree.
We have an array arr[0 . . . n-1]. We would like to
1 Compute the sum of the first i elements.
2 Modify the value of a specified element of the array arr[i] = x where 0 <= i <= n-1.

A simple solution is to run a loop from 0 to i-1 and calculate the sum of the elements. To update a value, simply do arr[i] = x. The first operation takes O(n) time and the second operation takes O(1) time. Another simple solution is to create an extra array and store the sum of the first i-th elements at the i-th index in this new array. The sum of a given range can now be calculated in O(1) time, but the update operation takes O(n) time now. This works well if there are a large number of query operations but a very few number of update operations.

Could we perform both the query and update operations in O(log n) time?
One efficient solution is to use Segment Tree that performs both operations in O(Logn) time.

An alternative solution is Binary Indexed Tree, which also achieves O(Logn) time complexity for both operations. Compared with Segment Tree, Binary Indexed Tree requires less space and is easier to implement..




Representation
Binary Indexed Tree is represented as an array. Let the array be BITree[]. Each node of the Binary Indexed Tree stores the sum of some elements of the input array. The size of the Binary Indexed Tree is equal to the size of the input array, denoted as n. In the code below, we use a size of n+1 for ease of implementation.

Construction
We initialize all the values in BITree[] as 0. Then we call update() for all the indexes, the update() operation is discussed below.

Operations

getSum(x): Returns the sum of the sub-array arr[0,…,x]
// Returns the sum of the sub-array arr[0,…,x] using BITree[0..n], which is constructed from arr[0..n-1]
1) Initialize the output sum as 0, the current index as x+1.
2) Do following while the current index is greater than 0.
…a) Add BITree[index] to sum
…b) Go to the parent of BITree[index]. The parent can be obtained by removing
the last set bit from the current index, i.e., index = index – (index & (-index))
3) Return sum.

BITSum

The diagram above provides an example of how getSum() is working. Here are some important observations.

BITree[0] is a dummy node.

BITree[y] is the parent of BITree[x], if and only if y can be obtained by removing the last set bit from the binary representation of x, that is y = x – (x & (-x)).




The child node BITree[x] of the node BITree[y] stores the sum of the elements between y(inclusive) and x(exclusive): arr[y,…,x).

 


update(x, val): Updates the Binary Indexed Tree (BIT) by performing arr[index] += val
// Note that the update(x, val) operation will not change arr[]. It only makes changes to BITree[]
1) Initialize the current index as x+1.
2) Do the following while the current index is smaller than or equal to n.
…a) Add the val to BITree[index]
…b) Go to parent of BITree[index]. The parent can be obtained by incrementing the last set bit of the current index, i.e., index = index + (index & (-index))

BITUpdate1

The update function needs to make sure that all the BITree nodes which contain arr[i] within their ranges being updated. We loop over such nodes in the BITree by repeatedly adding the decimal number corresponding to the last set bit of the current index.

 

How does Binary Indexed Tree work?
The idea is based on the fact that all positive integers can be represented as the sum of powers of 2. For example 19 can be represented as 16 + 2 + 1. Every node of the BITree stores the sum of n elements where n is a power of 2. For example, in the first diagram above (the diagram for getSum()), the sum of the first 12 elements can be obtained by the sum of the last 4 elements (from 9 to 12) plus the sum of 8 elements (from 1 to 8). The number of set bits in the binary representation of a number n is O(Logn). Therefore, we traverse at-most O(Logn) nodes in both getSum() and update() operations. The time complexity of the construction is O(nLogn) as it calls update() for all n elements.

Implementation:
Following are the implementations of Binary Indexed Tree.
    */
    class FenwickTree
    {
        // Max tree size  
        readonly static int MAX = 1000;

        static int[] BITree = new int[MAX];

        /* n --> No. of elements present in input array.  
        BITree[0..n] --> Array that represents Binary  
                        Indexed Tree.  
        arr[0..n-1] --> Input array for which prefix sum  
                        is evaluated. */

        // Returns sum of arr[0..index]. This function  
        // assumes that the array is preprocessed and  
        // partial sums of array elements are stored  
        // in BITree[].  
        int getSum(int index)
        {
            int sum = 0; // Iniialize result  

            // index in BITree[] is 1 more than  
            // the index in arr[]  
            index = index + 1;

            // Traverse ancestors of BITree[index]  
            while (index > 0)
            {
                // Add current element of BITree  
                // to sum  
                sum += BITree[index];

                // Move index to parent node in  
                // getSum View  
                index -= index & (-index);
            }
            return sum;
        }

        // Updates a node in Binary Index Tree (BITree)  
        // at given index in BITree. The given value  
        // 'val' is added to BITree[i] and all of  
        // its ancestors in tree.  
        public static void updateBIT(int n, int index,
                                            int val)
        {
            // index in BITree[] is 1 more than  
            // the index in arr[]  
            index = index + 1;

            // Traverse all ancestors and add 'val'  
            while (index <= n)
            {

                // Add 'val' to current node of BIT Tree  
                BITree[index] += val;

                // Update index to that of parent  
                // in update View  
                index += index & (-index);
            }
        }

        /* Function to construct fenwick tree  
        from given array.*/
        void constructBITree(int[] arr, int n)
        {
            // Initialize BITree[] as 0  
            for (int i = 1; i <= n; i++)
                BITree[i] = 0;

            // Store the actual values in BITree[]  
            // using update()  
            for (int i = 0; i < n; i++)
                updateBIT(n, i, arr[i]);
        }

        // Driver code  
        public static void Main(String[] args)
        {
            int[] freq = {2, 1, 1, 3, 2, 3,
                    4, 5, 6, 7, 8, 9};
            int n = freq.Length;
            FenwickTree tree = new FenwickTree();

            // Build fenwick tree from given array  
            tree.constructBITree(freq, n);

            Console.WriteLine("Sum of elements in arr[0..5]" +
                            " is " + tree.getSum(5));

            // Let use test the update operation  
            freq[3] += 6;

            // Update BIT for above change in arr[]  
            updateBIT(n, 3, 6);

            // Find sum after the value is updated  
            Console.WriteLine("Sum of elements in arr[0..5]" +
                        " after update is " + tree.getSum(5));
        }
        /*
         Output:
Sum of elements in arr[0..5] is 12
Sum of elements in arr[0..5] after update is 18
Can we extend the Binary Indexed Tree to computing the sum of a range in O(Logn) time?
Yes. rangeSum(l, r) = getSum(r) – getSum(l-1).

Applications:
The implementation of the arithmetic coding algorithm. The development of the Binary Indexed Tree was primarily motivated by its application in this case. See this for more details.

Example Problems:
        
         https://www.geeksforgeeks.org/count-inversions-array-set-3-using-bit/
        https://www.geeksforgeeks.org/two-dimensional-binary-indexed-tree-or-fenwick-tree/
        https://www.geeksforgeeks.org/counting-triangles-in-a-rectangular-space-using-2d-bit/
         */
    }

}
