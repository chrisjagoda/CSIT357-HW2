using System.Collections.Generic;

namespace CSIT357_HW2
{
	class Grid
	{
		public Node[,] grid;

		public Grid(Node[,] nodes)
		{
			grid = nodes;
		}

		public List<Node> getNeighbors(Node node)
		{
			List<Node> neighbors = new List<Node>();
			if (node.x > 0)
			{
				neighbors.Add(grid[node.x - 1, node.y]);
			}
			else if (node.x < grid.Length-1)
			{
				neighbors.Add(grid[node.x + 1, node.y]);
			}

			if (node.y > 0)
			{
				neighbors.Add(grid[node.x - 1, node.y]);
			}

			return neighbors;
		}
	}
}
