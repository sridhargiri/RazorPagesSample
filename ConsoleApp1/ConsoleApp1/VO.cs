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
    public class VO
    {
        public static void Main()
        {
            classA a = new classC();
            Console.WriteLine(a.Print());
        }
    }
}
