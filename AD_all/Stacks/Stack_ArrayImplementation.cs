using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all
{
	class Stack_ArrayImplementation
	{
		private int[] _array;
		private int _top_of_stack;

		public Stack_ArrayImplementation()
		{
			_array = new int[5];
			_top_of_stack = -1;
		}

		public int Pop()
		{
			this._top_of_stack--;
			return this._array[this._top_of_stack];
		}

		public int Top()
		{
			return this._array[this._top_of_stack];
		}

		public void Push(int newValue)
		{
			if (this._top_of_stack == this._array.Length - 1)
			{
				Verdubbel();
			}
			this._top_of_stack++;
			this._array[_top_of_stack] = newValue;
		}

		private void Verdubbel()
		{
			Console.WriteLine("Verdubbel...");
			int[] temp = new int[this._array.Length * 2];
			for (int i = 0; i < this._array.Length; i++)
			{
				temp[i] = this._array[i];
			}
			this._array = temp;
		}

		public override string ToString()
		{
			string s = "t.o.s = " + _top_of_stack + "[";
			for (int i = 1; i <= this._array.Length - 1; i++)
			{
				if (i < _top_of_stack)
				{
					s += _array[i] + ",";
				}
				else
				{
					s += "-,";
				}
			}
			return s + ">";
		}
	}
}
