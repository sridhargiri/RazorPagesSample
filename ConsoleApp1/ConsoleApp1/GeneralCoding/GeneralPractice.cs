using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    delegate string del(string str);
    class DelSample
    {
        public static string DelegateSample(string a)
        {
            return a.Replace(',', '*');
        }
    }
    public class InterviewProgram
    {
        public static void Main(string[] args)
        {
            del str1 = new del(DelSample.DelegateSample);
            str1 += a => { return a.Replace(',', '-'); };
            string str = str1("Welcome,,friends,,to,,TechBeamers");
            Console.WriteLine(str);
        }
    }
    public class WhatIstheOutput
    {
        public static void Main(string[] args)
        {
            int n = 5;
            int x = 4;
            int z, c, k;
            z = 3 * x * x + 2 * x + 4 / x + 8;
            for (c = 1; c <= n; c++)
            {
                for (k = 1; k <= c; k++)
                {
                    Console.Write(Convert.ToString(Convert.ToChar(z)));
                    z++;
                }
                Console.WriteLine();
            }
        }
    }
    public class BaseDer
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            int i = 10;
            d.Func(i);
            
        }
    }
    public class Base
    {
        public virtual void Func(int x)
        {
            Console.WriteLine("Base.Func(int)");
        }
    }
    public class Derived : Base
    {
        public override void Func(int x)
        {
            Console.WriteLine("Derived.Func(int)");
        }
        public void Func(object o)
        {
            Console.WriteLine("Derived.Func(object)");
        }
    }
    public class StringEqualise
    {
        public static void Main(string[] args)
        {
            string str1 = "TechBeamers";
            string str2 = "Techbeamers";
            if (str1 == str2)
                Console.WriteLine("Both Strings are Equal");
            else
                Console.WriteLine("Both Strings are Unequal");
            if (str1.Equals(str2))
                Console.WriteLine("Both Strings are Equal");
            else
                Console.WriteLine("Both Strings are Unequal");
        }
    }
    /*
    https://www.techbeamers.com/csharp-coding-interview-questions-developers/
    guess the output of below fragment
    answer will be 32333435363738394041 because space ascii value = 32 that will get summed upon each iteration
    */
    public class OneTwoThree
    {
        public static void Main()
        {
            for (int x = 0; x < 10; x++)
            {
                Console.Write(x + ' ');
            }
        }
    }
    public class NullArgs
    {
        public NullArgs(Object o)
        {
            Console.WriteLine("Object argument");
        }
        public NullArgs(double[] arr)
        {
            Console.WriteLine("double array argument");
        }
        public static void Main(string[] args)
        {
            new NullArgs(null);
        }
        //output double array argument
        //bcos since both object & less derived type is there, null choose the less derived i.e. double
    }
}
