using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FinalizeExample
    {
        static void Main(string[] args)
        {
            // create 50K events
            var events = Enumerable.Range(1, 50 * 1000)
                                    .Select(x => new Event())
                                    .ToList();

            ManualResetEvent startEvent = new ManualResetEvent(false);

            Task.Factory.StartNew(() =>
            {
                startEvent.WaitOne();  // wait for event
                foreach (var ev in events) // dispose events
                {
                    ev.Dispose();
                }
            });

            startEvent.Set(); // start disposing events
            Thread.Sleep(1);  // wait a bit and then exit
        }
    }

    public class Event : IDisposable
    {
        internal IntPtr hGlobal;  // allocate some unmanaged memory

        public Event()
        {
            hGlobal = Marshal.AllocHGlobal(500);
        }

        ~Event()  // finalizer 
        {
            Dispose();
            Console.WriteLine("posed");
        }

        public void Dispose()
        {
            if (hGlobal != IntPtr.Zero) // check if memory is gone
            {
                Marshal.FreeHGlobal(hGlobal); // free it
                GC.SuppressFinalize(this); // Prevent finalizer from running it again
                hGlobal = IntPtr.Zero;
            }
        }
    }
}
