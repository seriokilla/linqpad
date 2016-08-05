<Query Kind="Program" />

void Main()
{
	Enumerable
		.Range(1, 100)
		.Select(i => (i % 3 == 0 && i % 5 == 0 ? "fizzbuzz" : i % 3 == 0 ? "fizz" : i % 5 == 0 ? "buzz" : i.ToString()))
		.ToList()
		.ForEach(i => Console.WriteLine(i));
}

// Define other methods and classes here
