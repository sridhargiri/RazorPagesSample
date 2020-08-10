using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class sample
    {
        public static int x = 100;
        public static int y = 150;
    }
    public class newspaper : sample
    {
        new public static int x = 1000;
        static void Main(string[] args)
        {
            Console.WriteLine(sample.x + "  " + y + "  " + x);
        }
    }
    class AminusB
    {
       
        static void findMissing(int[] a, int[] b, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                int j;

                for (j = 0; j < m; j++)
                    if (a[i] == b[j])
                        break;

                if (j == m)
                    Console.Write(a[i] + " ");
            }
        }
        // Driver code 
        public static void Main()
        {
            int[] a = { 1, 13, 7, 2,5,13 };// { 1, 2, 6, 3, 2,5 };
            int[] b = { 1, 12, 2, 1 };// { 2, 4, 3, 1, 0 };

            int n = a.Length;
            int m = b.Length;

            findMissing(a, b, n, m);
        }
    }
}
