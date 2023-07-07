using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TCare
    {
        delegate void Test();

        public static void Main(string[] args)
        {
            List<Test> tests = new List<Test>();
            int i = 0;
            for (; i < 10; i++)
            {
                tests.Add(delegate { Console.WriteLine(i); });
            }
            foreach (var test in tests)
            {
                test();
            }
            // print 10 ten times
        }
    }
    //public class TCare2
    //{
    //    private static readonly string str;
    //    public TCare2()
    //    {
    //        str = "Hello";
    //        Console.WriteLine(str);
    //    }
    //    public TCare2(string newStr)
    //    {
    //        str = newStr + " - The Changed Value";
    //        Console.WriteLine(str);
    //    }
    //    public static void Main()
    //    {
    //        TCare2 te = new TCare2();
    //        TCare2 new_te = new TCare2("Hi");
    //    }
    //}
}
