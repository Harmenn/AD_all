using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.SortingAlgorithms
{
	class Queue_ArrayImplementation
	{
		private int[] theArray;
		private int currentSize;
		private int front;
		private int back;

		private static int DEFAULT_CAPACITY = 5;

		public Queue_ArrayImplementation()
		{
			theArray = new int[DEFAULT_CAPACITY];
			makeEmpty();
		}

		/**
		* Test if the queue is logically empty.
		* @return true if empty, false otherwise.
		*/
		public bool isEmpty()
		{
			return currentSize == 0;
		}

		/**
		 * Insert a new item into the queue.
		 * @param x the item to insert.
		 */
		public void enqueue(int x)
		{
			Console.WriteLine("Enqueue " + x);
			if (currentSize == theArray.Length)
				doubleQueue();
			back = increment(back);
			theArray[back] = x;
			currentSize++;

			Console.WriteLine(this);
		}

		/**
		* Internal method to expand theArray.
		*/
		private void doubleQueue()
		{
			Console.WriteLine("Doubling array!");
			int[] newArray;

			newArray = new int[theArray.Length * 2];

			// Copy elements that are logically in the queue
			for (int i = 0; i < currentSize; i++, front = increment(front))
				newArray[i] = theArray[front];

			theArray = newArray;
			front = 0;
			back = currentSize - 1;
		}

		/**
		 * Return and remove the least recently inserted item
		 * from the queue.
		 * @return the least recently inserted item in the queue.
		 * @throws UnderflowException if the queue is empty.
		 */
		public int dequeue()
		{
			if (isEmpty())
				Console.WriteLine("ArrayQueue dequeue: Queue already empty");
			currentSize--;

			int returnValue = theArray[front];
			theArray[front] = 0;
			front = increment(front);


			Console.WriteLine("Dequeue " + returnValue);
			Console.WriteLine(this);
			return returnValue;
		}

		/**
		* Get the least recently inserted item in the queue.
		* Does not alter the queue.
		* @return the least recently inserted item in the queue.
		* @throws UnderflowException if the queue is empty.
		*/
		public int getFront()
		{
			if (isEmpty())
				Console.WriteLine("ArrayQueue getFront: Queue is empty");
			return theArray[front];
		}

		/**
		 * Make the queue logically empty.
		 */
		public void makeEmpty()
		{
			currentSize = 0;
			front = 0;
			back = -1;
		}

		/**
		  * Internal method to increment with wraparound.
		  * @param x any index in theArray's range.
		  * @return x+1, or 0 if x is at the end of theArray.
		  */
		private int increment(int x)
		{
			if (++x == theArray.Length)
				x = 0;
			return x;
		}

		public override string ToString()
		{
			string str = "theArray: {";

			foreach (int i in this.theArray)
			{
				str += i + ", ";
			}
			return str.Substring(0, str.Length - 2) + "}\n";
		}
	}
}
