using System;
using System.Linq;

namespace ConsoleApp1
{
    class Class1
    {

        public static void Main(string[] args)
        {
            int[] firstarray = null;
            int[] secondarray = null;
            int[] temparray = null;
            int T = int.Parse(Console.ReadLine());
            int allowed = 0;
            int temp = 0;
            int arraynumber = 0;
            bool isEqual = false;
            for (int i = 0; i < T; i++)
            {
                allowed = 0;
                int size = int.Parse(Console.ReadLine());
                firstarray = Console.ReadLine().Split(' ').Select(n1 => Int32.Parse(n1)).ToArray();
                secondarray = Console.ReadLine().Split(' ').Select(n1 => Int32.Parse(n1)).ToArray();
                Array.Sort(firstarray);
                Array.Sort(secondarray);
                int sum1 = firstarray.Sum();
                int sum2 = secondarray.Sum();
                int diff = sum1 - sum2;
                if (diff < 0)
                {
                    Console.WriteLine(Math.Abs(diff) + " " + 1);
                }
                else
                {
                    Console.WriteLine(Math.Abs(diff) + " " + 2);

                }
            }
        }
    }
    //class Class1
    //{
    //    public static void Main(string[] args)
    //    {
    //        int[] firstarray = null;
    //        int[] secondarray = null;
    //        int[] temparray = null;
    //        int T = int.Parse(Console.ReadLine());
    //        int allowed = 0;
    //        int temp = 0;
    //        int arraynumber = 0;
    //        bool isEqual = false;
    //        for (int i = 0; i < T; i++)
    //        {
    //            allowed = 0;
    //            int size = int.Parse(Console.ReadLine());
    //            firstarray = Console.ReadLine().Split(' ').Select(n1 => Int32.Parse(n1)).ToArray();
    //            secondarray = Console.ReadLine().Split(' ').Select(n1 => Int32.Parse(n1)).ToArray();
    //            //Array.Sort(firstarray);
    //            //Array.Sort(secondarray);
    //            int sum1 = firstarray.Sum();
    //            int sum2 = secondarray.Sum();
    //            int diff = sum1 - sum2;

    //            //for (int j = 0; j < size; j++)
    //            //{

    //            //    if (firstarray.Contains(secondarray[j]))
    //            //    {
    //            //        allowed++;

    //            //    }
    //            //}
    //            if (sum1 == sum2 && firstarray.Except(secondarray).Count() == 0)
    //            {
    //                //Identical
    //                Console.WriteLine("Yes");
    //            }
    //            else if (diff > 0)
    //            {
    //                temparray = secondarray;
    //                for (int j = 0; j < size; j++)
    //                {
    //                    temparray[j] = secondarray[j] + diff;
    //                    var result = firstarray.Except(temparray);
    //                    isEqual = result.Count() == 0;
    //                    temparray[j] = secondarray[j];
    //                    if (isEqual)
    //                    {
    //                        break;
    //                    }
    //                }
    //                if (isEqual)
    //                {
    //                    Console.WriteLine(diff + " " + 2);
    //                }
    //                else
    //                {
    //                    Console.WriteLine("No");
    //                }


    //            }
    //            else
    //            {
    //                temparray = firstarray;
    //                for (int j = 0; j < size; j++)
    //                {
    //                    firstarray[j] = firstarray[j] + Math.Abs(diff);
    //                    var result = secondarray.Except(temparray);
    //                    isEqual = result.Count() == 0;
    //                    firstarray[j] = firstarray[j] - Math.Abs(diff);
    //                    if (isEqual)
    //                    {
    //                        break;
    //                    }
    //                }
    //                if (isEqual)
    //                {
    //                    Console.WriteLine(Math.Abs(diff) + " " + 1);
    //                }
    //                else
    //                {
    //                    Console.WriteLine("No");
    //                }

    //            }

    //        }
    //        Console.ReadLine();
    //    }
    //}
}
