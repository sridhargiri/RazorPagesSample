using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MatrixClass<T>
    {
        public static T[,] TransposeMatrix(T[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);

            var result = new T[columns, rows];

            for (var c = 0; c < columns; c++)
            {
                for (var r = 0; r < rows; r++)
                {
                    result[c, r] = matrix[r, c];
                }
            }

            return result;
        }
    }
    public class MatrixTranspose
    {

        public static void Main(string[] args)
        {
            int[,] matris = new int[5, 8]
        {
            {1  , 2 , 3 , 4 , 5 , 6 , 7 , 8 },
            {9  , 10, 11, 12, 13, 14, 15, 16},
            {17 , 18, 19, 20, 21, 22, 23, 24},
            {25 , 26, 27, 28, 29, 30, 31, 32},
            {33 , 34, 35, 36, 37, 38, 39, 40},

        };
            var tMatrix = MatrixClass<int>.TransposeMatrix(matris);
            for (int i = 0; i < tMatrix.GetLength(0); i++)
            {

                for (int j = 0; j < tMatrix.GetLength(1); j++)
                {
                    Console.Write(tMatrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
