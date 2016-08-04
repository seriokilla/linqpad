<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

static void Main()
{
//
// Compute two with the exponent of 30.
//
	foreach (int value in ComputePower(2, 30))
	{
		Console.Write(value);
		Console.Write(" ");
	}
	Console.WriteLine();
	Console.WriteLine();
	
	foreach(int val in ComputePower2(2, 30))
	{
		Console.Write(val);
		Console.Write(" ");
	}
	Console.WriteLine();
}

public static IEnumerable<int> ComputePower(int number, int exponent)
{
	int exponentNum = 0;
	int numberResult = 1;
	//
	// Continue loop until the exponent count is reached.
	//
	while (exponentNum < exponent)
	{
		//
		// Multiply the result.
		//
		numberResult *= number;
		exponentNum++;
		//
		// Return the result with yield.
		//
		yield return numberResult;
	}
}

public static List<int> ComputePower2(int number, int exponent)
{
	var list = new List<int>();
	for(int i=1; i<=exponent; i++)
	{
		int res = 1;
		for(int j=1; j<=i; j++)
			res *= number;
			
		list.Add(res);
	}
	return list;
}