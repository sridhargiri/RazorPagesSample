using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Orient
    {
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine()); int noofdrones = 0, noofoperations = 0, startindex = 0, endindex = 0;
            string droneline = "";//<<<>
            int[] spaceindex = new int[2];
            string temp = ""; bool done = false;
            for (int i = 0; i < T; i++)
            {
                noofdrones = int.Parse(Console.ReadLine());
                droneline = Console.ReadLine();
                noofoperations = int.Parse(Console.ReadLine());
                if (noofoperations == 0)
                {
                    Console.WriteLine(droneline); done = true;
                }
                for (int j = 0; j < noofoperations; j++)
                {
                    spaceindex = Console.ReadLine().Split(' ').Select(n1 => Int32.Parse(n1)).ToArray();
                    startindex = spaceindex[0];
                    endindex = spaceindex[1];
                    for (int k = startindex; k <= endindex; k++)
                    {
                        if (droneline[k] == '<')
                        {
                            droneline = droneline.Remove(k, 1).Insert(k, ">");
                        }
                        else
                        {
                            droneline = droneline.Remove(k, 1).Insert(k, "<");
                        }
                    }
                }
                if (!done) Console.WriteLine(droneline); done = false;
            }
        }
    }
}
