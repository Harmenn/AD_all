using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.Graph
{
	// Represents an entry in the priority queue for Dijkstra's algorithm.
	class Path
	{
		public Vertex dest; // w
		public double cost; // d(w)

		public Path(Vertex d, double c)
		{
			dest = d;
			cost = c;
		}

		public int CompareTo(Path rhs)
		{
			double otherCost = rhs.cost;

			return cost < otherCost ? -1 : cost > otherCost ? 1 : 0;
		}
	}
}
