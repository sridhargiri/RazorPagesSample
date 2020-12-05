using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SumDiagonals
    {
        static void PrintDiagonalSums(int[,] mat, int n)
        {
            int principal = 0, secondary = 0;
            for (int i = 0; i < n; i++)
            {
                principal += mat[i, i];
                secondary += mat[i, n - i - 1];
            }

            Console.WriteLine("{0}:{1}", principal, secondary);
        }
        public static int diagonalDifference(List<List<int>> arr)
        {
            int principal = 0, secondary = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                principal += arr[i][i];
                secondary += arr[i][arr.Count - i - 1];
            }
            return Math.Abs(principal - secondary);
        }
        public static void Main(string[] args)
        {
            int[,] a ={ { 1, 2, 3, 4 },
                        { 5, 6, 7, 8 },
                        { 1, 2, 3, 4 },
                        { 5, 6, 7, 8 } };

            PrintDiagonalSums(a, 4);
        }
    }
}
