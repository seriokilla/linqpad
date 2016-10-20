<Query Kind="Program" />

void Main()
{
	var nums = new [] {3,2,4,1,7,6,8};
	var head = new TreeNode<int>(5);
	
	foreach(var n in nums)
		Insert(n, ref head);
		
	Traverse<int>(head);
}

public void Traverse<T>(TreeNode<T> head) where T : IComparable<T>
{
	if (head == null) return;
	
	Traverse(head.Left);
	Console.WriteLine(head.Content);
	Traverse(head.Right);
}

public void Insert<T>(T item, ref TreeNode<T> node) where T : IComparable<T>
{
	if (node == null)
	{
		node = new TreeNode<T>(item);
		return;
	}
	
	if (node.Content.CompareTo(item) > 0)
	{
		Insert(item, ref node.Left);
	}
	
	if (node.Content.CompareTo(item) < 0)
	{
		Insert(item, ref node.Right);
	}
}

public class TreeNode<T> where T : IComparable<T>
{
	public T Content;
	public TreeNode<T> Left;
	public TreeNode<T> Right;
	public TreeNode(T c)
	{
		Content = c;
	}
}