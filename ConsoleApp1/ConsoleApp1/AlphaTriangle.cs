using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class AlphaTriangle
    {
        public static void Main(string[] args)
        {
            char ch = 'A';
            int i, j, k, m;
            for (i = 1; i <= 6; i++)
            {
                for (j = 6; j >= i; j--)
                    Console.Write(" ");
                for (k = 1; k <= i; k++)
                    Console.Write(ch++);
                ch--;
                for (m = 1; m < i; m++)
                    Console.Write(--ch);
                Console.Write("\n");
                ch = 'A';
            }
        }
    }
    /*
6	1	0
5	2	1
4	3	2
3	4	3
2	5	4
1	6	5
     */
}
