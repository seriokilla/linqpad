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

        public Node<T> Left { get; set; }
        public Node<T> Mid { get; set; }
        public Node<T> Right { get; set; }

        public Node(T item)
        {
            Item = item;
        }
        public void Insert(T item)
        {
            if (Item.CompareTo(item) < 0)
            {
                if (Right == null)
                    Right = new Node<T>(item);
                else
                    Right.Insert(item);
            }

            if (Item.CompareTo(item) == 0)
            {
                if (Mid == null)
                    Mid = new Node<T>(item);
                else
                    Mid.Insert(item);
            }

            if (Item.CompareTo(item) > 0)
            {
                if (Left == null)
                    Left = new Node<T>(item);
                else
                    Left.Insert(item);
            }
        }
    }

    public class TernaryTree<T> where T : IComparable<T>
    {
        private Node<T> _head;

        public void Insert(T item)
        {
            if (_head == null)
                _head = new Node<T>(item);
            else
                _head.Insert(item);
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