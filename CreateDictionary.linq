<Query Kind="Program" />

void Main()
{
	var names = new []{"three", "four", "six", "seven"};
	var headers = new List<string> {"one", "two", "three", "four", "five", "six"};
	var dict = names.Where(f => headers.Contains(f))
				 .ToDictionary (k => k, v => headers.FindIndex(f => f == v));
	dict.Dump();
}

// Define other methods and classes here
