using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TaskDoWork
    {
        private static void Main(string[] args)
        {
            var task = DoWork();
            Console.WriteLine("Task status: " + task.Status);
            Console.WriteLine("Waiting for ENTER");
            Console.ReadLine();
        }
        private static async Task DoLong(string note)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"async task {note} " + i);
                    // imitating time consuming code
                    Thread.Sleep(1000);
                }
            });
        }
        private static async Task DoWork()
        {
            Console.WriteLine("Entered DoWork(). Sleeping 3");
            // imitating time consuming code
            // in a real-world app this should be inside task, 
            // so method returns fast
            Thread.Sleep(3000);
            await DoLong("p1");
            await DoLong("p2");
            Console.WriteLine("Exiting DoWork()");
        }
    }

    public class TaskWait
    {
        static void Main(string[] args)
        {
            WriteOutput("Program Begin");
            // DoAsTask();
            DoAsAsync();
            WriteOutput("Program End");
            Console.ReadLine();
        }

        static void DoAsTask()
        {
            WriteOutput("1 - Starting");
            var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
            WriteOutput("2 - Task started");
            t.Wait();
            WriteOutput("3 - Task completed with result: " + t.Result);
        }

        static async Task DoAsAsync()
        {
            WriteOutput("1 - Starting");
            var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
            WriteOutput("2 - Task started");
            var result = await t;
            WriteOutput("3 - Task completed with result: " + result);
        }

        static int DoSomethingThatTakesTime()
        {
            WriteOutput("A - Started something");
            Thread.Sleep(1000);
            WriteOutput("B - Completed something");
            return 123;
        }

        static void WriteOutput(string message)
        {
            Console.WriteLine("[{0}] {1}", Thread.CurrentThread.ManagedThreadId, message);
        }
    }
}