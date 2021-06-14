using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



namespace ConsoleApp1

{

    class Base1

    {

        public Base1()

        {

            Console.WriteLine("It is Base  Class  Constructor");

        }

        ~Base1()

        {

            Console.WriteLine("It is Base  Class  Destructor");

        }

    }

    class Derived1 : Base1

    {

        public Derived1()

        {



            Console.WriteLine("It is Derived  Class  Constructor");

        }

        ~Derived1()

        {

            Console.WriteLine("It is Derived  Class  Destructor");

        }

    }

    class ConstructorInheritance

    {

        static void create()

        {

            Base1 obj = new Derived1();

        }

        static void Main()

        {

            create();

            GC.Collect();

            Console.Read();

        }

    }
    //constructor order https://stackoverflow.com/questions/1882692/c-sharp-constructor-execution-order
    public class ConstructorOrder
    {
        public static void Main()
        {
            var d = new D1();
        }
    }

    public class A1
    {
        public readonly C ac = new C("A");

        public A1()
        {
            Console.WriteLine("A");
        }
        public A1(string x) : this()
        {
            Console.WriteLine("A got " + x);
        }
    }

    public class B : A1
    {
        public readonly C bc = new C("B");

        public B() : base()
        {
            Console.WriteLine("B");
        }
        public B(string x) : base(x)
        {
            Console.WriteLine("B got " + x);
        }
    }

    public class D1 : B
    {
        public readonly C dc = new C("D");

        public D1() : this("ha")
        {
            Console.WriteLine("D");
        }
        public D1(string x) : base(x)
        {
            Console.WriteLine("D got " + x);
        }
    }

    public class C
    {
        public C(string caller)
        {
            Console.WriteLine(caller + "'s C.");
        }
    }
}

 