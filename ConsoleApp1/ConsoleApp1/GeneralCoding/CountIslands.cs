using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-number-of-islands/
    Find the number of islands | Set 1 (Using DFS)
    Given a boolean 2D matrix, find the number of islands. A group of connected 1s forms an island. For example, the below matrix contains 5 islands
Example: 
 

Input : mat[][] = {{1, 1, 0, 0, 0},
                   {0, 1, 0, 0, 1},
                   {1, 0, 0, 1, 1},
                   {0, 0, 0, 0, 0},
                   {1, 0, 1, 0, 1}}
Output : 5
This is a variation of the standard problem: “Counting the number of connected components in an undirected graph”. 
    Before we go to the problem, let us understand what is a connected component. A connected component of an undirected graph is a subgraph in which every two vertices are connected to each other by a path(s), and which is connected to no other vertices outside the subgraph. 
For example, the graph shown below has three connected components. 
    A graph where all vertices are connected with each other has exactly one connected component, consisting of the whole graph. Such a graph with only one connected component is called a Strongly Connected Graph.
The problem can be easily solved by applying DFS() on each component. In each DFS() call, a component or a sub-graph is visited. We will call DFS on the next un-visited component. The number of calls to DFS() gives the number of connected components. BFS can also be used.
What is an island? 
A group of connected 1s forms an island. For example, the below matrix contains 4 islands
    A cell in 2D matrix can be connected to 8 neighbours. So, unlike standard DFS(), where we recursively call for all adjacent vertices, here we can recursively call for 8 neighbours only. 
    We keep track of the visited 1s so that they are not visited again.

     */
    class CountIslands
    {
        // No of rows
        // and columns
        static int ROW = 5, COL = 5;

        // A function to check if
        // a given cell (row, col)
        // can be included in DFS
        static bool isSafe(int[,] M, int row,
                           int col, bool[,] visited)
        {
            // row number is in range,
            // column number is in range
            // and value is 1 and not
            // yet visited
            return (row >= 0) && (row < ROW) && (col >= 0) && (col < COL) && (M[row, col] == 1 && !visited[row, col]);
        }

        // A utility function to do
        // DFS for a 2D boolean matrix.
        // It only considers the 8
        // neighbors as adjacent vertices
        static void DFS(int[,] M, int row,
                        int col, bool[,] visited)
        {
            // These arrays are used to
            // get row and column numbers
            // of 8 neighbors of a given cell
            int[] rowNbr = new int[] { -1, -1, -1, 0,
                                   0, 1, 1, 1 };
            int[] colNbr = new int[] { -1, 0, 1, -1,
                                   1, -1, 0, 1 };

            // Mark this cell
            // as visited
            visited[row, col] = true;

            // Recur for all
            // connected neighbours
            for (int k = 0; k < 8; ++k)
                if (isSafe(M, row + rowNbr[k], col + colNbr[k], visited))
                    DFS(M, row + rowNbr[k],
                        col + colNbr[k], visited);
        }

        // The main function that
        // returns count of islands
        // in a given boolean 2D matrix
        static int countIslands(int[,] M)
        {
            // Make a bool array to
            // mark visited cells.
            // Initially all cells
            // are unvisited
            bool[,] visited = new bool[ROW, COL];

            // Initialize count as 0 and
            // traverse through the all
            // cells of given matrix
            int count = 0;
            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                    if (M[i, j] == 1 && !visited[i, j])
                    {
                        // If a cell with value 1 is not
                        // visited yet, then new island
                        // found, Visit all cells in this
                        // island and increment island count
                        DFS(M, i, j, visited);
                        ++count;
                    }

            return count;
        }

        // Driver Code
        public static void Main()
        {
            int[,] M = new int[,] { { 1, 1, 0, 0, 0 },
                                  { 0, 1, 0, 0, 1 },
                                  { 1, 0, 0, 1, 1 },
                                  { 0, 0, 0, 0, 0 },
                                  { 1, 0, 1, 0, 1 } };
            Console.Write("Number of islands is: " + countIslands(M));
            /*
             Output
Number of islands is: 5
Time complexity: O(ROW x COL)
            */
        }
    }
    //Alternative solution without creating visited matrix:
    public class CountIslandsNoExtraSpace
    {

        // A utility function to do DFS for a 2D
        //  boolean matrix. It only considers
        // the 8 neighbours as adjacent vertices
        static void DFS(int[,] M, int i, int j, int ROW, int COL)
        {

            // Base condition
            // if i less than 0 or j less than 0 or i greater than ROW-1 or j greater than COL-  or if M[i][j] != 1 then we will simply return
            if (i < 0 || j < 0 || i > (ROW - 1) || j > (COL - 1) || M[i, j] != 1)
            {
                return;
            }

            if (M[i, j] == 1)
            {
                M[i, j] = 0;
                DFS(M, i + 1, j, ROW, COL);     //right side traversal
                DFS(M, i - 1, j, ROW, COL);     //left side traversal
                DFS(M, i, j + 1, ROW, COL);     //upward side traversal
                DFS(M, i, j - 1, ROW, COL);     //downward side traversal
                DFS(M, i + 1, j + 1, ROW, COL); //upward-right side traversal
                DFS(M, i - 1, j - 1, ROW, COL); //downward-left side traversal
                DFS(M, i + 1, j - 1, ROW, COL); //downward-right side traversal
                DFS(M, i - 1, j + 1, ROW, COL); //upward-left side traversal
            }
        }

        static int countIslands(int[,] M)
        {
            int ROW = M.GetLength(0);
            int COL = M.GetLength(1);
            int count = 0;
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (M[i, j] == 1)
                    {
                        M[i, j] = 0;
                        count++;
                        DFS(M, i + 1, j, ROW, COL);     //right side traversal
                        DFS(M, i - 1, j, ROW, COL);     //left side traversal
                        DFS(M, i, j + 1, ROW, COL);     //upward side traversal
                        DFS(M, i, j - 1, ROW, COL);     //downward side traversal
                        DFS(M, i + 1, j + 1, ROW, COL); //upward-right side traversal
                        DFS(M, i - 1, j - 1, ROW, COL); //downward-left side traversal
                        DFS(M, i + 1, j - 1, ROW, COL); //downward-right side traversal
                        DFS(M, i - 1, j + 1, ROW, COL); //upward-left side traversal
                    }
                }
            }
            return count;
        }

        // Driver code
        static void Main()
        {
            int[,] M = {{1, 1, 0, 0, 0},
                 {0, 1, 0, 0, 1},
                 {1, 0, 0, 1, 1},
                 {0, 0, 0, 0, 0},
                 {1, 0, 1, 0, 1}};

            Console.Write("Number of islands is: " + countIslands(M));
            /*
             Output
Number of islands is: 5
Time complexity: O(ROW x COL)
https://www.geeksforgeeks.org/find-the-number-of-islands-set-2-using-disjoint-set/
            */
        }
    }
}
