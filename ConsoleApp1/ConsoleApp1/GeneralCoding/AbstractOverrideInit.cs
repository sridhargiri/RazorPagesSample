using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AbstractOverrideInit
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Task.Run(null);
            }
            catch (Exception)
            {
                await Task.FromResult(1);
            }
            ABase aobj = new BBase();
            BBase bobj = new BBase();
            aobj.j = 8;
            bobj.i = 1;
            bobj.P1 = 10;
            bobj.PrintLine();
        }

    }
    public abstract class ABase
    {
        public int j = 7;
        public int P1 { get; set; }
        public abstract void PrintLine();
    }
    public class BBase : ABase
    {
        public int i;
        public override void PrintLine()
        {
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.WriteLine(P1);
            // outputs 1 7 10 bcos fields in abstract class cannot be changed by assigning new values in deriving class but properties can be changed (capgemini interview mocha online test)
            string jwt = "Order {0} {{1}} is already closed.";
            int one = 1, two = 2;
            string outputted=string.Format(jwt, one, two);
            string outputted1 = $"Order {one} {{{two}}} is already closed.";
            Console.WriteLine(outputted);
            Console.WriteLine(outputted1);
        }
    }
}
