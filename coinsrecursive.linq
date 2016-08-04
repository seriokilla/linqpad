<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	var coins = new List<int>();
	change(coins, 0, 0, 2);
}
public static int[] amounts = new[]{2,3,6,7,8};
// Define other methods and classes here

public static void change(List<int> coins, int start, int sum, int goal)
{
	if (sum == goal)
	{
		coins.Dump();
		return;
	}
	
	if (sum > goal) return;
	
	foreach(int a in amounts)
	{
		if (a >= start)
		{
			var copy = new List<int>(coins);
			copy.Add(a);
			change(copy, a, sum + a, goal);
		}
	}
}
