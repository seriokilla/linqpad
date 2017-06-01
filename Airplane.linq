<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	TheAirplane();
}

// Define other methods and classes here
void TheAirplane()
{
	Enumerable.Range(0, 10).ToList().ForEach((i) => {SpewVerbalDiarreah(i+1);});
}

void SpewVerbalDiarreah(int companies)
{
	Console.WriteLine("I was successful {0} times at {1} different companies.", companies+1, companies);
	Console.WriteLine("And I've done this many many times.");
	// done
}