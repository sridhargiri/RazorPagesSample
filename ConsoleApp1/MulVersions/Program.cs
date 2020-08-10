using System;

namespace MulVersions
{
    class Program
    {
        public static void Main(string[] args)
        {

#if NET40
        Console.WriteLine("Target framework: .NET Framework 4.0");
#elif NET45
        Console.WriteLine("Target framework: .NET Framework 4.5");
#else
            Console.WriteLine("Target framework: .NET Core 2.0");
#endif
            Console.ReadKey();
            string s1 = "geeks";
            string s2 = "forgeeks";
            string result = string.Empty;
            for (int i = 0; i < s1.Length || i < s2.Length; i++)
            {

                // First choose the ith character of the  
                // first string if it exists  
                if (i < s1.Length)
                    result += s1[i];

                // Then choose the ith character of the  
                // second string if it exists  
                if (i < s2.Length)
                    result += s2[i];
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
