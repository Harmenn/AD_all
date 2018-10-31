using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_all.Graph
{
	class Edge
	{
		public Vertex dest; // Second vertex in Edge
		public double cost; // Edge cost

		public Edge(Vertex d, double c)
		{
			dest = d;
			cost = c;
		}
	}
}
