using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all
{
	class LinkedList<T>
	{ 
		private Node<T> headerNode;

		/*
         * De headerNode is de eerste node van de lijst.
         * Deze node is niet echt een lijst item, maar markeert het begin van de lijst.
         * De null geeft aan dat het de laatste node is van de lijst.
         */
		public LinkedList(T value)
		{
			headerNode = new Node<T>(value, null);
		}

		// Voeg een item toe aan het begin van de lijst
		public void addFirst(T data)
		{
			Node<T> firstNode = getFirst();
			Node<T> newNode = new Node<T>(data, firstNode);
			headerNode.next = newNode;
		}

		// Verwijder alle nodes uit de lijst
		public void clear()
		{
			headerNode.next = null;
			Console.WriteLine("De lijst is leeg gemaakt\n");
		}

		// Geeft het eerste item terug
		public Node<T> getFirst()
		{
			return headerNode.next;
		}

		// Voeg een item in op een bepaalde index (niet overschrijven!)
		public void insert(int index, T data)
		{
			Node<T> currentNode = headerNode;
			Node<T> previousNode = currentNode;

			for (int i = 0; i < index; i++)
			{
				if (currentNode != null)
				{
					previousNode = currentNode;
					currentNode = currentNode.next;
				}
			}

			/*
             * Als de betreffende node niet is gevonden met de meegegevens index, 
             * wordt de nieuwe node aan de laatste node toegevoegd.
             */
			Node<T> newNode = new Node<T>(data, currentNode);
			previousNode.next = newNode;
		}

		public void addLast(T data)
		{
			Node<T> currentNode = headerNode;
			Node<T> previousNode = currentNode;

			while (currentNode != null)
			{
				previousNode = currentNode;
				currentNode = currentNode.next;
			}

			Node<T> newNode = new Node<T>(data, currentNode);
			previousNode.next = newNode;
		}

		public int getIndexValue(T value)
		{
			Node<T> currentNode = headerNode;

			int count = 0;

			while (currentNode != null)
			{
				count++;
				if (EqualityComparer<T>.Default.Equals(currentNode.value, value))
				{
					return count;
				}
				currentNode = currentNode.next;
			}
			return -1;
		}

		// Print de waarde van de meegegeven node uit
		public void printNode(Node<T> node)
		{
			if (node != null)
			{
				Node<T> currentNode = node;
				Console.WriteLine(currentNode.value);
			}
			else
			{
				Console.WriteLine("Er zitten nog geen items in de lijst\n");
			}
		}

		// Print alle nodes uit die in de lijst zitten
		public void print()
		{
			Node<T> currentNode = headerNode;

			while (currentNode.next != null)
			{
				currentNode = currentNode.next;
				Console.WriteLine(currentNode.value);
			}
			Console.WriteLine("Einde van de lijst\n");
		}

		// Verwijder de eerste node
		public void removeFirst()
		{
			Node<T> firstNode = headerNode.next;
			headerNode.next = firstNode.next;
		}

		// Verwijder de laatste node?
		public void removeLast() { }

	}

	public class Node<T>
	{
		public T value;
		public Node<T> next;
		//public Node previous;

		// De constructor instantieert een nieuwe Node met een generic value en een referentie naar de volgende node
		public Node(T value, Node<T> next)
		{
			this.value = value;
			this.next = next;
		}
	}
}
