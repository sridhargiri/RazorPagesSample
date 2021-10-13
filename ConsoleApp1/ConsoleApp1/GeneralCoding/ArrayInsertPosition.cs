using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/how-to-insert-an-element-at-a-specific-position-in-an-array-in-java/
    How to Insert an element at a specific position in an Array in Java
Difficulty Level : Medium
Last Updated : 02 Aug, 2021
An array is a collection of items stored at contiguous memory locations. In this article, we will see how to insert an element in an array in Java.
Given an array arr of size n, this article tells how to insert an element x in this array arr at a specific position pos.
 



Approach 1: 
Here’s how to do it.
 

First get the element to be inserted, say x
Then get the position at which this element is to be inserted, say pos
Create a new array with the size one greater than the previous size
Copy all the elements from previous array into the new array till the position pos
Insert the element x at position pos
Insert the rest of the elements from the previous array into the new array after the pos
Below is the implementation of the above approach:
     */
    public class ArrayInsertPosition
    {

        public static int[] insertX(int n, int[] arr, int x, int pos)
        {
            int i;

            // create a new array of size n+1
            int[] newarr = new int[n + 1];

            // insert the elements from
            // the old array into the new array
            // insert all elements till pos
            // then insert x at pos
            // then insert rest of the elements
            for (i = 0; i < n + 1; i++)
            {
                if (i < pos - 1)
                    newarr[i] = arr[i];
                else if (i == pos - 1)
                    newarr[i] = x;
                else
                    newarr[i] = arr[i - 1];
            }
            return newarr;
        }

        // Driver code
        public static void Main(String[] args)
        {

            int n = 10;
            int i;

            // initial array of size 10
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            // element to be inserted
            int x = 50;

            // position at which element
            // is to be inserted
            int pos = 5;

            // call the method to insert x
            // in arr at position pos
            arr = insertX(n, arr, x, pos);
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            /*
             Output: 

Initial Array:
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

Array with 50 inserted at position 5:
[1, 2, 3, 4, 50, 5, 6, 7, 8, 9, 10]

             */
        }
    }
}
