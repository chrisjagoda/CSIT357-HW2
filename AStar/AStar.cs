﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AStar
{
	class AStar
	{
		public double ShortestPathLength = 0;
		public double ShortestPathCost = 0;
		public int NodeVisits = 0;

		public AStar() { }

		public List<Node> GetShortestPath(Node node, Grid grid)
		{
			List<Node> shortestPath = new List<Node>();
			shortestPath.Add(node);

			while (node.ClosestToStart != null)
			{
				shortestPath.Add(node.ClosestToStart);

				ShortestPathLength += 1; //	each path movement is 1 unit because we are only traveling horizontally and vertically on a grid
				ShortestPathCost += HeightDifference(node.Neighbors.Single(x => x == node.ClosestToStart).Height, node.Height);	// add difference in height between each node

				node = node.ClosestToStart;
			}

			shortestPath.Reverse();

			return shortestPath;
		}

		public List<Node> Search(Node start, Node end, Grid grid)
		{
			start.CostToStart = 0; // initialize the cost of start of start to 0
			List<Node> priorityQueue = new List<Node>();
			priorityQueue.Add(start);
			bool searching = true;

			foreach (Node node in grid.Nodes)
			{
				node.DistanceToEnd = StraightLineDistanceTo(node.X, node.Y, end.X, end.Y);
			}

			do
			{
				priorityQueue = priorityQueue.OrderBy(n => n.CostToStart + n.DistanceToEnd).ToList();
				Node node = priorityQueue.First();
				priorityQueue.Remove(node);
				NodeVisits++;

				if (node.Neighbors.Count == 0)
				{
					node.Neighbors = grid.GetNeighbors(node.X, node.Y);
				}

				foreach (Node neighbor in node.Neighbors.OrderBy(x => HeightDifference(node.Height, x.Height)))
				{
					if (neighbor.Visited)
					{
						continue;
					}

					float heightDifference = HeightDifference(node.Height, neighbor.Height);

					if (neighbor.CostToStart == null || node.CostToStart + heightDifference < neighbor.CostToStart)
					{
						neighbor.CostToStart = node.CostToStart + heightDifference;
						neighbor.ClosestToStart = node;

						if (!priorityQueue.Contains(neighbor))
						{
							priorityQueue.Add(neighbor);
						}
					}
				}

				node.Visited = true;

				if (node == end || priorityQueue.Count <= 0)
				{
					searching = false;
				}
			}
			while (searching);

			priorityQueue.Add(end);
			return priorityQueue;
		}

		private static int StraightLineDistanceTo(int x1, int y1, int x2, int y2)
		{
			return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
		}

		private static float HeightDifference(float h1, float h2)
		{
			return Math.Abs(h1 - h2);
		}
	}
}
