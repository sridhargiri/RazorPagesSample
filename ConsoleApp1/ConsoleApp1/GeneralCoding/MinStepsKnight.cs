using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MinStepsKnight
    {
        /*
		 Minimum steps to reach target by a Knight | Set 1
		Difficulty Level : Hard
		 Last Updated : 23 Jun, 2020
		Given a square chessboard of N x N size, the position of Knight and position of a target is given. We need to find out the minimum steps a Knight will take to reach the target position.

		Examples:



		In above diagram Knight takes 3 step to reach 
		from (4, 5) to (1, 1) (4, 5) -> (5, 3) -> (3, 2) 
		-> (1, 1)  as shown in diagram
		Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
		Approach:
		This problem can be seen as shortest path in unweighted graph. Therefore we use BFS to solve this problem. We try all 8 possible positions where a Knight can reach from its position. If reachable position is not already visited and is inside the board, we push this state into queue with distance 1 more than its parent state. Finally we return distance of target position, when it gets pop out from queue.

		Below code implements BFS for searching through cells, where each cell contains its coordinate and distance from starting node. In worst case, below code visits all cells of board, making worst-case time complexity as O(N^2)
		*/
        public class cell
        {
            public int x, y;
            public int dis;

            public cell(int x, int y, int dis)
            {
                this.x = x;
                this.y = y;
                this.dis = dis;
            }
        }

        // Utility method returns true 
        // if (x, y) lies inside Board 
        static bool isInside(int x, int y, int N)
        {
            if (x >= 1 && x <= N && y >= 1 && y <= N)
                return true;
            return false;
        }

        // Method returns minimum step 
        // to reach target position 
        static int minStepToReachTarget(int[] knightPos,
                                        int[] targetPos, int N)
        {
            // x and y direction, where a knight can move 
            int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
            int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

            // queue for storing states of knight in board 
            Queue<cell> q = new Queue<cell>();

            // push starting position of knight with 0 distance 
            q.Enqueue(new cell(knightPos[0],
                            knightPos[1], 0));

            cell t;
            int x, y;
            bool[,] visit = new bool[N + 1, N + 1];

            // make all cell unvisited 
            for (int i = 1; i <= N; i++)
                for (int j = 1; j <= N; j++)
                    visit[i, j] = false;

            // visit starting state 
            visit[knightPos[0], knightPos[1]] = true;

            // loop untill we have one element in queue 
            while (q.Count != 0)
            {
                t = q.Peek();
                q.Dequeue();

                // if current cell is equal to target cell, 
                // return its distance 
                if (t.x == targetPos[0] && t.y == targetPos[1])
                    return t.dis;

                // loop for all reachable states 
                for (int i = 0; i < 8; i++)
                {
                    x = t.x + dx[i];
                    y = t.y + dy[i];

                    // If reachable state is not yet visited and 
                    // inside board, push that state into queue 
                    if (isInside(x, y, N) && !visit[x, y])
                    {
                        visit[x, y] = true;
                        q.Enqueue(new cell(x, y, t.dis + 1));
                    }
                }
            }
            return int.MaxValue;
        }

        // Driver code 
        public static void Main(String[] args)
        {
            int N = 30;
            int[] knightPos = { 1, 1 };
            int[] targetPos = { 30, 30 };
            Console.WriteLine(
                minStepToReachTarget(
                    knightPos,
                    targetPos, N));
        }
    }
    /*
	 Output:
20
Complexity Analysis:

Time complexity: O(N^2).
At worst case, all the cells will be visited so time complexity is O(N^2).
Auxiliary Space: O(N^2).
The nodes are stored in queue. So the space Complexity is O(N^2).
	https://www.geeksforgeeks.org/minimum-steps-reach-target-knight/
	image -> https://media.geeksforgeeks.org/wp-content/uploads/KnightChess.jpg*/

}
