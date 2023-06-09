using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // https://www.section.io/engineering-education/using-c-sharp-to-demonstrate-lock-in-thread/
    public class LockExample2
    {
        // create a thread named identity
        static readonly object Identity = new object();
        static void output()
        {
            // Enter the lock to the thread
            lock (Identity)
            {
                // initialize the integer to be used in the for loop
                int y;
                y = 4;
                // compute the for loop
                for (; y <= 6; y++)
                {
                    // Output string and the value of the lock
                    Console.WriteLine("The output will be: {0}", y);
                }
            }
        }
        static void Main(string[] args)
        {
            Thread one = new Thread(output);
            Thread two = new Thread(output);
            one.Start();
            two.Start();
        }
    }
}
