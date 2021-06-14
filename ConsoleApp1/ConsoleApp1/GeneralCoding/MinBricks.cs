using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimum-number-of-bricks-that-can-be-intersected/
    Minimum number of bricks that can be intersected
Last Updated : 03 Jun, 2021
Given a 2D array arr[][], representing width of bricks of the same height present on a wall, the task is to find the minimum number of bricks that can be intersected by drawing a straight line from the top to the bottom of the wall.
Note: A line is said to intersect a brick if it passes through the brick and is non-intersecting if it is touching a brick’s boundary.

Examples:

Input: arr[][] = {{1, 2, 2, 1}, {3, 1, 2}, {1, 3, 2}, {2, 4}, {3, 1, 2}, {1, 3, 1, 1}}



Output: 2
Explanation: Considering the top left corner of the 2D array as the origin, the line is drawn at the coordinate x = 4 on the x-axis, such that it crosses the bricks on the 1st and 4th level, resulting in the minimum number of bricks crossed.



Input: arr[][] = {{1, 1, 1}}
Output: 0
Explanation: The line can be drawn at x = 1 or x = 2 coordinate on the x-axis such that it does not cross any brick resulting in the minimum number of bricks crossed.

Naive Approach: The simplest approach is to consider straight lines that can be drawn on every possible coordinate on the x-axis, along the width of the wall, considering x = 0 at the top left corner of the wall. Then, calculate the number of bricks inserted in each case and print the minimum count obtained.
Time Complexity: O(N * M) where N is the total number of bricks and M is the total width of the wall
Auxiliary Space: O(1) 

Approach: To optimize the above approach, the idea is to store the number of bricks ending at a certain width on the x-axis in a hashmap, and then find the line where the most number of bricks end. After getting this count, subtract it from the total height of the wall to get the minimum number of bricks crossed. 

Follow the steps below to solve the problem:

Initialize a hashmap, M to store the number of bricks ending at a certain width on the x-axis.
Traverse the array, arr using the variable i to store row index
Initialize a variable, width as 0 to store the ending position.
Store the size of the current row in a variable X.
Iterate in the range [0, X-2] using the variable j
Increment the value of width by arr[i][j] and increment the value of width in M by 1.
Also, keep track of the most number of bricks ending at a certain width and store it in a variable, res.
Subtract the value of res from the overall height of the wall and store it in a variable, ans.
Print the value of ans as the result.
Below is the implementation of the above approach:
     */
    class MinBricks
    {
        static void leastBricks(List<List<int>> wall)
        {
            // Declare a hashmap
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Store the maximum number of
            // brick ending a point on x-axis
            int res = 0;

            // Iterate over all the rows
            foreach (List<int> list in wall)
            {

                // Initialize width as 0
                int width = 0;

                // Iterate over individual bricks
                for (int i = 0; i < list.Count - 1; i++)
                {

                    // Add the width of the current
                    // brick to the total width
                    width += list[i];

                    // Increment number of bricks
                    // ending at this width position
                    map[width]++;

                    // Update the variable, res
                    res = Math.Max(res, map[width]);
                }
            }

            // Print the answer
            Console.WriteLine(wall.Count - res);
        }
        public static void Main(string[] args)
        {
            {
                // Given Input
                List<List<int>> arr = new List<List<int>>();
                arr.Add(new List<int> { 1, 2, 2, 1 });
                arr.Add(new List<int> { 3, 1, 2 });
                arr.Add(new List<int> { 1, 3, 2 });
                arr.Add(new List<int> { 2, 4 });
                arr.Add(new List<int> { 3, 1, 2 });
                arr.Add(new List<int> { 1, 3, 1, 1 });


                // Function Call
                leastBricks(arr);//output 2

            }
        }
    }
}
