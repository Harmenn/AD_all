using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.Graph
{
	class Graph : IGraph
	{
		public static readonly double INFINITY = Double.MaxValue;

		public override string ToString()
		{
			string startVertex = "";
			foreach (Vertex vertex in vertexMap.Values)
			{
				startVertex += vertex.name + " --> ";
				string edgeVertex = "";
				foreach (Edge edge in vertex.adj)
				{
					edgeVertex += edge.dest.name + "(" + edge.cost + ") ";
				}

				startVertex += edgeVertex + "\n";
			}

			return startVertex;
		}

		/**
		 * If vertexName is not present, add it to vertexMap.
		 * In either case, return the Vertex.
		 */
		public Vertex GetVertex(string name)
		{
			{
				Vertex v = null;

				if (!vertexMap.ContainsKey(name))
				{
					v = new Vertex(name);
					vertexMap.Add(name, v);
				}
				else
				{
					v = vertexMap[name];
				}

				return v;
			}
		}

		/**
		 * Add a new edge to the graph.
		 */
		public void AddEdge(string source, string dest, double cost)
		{
			Vertex v = GetVertex(source);
			Vertex w = GetVertex(dest);
			v.adj.Add(new Edge(w, cost));
		}

		/**
		 * Driver routine to handle unreachables and print total cost.
		 * It calls recursive routine to print shortest path to
		 * destNode after a shortest path algorithm has run.
		 */
		public void PrintPath(String destName)
		{
			Vertex w = vertexMap[destName];
			if (w == null)
			{
				throw new Exception();
			}
			else if (w.dist == INFINITY)
			{
				Console.WriteLine(destName + " is unreachable");
			}
			else
			{
				Console.WriteLine("(Cost is: " + w.dist + ") ");
				PrintPath(w);
				Console.WriteLine();
			}
		}

		/**
		 * DEZE FUNCTIE MOET NIET OPZICHZELF WORDEN AANGEROEPEN. DEZE WORDT AANGEROPEEN DOOR DE PRINT FUNCTIE HIER BOVEN.
		 *
		 * Recursive routine to print shortest path to dest
		 * after running shortest path algorithm. The path
		 * is known to exist.
		 */
		private void PrintPath(Vertex dest)
		{
			if (dest.prev != null)
			{
				PrintPath(dest.prev);
				Console.WriteLine(" to ");
			}

			Console.WriteLine(dest.name);
		}


		/**
		 * Single-source unweighted shortest-path algorithm.
		 */
		public void Unweighted(String startName)
		{
			ClearAll();

			Vertex start = vertexMap[startName];
			if (start == null)
				throw new Exception("Start vertex not found");

			Queue<Vertex> q = new Queue<Vertex>();
			q.Enqueue(start);
			start.dist = 0;

			while (q.Count > 0)
			{
				Vertex v = q.Dequeue();

				foreach (Edge e in v.adj)
				{
					Vertex w = e.dest;

					if (w.dist == INFINITY)
					{
						w.dist = v.dist + 1;
						w.prev = v;
						q.Enqueue(w);
					}
				}
			}
		}

		public void VulAfstand()
		{
			ClearAll();

			//			Vertex start = vertexMap["G"];
			//			if (start == null)
			//				throw new Exception("Start vertex not found");

			foreach (KeyValuePair<string, Vertex> keyValuePair in vertexMap)
			{
				Vertex start = keyValuePair.Value;

				Queue<Vertex> q = new Queue<Vertex>();
				q.Enqueue(start);
				start.dist = 0;

				while (q.Count > 0)
				{
					Vertex v = q.Dequeue();

					foreach (Edge e in v.adj)
					{
						Vertex w = e.dest;

						if (w.dist == INFINITY)
						{
							w.dist = v.dist + 1;
							w.prev = v;
							q.Enqueue(w);
						}
					}
				}
			}
		}

		public void ToonAfstand()
		{
			foreach (KeyValuePair<string, Vertex> keyValuePair in vertexMap)
			{
				Vertex v = keyValuePair.Value;

				if (v.dist == INFINITY)
				{
					Console.WriteLine("G is unreachable");
				}

				Console.WriteLine(v.name);
				Console.WriteLine("(Cost is: " + v.dist + ") ");
				Console.WriteLine();
			}

			//			Vertex w = vertexMap["G"];
			//			if (w == null)
			//			{
			//				throw new Exception();
			//			}
			//			else if (w.dist == INFINITY)
			//			{
			//				Console.WriteLine("G is unreachable");
			//			}
			//			else
			//			{
			//				Console.WriteLine("(Cost is: " + w.dist + ") ");
			//				PrintPath(w);
			//				Console.WriteLine();
			//			}
		}

		/**
		 * Single-source weighted shortest-path algorithm.
		 */
		public void Dijkstra(String startName)
		{
			SortedSet<Path> pq = new SortedSet<Path>();

			Vertex start = vertexMap[startName];
			if (start == null)
				throw new Exception("Start vertex not found");

			ClearAll();
			pq.Add(new Path(start, 0));
			start.dist = 0;

			int nodesSeen = 0;
			while (pq.Count > 0 && nodesSeen < vertexMap.Count)
			{
				Path vrec = pq.Min;
				pq.Remove(pq.Min);

				Vertex v = vrec.dest;
				if (v.scratch != 0) // already processed v
					continue;

				v.scratch = 1;
				nodesSeen++;

				foreach (Edge e in v.adj)
				{
					Vertex w = e.dest;
					double cvw = e.cost;

					if (cvw < 0)
						throw new Exception("Graph has negative edges");

					if (w.dist > v.dist + cvw)
					{
						w.dist = v.dist + cvw;
						w.prev = v;
						pq.Add(new Path(w, w.dist));
					}
				}
			}
		}

		public void Negative(String startName)
		{
			/* Figure 14.29 */
		}

		public void Acyclic(String startName)
		{
			/* Figure 14.32 */
		}

		/**
		 * Initializes the vertex output info prior to running
		 * any shortest path algorithm.
		 */
		private void ClearAll()
		{
			foreach (Vertex v in vertexMap.Values)
			{
				{
					v.Reset();
				}
			}
		}

		private Dictionary<String, Vertex> vertexMap = new Dictionary<String, Vertex>();
	}

}
