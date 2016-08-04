<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var head = new Node();
	
	var curr = head;
	Node mid = head;
	for(int i=0; i<100; i++)
	{
		curr.Data = i;
		curr.Next = new Node();
		
		curr = curr.Next;
	}
	curr.Next = head;
	
	var isCircle = IsCircle(head);
	Console.WriteLine(isCircle.ToString());
}

// Define other methods and classes here
class Node
{
	public Node Next;
	public int Data;
}

bool IsCircle(Node head)
{
	if (head == null || head.Next == null)
		return false;
		
	Node slow = head;
	Node fast = head.Next;
	
	while(true)
	{
		if (fast == null || fast.Next == null)
			return false;
		else if (fast == slow || fast.Next == slow)
			return true;
		else
		{
			fast = fast.Next.Next;
			slow = slow.Next;
		}
	}
}