using System.Collections.Generic;
using System.Linq;
using RogueLike.Katano.Maze;
using UniRx.Async;
using Unity.Linq;
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

		private void OnDestroy()
		{
			Rooms.Values.Select(x => gameObject).Destroy();
			Aisles.Values.Select(x => gameObject).Destroy();
		}
	}
}