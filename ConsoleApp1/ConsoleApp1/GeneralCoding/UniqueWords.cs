using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
This page has DevExpress hackerrank online test taken on 24 oct 2022 late night
Q1 - return count of unique words in string
Q2 - flatten tree recursively using preorder traversal
Q3 - count order summary using json object inputs

Q1 - done
Q2 - incomplete
Q3 - completed fully (but compile error due to record type, the same works well with normal class in visual studio)
 */

namespace ConsoleApp1
{
    public class SumOrder
    {
        static void Main(string[] args)
        {
            List<ProductClass> products = new List<ProductClass>();
            products.Add(new ProductClass { Id = 0, Name = "Bananas", Price = 5 });
            products.Add(new ProductClass { Id = 1, Name = "Apples", Price = 8 });

            List<Order> orders = new List<Order>();
            orders.Add(
                new Order
            {
                Date = new DateTime(2019, 1, 1),
                Items = new List<OrderItem>() {
                    new OrderItem { ProductId=0,Quantity=20 },
                    new OrderItem { ProductId=1,Quantity=10 } }
            });
            orders.Add(
                new Order
                {
                    Date = new DateTime(2019, 1, 2),
                    Items = new List<OrderItem>() {
                    new OrderItem { ProductId=0,Quantity=20 } }
                });
            orders.Add(
                new Order
                {
                    Date = new DateTime(2020, 1, 3),
                    Items = new List<OrderItem>() {
                    new OrderItem { ProductId=1,Quantity=20 } }
                });
            var s = GetSummaries(orders, products, 2020);
        }
        public static IEnumerable<Summary> GetSummaries(IEnumerable<Order> orders, IEnumerable<ProductClass> products, int year)
        {
            var yearfiltered = orders.Where(d => d.Date.Year == year);
            List<OrderItem> _items = new List<OrderItem>();
            List<Summary> _pitems = new List<Summary>();
            foreach (var item in yearfiltered)
            {
                _items.AddRange(item.Items);
            }
            var joined = (from i in _items join p in products on i.ProductId equals p.Id  select new {ProdId=p.Id, ProductName = p.Name, ProductPrice = p.Price, ProductQuantity = i.Quantity }).GroupBy(d=>d.ProdId)
    .Select(cl => new 
    {
        ProductName = cl.First().ProductName,
        Sum = cl.Sum(c => c.ProductQuantity*c.ProductPrice),
    }).ToList();
            foreach (var j in joined)
            {
                _pitems.Add(new Summary ( j.ProductName,j.Sum ));
            }
            return _pitems;
        }
    }
    public record Summary (string Product, decimal sum);
    public class ProductClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public DateTime Date { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class FlattenTree
    {
        static void Main(string[] args)
        {

        }
    }
    public static class FlattenTreeExtension
    {
        public static IEnumerable<VisualElement> GetChildren(this VisualElement root)
        {
            return GetChildren(root);
        }
        public static IEnumerable<VisualElement> Traverse(this VisualElement root)
        {
            var stack = new Stack<VisualElement>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                foreach (var child in current.Children)
                    stack.Push(child);
            }
        }
    }
    public class VisualElement
    {
        public string Name { get; set; }
        public IEnumerable<VisualElement> Children { get; set; }
    }
    public class UniqueWords
    {
        static void Main(string[] args)
        {
            String source = "a aa aa bbb bbb bbb";
            //TODO: check this    
            Char[] separators = new Char[] { ' ', '\r', '\n', '\t', ',', '.', ';', '!', '?' };

            HashSet<String> uniqueWords =
              new HashSet<String>(source.Split(separators, StringSplitOptions.RemoveEmptyEntries),
              StringComparer.OrdinalIgnoreCase);

            // 13
            Console.WriteLine(uniqueWords.Count);

            // I, have, a, car, had, bought, it, two, years, ago, like, very, much
            Console.WriteLine(String.Join(", ", uniqueWords));
        }
    }
}
