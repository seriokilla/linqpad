<Query Kind="Program" />

void Main()
{
	var vals = new []{1, 9, 8, 4, 11, 2, 3, 6, 7};
	var	Head = new Leaf<int>(1);
	var curr = Head;
	for(int i=1; i<vals.Length; i++)
	{
		SeriesCounter.Insert(ref curr, vals[i]);
	}	
	
	var list = new List<int>();
	int max = 0;
	int cur = 0;
	SeriesCounter.CountInOrder(Head, ref list, ref cur, ref max);
	Console.WriteLine("Max: " + max);
}

// Define other methods and classes here
public class Leaf<T>
{
	public T Item;
	public Leaf<T> Left;
	public Leaf<T> Right;
	public Leaf(T item){Item = item;}
}

public class SeriesCounter
{
	public static void Insert(ref Leaf<int> node, int item)
	{
		if (node == null)
		{
			node = new Leaf<int>(item);
		}
		else
		{
			if (item < node.Item)
				Insert(ref node.Left, item);
			else
				Insert(ref node.Right, item);
		}
	}
		
	public static void CountInOrder(Leaf<int> head, ref List<int> list, ref int cur, ref int max)
	{
		if (head == null)
			return;
	
		CountInOrder(head.Left, ref list, ref cur, ref max);
		
		Console.WriteLine(head.Item);
		
		if (list.Count == 0 || list[list.Count-1]+1 == head.Item)
			cur++;
		else
		{
			if (cur > max)
			{
				max = cur;
			}
			cur = 1;
		}
			
		list.Add(head.Item);
		
		CountInOrder(head.Right, ref list, ref cur, ref max);
		
		if (cur > max)
		{
			max = cur;
		}
	}
}