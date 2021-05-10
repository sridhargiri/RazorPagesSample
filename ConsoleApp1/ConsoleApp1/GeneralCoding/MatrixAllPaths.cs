using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/print-all-possible-paths-from-top-left-to-bottom-right-of-a-mxn-matrix/
    Print all possible paths from top left to bottom right of a mXn matrix
Difficulty Level : Medium
Last Updated : 06 Jan, 2021
The problem is to print all the possible paths from top left to bottom right of a mXn matrix with the constraints that from each cell you can either move only to right or down.

Examples : 

Input : 1 2 3
        4 5 6
Output : 1 4 5 6
         1 2 5 6
         1 2 3 6

Input : 1 2 
        3 4
Output : 1 2 4
         1 3 4
The algorithm is a simple recursive algorithm, from each cell first print all paths by going down and then print all paths by going right. Do this recursively for each cell encountered.

Following are implementation of the above algorithm. 
    */
    public class MatrixAllPaths
    {


        /* mat: Pointer to the starting of mXn matrix
    i, j: Current position of the robot (For the first call use 0,0)
    m, n: Dimentions of given the matrix
    pi: Next index to be filed in path array
    *path[0..pi-1]: The path traversed by robot till now (Array to hold the
                    path need to have space for at least m+n elements) */
        private static void printMatrix(int[,] mat, int m, int n,
                                        int i, int j, int[] path, int idx)
        {
            path[idx] = mat[i, j];

            // Reached the bottom of the matrix so we are left with
            // only option to move right
            if (i == m - 1)
            {
                for (int k = j + 1; k < n; k++)
                {
                    path[idx + k - j] = mat[i, k];
                }
                for (int l = 0; l < idx + n - j; l++)
                {
                    Console.Write(path[l] + " ");
                }
                Console.WriteLine();
                return;
            }

            // Reached the right corner of the matrix we are left with
            // only the downward movement.
            if (j == n - 1)
            {
                for (int k = i + 1; k < m; k++)
                {
                    path[idx + k - i] = mat[k, j];
                }
                for (int l = 0; l < idx + m - i; l++)
                {
                    Console.Write(path[l] + " ");
                }
                Console.WriteLine();
                return;
            }

            // Print all the paths that are possible after moving down
            printMatrix(mat, m, n, i + 1, j, path, idx + 1);

            // Print all the paths that are possible after moving right
            printMatrix(mat, m, n, i, j + 1, path, idx + 1);
        }

        // Driver code
        public static void Main(String[] args)
        {
            int m = 2;
            int n = 3;
            int[,] mat = { { 1, 2, 3 },
                        { 4, 5, 6 } };
            int maxLengthOfPath = m + n - 1;
            printMatrix(mat, m, n, 0, 0, new int[maxLengthOfPath], 0);
            /*
             Output: 



1 4 5 6
1 2 5 6
1 2 3 6
Note that in the above code, the last line of printAllPathsUtil() is commented, If we uncomment this line, we get all the paths from the top left to bottom right of a nXm matrix if the diagonal movements are also allowed. And also if moving to some of the cells are not permitted then the same code can be improved by passing the restriction array to the above function and that is left as an exercise
            */
        }
    }
    public class MatrixAllPathsEff
    {

        static List<List<int>> allPaths = new List<List<int>>();

        static void findPathsUtil(List<List<int>> maze,
                                  int m, int n, int i,
                                  int j, List<int> path,
                                  int indx)
        {

            // If we reach the bottom of maze,
            // we can only move right
            if (i == m - 1)
            {
                for (int k = j; k < n; k++)
                {

                    // path.append(maze[i][k])
                    path[indx + k - j] = maze[i][k];
                }

                // If we hit this block, it means one
                // path is completed. Add it to paths
                // list and print
                Console.Write("[" + path[0] + ", ");
                for (int z = 1; z < path.Count - 1; z++)
                {
                    Console.Write(path[z] + ", ");
                }
                Console.WriteLine(path[path.Count - 1] + "]");
                allPaths.Add(path);
                return;
            }

            // If we reach to the right most
            // corner, we can only move down
            if (j == n - 1)
            {
                for (int k = i; k < m; k++)
                {
                    path[indx + k - i] = maze[k][j];
                }

                // path.append(maze[j][k])
                // If we hit this block, it means one
                // path is completed. Add it to paths
                // list and print
                Console.Write("[" + path[0] + ", ");
                for (int z = 1; z < path.Count - 1; z++)
                {
                    Console.Write(path[z] + ", ");
                }
                Console.WriteLine(path[path.Count - 1] + "]");
                allPaths.Add(path);
                return;
            }

            // Add current element to the path list
            //path.append(maze[i][j])
            path[indx] = maze[i][j];

            // Move down in y direction and call
            // findPathsUtil recursively
            findPathsUtil(maze, m, n, i + 1,
                          j, path, indx + 1);

            // Move down in y direction and
            // call findPathsUtil recursively
            findPathsUtil(maze, m, n, i, j + 1,
                                path, indx + 1);
        }

        static void findPaths(List<List<int>> maze, int m, int n)
        {
            List<int> path = new List<int>();
            for (int i = 0; i < m + n - 1; i++)
            {
                path.Add(0);
            }
            findPathsUtil(maze, m, n, 0, 0, path, 0);
        }

        // Driver code
        static void Main()
        {
            List<List<int>> maze = new List<List<int>>();
            maze.Add(new List<int> { 1, 2, 3 });
            maze.Add(new List<int> { 4, 5, 6 });
            maze.Add(new List<int> { 7, 8, 9 });

            findPaths(maze, 3, 3);
            /*
             Output: 

[1, 4, 7, 8, 9]
[1, 4, 5, 8, 9]
[1, 4, 5, 6, 9]
[1, 2, 5, 8, 9]
[1, 2, 5, 6, 9]
[1, 2, 3, 6, 9]
            */
        }
    }
}
