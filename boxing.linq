<Query Kind="Program" />

void Main()
{
	Console.WriteLine(String.Concat("Answer", 42, true));
	
	
	int i = 123;      // a value type
	object o = i;     // boxing
	int j = (int)o;   // unboxing
	j = j + 100;
	i = i * 2;

	j.Dump();
	o.Dump();
	i.Dump();
}

// Define other methods and classes here
