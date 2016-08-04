<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	Console.WriteLine(ConvertToDecimal("12345.6789"));
	LoopBackAround(10);
	Console.WriteLine(recursive_reverse("this is my string"));
	
	var divList = DivisibleByValue(0, 100, 33);
	divList.Dump();
	
	var list = new List<int>();
	
	for(int i=0; i<1000; i++)
		list.Add(i);
	
	Batch(list, 5);
}

void Batch(List<int> list, int batchSize)
{
	int start = 0;
	while(start < list.Count)
	{
		var batch = list.GetRange(start, batchSize);
		start = start+batchSize;
		
		batch.Dump();
	}
}

IEnumerable<IEnumerable<T>> Batch<T>(List<T> source, int batchSize)
{
	for(int i=0; i<source.Count; i+=batchSize)
	{
		yield return source.Skip(i).Take(batchSize);
	}
}

string recursive_reverse(string s)
{
		if (s.Length == 0) return "";
		return recursive_reverse(s.Substring(1)) + s[0];
}

void LoopBackAround(int numberTimes)
{
	 string[] a = new []{"one", "two", "three", "four", "five", "six", "seven"};
		
		for(int i=0; i<numberTimes; i++)
		{
			Console.WriteLine(i + " " + a[i%a.Length]);
		}
}

decimal ConvertToDecimal(string s)
{
	decimal dec = 0.00M;
	
	bool isLeft = true;
	int place = 1;
	for (int i = 0; i < s.Length; i++)
	{
		if (s[i] == '.')
		{
				isLeft = false;
		}
		else
		{
			if (isLeft)
				dec = (dec * 10) + (s[i] - '0');
			else
				dec = dec + (s[i] - '0') / (decimal) Math.Pow(10, place++);
		}
	}
	
	return dec;
}

List<int> DivisibleByValue(int start, int end, int ValToBeDiv)
{
	List<int> isDivList = new List<int>();
	for(int i=start; i<=end; i++)
	{
		if (i%ValToBeDiv == 0)
		{
			isDivList.Add(i);
		}
	}

	return isDivList;
}