using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Department
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
    }
    /*
     Aploris Teamslide online test taken on 28/02/2023
     */
    public class Aploris
    {
        static void Main(string[] args)
        {
            var max = FindMaximum(new int[] { 11, 1, 3 });
            Console.WriteLine(max);
            var idx = FirstIndexOfElement("2", new object[] { "1", "2", "3", "2" });
            Console.WriteLine(idx);
            var s = RecursiveStringReverse("sridhar");
            Console.WriteLine(s);
            var lst = ReverseList<int>(new List<int> { 4, 3, 2, 1 });
            lst.ForEach((j) => Console.WriteLine(j));
            Console.WriteLine(GetBitStringForInt(12));
            var list = new List<Department>()
 {
 new Department() { Name ="Finance",Number = 1,BuildingId = 15 },
 new Department() { Name ="HR",Number = 2,BuildingId = 3 },
 new Department() { Name ="IT",Number = 3,BuildingId = 15 },
 new Department() { Name ="Sales", Number = 4, BuildingId = 3 }
 };
            var newList = from department in list
                          group department by department.BuildingId into dp
                          select new { counter = dp.Key, department = dp };
            Console.Out.WriteLine(newList.Count());
        }
        public static int FindMaximum(IEnumerable<int> nums)
        {
            int maximum = int.MinValue; // smaller than all other numbers
            foreach (int num in nums)
                if (num > maximum)
                    maximum = num;
            return maximum;
        }

        public static int FirstIndexOfElement(object element, object[] array)
        {
            for (int i = 0; i < array.Length;)
            {
                if (array[++i] == element) return i;
            }
            return -1;
        }

        // Method returns new list with elements from input list in reversed order
        public static List<T> ReverseList<T>(List<T> elems)
        {
            var newList = new List<T>();
            for (int i = 1; i <= elems.Count; i++)
            {
                newList.Add(elems[elems.Count - i]);
            }
            return newList;
        }
        public static string GetBitStringForInt(int n)
        {
            StringBuilder rtn = new StringBuilder();
            for (int i = 31; i >= 0; i--)
            {
                int v = (1 << i) & n;
                rtn.Append(v == 1 ? "1" : "0");
            }
            return rtn.ToString();
        }

        public static string RecursiveStringReverse(string input)
        {
            if (input.Length <= 1)
                return input;
            char firstChar = input[0];
            string lastChars = input.Substring(1);
            return RecursiveStringReverse(lastChars) + firstChar;

        }
    }
}
