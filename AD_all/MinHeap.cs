using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.Stacks
{
	class BinaryHeap
	{
		private int[] array;
		private int currentSize;

		public BinaryHeap()
		{
			array = new int[10];
			array = new int[15] { 0, 13, 21, 16, 24, 31, 19, 68, 65, 26, 32, 0, 0, 0, 0 };
			array = new int[15] { 0, 13, 14, 16, 19, 21, 19, 68, 65, 26, 32, 31, 0, 0, 0 };
			currentSize = 11;
		}

		public void Add(int val)
		{
			if (currentSize == 0)
			{
				currentSize = 1;
				array[1] = val;
				return;
			}

			if (currentSize + 1 > array.Length - 1)
				Verdubbel();

			currentSize++;
			int ndx = currentSize;
			int ndx_parent = currentSize / 2;

			array[currentSize] = val;

			//Console.WriteLine("child " + array[ndx] + " its parent is " + array[ndx_parent]);

			while (ndx_parent > 0)
			{
				//Console.WriteLine(array[ndx_parent] + " comparing to " + array[ndx]);
				if (array[ndx_parent] > array[ndx])
				{
					//Console.WriteLine(array[ndx_parent] + " is bigger than " + array[ndx]);
					array[ndx] = array[ndx_parent];
					array[ndx_parent] = val;
				}
				else
				{
					//Console.WriteLine("Done perculating up");
					//Console.WriteLine("child " + array[ndx] + " its parent is " + array[ndx_parent]);
					break;
				}

				ndx = ndx_parent;
				ndx_parent = ndx_parent / 2;
			}
		}

		private void Verdubbel()
		{
			Console.WriteLine("Verdubbel");
			if (currentSize >= this.array.Length)
			{
				int[] newArray;
				newArray = new int[array.Length * 2];

				// Copy elements that are logically in the queue
				for (int i = 0; i < array.Length; i++)
					newArray[i] = array[i];

				array = newArray;
			}
		}

		public int find()
		{
			return 0;
		}

		public int findMin()
		{
			return array[1];
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

				if (array[left_child_index] > array[right_child_index])
				{
					currIndex = left_child_index;
				}
				else
				{
					currIndex = right_child_index;
				}
			}
			return array[currIndex];
		}

		public void removeMin()
		{
			array[1] = array[currentSize];
			array[currentSize] = 0; //niet nodig maar is overzichtelijker
			currentSize--;

			Percolate_down(1);
		}

		private void Percolate_down(int ndx_index)
		{
			int ndx_left_child_index = ndx_index * 2;
			int ndx_right_child_index = ndx_index * 2 + 1;


			while (array[ndx_index] > ndx_left_child_index || array[ndx_index] > ndx_right_child_index)
			{
				ndx_left_child_index = ndx_index * 2;
				ndx_right_child_index = ndx_index * 2 + 1;

				if (currentSize < ndx_left_child_index)
					break;

				if (currentSize < ndx_right_child_index)
					break;

				if (array[ndx_index] < array[ndx_left_child_index] && array[ndx_index] < array[ndx_right_child_index])
					break;

				if (ndx_left_child_index > currentSize)
					break;

				int moveIndex = ndx_left_child_index;
				//Console.WriteLine("Swapping " + array[ndx_index] + " with " + array[moveIndex]);
				if (array[ndx_left_child_index] > array[ndx_right_child_index])
					moveIndex = ndx_right_child_index;

				int tmp = array[moveIndex];
				array[moveIndex] = array[ndx_index];
				array[ndx_index] = tmp;
				ndx_index = moveIndex;
			}
		}

		public void buildHeap(int[] heap)
		{
			this.array = heap;
			this.currentSize = heap.Length - 1;
			for (int i = currentSize / 2; i > 0; i--)
				Percolate_down(i);
		}

		public override string ToString()
		{
			string str = "BinHeap[";

			foreach (int i in this.array)
			{
				str += i + ", ";
			}
			return str.Substring(0, str.Length - 2) + "]\n";
		}
	}
}
