using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    public class MyClass1
    {

    }
    class Socks
    {
        static void Main(String[] args)
        {
            MyClass1 my = new MyClass1();
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Sort(A);
            int ans = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] == A[i - 1])
                {
                    ans++; 
                    i++;
                }
            }
            Console.WriteLine(ans); Console.ReadLine();
        }
    }
}