using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class MyExtensions
    {
        public static string ShiftL(this string s, int count)
        {
            return s.Remove(0, count) + s.Substring(0, count);
        }
        public static string ShiftR(this string s, int count)
        {
            return s.Substring(0, count) + s.Remove(0, count);
        }
        public static string leftRotateShift(this string key, int shift)
        {
            shift %= key.Length;
            return key.Substring(shift) + key.Substring(0, shift);
        }

        public static string rightRotateShift(this string key, int shift)
        {
            shift %= key.Length;
            return key.Substring(key.Length - shift) + key.Substring(0, key.Length - shift);
        }
    }
    public class AthenaHackerrank
    {
        /*
         pick the most featured product. if there is a tie display all the equal rank products in alphabetical order
        example : [orange,orange,blue,blue,black,white]
        output : blue,orange
         */
        public static void featuredProduct(List<string> products)
        {
            var result = products.GroupBy(n => n)
                    .Select(c => new { Key = c.Key, total = c.Count() }).OrderByDescending(x => x.total).GroupBy(x => x.total);
            if (result != null && result.Count() >= 1)
            {
                foreach (var item in result.First().OrderBy(x => x.Key))
                {
                    Console.WriteLine(item.Key);
                }
                return;
            }
        }
        /*
         left rotate by n shifts then right rotate by m shifts
        ex - geekforgeeks , left 2 , right 3
        out - eeksforgeeksg
         */
        public static string getShiftedString(string s, int leftShifts, int rightShifts)
        {
            string temp = s.leftRotateShift(leftShifts).rightRotateShift(rightShifts);
            return temp;
        }
        public static void Main(string[] args)
        {
            List<string> products = new List<string>();
            products.Add("grey");
            products.Add("orange");
            products.Add("blue");
            products.Add("blue");
            products.Add("black");
            products.Add("white");
            featuredProduct(products);
            //string o = "cdefgab".rightRotateShift(4);
            string o = getShiftedString("abcd", 1, 0);
            Console.WriteLine(o);
            List<string> names = new List<string>();

            names.Add("Rose");
            names.Add("Abs");
            names.Add("Edward");
            names.Add("Sita");
            names.Add("Ram");
            names.Sort();
            foreach (string s in names)
                Console.WriteLine(s);
            Console.ReadLine();
        }
        //left
        public static string ShiftString(string t)
        {
            return t.Substring(1, t.Length - 2) + t.Substring(0, 2);
        }
    }
}
