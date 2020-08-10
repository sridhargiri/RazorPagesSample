using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



namespace ProgramCall

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

            Derived1 obj = new Derived1();

        }

        static void Main()

        {

            create();

            GC.Collect();

            Console.Read();

        }

    }
}

 