using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RunMe
    {
        private static string result;
        public static void Main(string[] args)
        {
            var k = 1 / 0.0;
            //k = 1 / 0;
            //k = 1 / (0.ToString());
            //k = 1 / Convert.ToInt32(0);
            Console.WriteLine("Hi");
            john();
            Console.WriteLine(result);
            paul();
            Console.WriteLine(result);
            rigo();
            Console.WriteLine(result);
            george();
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static async Task john()
        {
            await Task.Delay(5);
            result = "donot make bad";
        }
        static async Task<object> paul()
        {
            await Task.Delay(0);
            result = "no afraid";
            return Task.FromResult<object>(null);
        }
        static async Task<bool> rigo()
        {
            Thread.Sleep(5);
            result = "dont let me down";
            return false;
        }
        static async Task<string> george()
        {
            Thread.Sleep(1);
            result = "You'll do";
            return "Beatles";
        }
    }
}