using System;
using System.Collections.Generic;
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
    public class Base26Do
    {

        public static string getShiftedString(string s, int leftShifts, int rightShifts)
        {
            string temp = s.leftRotateShift(leftShifts).rightRotateShift(rightShifts);
            return temp;
        }
        public static void Main(string[] args)
        {
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
