using System;
using System.Collections.Generic;

namespace CSIT357_HW2
{
	class Grid
	{
		public Node[,] Nodes;
		private int Width;
		private int Height;

		public Grid(Node[,] nodes)
		{
			Nodes = nodes;
			Width = Nodes.GetLength(0);
			Height = Nodes.GetLength(1);
		}

		public Node GetNode(int x, int y)
		{
			return Nodes[x, y];
		}

		public List<Node> GetNeighbors(int x, int y)
		{
			List<Node> neighbors = new List<Node>();
			
			try
			{
				if (x > 0)
				{
					neighbors.Add(Nodes[x - 1, y]);
				}
				if (x < Nodes.GetLength(0)-1)
				{
					neighbors.Add(Nodes[x + 1, y]);
				}

				if (y > 0)
				{
					neighbors.Add(Nodes[x, y - 1]);
				}
				if (y < Nodes.GetLength(1)-1)
				{
					neighbors.Add(Nodes[x, y + 1]);
				}
			}
			catch (IndexOutOfRangeException e)
			{
				Console.Error.Write(e.Message);
			}

			return neighbors;
		}
	}
}
