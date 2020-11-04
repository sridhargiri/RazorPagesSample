using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Mini_max_sum
    {
        public static void Main(string[] args)
        {
            miniMaxSum(new int[] { 1, 2, 3, 4, 5 });
            birthdayCakeCandles(new List<int> { 3,2,1,3});
        }
        public static int birthdayCakeCandles(List<int> candles)
        {
            int max = 0;
            int counter = 0;
            for (int i = 0; i < candles.Count; i++)
            {
                if (max < candles[i])
                {
                    max = candles[i];
                }
            }
            for (int j = 0; j < candles.Count; j++)
            {
                if (candles[j] == max) counter++;
            }
            return counter;
        }
        // Complete the miniMaxSum function below.
        static void miniMaxSum(int[] arr)
        {
            long sum = 0;
            long min = 1000000000;
            long max = 0;
            int i = 0; int n = arr.Length;
            while (i < n)
            {
                sum += arr[i];
                if (min > arr[i])
                {
                    min = arr[i];
                }
                if (max < arr[i])
                {
                    max = arr[i];
                }
                i++;
            }
            Console.WriteLine((sum - max) + " " + (sum - min));
        }

    }
}
