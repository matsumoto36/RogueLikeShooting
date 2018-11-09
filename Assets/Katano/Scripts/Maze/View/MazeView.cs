using System.Collections.Generic;

namespace RogueLike.Katano.Maze.View
{
	public class MazeView
	{
		public Maze Maze { get; }
		public IReadOnlyDictionary<int, RoomView> Rooms { get; }
		public IReadOnlyDictionary<int, AisleView> Aisles { get; }

		public MazeView(Maze maze, IReadOnlyDictionary<int, RoomView> rooms, IReadOnlyDictionary<int, AisleView> aisles)
		{
			Maze = maze;
			Rooms = rooms;
			Aisles = aisles;
		}
	}
}