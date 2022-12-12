using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MinStepsKnight
    {
        /*
		 Minimum steps to reach target by a Knight | Set 1
		Difficulty Level : Hard
		 Last Updated : 23 Jun, 2020
		Given a square chessboard of N x N size, the position of Knight and position of a target is given. 
        We need to find out the minimum steps a Knight will take to reach the target position.

		Examples:



		In above diagram Knight takes 3 step to reach 
		from (4, 5) to (1, 1) (4, 5) -> (5, 3) -> (3, 2) 
		-> (1, 1)  as shown in diagram
		
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
        /*
         Output: 20
    Complexity Analysis:

    Time complexity: O(N^2).
    At worst case, all the cells will be visited so time complexity is O(N^2).
    Auxiliary Space: O(N^2).
    The nodes are stored in queue. So the space Complexity is O(N^2).
        https://www.geeksforgeeks.org/minimum-steps-reach-target-knight/
        image -> https://media.geeksforgeeks.org/wp-content/uploads/KnightChess.jpg
        */
    }
    /*
     https://www.geeksforgeeks.org/possible-moves-knight/?ref=gcse
    Possible moves of knight
    Given a chess board of dimension m * n. Find number of possible moves where knight can be moved on a chessboard from given position. 
    If mat[i][j] = 1 then the block is filled by something else, otherwise empty. 
    Assume that board consist of all pieces of same color, i.e., there are no blocks being attacked

    Examples: 

Input : mat[][] = {{1, 0, 1, 0},
                   {0, 1, 1, 1},
                   {1, 1, 0, 1},
                   {0, 1, 1, 1}}
        pos = (2, 2)
Output : 4
Knight can moved from (2, 2) to (0, 1), (0, 3), (1, 0) ans (3, 0).

We can observe that knight on a chessboard moves either: 

Two moves horizontal and one move vertical 
Two moves vertical and one move horizontal

The idea is to store all possible moves of knight and then count number of valid moves. A move will be invalid if:
1.  A block is already occupied by another piece. 
2.  Move is out of chessboard.

Implementation:

     */
    public class PossibleMovesKnight
    {
        static int n = 4;
        static int m = 4;

        // To calculate possible moves
        static int findPossibleMoves(int[,] mat, int p, int q)
        {
            /*
            based on above observation,
            1,2	
            2,1	    reversed
            1,-2
            -2,1	reversed
            -1,2
            2,-1	reversed
            -1,-2
            -2,-1	reversed
            
            forming X and Y array as under
             */
            int[] X = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] Y = { 1, 2, 2, 1, -1, -2, -2, -1 };

            int count = 0;

            // Check if each possible
            // move is valid or not
            // iterate till 8, since 8 x 8 board
            for (int i = 0; i < 8; i++)
            {

                // Position of knight
                // after move
                int x = p + X[i];
                int y = q + Y[i];

                // count valid moves
                if (x >= 0 && y >= 0 && x < n && y < m && mat[x, y] == 0)
                    count++;
            }

            // Return number
            // of possible moves
            return count;
        }

        // Driver Code
        static public void Main()
        {
            int[,] mat = { { 1, 0, 1, 0 },
                       { 0, 1, 1, 1 },
                       { 1, 1, 0, 1 },
                       { 0, 1, 1, 1 }};

            int p = 2, q = 2;

            Console.WriteLine(findPossibleMoves(mat, p, q));
            /*
            Output: 4
            Time Complexity: O(1) 
            Auxiliary Space: O(1)
             */
        }
    }
    /*
     https://www.geeksforgeeks.org/the-knights-tour-problem-backtracking-1/?ref=gcse
    The Knight’s tour problem | Backtracking-1
Difficulty Level : Hard

    Backtracking is an algorithmic paradigm that tries different solutions until finds a solution that “works”. Problems that are typically solved using the backtracking technique have the following property in common. These problems can only be solved by trying every possible configuration and each configuration is tried only once. A Naive solution for these problems is to try all configurations and output a configuration that follows given problem constraints. Backtracking works incrementally and is an optimization over the Naive solution where all possible configurations are generated and tried.
For example, consider the following Knight’s Tour problem. 
    http://en.wikipedia.org/wiki/Knight%27s_tour

    Problem Statement:
Given a N*N board with the Knight placed on the first block of an empty board. 
    Moving according to the rules of chess knight must visit each square exactly once. 
    Print the order of each cell in which they are visited.
    Example:

Input : 
N = 8
Output:
0  59  38  33  30  17   8  63
37  34  31  60   9  62  29  16
58   1  36  39  32  27  18   7
35  48  41  26  61  10  15  28
42  57   2  49  40  23   6  19
47  50  45  54  25  20  11  14
56  43  52   3  22  13  24   5
51  46  55  44  53   4  21  12
The path followed by Knight to cover all the cells
Following is a chessboard with 8 x 8 cells. Numbers in cells indicate the move number of Knight. 

    Let us first discuss the Naive algorithm for this problem and then the Backtracking algorithm.

Naive Algorithm for Knight’s tour 
The Naive Algorithm is to generate all tours one by one and check if the generated tour satisfies the constraints. 

while there are untried tours
{ 
   generate the next tour 
   if this tour covers all squares 
   { 
      print this path;
   }
}

Backtracking works in an incremental way to attack problems. 
    Typically, we start from an empty solution vector and one by one add items (Meaning of item varies from problem to problem. In the context of Knight’s tour problem, an item is a Knight’s move). 
    When we add an item, we check if adding the current item violates the problem constraint, if it does then we remove the item and try other alternatives. 
    If none of the alternatives works out then we go to the previous stage and remove the item added in the previous stage. If we reach the initial stage back then we say that no solution exists. 
    If adding an item doesn’t violate constraints then we recursively add items one by one. If the solution vector becomes complete then we print the solution

    Backtracking Algorithm for Knight’s tour 

Following is the Backtracking algorithm for Knight’s tour problem. 

If all squares are visited 
    print the solution
Else
   a) Add one of the next moves to solution vector and recursively 
   check if this move leads to a solution. (A Knight can make maximum 
   eight moves. We choose one of the 8 moves in this step).
   b) If the move chosen in the above step doesn't lead to a solution
   then remove this move from the solution vector and try other 
   alternative moves.
   c) If none of the alternatives work then return false (Returning false 
   will remove the previously added item in recursion and if false is 
   returned by the initial call of recursion then "no solution exists" )
Following are implementations for Knight’s tour problem. It prints one of the possible solutions in 2D matrix form. Basically, the output is a 2D 8*8 matrix with numbers from 0 to 63 and these numbers show steps made by Knight


     */
    public class KnightsTourProblem
    {
        static int N = 8;

        /* A utility function to
        check if i,j are valid
        indexes for N*N chessboard */
        static bool isSafe(int x, int y, int[,] sol)
        {
            return (x >= 0 && x < N && y >= 0 && y < N
                    && sol[x, y] == -1);
        }

        /* A utility function to
        print solution matrix sol[N][N] */
        static void printSolution(int[,] sol)
        {
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                    Console.Write(sol[x, y] + " ");
                Console.WriteLine();
            }
        }

        /* This function solves the
        Knight Tour problem using
        Backtracking. This function
        mainly uses solveKTUtil() to
        solve the problem. It returns
        false if no complete tour is
        possible, otherwise return true
        and prints the tour. Please note
        that there may be more than one
        solutions, this function prints
        one of the feasible solutions. */
        static bool solveKT()
        {
            int[,] sol = new int[8, 8];

            /* Initialization of
            solution matrix */
            for (int x = 0; x < N; x++)
                for (int y = 0; y < N; y++)
                    sol[x, y] = -1;

            /* xMove[] and yMove[] define
               next move of Knight.
               xMove[] is for next
               value of x coordinate
               yMove[] is for next
               value of y coordinate */
            int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

            // Since the Knight is
            // initially at the first block
            sol[0, 0] = 0;

            /* Start from 0,0 and explore
            all tours using solveKTUtil() */
            if (!solveKTUtil(0, 0, 1, sol, xMove, yMove))
            {
                Console.WriteLine("Solution does "
                                  + "not exist");
                return false;
            }
            else
                printSolution(sol);

            return true;
        }

        /* A recursive utility function
        to solve Knight Tour problem */
        static bool solveKTUtil(int x, int y, int movei,
                                int[,] sol, int[] xMove,
                                int[] yMove)
        {
            int k, next_x, next_y;
            if (movei == N * N)
                return true;

            /* Try all next moves from
            the current coordinate x, y */
            for (k = 0; k < 8; k++)
            {
                next_x = x + xMove[k];
                next_y = y + yMove[k];
                if (isSafe(next_x, next_y, sol))
                {
                    sol[next_x, next_y] = movei;
                    if (solveKTUtil(next_x, next_y, movei + 1,
                                    sol, xMove, yMove))
                        return true;
                    else
                        // backtracking
                        sol[next_x, next_y] = -1;
                }
            }

            return false;
        }

        // Driver Code
        public static void Main()
        {
            // Function Call
            solveKT();
        }
        /*
         Output
  0  59  38  33  30  17   8  63 
 37  34  31  60   9  62  29  16 
 58   1  36  39  32  27  18   7 
 35  48  41  26  61  10  15  28 
 42  57   2  49  40  23   6  19 
 47  50  45  54  25  20  11  14 
 56  43  52   3  22  13  24   5 
 51  46  55  44  53   4  21  12 
Time Complexity : 
There are N2 Cells and for each, we have a maximum of 8 possible moves to choose from, so the worst running time is O(8N^2).

Auxiliary Space: O(N2)

Important Note:
No order of the xMove, yMove is wrong, but they will affect the running time of the algorithm drastically. 
        For example, think of the case where the 8th choice of the move is the correct one, and before that our code ran 7 different wrong paths. 
        It’s always a good idea a have a heuristic than to try backtracking randomly. Like, in this case, we know the next step would probably be in the south or east direction, then checking the paths which lead their first is a better strategy.

Note that Backtracking is not the best solution for the Knight’s tour problem. See the below article for other better solutions. 
        The purpose of this post is to explain Backtracking with an example. 
        https://www.geeksforgeeks.org/warnsdorffs-algorithm-knights-tour-problem/

Refer:
http://see.stanford.edu/materials/icspacs106b/H19-RecBacktrackExamples.pdf 
http://www.cis.upenn.edu/~matuszek/cit594-2009/Lectures/35-backtracking.ppt 
http://mathworld.wolfram.com/KnightsTour.html 
http://en.wikipedia.org/wiki/Knight%27s_tour 
         */
    }

}
