using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StaticExample
    {
        public int? m = 0;
        private static string staticvar = "";
        public StaticExample(int a=0,int b=0)
        {
            Console.WriteLine("Instance Constructor");
            m = 1;
        }
        private StaticExample()
        {
               m = 2;
        }
        protected StaticExample(int x, int y, int z)
        {
            m = 3;
        }

        static StaticExample()
        {
            staticvar = "staticvar";
            Console.WriteLine("THis is staticcc");
        }

        public static StaticExample b = new StaticExample();
        public static StaticExample BC
        {
            get
            {
                return b;
            }
        }

        static void Main()
        {
            Console.WriteLine(BC.m);
            Console.WriteLine(staticvar);
            Console.ReadKey();
        }
    }
}
