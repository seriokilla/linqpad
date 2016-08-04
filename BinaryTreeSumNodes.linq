<Query Kind="Program" />

void Main()
{
	var n = new Node(5);
	n.Left = new Node(3);
	n.Right = new Node(7);
	
	n.Left.Left = new Node(2);
	n.Left.Right = new Node(4);
	n.Left.Left.Left = new Node(1);

	n.Right.Left = new Node(6);
	n.Right.Right = new Node(8);
	n.Right.Right.Right = new Node(9);

	n.Sum().Dump();
}

// Define other methods and classes here
public class Node
{
	public int Value;
	public Node Left;
	public Node Right;
	public Node(int val)
	{
		Value = val;
	}
	
	public int Sum()
	{
		return Sum(this);
	}
	
	protected int Sum(Node n)
	{
		if (n == null) return 0;
		
		int l = Sum(n.Left);
		int r = Sum(n.Right);
		return l + r + Value;
	}
}
