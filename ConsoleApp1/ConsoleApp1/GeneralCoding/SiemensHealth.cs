using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SiemensHealth
    {
        /*
         Split string skip at double quotes
         */
        public static IEnumerable<String> ParseText(String line, Char delimiter, Char textQualifier)
        {

            if (line == null)
                yield break;

            else
            {
                char prevChar = '\0';
                Char nextChar = '\0';
                Char currentChar = '\0';

                Boolean inString = false;

                StringBuilder token = new StringBuilder();

                for (int i = 0; i < line.Length; i++)
                {
                    currentChar = line[i];

                    if (i > 0)
                        prevChar = line[i - 1];
                    else
                        prevChar = '\0';

                    if (i + 1 < line.Length)
                        nextChar = line[i + 1];
                    else
                        nextChar = '\0';

                    if (currentChar == textQualifier && (prevChar == '\0' || prevChar == delimiter) && !inString)
                    {
                        inString = true;
                        continue;
                    }

                    if (currentChar == textQualifier && (nextChar == '\0' || nextChar == delimiter) && inString)
                    {
                        inString = false;
                        continue;
                    }

                    if (currentChar == delimiter && !inString)
                    {
                        yield return token.ToString();
                        token = token.Remove(0, token.Length);
                        continue;
                    }

                    token = token.Append(currentChar);

                }

                yield return token.ToString();

            }
        }
        /*
         Consider only 5kg and 1kg packs are allowed to fill up given weight
        example - 6kg can be filled with 5 and 1 but 7kg cannot be obtained using these packs
        print "YES" if possible else print "NO"
         */
        public static void PrintPackages(int m, int n, int w)
        {
            if (w - m == n)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        public static void Main(string[] args)
        {
            string input = "one \"two two\" three \"four four\" five six";
            var parsedText = ParseText(input, ' ', '"');
            foreach (var item in parsedText)
            {
                Console.WriteLine(item);
            }
            PrintPackages(5, 1, 6); PrintPackages(5, 1, 7);
        }
    }
}
