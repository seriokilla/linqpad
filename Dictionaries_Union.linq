<Query Kind="Program" />

void Main()
{
	var d1 = new Dictionary<string, int>()
	{
		{"one", 1},
		{"two", 2},
		{"three", 3}
	};
	
	var d2 = new Dictionary<string, int>()
	{
		{"three", 3},
		{"four", 4}
	};
	
	var total = d1.Union(d2).ToDictionary (k => k.Key, v => v.Value);
	
	total.Dump();
}

// Define other methods and classes here
