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
         * A construction company is building a new neighbourhood. Each house will be built using one of three main materials [wood,brick,cement], but no side by side houses should be built using the same material. Given an n*3 array where values in column respresents the cost of materials and "n" represents the number of houses , determine the minimum cost to build the neighbourhood.

Example 1:
given input : [[1,2,3],[1,2,3],[3,3,1]] (values in column represent cost of materials)

output : 4

Explanation:
choose material-1 of cost 1 in first house(row)
choose material-2 of cost 2 in second house(row)
choose material-3 of cost 1 in third house (row)
total = 1+2+1 -> 4

Example 2:

input: [[1,10,20],[2,100,200]]

output: 12

Explanation:
choose material-2 of cost 10 in first house(row)
choose material-1 of cost 2 in second house(row)
total = 10 + 2 -> 12

         * Complete the 'minCost' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY cost as parameter.
         */

        public static int minCost(List<List<int>> cost)
        {
            int price = 0;

            for (int i = 1; i < cost.Count; i++)
            {
                cost[i][0] += Math.Min(cost[i - 1][1], cost[i - 1][2]);
                cost[i][1] += Math.Min(cost[i - 1][0], cost[i - 1][2]);
                cost[i][2] += Math.Min(cost[i - 1][1], cost[i - 1][0]);
            }

            price = Math.Min(Math.Min(cost[cost.Count - 1][0], cost[cost.Count - 1][1]), cost[cost.Count - 1][2]);
            return price;
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
