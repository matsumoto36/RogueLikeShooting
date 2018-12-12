namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 座標構造体
	/// </summary>
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
			return $"({X}, {Y})";
		}

		public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
	}
}