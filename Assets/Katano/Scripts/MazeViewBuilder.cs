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
		private readonly Maze _maze;
		private readonly MazeDataAssetBase _mazeDataAsset;
		private readonly Transform _transform;
		private const int Interval = 25;

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="mazeDataAsset"></param>
		/// <param name="transform"></param>
		public MazeViewBuilder(Maze maze, MazeDataAssetBase mazeDataAsset, Transform transform)
		{
			_maze = maze;
			_mazeDataAsset = mazeDataAsset;
			_transform = transform;
		}
		
		/// <summary>
		/// 迷宮を実体化する
		/// </summary>
		/// <param name="maze"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public MazeView Construct()
		{
			var rooms = new Dictionary<int, RoomView>();
			var aisles = new Dictionary<int, AisleView>();
			
			// RoomViewの生成
//			for (var i = 0; i < _maze.Width; i++)
//			{
//				for (var j = 0; j < _maze.Height; j++)
//				{
//					if (!_maze.RoomList[i, j].IsEnable) continue;
//				
//					var view = Object.Instantiate(_mazeDataAsset.RoomPrefabList.RandomAt(), new Vector3(i + Interval * i, 0, j + Interval * j), Quaternion.identity, _transform);
//					rooms.Add(_maze.RoomList[i,j].Id, view);
//				}
//			}

			var shuffledRooms = _maze.RoomList.OfType<Room>().Where(x => x.IsEnable).Shuffle().ToList();
			for (var i = 0; i < shuffledRooms.Count; i++)
			{
				GameObject view;
				var room = shuffledRooms[i];
				if (i == 0)
				{
					view = Object.Instantiate(_mazeDataAsset.PlayerRoomPrefab, new Vector3(room.Coord.X + Interval * room.Coord.X, 0, room.Coord.Y + Interval * room.Coord.Y), Quaternion.identity, _transform);	
				}
				else
				{
					view = Object.Instantiate(_mazeDataAsset.RoomPrefabList.RandomAt(), new Vector3(room.Coord.X + Interval * room.Coord.X, 0, room.Coord.Y + Interval * room.Coord.Y), Quaternion.identity, _transform);	
				}
				
				rooms.Add(room.Id, view.GetComponent<RoomView>());
			}
			
			
			// AisleViewの生成
			foreach (var aisle in _maze.Aisles)
			{
				var spawn = Vector3.Lerp(rooms[aisle.Room0.Id].transform.position, rooms[aisle.Room1.Id].transform.position, 0.5f);
				var view = GameObject.CreatePrimitive(PrimitiveType.Cube);

				switch (aisle.AisleChainState)
				{
					case AisleChainState.Horizontal:
					{
						view.transform.localScale = new Vector3(10, 0.1f, 1);
						break;
					}
					case AisleChainState.Vertical:
					{
						view.transform.localScale = new Vector3(1, 0.1f, 10);
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}
				view.transform.localPosition = spawn;
				view.transform.SetParent(_transform);
				
				aisles.Add(aisle.Id, view.GetComponent<AisleView>());
			}
			
			return new MazeView(_maze, rooms, aisles);
		}
	}
}