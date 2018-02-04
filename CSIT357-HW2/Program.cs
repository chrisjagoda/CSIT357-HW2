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
			int intensity = 1000;
			int height = 300, width = height;
			Node[,] heightMap = new Node[width, height]; // 2D heightmap to create terrain/heuristic

			// Set heuristics and create height map to form grid
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					heightMap[x, y] = new Node(x, y, Util.Clamp((myNoise.GetNoise(x, y) + (float)0.5) * intensity, 0, intensity));
					//Util.setColor(heightMap[x, y].Height, intensity);
					// Console.Write(heightMap[x, y].Height.ToString("0.0") + " "); // trim output to 1 demical place between 0 and 1 inclusive - displays grid node Heights
					//Console.Write("O" + " ");
				}

				//Console.WriteLine();
			}

			//Console.BackgroundColor = ConsoleColor.Black;
			Grid grid = new Grid(heightMap);
			Node start = grid.GetNode(1, 1);
			Node end = grid.GetNode(299, 299);
			List<Node> path;
			AStar search = new AStar();
			path = search.GetShortestPath(start, end, grid);

			// Draw grid with path
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					if (path.Exists(n => n.X == x && n.Y == y))
					{
						Console.BackgroundColor = ConsoleColor.Black;
						Console.Write("X");
					}
					else
					{
						Util.setColor(heightMap[x, y].Height, intensity);
						Console.Write("O");
					}
				}

				Console.WriteLine();
			}
			Console.BackgroundColor = ConsoleColor.Black;

			foreach (Node node in path)
			{
				Console.WriteLine(node.X + " " + node.Y);
			}
			Console.WriteLine(search.ShortestPathLength + " " + search.ShortestPathCost);

			Console.ReadLine();
		}
	}
}