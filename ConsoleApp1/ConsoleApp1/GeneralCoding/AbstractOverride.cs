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
            Console.WriteLine("Class name is  G2");
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

    class VirtualOverrrideCopy
    {
        static int Main(string[] args)
        {
            BFoo b = new BFoo();
            AFoo a = b;
            a.foo(); // Prints A::foo
            b.foo(); // Prints B::foo
            a.bar(); // Prints B::bar
            b.bar(); // Prints B::bar
            return 0;
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
            Boxunbox(); var o1 = Singleton.Instance;
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
}