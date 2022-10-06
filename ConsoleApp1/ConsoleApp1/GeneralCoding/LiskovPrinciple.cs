using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            return "n/a";
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
            Animal animal = new Dog();
            Console.WriteLine(animal.Walk());
            Console.WriteLine(animal.Run());
            Console.WriteLine(animal.Fly());
            Console.WriteLine(animal.MakeNoise());
        }
    }
    public abstract class CalculatorBase
    {
        protected readonly int[] _numbers;

        public CalculatorBase(int[] numbers)
        {
            _numbers = numbers;
        }

        public abstract int Calculate();
    }
    public class SumCalculator : CalculatorBase
    {
        public SumCalculator(int[] numbers)
            : base(numbers)
        {
        }

        public override int Calculate() => _numbers.Sum();
    }
    public class EvenNumbersSumCalculator : CalculatorBase
    {
        public EvenNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {
        }
        public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
    }
    public class LiskovExample
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
            CalculatorBase sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
            Console.WriteLine();
            sum = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {sum.Calculate()}");
        }
    }
}
