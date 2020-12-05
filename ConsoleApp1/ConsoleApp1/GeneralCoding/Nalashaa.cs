using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   public class Nalashaa
    {
        static void M(int i) { }
        public static void Main(string[] args)
        {
            var x = 5;
            dynamic y = 5;
            M(x);M(y);
        }
    }
}
