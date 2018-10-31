using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all
{
	class bhNode
	{
		private int value;
		private bool isset;

		public bhNode()
		{
			this.isset = false;
		}

		public bhNode(int value)
		{
			this.value = value;
			this.isset = true;
		}

		public int getValue()
		{
			if (isset)
				return value;
			else
				return -1;
		}

		public bool hasValue()
		{
			return isset;
		}
	}

	class BinaryHeap
	{
		private bhNode[] array;
		private int currentSize;

		public BinaryHeap()
		{
			array = new bhNode[10];
			currentSize = 0;
			//array = new int[15] { 0, 13, 21, 16, 24, 31, 19, 68, 65, 26, 32, 0, 0, 0, 0 };
			//array = new int[15] { 0, 13, 14, 16, 19, 21, 19, 68, 65, 26, 32, 31, 0, 0, 0 };
			//currentSize = 11;
			//array = new int[15] { 0, 10, 4, 7, 1, 3, 5, 0, 0, 0, 0, 0, 0, 0, 0 };
			//currentSize = 6;
		}

		public bool isComplete(int index)
		{
			int left_child_index = index * 2;
			int right_child_index = index * 2 + 1;

			if (index == currentSize || right_child_index > currentSize || left_child_index > currentSize) // last node in tree
			{
				return true;
			}
			if (array[left_child_index].hasValue() && (array[right_child_index].hasValue()))
			{
				if (isComplete(left_child_index) && isComplete(right_child_index))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		public bool isMaxHeap(int index)
		{

			return false;
		}

		public void Add(int val)
		{
			if (currentSize == 0)
			{
				currentSize = 1;
				array[1] = new bhNode(val);
				return;
			}

			if (currentSize + 1 > array.Length - 1)
				Verdubbel();

			currentSize++;
			array[currentSize] = new bhNode(val);

		}

		private void Verdubbel()
		{
			Console.WriteLine("Verdubbel");
			bhNode[] newArray;
			newArray = new bhNode[array.Length * 2];

			// Copy elements that are logically in the queue
			for (int i = 0; i < array.Length; i++)
				newArray[i] = array[i];

			array = newArray;

		}

		public int find()
		{
			return 0;
		}

		public int findMin()
		{
			return array[1].getValue();
		}

		public int findMax()
		{
			int currIndex = 1;
			int left_child_index = currIndex * 2;
			int right_child_index = currIndex * 2 + 1;
			while (left_child_index < currentSize)
			{
				left_child_index = currIndex * 2;
				right_child_index = currIndex * 2 + 1;

				if (left_child_index > currentSize)
					break;

				if (array[left_child_index].getValue() > array[right_child_index].getValue())
				{
					currIndex = left_child_index;
				}
				else
				{
					currIndex = right_child_index;
				}
			}
			return array[currIndex].getValue();
		}

		public void removeMin()
		{
			array[1] = array[currentSize];
			array[currentSize] = new bhNode();
			currentSize--;

			Percolate_down(1);
		}

		private void Percolate_down(int ndx_index)
		{
			int ndx_left_child_index = ndx_index * 2;
			int ndx_right_child_index = ndx_index * 2 + 1;


			while (array[ndx_index].getValue() > ndx_left_child_index || array[ndx_index].getValue() > ndx_right_child_index)
			{
				ndx_left_child_index = ndx_index * 2;
				ndx_right_child_index = ndx_index * 2 + 1;

				if (currentSize < ndx_left_child_index)
					break;

				if (currentSize < ndx_right_child_index)
					break;

				if (array[ndx_index].getValue() < array[ndx_left_child_index].getValue() && array[ndx_index].getValue() < array[ndx_right_child_index].getValue())
					break;

				if (ndx_left_child_index > currentSize)
					break;

				int moveIndex = ndx_left_child_index;
				//Console.WriteLine("Swapping " + array[ndx_index] + " with " + array[moveIndex]);
				if (array[ndx_left_child_index].getValue() > array[ndx_right_child_index].getValue())
					moveIndex = ndx_right_child_index;

				bhNode tmp = array[moveIndex];
				array[moveIndex] = array[ndx_index];
				array[ndx_index] = tmp;
				ndx_index = moveIndex;
			}
		}

		public void newHeap(bhNode[] heap)
		{
			this.array = heap;
			this.currentSize = this.array.Length - 1;
		}

		public void buildHeap(bhNode[] heap)
		{


			this.array = heap;
			this.currentSize = heap.Length - 1;
			for (int i = currentSize / 2; i > 0; i--)
				Percolate_down(i);
		}

		public override string ToString()
		{
			string str = "BinHeap[";

			foreach (bhNode i in this.array)
			{
				if (i.hasValue())
				{
					str += i.getValue() + ", ";
				}
				else
				{
					str += "-, ";
				}
			}
			return str.Substring(0, str.Length - 2) + "]\n";
		}
	}
}
