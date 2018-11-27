using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLike.Katano.Maze.View
{
	/// <summary>
	///     迷路のViewオブジェクト
	/// </summary>
	public class MazeView : MonoBehaviour
	{
		public Maze Maze { get; private set; }
		public IReadOnlyDictionary<int, RoomView> Rooms { get; private set; }
		public IReadOnlyDictionary<int, AisleView> Aisles { get; private set; }

		/// <summary>
		///     .ctor
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="rooms"></param>
		/// <param name="aisles"></param>
		public void Construct(Maze maze, IReadOnlyDictionary<int, RoomView> rooms,
			IReadOnlyDictionary<int, AisleView> aisles)
		{
			Maze = maze;
			Rooms = rooms;
			Aisles = aisles;

			foreach (var room in Rooms.Values)
			{
				room.Initialize();
			}
		}

		public void Dispose()
		{
			foreach (var mazeComponents in Rooms.Values.Concat<Component>(Aisles.Values))
				Destroy(mazeComponents.gameObject);


			Maze = null;
			Rooms = null;
			Aisles = null;

			Destroy(this);
		}
	}
}