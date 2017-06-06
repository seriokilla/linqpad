<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	// given a list of numbers:
	// count total even, total odd, total perfect squares 
	// and output all primes in descending order
	DoWork(Enumerable.Range(0, 100));
}

void DoWork(IEnumerable<int> numbers)
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
    var boundary = (int)Math.Sqrt(number);

    for (int i = 2; i <= boundary; ++i)
    {
        if (number % i == 0)  return false;
    }

    return true;        
}