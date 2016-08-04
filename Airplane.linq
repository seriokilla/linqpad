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
	int companies = 1;

	for(int i=0; i<10; i++)
		SpewVerbalDiarreah(companies++);
}

void SpewVerbalDiarreah(int companies)
{
	Console.WriteLine("I was successful {0} times at {1} different companies.", companies+1, companies);
	Console.WriteLine("And I've done this many many times.");
	// done
}