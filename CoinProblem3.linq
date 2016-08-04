<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

class Program
{
    static void Main()
    {
		List<int> coins = new List<int>();
		List<int> amounts = new List<int>() { 1, 5, 10, 25, 50 };
		//
		// Compute change for 51 cents.
		//
		Change(coins, amounts, 0, 0, 51);
    }

    static void Change(List<int> coins, List<int> amounts, int highest, int sum, int goal)
    {
		//
		// See if we are done.
		//
		if (sum == goal)
		{
			Display(coins, amounts);
			return;
		}
		//
		// See if we have too much.
		//
		if (sum > goal)
		{
			return;
		}
		//
		// Loop through amounts.
		//
		foreach (int value in amounts)
		{
			//
			// Only add higher or equal amounts.
			//
			if (value >= highest)
			{
				List<int> copy = new List<int>(coins);
				copy.Add(value);
				Change(copy, amounts, value, sum + value, goal);
			}
		}
    }

    static void Display(List<int> coins, List<int> amounts)
    {
		for (int i=amounts.Count-1; i>=0; i--)
		{
			int count = coins.Count(value => value == amounts[i]);
			Console.Write("[{0:00}]: {1,2}\t", amounts[i], count);
		}
		Console.WriteLine();
    }
}