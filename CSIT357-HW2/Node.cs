using System.Collections.Generic;

namespace CSIT357_HW2
{
	class Node
	{
		public int X, Y;
		public float DistanceToEnd;	// Straight line distance to end
		public float? CostToStart;	// Minimum cost to start
		public float Height;        // Heuristic for search algorithm
		public Node ClosestToStart; // Closest adjacent node to starting node
		public List<Node> Neighbors;
		public bool Visited;

		public Node(int xCoord, int yCoord, float z)
		{
			X = xCoord;
			Y = yCoord;
			Height = z;
			Neighbors = new List<Node>();
		}
	}
}
