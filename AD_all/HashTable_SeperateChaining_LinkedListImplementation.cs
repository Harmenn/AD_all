using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.SortingAlgorithms
{
	class HashTable_SeperateChaining_LinkedListImplementation
	{
		private Dictionary<int, LinkedList<string>> table;
		private int tableLength = 11;

		public HashTable_SeperateChaining_LinkedListImplementation()
		{
			table = new Dictionary<int, LinkedList<string>>();
		}

		public void addRecord(string s)
		{
			int index = hash(s, tableLength);
			LinkedList<string> record;
			if (table.TryGetValue(index, out record))
			{
				//add to linkedlist
				record.addLast(s);
				Console.WriteLine("added value " + s + " on index " + index);
			}
			else
			{
				//add record
				record = new LinkedList<string>(s);
				table[index] = record;
				Console.WriteLine("created new linkedlist on index " + index + " for value " + s);
			}
		}

		public string findRecord(string s)
		{
			int index = hash(s, tableLength);
			LinkedList<string> record;
			if (table.TryGetValue(index, out record))
			{
				int linkedListIndex = record.getIndexValue(s);
				if (linkedListIndex >= 0)
				{
					Console.WriteLine("Found value " + s + " on table index " + index + " on linkedlist index " + linkedListIndex);
					return linkedListIndex.ToString();
				}
				else
				{
					Console.WriteLine("Value " + s + " not found (not found in linkedlist)");
					return linkedListIndex.ToString();
				}
			}
			else
			{
				Console.WriteLine("Value " + s + " not found (No list on index)");
				return "Not found";
			}
		}

		private int hash(string key, int tableSize)
		{
			int hashVal = 0;

			for (int i = 0; i < key.Length; i++)
				hashVal = 37 * hashVal + key[i];

			hashVal %= tableSize;

			if (hashVal < 0)

				hashVal += tableSize;

			return hashVal;
		}
	}
}
