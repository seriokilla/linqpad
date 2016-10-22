<Query Kind="Program" />

void Main()
{
	var s = "baa";
	var ans = removeDupeChar(s);
	Console.WriteLine(ans);
}

// Define other methods and classes here
string removeDupeChar(string str)
{
	var ary = str.ToCharArray();
	if (ary.Length == 0) return str;
	
	int ptr = 1;
	for(int i=1; i<ary.Length; i++)
	{
		int j;
		for(j=0; j<ptr; j++)
		{
			if (ary[i] == ary[j]) break;
		}
		
		if (j == ptr)
		{
			ary[ptr] = ary[i];
			ptr++;
		}
	}
	return new string(ary).Substring(0, ptr);
}