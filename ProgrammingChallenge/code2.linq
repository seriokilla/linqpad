<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var intarray = new[]{81, 861391, 861392, 861393, 861394};
	DoWork(intarray);
	
//	for(var i=0; i<1000000; i++)
//	{
//		if (IsPrime(i))
//			Console.WriteLine(i);
//	}
}

void DoWork(int[] numbers)
{
	int totalEven = 0;
	int totalOdd = 0;
	int totalPerfectSquares = 0;
	var primes = new List<int>();
	
	foreach(var n in numbers)
	{
		if (IsEven(n)) 
			totalEven++;
		else 
			totalOdd++;

		if (IsPerfectSquare(n)) 
			totalPerfectSquares++;
			
		if (IsPrime(n))
			primes.Add(n);
	}
	
	Console.WriteLine("Total Even:" + totalEven);
	Console.WriteLine("Total Odd:" + totalOdd);
	Console.WriteLine("Total Perfect Squares:" + totalPerfectSquares);
	Console.WriteLine("Primes: " + string.Join(", ", primes.OrderByDescending (p => p)));
}

// Define other methods and classes here
bool IsEven(int number)
{
	return number % 2 == 0;
}
bool IsPerfectSquare(int number)
{
	double result = Math.Sqrt(number);
	return result%1 == 0;
}
bool IsPrime(int number)
{
    if (number < 2) return false;
    if (number == 2) return true;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 2; i <= boundary; ++i)
    {
        if (number % i == 0)  return false;
    }

    return true;        
}