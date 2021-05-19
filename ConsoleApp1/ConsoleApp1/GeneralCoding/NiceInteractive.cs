using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     parent string1 abde, parent string 2 derf, child str=abrf. atmost two parent will exist. from given list of parents find the actual parent of the children

     */
    class NiceInteractive
    {
        public static void Main(string[] args)
        {
            string parent = "abrf";
            List<string> ch = new List<string>();
            ch.Add("abde");
            ch.Add("derf");
            ch.Add("xyz0");
            findChild(ch, parent);
        }
        static void findChild(List<string> children, string parent)
        {
            int i = 0;
            foreach (string item in children)
            {
                i++;
                foreach (char c in item)
                {
                    if (parent.Contains(c))
                    { Console.WriteLine(item); break; }
                }
            }
        }
    }
}
