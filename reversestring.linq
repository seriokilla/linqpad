<Query Kind="Program" />

void Main()
{
	var str = "ABC".ToCharArray();
	reverse(ref str);
	str.Dump();
	
	var s = ReverseString_Rec("abc");
	s.Dump();
}

// Define other methods and classes here
void reverse(ref char[] str)
{
	for(int start=0, end=str.Length-1; start < str.Length/2; start++, end--)
	{
		Swap(ref str[start], ref str[end]);
	}
}

void Swap(ref char x, ref char y)
{
	char t = y;
	y = x;
	x = t;
}

public static string ReverseString_Rec(string str)
{
   if (str.Length <= 1)
    return str;
   else
   return ReverseString_Rec(str.Substring(1)) + str[0];
}