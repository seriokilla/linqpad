<Query Kind="Program" />

void Main()
{
	Permutation_Method(new[]{1,2,3}, 0);
}

public void Permutation_Method<T>(T[] list, int pos)
{
    if(pos == list.Length)
	{
		Console.WriteLine(string.Join(" ", list));
	}
	else
	{
		for(int i = pos; i < list.Length; i++)
		{
			Swap(ref list[pos], ref list[i]);
			Permutation_Method(list, pos + 1);
			Swap(ref list[pos], ref list[i]);
		}
	}
}

public void Swap<T>(ref T x, ref T y)
{
	T t = x;
	x = y;
	y = t;
}
