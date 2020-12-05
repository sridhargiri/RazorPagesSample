using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class BankThreadExample
    {
        static void Main(string[] args)
        {
            //Thread bankThread = new Thread(() =>
            //{
            //    Console.WriteLine("Bank: Money has is now available in the account.");
            //});

            //Console.WriteLine("Customer: I would like to deposit");
            //Console.WriteLine("Clerk: No problem");

            //bankThread.Start();

            //Console.WriteLine("Customer: Thank you");
            foo(true, true);
            foo(true, false);
            foo(false, true);
            foo(false, false);

            Console.ReadLine();
        }
        public static void foo(bool a, bool b)
        {
            if (a)
            {
                Console.WriteLine("A");
            }
            else if (a && b)
            {
                Console.WriteLine("A && B");
            }
            else
            {
                if (!b)
                {
                    Console.WriteLine("notB");
                }
                else
                {
                    Console.WriteLine("ELSE");
                }
            }
        }
    }
}
