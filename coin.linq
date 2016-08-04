<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	var pts = new List<int>();
	GetPermutation(pts.ToArray(), 0, 0, 15);
}
public static int[] points = new[]{3, 6, 7};

public static void GetPermutation(int[] pts, int start, int sum, int goal)
{
	if (sum > goal) 
	{
		var output = string.Join(",", pts.Select (f  => f.ToString()).ToArray());
		Console.WriteLine("N: " + output);
		return;
	}
		
	if (sum == goal)
	{
		var output = string.Join(",", pts.Select (f  => f.ToString()).ToArray());
		Console.WriteLine("Y: " + output);
		return;
	}
	
	foreach(int p in points)
	{
		if (p >= start)
		{
			var copy = new List<int>(pts);
			copy.Add(p);
			GetPermutation(copy.ToArray(), p, sum + p, goal);
		}
	}
}