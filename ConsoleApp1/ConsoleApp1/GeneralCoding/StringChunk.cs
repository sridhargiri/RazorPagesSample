using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Partition(this string input, int partitionSize)
        {
            for (int i = 0; i < input.Length; i += partitionSize)
            {
                yield return input.Substring(i, Math.Min(partitionSize, input.Length - i));
            }
        }
    }

    // split string into equal chunks (Andela)
    // https://www.techiedelight.com/split-string-into-chunks-of-equal-size-in-csharp/
    public class StringChunk
    {
        public static void Main()
        {
            string s = "ABCDEFGH";

            var tokens = s.Partition(3);

            Console.WriteLine(String.Join(", ", tokens));        // AB, CD, EF, GH

        }
    }
}
