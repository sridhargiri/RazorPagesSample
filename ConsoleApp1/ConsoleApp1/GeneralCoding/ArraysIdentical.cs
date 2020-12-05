using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ArraysIdentical
    {
        static int N = 100010;

        /* 'id': stores parent of a node. 
            'sz': stores size of a DSU tree. */
        static int[] id = new int[100010];
        static int[] sz = new int[100010];

        // Function to assign root 
        static int Root(int idx)
        {
            int i = idx;
            while (i != id[i])
            {
                id[i] = id[id[i]];
                i = id[i];
            }

            return i;
        }

        // Function to find Union 
        static void Union(int a, int b)
        {
            int i = Root(a);
            int j = Root(b);

            if (i != j)
            {
                if (sz[i] >= sz[j])
                {
                    id[j] = i;
                    sz[i] += sz[j];
                    sz[j] = 0;
                }
                else
                {
                    id[i] = j;
                    sz[j] += sz[i];
                    sz[i] = 0;
                }
            }
        }

        // function to find minimum changes required 
        // to make both array equal. 
        static int minChange(int n, int[] a, int[] b)
        {

            // Sets as single elements 
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }

            // Combine items if they belong to different 
            // sets. 
            for (int i = 0; i < n; ++i)

                // true if both elements have different root 
                if (Root(a[i]) != Root(b[i]))
                    Union(a[i], b[i]); // make root equal 

            // Find sum sizes of all sets formed. 
            int ans = 0;
            for (int i = 0; i < n; ++i)
                if (id[i] == i)
                    ans += (sz[i] - 1);

            return ans;
        }
        static void countN(string str)
        {
            Dictionary<char, int> vs = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!vs.ContainsKey(str[i]))
                {
                    vs.Add(str[i], 1);
                }
                else
                {
                    vs[str[i]] = vs[str[i]] + 1;
                }
            }
            foreach (var item in vs)
            {
                Console.WriteLine("{0}{1}", item.Key, item.Value);
            }
        }
        /*
         Input : 1 2 2
        1 2 5
Output: 1
Here, (x, y) = (5, 2) hence ans = 1.

Input : 2 1 1 3 5
        1 2 2 4 5
Output: 2
Here, (x, y) = (1, 2) and (3, 4) thus ans = 2.
Other pairs are also possible.
             */
        // Driver program 
        public static void Main()
        {

            int[] a = { 2, 1, 1, 3, 5 };
            int[] b = { 1, 2, 2, 4, 5 };
            int n = a.Length;
            Console.WriteLine(minChange(n, a, b));
        }
    }
}
