using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BoxUnbox
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[2];
            arr[1] = 10;
            Object o = arr;
            int[] arr1 = (int[])o;
            arr1[1] = 100;
            Console.WriteLine(arr[1]);
            ((int[])o)[1] = 1000;
            Console.WriteLine(arr[1]);
        }
    }
}
