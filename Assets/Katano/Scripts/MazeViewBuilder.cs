using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Katano.Installers;
using DDD.Katano.View;
using DDD.Katano.View.RoomComponents;
using Reqweldzen.Extensions;
using DDD.Katano.Model;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace DDD.Katano.Maze
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
		private readonly MazeSettings _mazeSettings;

		private readonly DiContainer _container;

		/// <summary>
		/// 部屋の配置インターバル
		/// </summary>
		private const int Interval = 25;

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="mazeSettings"></param>
		/// <param name="container"></param>
		public MazeViewBuilder(Maze maze, MazeSettings mazeSettings, DiContainer container)
		{
			_maze = maze;
			_mazeSettings = mazeSettings;
			_container = container;
		}

		/// <summary>
		/// 迷宮を実体化する
		/// </summary>
		/// <returns></returns>
		public MazeView Construct()
		{
			var rooms = new Dictionary<int, RoomView>();
			var aisles = new Dictionary<int, AisleView>();
			
			MakeRoomView(ref rooms);
//			MakeAisleView(ref aisles, rooms);

			var mazeView = MazeView.Create(_maze, rooms, aisles);
			
			return mazeView;
		}
		
		/// <summary>
		/// 部屋オブジェクトを作成
		/// </summary>
		/// <param name="roomViewList"></param>
		private void MakeRoomView(ref Dictionary<int, RoomView> roomViewList)
		{
			// RoomViewの生成
			var indexed = _maze.RoomList.WithIndex().Where(x => x.Element.IsEnable).Shuffle().ToList();
			foreach (var room in indexed)
			{
				var coordinate = new Vector3(room.Element.Coordinate.X + Interval * room.Element.Coordinate.X, 0, -(room.Element.Coordinate.Y + Interval) * room.Element.Coordinate.Y);

				GameObject go;

				switch (room.Element.RoomAttribute)
				{
					case Room.RoomAttributes.FloorStart:
					{
						go = _container.InstantiatePrefab(_mazeSettings.PlayerRoom, coordinate, Quaternion.identity,
							null);
//						go = Object.Instantiate(_mazeSettings.PlayerRoom, coordinate, Quaternion.identity);
						break;
					}
					case Room.RoomAttributes.Stair:
					{
						go = _container.InstantiatePrefab(_mazeSettings.EnemyRoom, coordinate, Quaternion.identity,
							null);
						_container.InstantiateComponent<SpawnStairComponent>(go);
						
//						go = Object.Instantiate(_mazeSettings.EnemyRoom, coordinate, Quaternion.identity);
						// 階段コンポーネントを追加
//						go.AddComponent<SpawnStairComponent>();
						break;
					}
					case Room.RoomAttributes.Others:
					{
						go = _container.InstantiatePrefab(_mazeSettings.EnemyRoom, coordinate, Quaternion.identity,
							null);
						// go = Object.Instantiate(_mazeSettings.EnemyRoom, coordinate, Quaternion.identity);
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}

				var goTransform = go.transform;
				var cameraAnchor = Object.Instantiate(_mazeSettings.BirdsEyeCamera, goTransform);
				
				var view = go.GetComponent<RoomView>();
				view.Construct(room.Element, cameraAnchor.transform);
				roomViewList.Add(room.Element.Id, view);
			}
		}

		public class Factory : IFactory<Maze, MazeViewBuilder>
		{
			private DiContainer _container;

			[Inject]
			private void Construct(DiContainer container)
			{
				_container = container;
			}

			public MazeViewBuilder Create(Maze param1)
			{
				return _container.Instantiate<MazeViewBuilder>(new object []{param1});
			}
		}
	}
}