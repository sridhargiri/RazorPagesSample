using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //purpose not recorded
    public class OddPossible
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 7 };
            int K = 6;
            bool ispossible = isPossible(arr, arr.Length, K);
            Console.WriteLine(ispossible);
        }
        public static bool isPossible(int[] arr, int N, int K)
        {
            int oddCount = 0, evenCount = 0;

            // counting number of odd 
            // and even elements 
            for (int i = 0; i < N; i++)
            {
                if (arr[i] % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
            if (evenCount == N
                || (oddCount == N && K % 2 == 0)
                || (K == N && oddCount % 2 == 0))
                return false;
            else
                return true;
        }
    }
}
