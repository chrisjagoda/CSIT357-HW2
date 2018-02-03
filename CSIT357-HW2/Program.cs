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
					setColor(heightMap[x, y].Height);
					Console.Write(heightMap[x, y].Height.ToString("0.0") + " "); // trim output to 1 demical place between 0 and 1 inclusive - displays grid node Heights
				}
				Console.WriteLine();
			}
			Console.BackgroundColor = ConsoleColor.Black;

			Grid grid = new Grid(heightMap);

			Node start = grid.GetNode(30, 30);
			Node end = grid.GetNode(15, 50);
			List<Node> path;
			//List<Node> neighbors = grid.GetNeighbors(30, 30);
			//foreach (Node n in neighbors)
			//{
			//	Console.WriteLine(n.X.ToString() + " " + n.Y.ToString() + " " + n.Height.ToString("#,##0.00") + " ");
			//}
			//Node start = grid.GetNode(5, 7);
			//Node end = grid.GetNode(40, 15);

			AStar search = new AStar();
			path = search.GetShortestPath(start, end, grid);

			foreach (Node node in path)
			{
				Console.WriteLine(node.X + " " + node.Y);
			}

			Console.ReadLine();
		}

		static void setColor(float val)
		{
			int caseSwitch = (int)Math.Floor(val * 10);
			switch (caseSwitch)
			{
				case 0:
					Console.BackgroundColor = ConsoleColor.DarkCyan;
					break;
				case 1:
					Console.BackgroundColor = ConsoleColor.Cyan;
					break;
				case 2:
					Console.BackgroundColor = ConsoleColor.Blue;
					break;
				case 3:
					Console.BackgroundColor = ConsoleColor.DarkBlue;
					break;
				case 4:
					Console.BackgroundColor = ConsoleColor.DarkMagenta;
					break;
				case 5:
					Console.BackgroundColor = ConsoleColor.Magenta;
					break;
				case 6:
					Console.BackgroundColor = ConsoleColor.DarkRed;
					break;
				case 7:
					Console.BackgroundColor = ConsoleColor.Red;
					break;
				case 8:
					Console.BackgroundColor = ConsoleColor.DarkYellow;
					break;
				case 9:
					Console.BackgroundColor = ConsoleColor.Yellow;
					break;
				case 10:
					Console.BackgroundColor = ConsoleColor.White;
					break;
				default:
					break;
			}
		}
	}
}