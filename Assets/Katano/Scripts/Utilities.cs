using RogueLike.Katano;
using UnityEngine;

namespace Katano
{
	public static class Utilities
	{
		public static readonly Point[] Neighbors =
			{new Point(0, 1), new Point(-1, 0), new Point(0, -1), new Point(1, 0)};
		
		public static readonly Color[] ColorTable =
		{
			Color.white,
			Color.red,
			Color.yellow,
			Color.green,
			Color.cyan,
			Color.blue,
			Color.magenta
		};
	}
}