using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    public abstract class OrderBase
    {
        protected List<Product> products = new List<Product>
    {
        new Product {Name = "Phone", Price = 587},
        new Product {Name = "Tablet", Price = 800},
        new Product {Name = "PC", Price = 1200}
    };

        public abstract double CalculateTotalOrderPrice();
    }
    public class OrderDecorator : OrderBase
    {
        protected OrderBase order;

        public OrderDecorator(OrderBase order)
        {
            this.order = order;
        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine($"Calculating the total price in a decorator class");
            return order.CalculateTotalOrderPrice();
        }
    }
    public class PremiumPreorder : OrderDecorator
    {
        public PremiumPreorder(OrderBase order)
            : base(order)
        {
        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine($"Calculating the total price in the {nameof(PremiumPreorder)} class.");
            var preOrderPrice = base.CalculateTotalOrderPrice();

            Console.WriteLine("Adding additional discount to a preorder price");
            return preOrderPrice * 0.9;
        }
    }
    public class RegularOrder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating the total price of a regular order");
            return products.Sum(x => x.Price);
        }
    }
    public class Preorder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating the total price of a preorder.");
            return products.Sum(x => x.Price) * 0.9;
        }
    }
    public class DecoratorPatternSample
    {
        public static void Main(string[] args)
        {
            var regularOrder = new RegularOrder();
            Console.WriteLine(regularOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var preOrder = new Preorder();
            Console.WriteLine(preOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var premiumPreorder = new PremiumPreorder(preOrder);
            Console.WriteLine(premiumPreorder.CalculateTotalOrderPrice());
        }
    }
}
