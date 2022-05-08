using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://tutorial.techaltum.com/Ienumerable-and-Ienumerator-in-c-sharp.html
    public class CustomCollection : IEnumerable
    {
        /// <summary>
        /// Get or set the size
        /// </summary>
        public int Capacity
        {
            get { return _size; }
            set
            {
                _size = value;
            }
        }
        private int _size;
        int[] res = null;
        public CustomCollection(int size)
        {
            _size = size;
            res = new int[_size];
        }

        //Inedexer
        public int this[int idx]
        {
            get { return res[idx]; }

            set { res[idx] = value; }
        }

        //implemented method of IEnumerable
        public IEnumerator GetEnumerator()
        {

            foreach (int data in res)
            {
                //This statement is used to Iterate the user defined collection
                yield return data;

            }

        }

    }
    public class CustomCollectionExample
    {
        public static void Main(string[] args)
        {
            //create object of custom class
            CustomCollection cc = new CustomCollection(5);
            // pass value to array through indexer
            cc[0] = 100;
            cc[1] = 200;
            cc[2] = 300;
            cc[3] = 400;
            cc[4] = 500;

            //call GetEnumerator method
            IEnumerator res = cc.GetEnumerator();
            while (res.MoveNext())
            {

                Console.Write(res.Current + " ");
            }

        }
    }
}
