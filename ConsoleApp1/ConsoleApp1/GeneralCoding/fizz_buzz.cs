using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FizzBuzz
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 15; i++)
            {
                if (i % 3 == 0)
                    Console.Write("fizz");
                if (i % 5 == 0)
                    Console.Write("buzz");
                if (i % 3 > 0 && i % 5 > 0)
                    Console.Write("{0}", i);
                Console.WriteLine("");
            }
        }
    }
    public class StackError
    {
        static void Main(string[] args)
        { new StackError().Run(); }
    private int _sharedInteger;

        public void Run()
        {
            Task modifyTaskOne = Task.Run(() => ModifySharedIntegerInLoop(600, 1));
            Task modifyTaskTwo = Task.Run(() => ModifySharedIntegerInLoop(600, -1));
            Task modifyTaskThree = Task.Run(() => ModifySharedIntegerInLoop(600, 1));
            Task modifyTaskFour = Task.Run(() => ModifySharedIntegerInLoop(600, -1));
            Task modifyTaskFive = Task.Run(() => ModifySharedIntegerInLoop(600, 1));
            Task.WaitAll(modifyTaskOne, modifyTaskTwo, modifyTaskThree, modifyTaskFour, modifyTaskFive);
            Debug.WriteLine(string.Format("Final value: {0}", _sharedInteger));
        }

        private void ModifySharedIntegerInLoop(int maxLoops, int amount)
        {
            for (int i = 0; i < maxLoops; i++)
            {
                ModifySharedIntegerSingleTime(amount);
            }
        }

        private void ModifySharedIntegerSingleTime(int amount)
        {
            _sharedInteger += amount;
        }
    }
    /*
     Write a recursive function that returns a string and that takes 1 string parameter.
Each invocation of the function should concatenate the string parameter to itself. So, if the string "duck" was passed in, it should return the string "duckduck".

The recursion should stop when the length of the string exceeds 100.
    */
    public class RecursionStop
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Recur("duck",100));
        }
       static string Recur(string str,int len)
        {
            if (str.Length < len)
                return str + Recur(str, str.Length);
            return str;
        }
    }

}
