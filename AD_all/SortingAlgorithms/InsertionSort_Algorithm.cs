using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.SortingAlgorithms
{
	class InsertionSort_Algorithm
	{
		public static void InsertionSort(int[] arr)
		{
			for (int i = 1; i <= arr.Length - 1; i++)
			{
				for (int j = i; j > 0; j--)
				{
					if (arr[j] < arr[j - 1])
					{
						int tmp = arr[j - 1];
						arr[j - 1] = arr[j];
						arr[j] = tmp;
					}
				}
			}
		}
	}
}
