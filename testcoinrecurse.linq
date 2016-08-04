<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	var coins = new List<int>();
	change(9, 0, 0, coins);
}
public static int[] amounts = new[]{2,3,7,8};
// Define other methods and classes here

public static void change(int goal, int sum, int amt, List<int> res)
{
	if (sum == goal)
	{
		res.Dump();
		return;
	}
	
	if (sum > goal) return;
		
	foreach(int a in amounts)
	{
		if (a >= amt)
		{
			var copy = new List<int>(res);
			copy.Add(a);
			change(goal, sum+a, a, copy);
		}
	}
}
