using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ClassA
    {
        public virtual void F() { Console.WriteLine("A.F"); }
    }
    class ClassB : ClassA
    {
        public override void F() { Console.WriteLine("B.F"); }
    }
    class ClassC : ClassB
    {
        new public virtual void F() { Console.WriteLine("C.F"); }
    }
    class ClassD : ClassC
    {
        public override void F() { Console.WriteLine("D.F"); }
    }
    public class VirtualOverrideExample
    {
        static void Main()
        {
            ClassD d = new ClassD();
            ClassA a = d;
            ClassB b = d;
            ClassC c = d;
            a.F();
            b.F();
            c.F();
            d.F();
        }
    }
}
