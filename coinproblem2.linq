<Query Kind="Program" />

void Main()
{
	permute(new List<int>(),0,0,4);
}

List<int> parts = new List<int>{1,2,3};
void permute(List<int> list, int start, int sum, int total)
{
	if (sum == total)
	{
		Console.WriteLine(string.Join(",", list.Select(f => f.ToString()).ToArray()));
		return;
	}
	else if (sum < total)
	{
		foreach(var p in parts)
		{
			if (p >= start)
			{
				var copy = new List<int>(list);
				copy.Add(p);
				permute(copy, p, sum+p, total);
			}
		}
	}
}