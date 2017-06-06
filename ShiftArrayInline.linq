<Query Kind="Program" />

void Main()
{
	var a = new int[]{1, 2, 3, 4, 5};
	a.Dump();
	ShiftOnce(a);
	a.Dump();
	
	Shift(a, 3);
	a.Dump();
}

void Shift(int[] a, int numTimes)
{
	for(int i=0; i<numTimes; i++)
		ShiftOnce(a);
}

// Define other methods and classes here
void ShiftOnce(int[] a)
{
	for(int i=a.Length-1; i>0; i--)
	{
		Swap(ref a[i-1], ref a[i]);
	}
}

void Swap(ref int x, ref int y)
{
	var tmp = x;
	x = y;
	y = tmp;
}

