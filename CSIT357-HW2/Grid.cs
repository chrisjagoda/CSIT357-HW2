using System;
using System.Collections.Generic;

namespace CSIT357_HW2
{
	class Grid
	{
		public Node[,] grid;
		private int width;
		private int height;

		public Grid(Node[,] nodes)
		{
			grid = nodes;
			width = grid.GetLength(0);
			height = grid.GetLength(1);
		}

		public List<Node> getNeighbors(int x, int y)
		{
			List<Node> neighbors = new List<Node>();
			
			try
			{
				if (x > 0)
				{
					neighbors.Add(grid[x - 1, y]);
				}
				if (x < grid.GetLength(0)-1)
				{
					neighbors.Add(grid[x + 1, y]);
				}

				if (y > 0)
				{
					neighbors.Add(grid[x, y - 1]);
				}
				if (y < grid.GetLength(1)-1)
				{
					neighbors.Add(grid[x, y + 1]);
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
