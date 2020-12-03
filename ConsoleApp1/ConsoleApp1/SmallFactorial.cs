using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SmallFactorial
    {

        static void Main(string[] args)
        {
            int kases = Int32.Parse(System.Console.ReadLine().Trim());
            for (int kase = 1; kase <= kases; kase++)
            {
                int N = Int32.Parse(System.Console.ReadLine().Trim());
                List<int> result = new List<int>();
                result.Add(1);
                int temp, carry = 0;
                for (int i = 2; i <= N; i++)
                {
                    for (int j = 0; j < result.Count; j++)
                    {
                        temp = carry + result[j] * i;
                        carry = temp / 10;
                        result[j] = temp % 10;
                    }
                    while (carry > 0)
                    {
                        result.Add(carry % 10);
                        carry /= 10;
                    }
                }
                for (int i = result.Count - 1; i >= 0; i--)
                {
                    Console.Write(result[i]);
                }
                Console.Write("\n");

            }
        }
    }
}
