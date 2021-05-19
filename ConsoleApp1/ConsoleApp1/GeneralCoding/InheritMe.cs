using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class P
    {
        public void f(int i)
        {
            Console.WriteLine(i);
        }
    }
    class Q:P
    {
        public void f(int i)
        {
            Console.WriteLine(2*i);
        }
    }
    class InheritMe
    {
        static void Main(string[] args)
        {
            P x = new Q();
            Q y = new Q();
            P z = new Q(); x.f(1); ((P)y).f(1); z.f(1);
        }
    }
}
