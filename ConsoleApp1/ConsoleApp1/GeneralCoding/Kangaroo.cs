using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// Complete the function kangaroo in the editor below. It should return YES if they reach the same position at the same time, or NO if they don't.

    ///kangaroo has the following parameter(s) :

    ///x1, v1: integers, starting position and jump distance for kangaroo 1
    ///x2, v2: integers, starting position and jump distance for kangaroo 2
    /// </summary>
    class Kangaroo
    {

        // Complete the kangaroo function below.
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            String yes = "YES"; string no = "NO";
            int difference = Math.Abs(x1 - x2);

            if (difference == 0 && v1 != v2)
            {
                x1 = x1 + v1;
                x2 = x2 + v2;
                difference = Math.Abs(x1 - x2);
            }
            else if (difference == 0 && v1 == v2)
            {
                return yes;
            }

            if ((x1 > x2 && v1 > v2) || (x2 > x1 && v2 > v1))
            {
                return no;
            }
            else
            {
                for (int i = 0; i < difference; ++i)
                {
                    x1 = x1 + v1;
                    x2 = x2 + v2;
                    if (x1 == x2)
                    {
                        return yes;
                    }
                }
                if (x1 != x2)
                {
                    return no;
                }
            }
            return no;
        }


        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] x1V1X2V2 = Console.ReadLine().Split(' ');

            int x1 = Convert.ToInt32(x1V1X2V2[0]);

            int v1 = Convert.ToInt32(x1V1X2V2[1]);

            int x2 = Convert.ToInt32(x1V1X2V2[2]);

            int v2 = Convert.ToInt32(x1V1X2V2[3]);

            string result = kangaroo(x1, v1, x2, v2);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
