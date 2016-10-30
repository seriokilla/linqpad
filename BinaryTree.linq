<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var tree = new BinaryTree<int>();

	var seq = new []{5,2,7};
	foreach(var s in seq)
	{
		tree.Insert(s);
	}
	var rc = tree.ReturnPreOrder(tree.Head);
	rc.Dump();
//	
//	tree.Traverse(BinaryTree<int>.TraverseOrder.InOrder);
//	Console.WriteLine("-------------------");
//	tree.Traverse(BinaryTree<int>.TraverseOrder.PreOrder);
//	Console.WriteLine("-------------------");
//	tree.Traverse(BinaryTree<int>.TraverseOrder.PostOrder);
//	Console.WriteLine("-------------------");
//	tree.Traverse(BinaryTree<int>.TraverseOrder.ReverseOrder);
}

// Define other methods and classes here

public class Node<T>
{
	public Node(T item){Item = item;}
	public T Item;
	public Node<T> Left;
	public Node<T> Right;
}

public class BinaryTree<T> where T : IComparable
{
	public enum TraverseOrder
	{
		PreOrder,
		InOrder,
		PostOrder,
		ReverseOrder
	};
	
	public Node<T> Head;
	
	public void Insert(T item)
	{
		Insert(ref Head, item);
	}
	public void Traverse(TraverseOrder order = TraverseOrder.InOrder)
	{
		switch(order)
		{
			case TraverseOrder.PreOrder:
				TraversePreOrder(Head);
				break;
			case TraverseOrder.PostOrder:
				TraversePostOrder(Head);
				break;
			case TraverseOrder.ReverseOrder:
				TraverseReverseOrder(Head);
				break;
			default:
				TraverseInOrder(Head);
				break;
		}
	}
	
	public List<T> ReturnPreOrder(Node<T> n)
	{
		var rc = new List<T>();
		if (n == null) return rc;
		
		rc.Add(n.Item);
		var l = ReturnPreOrder(n.Left);
		rc = rc.Concat(l).ToList();
		
		var r = ReturnPreOrder(n.Right);
		rc = rc.Concat(r).ToList();
		
		return rc;
	}
	
	protected void TraverseInOrder(Node<T> n)
	{
		if (n == null)
			return;
			
		TraverseInOrder(n.Left);
		Console.WriteLine(n.Item);
		TraverseInOrder(n.Right);
	}
	protected void TraversePreOrder(Node<T> n)
	{
		if (n == null) return;
		
		Console.WriteLine(n.Item);
		TraversePreOrder(n.Left);
		TraversePreOrder(n.Right);
	}
	protected void TraversePostOrder(Node<T> n)
	{
		if (n == null) return;
		
		TraversePostOrder(n.Left);
		TraversePostOrder(n.Right);
		Console.WriteLine(n.Item);
	}
	protected void TraverseReverseOrder(Node<T> n)
	{
		if (n == null) return;
		
		TraverseReverseOrder(n.Right);
		Console.WriteLine(n.Item);
		TraverseReverseOrder(n.Left);
	}
	protected void Insert(ref Node<T> node, T item)
	{
		if (node == null)
		{
			node = new Node<T>(item);
		}
		else
		{
			var comp = item.CompareTo(node.Item);
			if (comp == 0) return;
			
			if (item.CompareTo(node.Item) < 0)
				Insert(ref node.Left, item);
			else
				Insert(ref node.Right, item);
		}
	}
}