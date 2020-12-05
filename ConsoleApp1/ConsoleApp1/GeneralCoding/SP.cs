using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SP
    {
        //static void Main(string[] args)
        //{
        //    int x;
        //    x = Convert.ToInt32(Console.ReadLine());
        //    int c = 1;
        //    while (c <= x)
        //    {
        //        if (c % 2 == 0)
        //        {
        //            Console.WriteLine("ex while" + c + "\ttime");
        //        }
        //        c++;
        //    }
        //    Console.ReadLine();
        //}
        static void Main(string[] args)
        {
            int[] x = { 65, 66, 67, 68, 69, 70 }; fun(x); Console.ReadLine();

        }
        static void fun(params int[] x)
        {
            for (int i = 5; i > 0; i--)
            {
                x[i] = x[i] + 32;
                Console.WriteLine(Convert.ToChar(x[i]));
            }
        }
    }
}
