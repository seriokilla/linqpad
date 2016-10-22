<Query Kind="Program" />

void Main()
{
	var s = "bananas".ToCharArray();
	var ans = removeDupeChar(s);
	Console.WriteLine(ans);
}

// Define other methods and classes here
string removeDupeChar(char[] str)
{
	if (str == null) return "";
	
	int len = str.Length;
	if (len < 2) return new String(str);
	
	int tail = 1;
	
	for(int i=1; i<len; i++)
	{
		int j;
		for(j=0; j<tail; j++)
		{
			if (str[i] == str[j]) break;
		}
		if (j == tail)
		{
			str[tail] = str[i];
			tail++;
		}
	}
	return new String(str).Substring(0, tail);
}