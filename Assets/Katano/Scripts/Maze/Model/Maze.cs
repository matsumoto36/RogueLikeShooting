using System;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	///     ダンジョン
	/// </summary>
	public class Maze
	{
		public Maze(RoomList roomList, Aisle[] aisles)
		{
			RoomList = roomList;
			Aisles = aisles;
		}

		public RoomList RoomList { get; }
		public Aisle[] Aisles { get; }
	}

	/// <summary>
	///     生成オプション
	/// </summary>
	public struct MazeBuildOptions
	{
		public MazeBuildOptions(int horizontal, int vertical)
		{
			Horizontal = horizontal;
			Vertical = vertical;
		}

		public int Horizontal { get; }
		public int Vertical { get; }
	}

	[Flags]
	public enum AdjacentSides
	{
		North = 1 << 0,
		East = 1 << 1,
		South = 1 << 2,
		West = 1 << 3
	}

	/// <summary>
	///     生成パターンタイプ
	/// </summary>
	public enum GenerateTypes
	{
		AllChained
	}
}