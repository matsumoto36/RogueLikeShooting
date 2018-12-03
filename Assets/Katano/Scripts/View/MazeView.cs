using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace RogueLike.Katano.View
{
	/// <summary>
	///     迷路のViewオブジェクト
	/// </summary>
	[DisallowMultipleComponent]
	public class MazeView : MonoBehaviour
	{
		/// <summary>
		/// 
		/// </summary>
		public Maze.Maze Maze { get; private set; }
		
		/// <summary>
		/// 部屋リスト
		/// </summary>
		public IReadOnlyDictionary<int, RoomView> Rooms { get; private set; }
		
		/// <summary>
		/// 通路リスト
		/// </summary>
		public IReadOnlyDictionary<int, AisleView> Aisles { get; private set; }
		
		/// <summary>
		///     .ctor
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="rooms"></param>
		/// <param name="aisles"></param>
		private void Construct(Maze.Maze maze, IReadOnlyDictionary<int, RoomView> rooms, IReadOnlyDictionary<int, AisleView> aisles)
		{
			Maze = maze;
			Rooms = rooms;
			Aisles = aisles;

			this.OnDestroyAsObservable().Subscribe(_ => Destruct());
		}

		private void Destruct()
		{
			foreach (var mazeComponents in Rooms.Values.Concat<Component>(Aisles.Values))
				Destroy(mazeComponents.gameObject);


			Maze = null;
			Rooms = null;
			Aisles = null;

			Destroy(this);
		}

		/// <summary>
		/// 迷宮オブジェクト作成
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="rooms"></param>
		/// <param name="aisles"></param>
		/// <returns></returns>
		public static MazeView Create(
			Maze.Maze maze,
			IReadOnlyDictionary<int, RoomView> rooms,
			IReadOnlyDictionary<int, AisleView> aisles
		)
		{
			var @this = new GameObject("MazeView").AddComponent<MazeView>();
			@this.Construct(maze, rooms, aisles);

			return @this;
		}
	}
}