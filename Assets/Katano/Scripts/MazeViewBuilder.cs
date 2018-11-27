using System;
using System.Collections.Generic;
using System.Linq;
using Reqweldzen.Extensions;
using RogueLike.Katano.Maze.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 迷宮を可視化するクラス
	/// </summary>
	public class MazeViewBuilder
	{
		/// <summary>
		/// 迷宮データ
		/// </summary>
		private readonly Maze _maze;
		
		/// <summary>
		/// 迷宮構築アセットデータ
		/// </summary>
		private readonly MazeDataAsset _mazeDataAsset;
		
		/// <summary>
		/// 親Transform
		/// </summary>
		private readonly Transform _transform;
		
		/// <summary>
		/// 部屋の配置インターバル
		/// </summary>
		private const int Interval = 25;

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="mazeDataAsset"></param>
		/// <param name="transform"></param>
		public MazeViewBuilder(Maze maze, MazeDataAsset mazeDataAsset, Transform transform)
		{
			_maze = maze;
			_mazeDataAsset = mazeDataAsset;
			_transform = transform;
		}

		/// <summary>
		/// 迷宮を実体化する
		/// </summary>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public MazeView Construct()
		{
			var rooms = new Dictionary<int, RoomView>();
			var aisles = new Dictionary<int, AisleView>();
			
			MakeRoomView(ref rooms);
			MakeAisleView(ref aisles, rooms);
			
			var mazeView = _transform.gameObject.AddComponent<MazeView>();
			mazeView.Construct(_maze, rooms, aisles);
			return mazeView;
		}

		/// <summary>
		/// 部屋オブジェクトを作成
		/// </summary>
		/// <param name="roomViewList"></param>
		private void MakeRoomView(ref Dictionary<int, RoomView> roomViewList)
		{
			// RoomViewの生成
			var shuffledRooms = _maze.RoomList.OfType<Room>().Where(x => x.IsEnable).Shuffle().ToList();
			for (var i = 0; i < shuffledRooms.Count; i++)
			{
				GameObject obj;
				var room = shuffledRooms[i];
				
				var coord = new Vector3(room.Coord.X + Interval * room.Coord.X, 0, room.Coord.Y + Interval * room.Coord.Y);
				
				obj = Object.Instantiate(i == 0 
					? _mazeDataAsset.PlayerRoomPrefab 
					: _mazeDataAsset.RoomPrefabList.RandomAt(), 
					coord,
					Quaternion.identity, 
					_transform);

				var view = obj.GetComponent<RoomView>();
				view.Construct(room);
				roomViewList.Add(room.Id, view);
			}
		}

		private void MakeAisleView(ref Dictionary<int, AisleView> aisleViewList, IReadOnlyDictionary<int, RoomView> roomViewList)
		{
			// AisleViewの生成
			foreach (var aisle in _maze.Aisles)
			{
				var spawn = Vector3.Lerp(roomViewList[aisle.Room0.Id].transform.position, roomViewList[aisle.Room1.Id].transform.position, 0.5f);
				var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

				switch (aisle.AisleChainState)
				{
					case AisleChainState.Horizontal:
					{
						obj.transform.localScale = new Vector3(10, 0.1f, 1);
						break;
					}
					case AisleChainState.Vertical:
					{
						obj.transform.localScale = new Vector3(1, 0.1f, 10);
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}
				obj.transform.localPosition = spawn;
				obj.transform.SetParent(_transform);

				var view = obj.AddComponent<AisleView>();
				view.Construct(aisle);
				aisleViewList.Add(aisle.Id, view);
			}
		}
	}
}