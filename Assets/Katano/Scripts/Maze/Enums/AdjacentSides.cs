using System;

namespace RougeLike.Katano.Maze
{
	[Flags]
	public enum AdjacentSides
	{
		North = 1 << 0,
		East = 1 << 1,
		South = 1 << 2,
		West = 1 << 3
	}
}