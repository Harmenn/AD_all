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
