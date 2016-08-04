<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	function("()").Dump();
	function("())").Dump();
	function("(()").Dump();
	function(")").Dump();
}

static bool function(string s)
{
	int paren = 0;
	foreach(var c in s)
	{
		if (c == '(') paren++;
		if (c == ')') paren--;
		
		if (paren < 0) return false;
	}
	
	return (paren == 0);
}