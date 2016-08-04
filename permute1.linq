<Query Kind="Program" />

void Main()
{
	permute("", "abcd");	
}

// Define other methods and classes here
static int idx = 0;
void permute(string start, string end)
{
	if (end.Length == 1)
		Console.WriteLine(idx++ + "-" + start + "+" + end);
	else
	{
		for(int i=0; i<end.Length; i++)
		{
			var a = end[i];
			var b = end.Substring(i+1);
			var c = end.Substring(0, i);
			var str = b + c;
			Console.WriteLine(idx++ + "[" + start + "+" + end + "] fix " + a + ", " + b + "+" + c);
			permute(start + a, str);
		}
	}
}