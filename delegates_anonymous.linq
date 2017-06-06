<Query Kind="Program" />

void Main()
{
	var numbers = new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	var results = RunGauntlet(numbers, (n) => {return n > 4;});
	results.Dump();
}

// Define other methods and classes here
IEnumerable<int> RunGauntlet(IEnumerable<int> numbers, Func<int, bool> gauntlet)
{
	foreach(var n in numbers)
	{
		if (gauntlet(n))
			yield return n;
	}
}