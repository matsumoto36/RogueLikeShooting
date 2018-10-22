using System;
using System.Collections.Generic;
using System.Linq;
using Katano;
using Reqweldzen.Extensions;
using UnityEngine;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	///     迷路ビルダー
	/// </summary>
	public class MazeBuilder
	{
		private MazeBuildOptions _buildOptions;
		private bool _builtAisle;

		private bool _builtRoom;
		private bool _cleanup = true;
		private HashSet<Aisle> _rawAisleList;

		private RoomList _roomList;
		
		/// <summary>
		///     部屋を作成する
		/// </summary>
		/// <returns></returns>
		public void BuildRoom()
		{
			_roomList = new RoomList(_buildOptions.Width, _buildOptions.Height);
			_builtRoom = true;
		}

		public void SetOptions(MazeBuildOptions options)
		{
			_buildOptions = options;
		}

		/// <summary>
		///     通路を作成する
		/// </summary>
		/// <returns></returns>
		public void BuildAisle()
		{
			var aisles = new List<Aisle>();

			MakeAisle(ref aisles);

			// 重複する通路データを省く
			_rawAisleList = new HashSet<Aisle>(aisles, new AisleEqualityComparer());

			_builtAisle = true;
		}

		/// <summary>
		///     部屋数を短縮する
		/// </summary>
		/// <param name="rate">レート (0-1)</param>
		/// <returns></returns>
		public void ShortenRoom(float rate)
		{
			rate = Mathf.Clamp01(rate);

			var get = Mathf.FloorToInt(_roomList.Length * rate);

			ShortenRoomInternal(get).CleanupIsolatedRoom();
		}

		/// <summary>
		///     部屋数を短縮する
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		/// <exception cref="MazeException"></exception>
		private MazeBuilder ShortenRoomInternal(int count)
		{
			if (!_builtRoom)
				throw new MazeException("A room container has not been built yet.");
			if (!_builtAisle)
				throw new MazeException("Aisles has not been built yet.");

			foreach (var room in _roomList.TakeRandom(count)) room.IsEnable = false;

			_rawAisleList.RemoveWhere(x => !x.Room0.IsEnable || !x.Room1.IsEnable);

			_cleanup = false;

			return this;
		}

		/// <summary>
		///     通路無接続の部屋を無効化
		/// </summary>
		private void RemoveIsolatedRoom()
		{
			// ぼっちは生きられない
			foreach (var room in _roomList.GetIsolatedRoom(_rawAisleList)) room.IsEnable = false;
		}

		/// <summary>
		///     小さいクラスターを無効化
		/// </summary>
		private void RemoveSmallCluster()
		{
			var roomList = _roomList.Where(x => x.IsEnable).ToList();
			var checkedRoomList = new HashSet<Room>(new RoomEqualityComparer());
			var checkedRoomSet = new List<List<Room>>();

			var pick = roomList.RandomAt();
			CountChainRooms(pick, ref checkedRoomList);

			if (checkedRoomList.Count < roomList.Count / 2)
			{
				while (true)
				{
					checkedRoomSet.Add(checkedRoomList.ToList());
					roomList = roomList.Except(checkedRoomSet.SelectMany(x => x)).ToList();
					checkedRoomList.Clear();

					if (!roomList.Any()) break;

					pick = roomList.RandomAt();
					CountChainRooms(pick, ref checkedRoomList);
				}

				foreach (var room in checkedRoomSet.OrderByDescending(x => x.Count)
					.ThenByDescending(x => x.OrderByDescending(y => y.Id).ElementAt(0).Id).Skip(1)
					.SelectMany(x => x)) room.IsEnable = false;
			}
			else
			{
				// 大きいクラスター以外の部屋を無効化
				foreach (var room in roomList.Except(checkedRoomList)) room.IsEnable = false;
			}
		}

		/// <summary>
		///     孤立した部屋を消す
		/// </summary>
		/// <returns></returns>
		private void CleanupIsolatedRoom()
		{
			// 単一の部屋を消す
			RemoveIsolatedRoom();

			// つながりが少ない部屋を消す
			RemoveSmallCluster();

			_rawAisleList.RemoveWhere(x => !x.Room0.IsEnable || !x.Room1.IsEnable);

			_cleanup = true;
		}

		/// <summary>
		///     再帰的に部屋が全通かチェックする
		/// </summary>
		/// <returns></returns>
		private void CountChainRooms(Room origin, ref HashSet<Room> checkedList)
		{
			// 部屋に接続しているすべての通路
			foreach (var aisle in _rawAisleList.GetConnectingAisle(origin))
			{
				// つながってる部屋を取得
				var counterSide = aisle.GetCounterSide(origin);

				if (checkedList.Contains(counterSide)) continue;
				
				// カウント済みリストに追加
				checkedList.Add(counterSide);

				CountChainRooms(counterSide, ref checkedList);
			}
		}

		/// <summary>
		///     迷路を作成
		/// </summary>
		/// <returns></returns>
		/// <exception cref="MazeException"></exception>
		public Maze Build()
		{
			if (!_builtRoom) throw new MazeException("A room container has not been built yet.");
			if (!_builtAisle) throw new MazeException("Aisles has not been built yet.");
			if (!_cleanup) throw new MazeException("Maze has not been cleaned yet.");

			return new Maze(_roomList, _rawAisleList.ToArray());
		}

		/// <summary>
		///     部屋間に通路を敷く
		/// </summary>
		/// <param name="aisles"></param>
		private void MakeAisle(ref List<Aisle> aisles)
		{
			for (var i = 0; i < _buildOptions.Width; i++)
			for (var j = 0; j < _buildOptions.Height; j++)
			for (var k = 0; k < Utilities.Neighbors.Length; k++)
			{
				// Point
				var (x, y) = Utilities.Neighbors[k];

				// 範囲外は除外
				if (i + x < 0 || i + x >= _buildOptions.Width) continue;
				if (j + y < 0 || j + y >= _buildOptions.Height) continue;

				_roomList[i + x, j + y].AdjacentSide |= (AdjacentSides) (1 << k);

				var aisle = new Aisle(
					_roomList[i, j],
					_roomList[i + x, j + y],
					k % 2 == 0
						? AisleTypes.Vertical
						: AisleTypes.Horizontal);

				aisles.Add(aisle);
			}
		}

		public void Decoration()
		{
			switch (_buildOptions.DecorationState)
			{
				case EnumDecorationState.None:
					break;
				case EnumDecorationState.Labyrinth:
					LabyrinthDecoration();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
		private void LabyrinthDecoration()
		{
			// 再帰的に部屋が全通かチェックする
			void FillMark(Room origin)
			{
				// 部屋に接続しているすべての通路
				foreach (var aisle in _rawAisleList.GetConnectingAisle(origin))
				{
					if (!aisle.IsEnable) continue;
					
					var counterSide = aisle.GetCounterSide(origin);

					// マーク済みなら何もしない
					if (counterSide.IsCompleted) continue;

					counterSide.SetMarkAndComplete(origin);
					
					FillMark(counterSide);
				}
			}
			
			// 通路のチェック済みフラグを消す
			foreach (var aisle in _rawAisleList)
			{
				aisle.Reset();
			}
			
			// 有効な部屋のリスト
			var roomList = _roomList.Where(x => x.IsEnable).ToList();
			
			// マーキング
			var mark = 0;
			
			// 部屋をリマークする
			foreach (var room in roomList)
			{
				room.SetMark(mark);
			}
			
			// 通路の数だけループする
			for (var i = 0; i < _rawAisleList.Count ; i++)
			{
				// 未チェックかつ有効な通路を選択
				var aisle = _rawAisleList.RandomAt(x => !x.IsCompleted && x.IsEnable);
				
				// 通路を無効化
				aisle.IsEnable = false;

				// 部屋のチェックフラグを初期化
				foreach (var room in roomList) room.IsCompleted = false;

				// 適当な部屋を選ぶ
				var pickRoom = roomList.RandomAt();
				
				// マークを進める
				mark++;
				
				pickRoom.SetMarkAndComplete(mark);
				
				// つながっている部屋に同じマークを付ける
				FillMark(pickRoom);

				// 新しいマークがついていない部屋があれば、通路を元に戻す
				if (roomList.Any(x => mark != x.Mark))
				{
					aisle.IsEnable = true;
				}

				// 処理済みとしてチェック
				aisle.IsCompleted = true;
			}
		}

		private class RoomEqualityComparer : IEqualityComparer<Room>
		{
			public bool Equals(Room x, Room y)
			{
				if (x == null && y == null)
					return true;
				if (x == null || y == null)
					return false;

				return x.Id == y.Id;
			}

			public int GetHashCode(Room obj)
			{
				return obj.Id.GetHashCode();
			}
		}

		/// <summary>
		///     等価性の比較処理クラス
		/// </summary>
		private class AisleEqualityComparer : IEqualityComparer<Aisle>
		{
			public bool Equals(Aisle x, Aisle y)
			{
				if (x == null && y == null)
					return true;
				if (x == null || y == null)
					return false;
				return x.Room0.Id == y.Room0.Id && x.Room1.Id == y.Room1.Id;
			}

			public int GetHashCode(Aisle obj)
			{
				var hashCode = obj.Room0.Id ^ obj.Room1.Id;
				return hashCode.GetHashCode();
			}
		}
	}

	/// <summary>
	///     生成オプション
	/// </summary>
	public struct MazeBuildOptions
	{
		public MazeBuildOptions(int width, int height, EnumDecorationState decorationState)
		{
			Width = width;
			Height = height;
			DecorationState = decorationState;
		}

		public int Width { get; }
		public int Height { get; }
		public EnumDecorationState DecorationState { get; }
	}
}