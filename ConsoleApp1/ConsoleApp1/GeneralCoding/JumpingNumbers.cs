using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class JumpingNumbers
    {

        // Prints all jumping numbers smaller than or  
        // equal to x starting with 'num'. It mainly 
        // does BFS starting from 'num'. 
        public void bfs(int x, int num)
        {
            // Create a queue and enqueue 'i' to it 
            Queue<int> q = new Queue<int>();
            q.Enqueue(num);

            // Do BFS starting from i 
            while (q.Count != 0)
            {
                num = q.Peek();
                q.Dequeue();
                if (num <= x)
                {
                    Console.Write(num + " ");
                    int last_digit = num % 10;

                    // If last digit is 0, append next digit only 
                    if (last_digit == 0)
                    {
                        q.Enqueue((num * 10) + (last_digit + 1));
                    }

                    // If last digit is 9, append previous digit only 
                    else if (last_digit == 9)
                    {
                        q.Enqueue((num * 10) + (last_digit - 1));
                    }

                    // If last digit is neighter 0 nor 9, append both 
                    // previous and next digits 
                    else
                    {
                        q.Enqueue((num * 10) + (last_digit - 1));
                        q.Enqueue((num * 10) + (last_digit + 1));
                    }
                }
            }
        }

        // Prints all jumping numbers smaller than or equal to 
        // a positive number x 
        public void printJumping(int x)
        {
            Console.Write("0 ");

            for (int i = 1; i <= 9 && i <= x; i++)
            {
                this.bfs(x, i);
            }
        }

        // Driver code 
        public static void Main(String[] args)
        {
            int x = 40;
            JumpingNumbers obj = new JumpingNumbers();
            obj.printJumping(x);
        }
    }
}
