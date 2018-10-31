using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all
{
	class Program
	{
		static int[] array = new int[7] { 9, 7, 1, 8, 5, 4, 2 };
		public int[] quickSortarray = new int[11] { 1, 8, 7, 10, 2, 4, 11, 3, 5, 6, 9 };

		static void Main(string[] args)
		{
			BinaryHeap bh = new BinaryHeap();
			bh.newHeap(new bhNode[8] { new bhNode(),
										new bhNode(10),
										new bhNode(4),
										new bhNode(7),
										new bhNode(1),
										new bhNode(3),
										new bhNode(),
										new bhNode(5) });
			Console.WriteLine("isComplete: "+ bh.isComplete(1));
			
			BinaryHeap bh2 = new BinaryHeap();
			bh2.newHeap(new bhNode[9] { new bhNode(),
										new bhNode(15),
										new bhNode(5),
										new bhNode(11),
										new bhNode(3),
										new bhNode(4),
										new bhNode(10),
										new bhNode(7),
										new bhNode(1) });
			Console.WriteLine("isComplete: " + bh2.isComplete(1));


			SortingAlgorithms.MergeSort_Algorithm.MergeSort(array);

			Echoarray(array);
		}

		static void Echoarray(int[] arr)
		{
			string s = "";
			for (int i = 0; i < arr.Length; i++)
			{
				s += "," + arr[i];
			}
			Console.WriteLine(s.Substring(1, s.Length - 1));
			Console.Read();
		}
	}
}
