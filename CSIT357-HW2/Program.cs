using System;
using System.Collections.Generic;

namespace CSIT357_HW2
{
	class Program
	{
		static void Main(string[] args)
		{
			FastNoise myNoise = new FastNoise(new Random().Next(0, 9999)); // Create a FastNoise object with a random seed
			myNoise.SetNoiseType(FastNoise.NoiseType.Perlin); // Set the desired noise type

			int height = 59, width = height;

			Node[,] heightMap = new Node[width, height]; // 2D heightmap to create terrain/heuristic

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					heightMap[x, y] = new Node(x, y, Util.Clamp(myNoise.GetNoise(x, y) + (float)0.5, 0, 1));
					Console.Write(heightMap[x, y].weight.ToString("0.0") + " "); // trim output to 1 demical place between 0 and 1 inclusive - displays grid node weights
				}
				Console.WriteLine();
			}

			Grid grid = new Grid(heightMap);
			List<Node> neighbors = grid.getNeighbors(30, 30);
			foreach (Node n in neighbors)
			{
				Console.WriteLine(n.x.ToString() + " " + n.y.ToString() + " " + n.weight.ToString("#,##0.00") + " ");
			}
			Console.ReadLine();
		}
	}
}