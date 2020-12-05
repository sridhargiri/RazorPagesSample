using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class PhoneNumber
    {
        public string Number { get; set; }
    }

    public class Person
    {
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }
    }
    public class AltTab
    {
        public static void Main(string[] args)
        {
            //int[] input1 = { 1, 2, 3, 4 };
            //int index = 3;
            //var t = input1.ToList();
            //int temp = input1[index - 1];
            //t.RemoveAt(index - 1);
            //t.Insert(0, temp);
            //int[] temparray = new int[4];
            //Array.Copy(input1, temparray, 3);
            List<string> animals = new List<string>() { "cat", "dog", "donkey" };
            List<int> number = new List<int>() { 10, 20 };

            var mix = number.SelectMany(num => animals, (n, a) => new { n, a });
            foreach (var item in mix)
            {
                Console.WriteLine($"item.a {item.a} item.n {item.n}");
            }
        }
    }
}
