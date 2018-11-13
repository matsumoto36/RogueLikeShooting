using System.Collections.Generic;

namespace RogueLike.Katano.Maze
{
	public struct Point
	{
		public int X { get; }
		public int Y { get; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"({0}, {1})";
		}

		public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
	}
}