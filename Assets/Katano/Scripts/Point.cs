namespace RougeLike.Katano
{
	public struct Point
	{
		public int X { get; set; }
		public int Y { get; set; }

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