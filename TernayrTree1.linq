<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net.NetworkInformation</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

	void Main()
	{
		var t = new TernaryTree<int>();

            t.Insert(5);
            t.Insert(3);
            t.Insert(1);
            t.Insert(7);
            t.Insert(5);
            t.Insert(2);
            t.Insert(1);
            t.Insert(2);
            t.Insert(6);
            t.Insert(7);
            t.Insert(8);
            t.Insert(4);
            t.Insert(4);

            t.InOrderTraversal();
	}


    public class Node<T> where T : IComparable<T>
    {
        public T Item { get; set; }

        public Node<T> Left;
        public Node<T> Mid;
        public Node<T> Right;
    }

    public class TernaryTree<T> where T : IComparable<T>
    {
        public Node<T> _head;

        public void Insert(T item)
        {
            Insert(item, ref _head);
        }
		
		protected void Insert(T item, ref Node<T> current)
		{
			if (current == null)
			{
				current = new Node<T>() { Item = item };
				return;
			}
			
			if (current.Item.CompareTo(item) > 0)
				Insert(item, ref current.Left);
				
			if (current.Item.CompareTo(item) == 0)
				Insert(item, ref current.Mid);
				
			if (current.Item.CompareTo(item) < 0)
				Insert(item, ref current.Right);
		}

        public void InOrderTraversal()
        {
            if (_head != null)
                InOrderTraversal(_head);
        }

        protected void InOrderTraversal(Node<T> current)
        {
            if (current == null)
                return;

            InOrderTraversal(current.Left);
            InOrderTraversal(current.Mid);
            Console.WriteLine(current.Item);
            InOrderTraversal(current.Right);
            
        }

        
    }
