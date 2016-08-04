<Query Kind="Program" />

void Main()
{
	var head = new TreeNode<int>(5);
	head.Left = new TreeNode<int>(3);
	head.Left.Left = new TreeNode<int>(2);
	head.Left.Right = new TreeNode<int>(4);
	head.Left.Left.Left = new TreeNode<int>(1);
	
	head.Right = new TreeNode<int>(7);
	head.Right.Left = new TreeNode<int>(6);
	head.Right.Right = new TreeNode<int>(8);
	
	Traverse<int>(head);
	
}
public void Traverse<T>(TreeNode<T> head)
{
	if (head == null) return;
	
	Traverse(head.Left);
	Console.WriteLine(head.Content);
	Traverse(head.Right);
}
// Define other methods and classes here
public class TreeNode<T>
{
	public T Content;
	public TreeNode<T> Left;
	public TreeNode<T> Right;
	public TreeNode(){}
	public TreeNode(T c)
	{
		Content = c;
	}
}