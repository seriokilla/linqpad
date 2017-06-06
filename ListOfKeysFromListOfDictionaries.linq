<Query Kind="Program" />

void Main()
{
	var d1 = new Dictionary<string, int>(){ {"one", 1}, {"two", 2} };
	var d2 = new Dictionary<string, int>(){ {"twentyone", 21}, {"twentytwo", 22} };
	var d3 = new Dictionary<string, int>(){ {"thirtyone", 31}, {"thirtytwo", 32} };
	
	var list = new List<Dictionary<string, int>>() { d1, d2, d3 };
	
	var k = list.SelectMany (l => l.Keys); // key is to use SelectMany
	k.Dump();
}
