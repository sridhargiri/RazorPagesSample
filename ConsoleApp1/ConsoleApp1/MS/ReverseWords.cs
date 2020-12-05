// C# program to reverse individual 
// words in a given string using STL list 
using System;
using System.Collections.Generic;

class ReverseWords
{

	// reverses individual words 
	// of a string 
	public static void reverseWords(string str)
	{
		Stack<char> st = new Stack<char>();

		// Traverse given string and push 
		// all characters to stack until 
		// we see a space. 
		for (int i = 0; i < str.Length; ++i)
		{
			if (str[i] != ' ')
			{
				st.Push(str[i]);
			}

			// When we see a space, we 
			// print contents of stack. 
			else
			{
				while (st.Count > 0)
				{
					Console.Write(st.Pop());

				}
				Console.Write(" ");
			}
		}

		// Since there may not be 
		// space after last word. 
		while (st.Count > 0)
		{
			Console.Write(st.Pop());

		}
	}

	// Driver Code 
	public static void Main(string[] args)
	{
		string str = "Geeks for Geeks";
		reverseWords(str);
	}
}

// This code is contributed 
// by Shrikant13 
