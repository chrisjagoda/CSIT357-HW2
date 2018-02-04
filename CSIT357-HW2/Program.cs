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
			int intensity = 100;

			int height = 200, width = height;

			Node[,] heightMap = new Node[width, height]; // 2D heightmap to create terrain/heuristic

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					heightMap[x, y] = new Node(x, y, Util.Clamp((myNoise.GetNoise(x, y) + (float)0.5) * intensity, 0, intensity));
					Util.setColor(heightMap[x, y].Height, intensity);
					Console.Write(heightMap[x, y].Height.ToString("0.0") + " "); // trim output to 1 demical place between 0 and 1 inclusive - displays grid node Heights
				}
				Console.WriteLine();
			}
			Console.BackgroundColor = ConsoleColor.Black;

			Grid grid = new Grid(heightMap);

			Node start = grid.GetNode(190, 190);
			Node end = grid.GetNode(15, 49);
			List<Node> path;

			AStar search = new AStar();
			path = search.GetShortestPath(start, end, grid);

			foreach (Node node in path)
			{
				Console.WriteLine(node.X + " " + node.Y);
			}
			Console.WriteLine(search.ShortestPathLength + " " + search.ShortestPathCost);

			Console.ReadLine();
		}
	}
}