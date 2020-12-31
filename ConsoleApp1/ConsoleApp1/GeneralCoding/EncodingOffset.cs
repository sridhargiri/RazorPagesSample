/*
A kind of ceaser cipher got in internet hackerrank. drectly typed in github editor
sample run 1
zyxa                                                                                                                    
4                                                                                                                       
dcbe  

sample run 2
3
abcdef
defgef
*/
namespace ConsoleApp1{
public class EncodingOffset
{
    //n is the upto index of the string
    //s input string
    //k is the offset
    public string CharacterOffsetEncoding(int n, string s, int k)
    {
        char[] temp = s.ToCharArray();
        for (int i = 0; i <= n; i++)
        {
            if (s[i] >= 'a' && s[i] <= 'z')
            { // if phrase is lowercase char
                temp[i] = (char)(((s[i] - 'a' + k) % 26) + 'a'); // add key to it and wrap it in range
                                                                 // this guarantees wrap-around, explicitly ensure phrase[i] is a char. this to cycle from the character index not from zero
            }
            else if (s[i] >= 'A' && s[i] <= 'Z')
            { // same as if, but uppercase
                temp[i] = (char)(((s[i] - 'A' + k) % 26) + 'A');
            }
        }
        return new string(temp);
    }
    public static void Main(string[] args)
    {
        EncodingOffset offset = new EncodingOffset();
        string outing = offset.CharacterOffsetEncoding(3, "abcd", 3);
        System.Console.WriteLine(outing);
    }
}
}