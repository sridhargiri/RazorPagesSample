using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/tiling-problem/
    Tiling Problem

Geek Week
Given a “2 x n” board and tiles of size “2 x 1”, count the number of ways to tile the given board using the 2 x 1 tiles. A tile can either be placed horizontally i.e., as a 1 x 2 tile or vertically i.e., as 2 x 1 tile. 

Examples: 

Input: n = 4

Output: 3

Explanation:



For a 2 x 4 board, there are 3 ways

All 4 vertical
All 4 horizontal
2 vertical and 2 horizontal
Input: n = 3

Output: 2

Explanation:

We need 2 tiles to tile the board of size  2 x 3.

We can tile the board using following ways

Place all 3 tiles vertically.
Place 1 tile vertically and remaining 2 tiles horizontally.
 
Implementation – 

Let “count(n)” be the count of ways to place tiles on a “2 x n” grid, we have following two ways to place first tile. 
1) If we place first tile vertically, the problem reduces to “count(n-1)” 
2) If we place first tile horizontally, we have to place second tile also horizontally. So the problem reduces to “count(n-2)” 
Therefore, count(n) can be written as below. 

   count(n) = n if n = 1 or n = 2
   count(n) = count(n-1) + count(n-2)
Here’s the code for the above approach:
     */
    class Tiles
    {
        static int getNoOfWays(int n)
        {
            // Base case
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return getNoOfWays(n - 1) + getNoOfWays(n - 2);
        }
        public static void Main(string[] args)
        {
            getNoOfWays(4); getNoOfWays(3);
            /*
             Output:

3
2
            */
        }
    }
}
