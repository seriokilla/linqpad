<Query Kind="Program" />

void Main()
{
	Permutation_Method("abc".ToCharArray(), 0);
}

public void Swap<T>(ref T x, ref T y)
{
	T t = x;
	x = y;
	y = t;
}

static int indent = 0;
public void Permutation_Method<T>(T[] list, int idx)
{
	indent ++;
    if(idx == list.Length)
	{
		Console.WriteLine(string.Join("", list));
	}
	else
	{
		for(int i = idx; i < list.Length; i++)
		{
			Swap(ref list[idx], ref list[i]);
			Permutation_Method(list, idx+1);
			Swap(ref list[idx], ref list[i]);
		}
	}
	indent --;
}