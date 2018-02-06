using System;
using System.Collections.Generic;
using System.Linq;

namespace AStar
{
	class Program
	{
		static void Main(string[] args)
		{
			FastNoise myNoise = new FastNoise(new Random().Next(0, 9999)); // Create a FastNoise object with a random seed
			// FastNoise myNoise = new FastNoise(24); // Create a FastNoise object with a static seed - 24
			myNoise.SetNoiseType(FastNoise.NoiseType.Perlin); // Set the desired noise type
			int intensity = 300; // The degree of intensity in height between each node - effects generally seen in 100+ range
			int width = 333;
			int height = 100;
			Node[,] heightMap = new Node[width, height]; // 2D heightmap to create terrain/heuristic

			// Set heuristics and create height map to form grid
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					heightMap[x, y] = new Node(x, y, Util.Clamp((myNoise.GetNoise(x, y) + (float)0.5) * intensity, 0, intensity));
					// Console.Write(heightMap[x, y].Height.ToString("0.0") + " "); // displays grid node Heights and trim output to 1 demical place between 0 and 1 inclusive
				}
			}
			
			Grid grid = new Grid(heightMap);
			Node start = grid.GetNode(1, 1);
			Node end = grid.GetNode(width-2, height-2);
			AStar search = new AStar();
			search.Search(start, end, grid);
			List<Node> path = search.GetShortestPath(end, grid);
			
			// Draw grid with path
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (path.Exists(n => n.X == x && n.Y == y))
					{
						Console.BackgroundColor = ConsoleColor.Black;
						Console.Write("X");
					}
					else if (grid.GetNode(x, y).Visited)
					{
						// Console.BackgroundColor = ConsoleColor.Green;
						Util.setColor(heightMap[x, y].Height, intensity);
						Console.Write("V");
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
			float previousNodeHeight = path.First().Height;

			foreach (Node node in path)
			{
				Console.WriteLine(node.X + " " + node.Y + " " + Math.Abs(previousNodeHeight - node.Height));
				previousNodeHeight = node.Height;
			}

			Console.WriteLine("Total nodes: " + width * height);
			Console.WriteLine("Node visits: " + search.NodeVisits);
			Console.WriteLine("Path length: " + search.ShortestPathLength);
			Console.WriteLine("Path cost: " + search.ShortestPathCost);
			Console.WriteLine("Average path cost per node: " + search.ShortestPathCost/search.ShortestPathLength);
			Console.ReadLine();
		}
	}
}