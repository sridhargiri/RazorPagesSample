// C# program to illustrate the 
// concept of abstract class 
using System;

namespace ConsoleApp1
{

    // abstract class 'G' 
    public abstract class G
    {
        public G()
        {

        }
        // abstract method 'gfg1()' 
        public abstract void gfg1();
    }

    // class 'G' inherit 
    // in child class 'G1' 
    public class G1 : G
    {
        public G1()
        {

        }
        // abstract method 'gfg1()' 
        // declare here with 
        // 'override' keyword 
        public override void gfg1()
        {
            Console.WriteLine("Class name is G1");
        }
    }

    // class 'G' inherit in 
    // another child class 'G2' 
    public class G2 : G
    {

        // same as the previous class 
        public override void gfg1()
        {
            Console.WriteLine("Class name is G2");
        }
    }

    public class AbstractOverride
    {

        // Main Method 
        public static void Main()
        {
            byte num = 100;
            dynamic val = num;
            Console.WriteLine(val.GetType());
            val += 100;
            Console.WriteLine(val.GetType());
            // 'obj' is object of class 
            // 'G' class ' 
            // G' cannot 
            // be instantiate 
            G obj;

            // instantiate class 'G1' 
            obj = new G1();

            // call 'gfg1()' of class 'G1' 
            obj.gfg1();

            // instantiate class 'G2' 
            obj = new G2();

            // call 'gfg1()' of class 'G2' 
            obj.gfg1();
        }
    }
    // virtual override sample
    class AFoo
    {
        public void foo()
        {
            Console.WriteLine("A::foo()");
        }
        public virtual void bar()
        {
            Console.WriteLine("A::bar()");
        }
    }

    class BFoo : AFoo
    {
        public new void foo()
        {
            Console.WriteLine("B::foo()");
        }
        public override void bar()
        {
            Console.WriteLine("B::bar()");
        }
    }

    public class VirtualOverrideCopy
    {
        public static void Main(string[] args)
        {
            // equivalent to B b = new B() and A a = new B()
            BFoo b = new BFoo();
            AFoo a = b;
            a.foo(); // Prints A::foo
            b.foo(); // Prints B::foo
            a.bar(); // Prints B::bar
            b.bar(); // Prints B::bar
        }
    }
    public class SingletonMain
    {
        static void Boxunbox()
        {
            int i = 10;
            object o = i; // boxing
            o = 20;
            Console.WriteLine(i); // output: 10
        }
        public static void Main(string[] args)
        {
            Boxunbox(); 
            var o1 = Singleton.Instance;
            var o2 = Singleton.Instance;
            var o3 = Singleton.Instance;
            var o4 = Singleton.Instance;
        }
    }
    public class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    public interface IWork
    {
        void Func1();
        void Func2();

    }
    public abstract class WorkClass : IWork
    {
        public void Func1()
        {
            Console.WriteLine("Calling Func1");
        }
        public abstract void Func2();

    }

    public class MyClass : WorkClass
    {
        public static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.Func1();
            myClass.Func2();
        }

        public override void Func2()
        {
            Console.WriteLine("Calling Func2");

        }
    }
    public class BaseA
    {
        public virtual void Sa()
        {
            Console.WriteLine("Class A");
        }
    }
    public class BaseB : BaseA
    {
        public override void Sa()
        {
            Console.WriteLine("Class B");
        }
    }
    public class VirtualOverride
    {
        public static void Main(string[] args)
        {


            BaseA obj = new BaseA();
            BaseA obj1 = new BaseB();
            BaseB obj2 = new BaseB();
            //BaseB Obj3 = new BaseA();
            obj.Sa();
            obj1.Sa();
            obj2.Sa();
            //obj3.Sa(); error!
        }
    }



    // Abstract class
    abstract class Abstract_class
    {

        // Method declaration for abstract class
        public abstract void abstract_method();
    }

    // Parent class
    class Abstract_class2 : Abstract_class
    {

        // Method definition for abstract method
        public override void abstract_method()
        {
            Console.WriteLine("Abstract method is called");
        }
    }

    // First child class extends parent
    class Abstract_class3 : Abstract_class2
    {
        public override void abstract_method()
        {
            Console.WriteLine("Abstract method is called in Abstract_class3");
        }
        // Method definition
        public void Mymethod1()
        {
            Console.WriteLine("Method from GFG2 class");
        }
    }

    // Second child class extends first child class
    class GFG3 : Abstract_class3
    {

        public override void abstract_method()
        {
            Console.WriteLine("Abstract method is called in GFG Class");
        }
        // Method definition
        public void Mymethod2()
        {
            Console.WriteLine("Method from GFG3 class");
        }
    }

    public class AbstractOverride2
    {

        // Driver code
        public static void Main(String[] args)
        {

            // Creating an object of GFG3 class
            GFG3 obj = new GFG3();

            // Call the methods using GFG3 class
            obj.abstract_method();
            obj.Mymethod1();
            obj.Mymethod2();
        }
    }
}