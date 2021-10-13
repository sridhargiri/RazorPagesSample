using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Ariba
    {
        public int getId(String a) { return 0; }
        public int getId(Object a) { return 1; }

        public int getId1(String a) { return 0; }
        public int getId1(List<int> a) { return 1; }
        static void Main(string[] args)
        {
            Ariba instance = new Ariba();
            Console.WriteLine(instance.getId(null));
            //Console.WriteLine(instance.getId1(null));
        }
    }
}
