using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PrePost
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Pre increment");
            int a = 400;
            int b, c;
            b = 5 + (++a);
            Console.WriteLine("The value of a : {0}", a);
            Console.WriteLine("The value of b : {0}", b);
            c = 5 + (--a);
            Console.WriteLine("The value of a : {0}", a);
            Console.WriteLine("The value of c : {0}", c);

            Console.WriteLine("Post increment");
            a = 400;
            b = 5 + (a++);
            Console.WriteLine("The value of a : {0}", a);
            Console.WriteLine("The value of b : {0}", b);
            c = 5 + (a--);
            Console.WriteLine("The value of a : {0}", a);
            Console.WriteLine("The value of c : {0}", c);
            Console.ReadKey();
        }
    }
}
