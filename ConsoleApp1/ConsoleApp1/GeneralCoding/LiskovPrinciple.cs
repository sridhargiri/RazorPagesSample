using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    public class Animal
    {
        public string Walk()
        {
            return "Move feet";
        }

        public string Run()
        {
            return "Move feet quickly";
        }

        public virtual string Fly()
        {
            return null;
        }

        public virtual string MakeNoise()
        {
            return null;
        }
    }

    public class Dog : Animal
    {
        public override string MakeNoise()
        {
            return "Bark";
        }
    }

    public class Bird : Animal
    {
        public override string MakeNoise()
        {
            return "Chirp";
        }

        public override string Fly()
        {
            return "Flag wings";
        }
    }
    public class LiskovPrinciple
    {
        static void Main(string[] args)
        {
            Animal animal = new Bird();
            Console.WriteLine(animal.Walk());
            Console.WriteLine(animal.Run());
            Console.WriteLine(animal.Fly());
            Console.WriteLine(animal.MakeNoise());
            Console.ReadLine();
        }
    }
}
