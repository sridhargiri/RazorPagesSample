using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class FindFirstTwoMax
    {
        public static void topTwo(int[] numbers)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max1)
                {
                    max2 = max1;
                    max1 = numbers[i];
                }
                else if (numbers[i] > max2)
                {
                    max2 = numbers[i];
                }
            }
            Console.WriteLine(max1 + " " + max2);
        }
        public static void Main()
        {
            topTwo(new int[] { 20, 34, 21, 87, 92, int.MaxValue });
            topTwo(new int[] { 0, int.MinValue, -2 });
            topTwo(new int[] { int.MaxValue, 0, int.MaxValue });
            topTwo(new int[] { 1, 1, 0 });
        }
    }
}
