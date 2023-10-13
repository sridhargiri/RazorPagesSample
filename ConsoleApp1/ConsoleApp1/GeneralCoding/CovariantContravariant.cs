using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IProducer<out T>
    {
        T Produce();
    }

    public class Fruit { }

    public class Apple : Fruit { }

    public class FruitProducer : IProducer<Fruit>
    {
        public Fruit Produce() => new Fruit();
    }

    public class AppleProducer : IProducer<Apple>
    {
        public Apple Produce() => new Apple();
    }

    public interface IConsumer<in T>
    {
        void Consume(T item);
        void Consume1(string item);
    }

    public class FruitConsumer : IConsumer<Fruit>
    {
        public void Consume(Fruit item)
        {
            // Consume the fruit
        }
        public void Consume1(string item)
        {
            // Consume the fruit
        }
    }

    public class AppleConsumer : IConsumer<Apple>
    {
        public void Consume(Apple item)
        {
            // Consume the apple
        }
        public void Consume1(string item)
        {
            // Consume the fruit
        }
    }
    public class CovariantContravariant
    {
        public static void Main(string[] args)
        {
            //covariant out

            //I need a fruit farm(base class) so i can produce fruits(base type)
            //But what I have is an apple farm(derived class) that produce apples (derive type)
            IProducer<Apple> appleFarm = new AppleProducer();
            //thats ok, I'll just mark it as covariant(out) since apple is also a fruit
            IProducer<Fruit> fruitFarm = appleFarm;

            //if you mark an interface generic as covariant, it must be able to output the generic type, and it allows you to convert a derive type of the generic type into its base type.

            Apple apple = appleFarm.Produce();
            //I can produce fruits since apple is a fruit
            Fruit fruit = apple;

            //contravariant in

            //I need an apple bakery(derive class) so i can use my apples(derive type)
            //But what I have is a fruit bakery(base class) that uses fruits(base type)
            IConsumer<Fruit> fruitBakery = new FruitConsumer();
            //thats ok, I'll just mark it as contravariant(in) since a fruit bakery can also consume apples
            IConsumer<Apple> appleBakery = fruitBakery;

            //if you mark an interface generic as contravariant, it must be able to input the generic type, and it allows you to convert a derive type of the generic type into its base type.

            //can consume apples and any fruits
            appleBakery.Consume(new Apple());
            fruitBakery.Consume(new Fruit());
            fruitBakery.Consume(new Apple());
        }
    }
}
