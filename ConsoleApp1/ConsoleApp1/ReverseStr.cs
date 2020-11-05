using System;
namespace ConsoleApp1
{

    public class ReverseStr
    {
        /// <summary>
        /// Reverse str skip special character
        /// Input string: a!!!b.c.d,e'f,ghi
        /// Output string: i!!!h.g.f,e'd,cba
        /// </summary>
        /// <param name="str"></param>
        public static void reverse(char[] str)
        {
            // Initialize left and right pointers  
            int r = str.Length - 1, l = 0;

            // Traverse string from both ends until  
            // 'l' and 'r'  
            while (l < r)
            {
                // Ignore special characters  
                if (!char.IsLetter(str[l]))
                    l++;
                else if (!char.IsLetter(str[r]))
                    r--;

                // Both str[l] and str[r] are not spacial  
                else
                {
                    char tmp = str[l];
                    str[l] = str[r];
                    str[r] = tmp;
                    l++;
                    r--;
                }
            }
        }

        // Driver Code  
        public static void Main()
        {
            String str = "a!!!b.c.d,e'f,gh";
            char[] charArray = str.ToCharArray();

            Console.WriteLine("Input string: " + str);
            reverse(charArray);
            String revStr = new String(charArray);

            Console.WriteLine("Output string: " + revStr);
        }
    }
}

// This code is contributed by PrinciRaj1992 