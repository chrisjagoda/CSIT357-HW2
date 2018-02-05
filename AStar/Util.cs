using System;

namespace AStar
{
	class Util
	{
		public static float Clamp(float value, float min, float max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}


		public static void setColor(float val, int intensity)
		{
			int caseSwitch = (int)Math.Floor(val / intensity * 10);
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
