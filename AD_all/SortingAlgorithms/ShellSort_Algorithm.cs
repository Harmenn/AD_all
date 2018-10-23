using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all
{
	class ShellSort_Algorithm
	{
		public static void ShellSort(int[] arr)
		{
			int array_size = arr.Length;
			int i, j, inc, temp;
			inc = 3;
			while (inc > 0)
			{
				for (i = 0; i < array_size; i++)
				{
					j = i;
					temp = arr[i];
					while ((j >= inc) && (arr[j - inc] > temp))
					{
						arr[j] = arr[j - inc];
						j = j - inc;
					}
					arr[j] = temp;
				}
				if (inc / 2 != 0)
					inc = inc / 2;
				else if (inc == 1)
					inc = 0;
				else
					inc = 1;
			}
		}
	}
}
