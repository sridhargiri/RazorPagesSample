using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DA
    {
        public DA()
        {
            Console.WriteLine("Created ClassA");
        }
        ~DA()
        {
            Console.WriteLine("Destructing -- ClassA");
        }
    }

    class DB : DA
    {
        public DB()
        {
            Console.WriteLine("Creating ClassB");
        }
        ~DB()
        {
            Console.WriteLine("Destructing -- ClassB");
        }
    }

    class DC : DB
    {
        public DC()
        {
            Console.WriteLine("Creating ClassC");
        }
        ~DC()
        {
            Console.WriteLine("Destructing -- ClassC");
        }
    }

    public class DestructorExample
    {
        static void Main(string[] args)
        {
            DC objC = new DC();
            Console.WriteLine("Object C is created..");
            objC = null;
            GC.Collect();
            Console.WriteLine("Object C is assigned to null.. Object now destructing..");
            Console.ReadLine();
        }
    }
}
