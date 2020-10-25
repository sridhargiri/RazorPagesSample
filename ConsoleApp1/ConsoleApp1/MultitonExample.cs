using System;
using System.Collections.Generic;
namespace ConsoleApp1
{

    public enum MultitonType
    {
        Zero,
        One,
        Two
    }

    public class Multiton
    {
        private static readonly Dictionary<MultitonType, Multiton> instances =
            new Dictionary<MultitonType, Multiton>();

        private MultitonType type;

        private Multiton(MultitonType type)
        {
            this.type = type;
        }

        public static Multiton GetInstance(MultitonType type)
        {
            // Lazy init (not thread safe as written)
            // Recommend using Double Check Locking if needing thread safety
            if (!instances.TryGetValue(type, out var instance))
            {
                instance = new Multiton(type);

                instances.Add(type, instance);
            }

            return instance;
        }

        public override string ToString()
        {
            return "My type is " + this.type;
        }
        static void ChangeReferenceType(Student std2)
        {
            std2.StudentName = "Steve";
        }
        // Sample usage
        public static void Main()
        {

            Student std1 = new Student();
            std1.StudentName = "Bill";
            Console.WriteLine(std1.StudentName);

            ChangeReferenceType(std1);

            Console.WriteLine(std1.StudentName);
            var m0 = GetInstance(MultitonType.Zero);
            var m1 = Multiton.GetInstance(MultitonType.One);
            var m2 = Multiton.GetInstance(MultitonType.Two);

            Console.WriteLine(m0);
            Console.WriteLine(m1);
            Console.WriteLine(m2);
            A v1 = new A();
            v1.val = 10;
            methodtoshowref(ref v1);
            Console.WriteLine(v1.val);
        }
        public static void methodtoshowref(ref A obj)
        {
            obj = null;
        }
    }

    public class A
    {
        public int val
        {
            get;
            set;
        }
    }
    internal class Student
    {
        public string StudentName { get; internal set; }
    }
}