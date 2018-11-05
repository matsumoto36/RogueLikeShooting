using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Katano.Maze.View
{
	public class MazeViewer
	{
		public Maze Maze { get; }
		public IReadOnlyDictionary<int, GameObject> Rooms { get; }
		public IReadOnlyDictionary<int, GameObject> Aisles { get; }

		public MazeViewer(Maze maze, IReadOnlyDictionary<int, GameObject> rooms, IReadOnlyDictionary<int, GameObject> aisles)
		{
			Maze = maze;
			Rooms = rooms;
			Aisles = aisles;
		}
	}
}