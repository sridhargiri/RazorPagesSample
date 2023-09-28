using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // asked during L1 interview on 28/09/2023
    public class AccionLabs
    {
        public static int TestValue;
        public AccionLabs()
        {
            if (TestValue == 0)
            {
                TestValue = 5;//10
            }
        }
        static AccionLabs()
        {
            if (TestValue == 0)
            {
                TestValue = 10;
            }
        }
        public void Print()
        {
            if (TestValue == 5)//condition fail
            {
                TestValue = 6;
            }
        }
        public static void Main(string[] args)
        {
            AccionLabs st = new AccionLabs();
            st.Print();
            Console.WriteLine(AccionLabs.TestValue);
            // output 10
        }

    }
}
