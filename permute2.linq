<Query Kind="Program" />

static void Main()
{
	var a = new int[] { 2, 3, 6, 7, 8 };
	Permute(a, 0, a.Length - 1);
}

// Define other methods and classes here
static void Permute<T>(T[] a, int start, int end)
{
	if (start == end)
		Console.WriteLine(string.Join(",", a));
	else
	{
		for (int i = start; i <= end; i++)
		{
			Swap(ref a[start], ref a[i]);
			Permute(a, start + 1, end);
			Swap(ref a[start], ref a[i]); //backtrack
		}
	}
}

static void Swap<T>(ref T x, ref T y)
{
	var t = x;
	x = y;
	y = t;
}
