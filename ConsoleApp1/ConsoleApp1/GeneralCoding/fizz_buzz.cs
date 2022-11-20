using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FizzBuzz
    {
        /*
         fizz buzz program, 
if divisible by 3 print Fizz
if divisible by 5 print Buzz
if divisible by both 3 and 5 print FizzBuzz
if not divisible by 3 or 5, print number itself
        */
        static void Main(string[] args)
        {
            for (int i = 1; i <= 15; i++)
            {
                if (i % 3 == 0)
                    Console.Write("Fizz");
                if (i % 5 == 0)
                    Console.Write("Buzz");
                if (i % 3 > 0 && i % 5 > 0)
                    Console.Write("{0}", i);
                Console.WriteLine("");
            }
        }
    }
    public class StackError
    {
        static void Main(string[] args)
        {
            new StackError().Run();
        }
        private int _sharedInteger;

        public void Run()
        {
            Task modifyTaskOne = Task.Run(() => ModifySharedIntegerInLoop(600, 1, 1));
            Task modifyTaskTwo = Task.Run(() => ModifySharedIntegerInLoop(600, -1, 2));
            Task modifyTaskThree = Task.Run(() => ModifySharedIntegerInLoop(600, 1, 3));
            Task modifyTaskFour = Task.Run(() => ModifySharedIntegerInLoop(600, -1, 4));
            Task modifyTaskFive = Task.Run(() => ModifySharedIntegerInLoop(600, 1, 5));
            Task.WaitAny(modifyTaskOne, modifyTaskTwo, modifyTaskThree, modifyTaskFour, modifyTaskFive);
            Debug.WriteLine(string.Format("Final value: {0}", _sharedInteger));
        }

        private void ModifySharedIntegerInLoop(int maxLoops, int amount, int order)
        {
            for (int i = 0; i < maxLoops; i++)
            {
                ModifySharedIntegerSingleTime(amount);
            }
            if (order == 5)
                throw new Exception();
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
        static void Main()
        {
            string s = "duck";
            s = Concatenate(s);
            Console.WriteLine(s);
            Console.ReadKey();
        }

        static string Concatenate(string s)
        {
            while (s.Length <= 100)
            {
                s = Concatenate(s + s);
            }
            return s;
        }
    }

}
