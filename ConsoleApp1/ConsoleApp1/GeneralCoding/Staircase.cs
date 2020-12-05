using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Staircase
    {
        /// <summary>
        /// Pring right aligned staircase
        /// </summary>
        /// <param name="n"></param>
        static void staircase(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i; k++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }

        }

        public static void Main(string[] args)
        {
            staircase(6);
        }
    }
}
