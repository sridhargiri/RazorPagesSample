using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class abcd
    {
        public static void Main(string[] args)
        {
            int i, j, n = 5;
            for ( i = 1; i <= n; i++)
            {
                for ( j = 1; j <= i; j++)
                {
                    Console.Write((char)(i + 64));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
