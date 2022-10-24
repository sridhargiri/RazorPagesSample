using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GenericExample
    {
        static void Main()
        {
            var d = new GenericD();
            var p = new GenericP<GenericD>();
            p.N(d);//Displays In Generic B
        }
    }

    class GenericB
    {
        public  void GenericM()// Note, not virtual
        {
            Console.WriteLine("In class Generic B");
        }
    }

    class GenericD : GenericB
    {
        public  void GenericM()// new, not overload
        {
            Console.WriteLine("In class Generic D");
        }
    }

    class GenericP<T> where T : GenericB
    {
        public void N(T t)
        {
            t.GenericM();
        }
    }
}
