using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Given a positive integer n, print the matrix filled with rectangle pattern as shown below:
a a a a a
a b b b a
a b c b a
a b b b a
a a a a a

where a = n, b = n – 1,c = n – 2 and so on.
 Examples:

Input : n = 4
Output :
4 4 4 4 4 4 4 
4 3 3 3 3 3 4 
4 3 2 2 2 3 4 
4 3 2 1 2 3 4 
4 3 2 2 2 3 4 
4 3 3 3 3 3 4 
4 4 4 4 4 4 4 

Input : n = 3
Output :
3 3 3 3 3 
3 2 2 2 3 
3 2 1 2 3 
3 2 2 2 3 
3 3 3 3 3 
    For the given n, the number of rows or columns to be printed will be 2*n – 1

     */
    class ConcentricRectangle
    {
        static void printPattern(int n)
        {
            int arraySize = n * 2 - 1;
            int[,] result = new int[arraySize, arraySize];

            // Fill the values  
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    result[i, j] = Math.Max(Math.Abs(i - arraySize / 2),
                                        Math.Abs(j - arraySize / 2)) + 1;
                }
            }

            // Print the array  
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Driver Code  
        public static void Main(String[] args)
        {
            int n = 4;

            printPattern(n);
        }
    }
    /*
https://www.geeksforgeeks.org/find-two-rectangles-overlap/
Find if two rectangles overlap
Difficulty Level : Easy
Last Updated : 18 Mar, 2021
Given two rectangles, find if the given two rectangles overlap or not.
Note that a rectangle can be represented by two coordinates, top left and bottom right. So mainly we are given following four coordinates. 
l1: Top Left coordinate of first rectangle. 
r1: Bottom Right coordinate of first rectangle. 
l2: Top Left coordinate of second rectangle. 
r2: Bottom Right coordinate of second rectangle.

rectanglesOverlap

We need to write a function bool doOverlap(l1, r1, l2, r2) that returns true if the two given rectangles overlap. 

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
Note : It may be assumed that the rectangles are parallel to the coordinate axis.
One solution is to one by one pick all points of one rectangle and see if the point lies inside the other rectangle or not. 
    https://www.geeksforgeeks.org/how-to-check-if-a-given-point-lies-inside-a-polygon/
    This can be done using the algorithm discussed here. https://www.geeksforgeeks.org/how-to-check-if-a-given-point-lies-inside-a-polygon/ 
Following is a simpler approach. Two rectangles do not overlap if one of the following conditions is true. 
1) One rectangle is above top edge of other rectangle. 
2) One rectangle is on left side of left edge of other rectangle.
We need to check above cases to find out if given rectangles overlap or not. Following is the implementation of the above approach. 
    */
    class OverlapRectangles
    {
        class Point
        {
            public int x, y;
        }

        // Returns true if two rectangles (l1, r1)
        // and (l2, r2) overlap
        static bool doOverlap(Point l1, Point r1,
                            Point l2, Point r2)
        {
            // If one rectangle is on left side of other
            if (l1.x >= r2.x || l2.x >= r1.x)
            {
                return false;
            }

            // If one rectangle is above other
            if (l1.y <= r2.y || l2.y <= r1.y)
            {
                return false;
            }
            return true;
        }

        // Driver Code
        public static void Main()
        {
            Point l1 = new Point(), r1 = new Point(),
                    l2 = new Point(), r2 = new Point();
            l1.x = 0; l1.y = 10; r1.x = 10; r1.y = 0;
            l2.x= 5; l2.y = 5; r2.x = 15; r2.y = 0;
            if (doOverlap(l1, r1, l2, r2))
            {
                Console.WriteLine("Rectangles Overlap");
            }
            else
            {
                Console.WriteLine("Rectangles Don't Overlap");
            }
        }
        /*
         Output: 



Rectangles Overlap
Time Complexity of above code is O(1) as the code doesn’t have any loop or recursion. 
        */
    }

    // This code is contributed by
    // Rajput-Ji

}
