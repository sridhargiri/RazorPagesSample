using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AsyncAwaitExample
    {
        static async Task Main(string[] args)
        {
            await callMethod();
        }

        public static async Task callMethod()
        {
            Method2();
            var count = await Method1();
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            /*
            without async lambda method 1 was printed 10 times without delay
            with async lambda method 1 was printed 10 times with 1 second delay
            */
            int count = 0;
            await Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    count += 1;
                    Console.WriteLine(" Method 1");
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
    public class AsyncAwaitExample2
    {
        static void Main(string[] args)
        {
            callMethod();
        }

        public static async Task callMethod()
        {
            Method2();
            var count = await Method1();
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            /*
            without async lambda method 1 was printed 10 times without delay
            with async lambda method 1 was printed 10 times with 1 second delay
            */
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Task.Delay(1000);
                    count += 1;
                    Console.WriteLine(" Method 1");
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
    public class TaskWaiting
    {
        static async Task Main(string[] args)
        {
            ConsoleWriteLine($"Start Program");

            var tasks = new List<Task<string>> {
         MethodAsync("A", 50),
         MethodAsync("B", 100),
         MethodAsync("C", 20)
      };

            while (tasks.Any())
            {
                Task<string> taskTerminated = await Task.WhenAny(tasks);
                ConsoleWriteLine($"Task terminated result {taskTerminated.Result}");
                tasks.Remove(taskTerminated);
            }

            ConsoleWriteLine($"End Program");
            Console.ReadKey();
        }

        static async Task<string> MethodAsync(string x, int delay)
        {
            for (int i = 0; i < 3; i++)
            {
                ConsoleWriteLine($" {x}{i}");
                await Task.Delay(delay);
            }
            string result = new string(x[0], 4);
            ConsoleWriteLine($" {x} returns result {result}");
            return result;
        }

        // Convenient helper to print colorful threadId on console
        static void ConsoleWriteLine(string str)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.ForegroundColor = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;
            Console.WriteLine(
               $"{str}{new string(' ', 29 - str.Length)}   Thread {threadId}");
        }
    }

    public class AsyncAwaitConsole
    {
        static void Main(string[] args)
        {
            LongProcess();

            ShortProcess();
        }

        static async Task LongProcess()
        {
            Console.WriteLine("LongProcess Started");

            await Task.Delay(1000); // hold execution for 4 seconds

            Console.WriteLine("LongProcess Completed");

        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");

            //do something here

            Console.WriteLine("ShortProcess Completed");
        }

    }
    public class AsyncAwaitConsole2
    {
        static async Task Main(string[] args)
        {
            await LongProcess();

            ShortProcess();
        }

        static async Task LongProcess()
        {
            Console.WriteLine("LongProcess Started");

            await Task.Delay(5000); // hold execution for 4 seconds

            Console.WriteLine("LongProcess Completed");

        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");

            //do something here

            Console.WriteLine("ShortProcess Completed");
        }

    }
}

