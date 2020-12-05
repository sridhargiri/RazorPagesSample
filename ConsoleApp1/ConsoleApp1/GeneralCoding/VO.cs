using System;
namespace ConsoleApp1
{

    public class classA
    {
        public classA()
        {

        }
        public virtual string Print()
        {
            return "classA";
        }
    }

    public class classB : classA
    {
        public classB()
        {

        }
        public override string Print()
        {
            return "classB";
        }
    }

    public class classC : classB
    {
        public classC()
        {

        }
        public override string Print()
        {
            return "ClassC";
        }
    }
    public class ClassOne { public void M1() { } }
    public class ClassTwo: ClassOne { public new void M1() { } }
    public class VO
    {
        public static void Main()
        {
            ClassOne c1 = new ClassTwo();
            c1.M1();
            classA a = new classC();
            Console.WriteLine(a.Print());
        }
    }
}
