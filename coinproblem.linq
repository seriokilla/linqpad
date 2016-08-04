<Query Kind="Program" />

void Main()
{
	var points = new[]{1,2,3};
	var pts = new List<int>();
	GetPermutation(points, pts.ToArray(), 0, 0, 4);
}
public static void GetPermutation(int[] points, int[] pts, int cur, int sum, int goal)
{
	if (sum < goal) 
	{
		foreach(int p in points)
		{
			if (cur <= p)
			{
				var copy = new List<int>(pts);
				copy.Add(p);
				GetPermutation(points, copy.ToArray(), p, sum + p, goal);
			}
		}
	}
		
	if (sum == goal)
	{
		var output = string.Join(",", pts.Select (f  => f.ToString()).ToArray());
		Console.WriteLine("Y: " + output);
		return;
	}
}