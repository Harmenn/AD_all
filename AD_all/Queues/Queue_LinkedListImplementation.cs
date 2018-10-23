using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.Queues
{
	class Queue_LinkedListImplementation
	{
		private Node<int> _head;
		private Node<int> _tail;
		private int _length = 0;

		public Queue_LinkedListImplementation()
		{
			_head = new Node<int>(0);
			_tail = new Node<int>(0);
		}

		public void Enqueue(int value)
		{
			Node<int> tempNode = new Node<int>(value);
			if (_head == null)
			{
				_head = tempNode;
				_tail = tempNode;
			}
			else
			{
				tempNode.Next = _head;
				_head = tempNode;
			}
			_length++;
		}

		public Node<int> Dequeue()
		{
			Node<int> temp = _head;
			_head = _head.Next;
			return temp;
		}

		public override string ToString()
		{
			Node<int> tempNode = _head;
			string s = "[";
			while (tempNode.Next != null)
			{
				s += tempNode.Value + ",";
				tempNode = tempNode.Next;
			}
			s += tempNode.Value;
			return s.Remove(s.Length - 1, 1) + "]";
		}

	}

	public class Node<T>
	{
		public Node<T> Next { get; set; }
		public T Value { get; set; }

		public Node(T val)
		{
			Value = val;
		}
	}
}