using System;
using System.Collections.Generic;
using System.Linq;
using Reqweldzen.Extensions;
using UnityEditor.U2D;
using UnityEngine;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	/// ダンジョン
	/// </summary>
	public class Maze
	{
		public RoomContainer RoomContainer { get; }
		public Aisle[] Aisles { get; }
		
		private Maze(RoomContainer roomContainer, Aisle[] aisles)
		{
			RoomContainer = roomContainer;
			Aisles = aisles;
		}
		
		/// <summary>
		/// ジェネレータ
		/// </summary>
		public class Generator
		{
			private static readonly Point[] Neighbor = { new Point(0, 1), new Point(-1, 0), new Point(0, -1), new Point(1, 0) };
			
			private readonly MazeOptions _options;

			private RoomContainer _roomContainer;
			private HashSet<Aisle> _rawAisleList;

			private bool _builtRoom;
			private bool _builtAisle;
			private bool _cleanup = true;
			
			public Generator(MazeOptions options)
			{
				_options = options;
			}

			public Generator BuildRoom()
			{
				_roomContainer = new RoomContainer(_options.Horizontal, _options.Vertical);
				_builtRoom = true;
				return this;
			}
			
			public Generator BuildAisle(GenerateTypes type)
			{
				var aisles = new List<Aisle>();

				switch (type)
				{
					case GenerateTypes.AllChained:
					{
						AllChain(ref aisles);
						break;
					}

					default:
						throw new ArgumentOutOfRangeException();
				}
				
				// 重複する通路データを省く
				_rawAisleList = new HashSet<Aisle>(aisles, new AisleEqualityComparer());
				
				_builtAisle = true;

				return this;
			}

			public Generator TakeDisableRoom(int count)
			{
				if (!_builtRoom)
					throw new MazeException("A room container has not been built yet.");
				if (!_builtAisle)
					throw new MazeException("Aisles has not been built yet.");
				
				foreach (var room in _roomContainer.TakeRandom(count))
				{
					room.IsEnable.Value = false;
				}
				
				_rawAisleList.RemoveWhere(x => !x.Room0.IsEnable.Value || !x.Room1.IsEnable.Value);

				_cleanup = false;
				
				return this;
			}

			private void CleanupSingleRoom()
			{
				// ぼっちは生きられない
				foreach (var room in _roomContainer.Where(room =>
					!_rawAisleList.Any(aisle => aisle.Room0 == room || aisle.Room1 == room)))
				{
					room.IsEnable.Value = false;
				}
			}

			private void CleanupSmallChainedRoom()
			{
				var roomList = _roomContainer.Where(x => x.IsEnable.Value).ToList();
				var checkedList = new List<Room>();
				var reserve = new List<List<Room>>();
				
				var pick = roomList.RandomAt();
				CountChainRooms(pick, ref checkedList);

				if (checkedList.Count < roomList.Count / 2)
				{
					while(true)
					{
						reserve.Add(checkedList.ToList());
						roomList = roomList.Except(reserve.SelectMany(x => x)).ToList();
						checkedList.Clear();
						
						if (!roomList.Any()) break;
						
						pick = roomList.RandomAt();
						CountChainRooms(pick, ref checkedList);
					}

					foreach (var room in reserve.OrderByDescending(x => x.Count).ThenByDescending(x => x.OrderByDescending(y => y.Id).ElementAt(0).Id).Skip(1).SelectMany(x => x))
					{
						room.IsEnable.Value = false;
					}
				}
				else
				{
					foreach (var room in roomList.Except(checkedList))
					{
						room.IsEnable.Value = false;
					}
				}
			}
			
			/// <summary>
			/// 孤立した部屋を消す
			/// </summary>
			/// <returns></returns>
			public Generator CleanupIsolatedRoom()
			{
				// 単一の部屋を消す
				CleanupSingleRoom();
				
				// つながりが少ない部屋を消す
				CleanupSmallChainedRoom();
				
				_rawAisleList.RemoveWhere(x => !x.Room0.IsEnable.Value || !x.Room1.IsEnable.Value);
				
				_cleanup = true;

				return this;
			}

			// 再帰的に部屋が全通かチェックする
			private void CountChainRooms(Room current, ref List<Room> checkedList)
			{
				// 部屋に接続しているすべての通路
				foreach (var aisle in _rawAisleList.Where(x => x.Room0 == current || x.Room1 == current))
				{
					// つながっている部屋
					Room dest;
					
					// 自分ではない方を入れる
					if (aisle.Room0 == current)
					{
						dest = aisle.Room1;
					}
					else if (aisle.Room1 == current)
					{
						dest = aisle.Room0;
					}
					else
					{
						// どちらも自分でなければエラー
						throw new MazeException("This aisle is not connected to the room");
					}

					// if (!aisle.IsEnable.Value) continue;

					if (checkedList.Contains(dest))
					{
						continue;
					}
					
					checkedList.Add(dest);
					
					CountChainRooms(dest, ref checkedList);
				}
			}
			
			public Maze Generate()
			{
				if (!_builtRoom) throw new MazeException("A room container has not been built yet.");
				if (!_builtAisle) throw new MazeException("Aisles has not been built yet.");
				if (!_cleanup) throw new MazeException("Maze has not been cleaned yet.");
				
				return new Maze(_roomContainer, _rawAisleList.ToArray());
			}

			private void AllChain(ref List<Aisle> aisles)
			{
				for (var i = 0; i < _options.Horizontal; i++)
				{
					for (var j = 0; j < _options.Vertical; j++)
					{
						for (var k = 0; k < Neighbor.Length; k++)
						{
							var (x, y) = Neighbor[k];
							
							if (i + x < 0 || i + x >= _options.Horizontal) continue;
							if (j + y < 0 || j + y >= _options.Vertical) continue;

							_roomContainer[i + x, j + y].AdjacentSide |= (AdjacentSides) (1 << k);
							var aisle = new Aisle(_roomContainer[i,j], _roomContainer[i + x, j + y]);

							aisles.Add(aisle);
						}
					}
				}
			}
			
			/// <summary>
			/// 等価性の比較処理クラス
			/// </summary>
			private class AisleEqualityComparer : IEqualityComparer<Aisle>
			{
				public bool Equals(Aisle x, Aisle y)
				{
					if (x == null && y == null)
						return true;
					if (x == null || y == null)
						return false;
					if (x.Room0.Id == y.Room0.Id && x.Room1.Id == y.Room1.Id)
						return true;
					return false;
				}

				public int GetHashCode(Aisle obj)
				{
					var hashCode = obj.Room0.Id ^ obj.Room1.Id;
					return hashCode.GetHashCode();
				}
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public struct MazeOptions
	{
		public MazeOptions(int horizontal, int vertical)
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
	/// 生成パターンタイプ
	/// </summary>
	public enum GenerateTypes
	{
		AllChained
	}
	
}