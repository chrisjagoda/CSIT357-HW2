using System;

namespace CSIT357_HW2
{
	class Program
	{
		static void Main(string[] args)
		{
			FastNoise myNoise = new FastNoise(new Random().Next(0, 9999)); // Create a FastNoise object with a random seed
			myNoise.SetNoiseType(FastNoise.NoiseType.Perlin); // Set the desired noise type

			int height = 32, width = height;

			Node[,] heightMap = new Node[width, height]; // 2D heightmap to create terrain/heuristic

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					heightMap[x, y].weight = myNoise.GetNoise(x, y);
					Console.Write(Math.Abs(heightMap[x, y].weight).ToString("#,##0.00") + " "); // trim output to 2 demical places - displays grid node weights
				}
				Console.WriteLine();
			}

			Grid grid = new Grid(heightMap);
			Console.ReadLine();
		}
	}
}