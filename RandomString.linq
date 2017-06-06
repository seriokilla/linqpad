<Query Kind="Program" />

void Main()
{
	// Loop it
	for(int i=1; i<=10; i++)
	{
		Console.WriteLine(RandomString(i));
	}

	// foreach in a range
	foreach(var el in Enumerable.Range(1, 10))
	{
		Console.WriteLine(RandomString(el));
	}
	
	// linq it
	Enumerable.Range(1, 10).ToList().ForEach((el) => {Console.WriteLine(RandomString(el));});
}

// Define other methods and classes here


public string RandomString(int length)
{
	int times = length / 11;
	var str = "";
	for(int i=0; i<=times; i++)
	{
		str += Path.GetRandomFileName().Replace(".", "");
	}
	return str.Substring(0, length);
}