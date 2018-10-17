using System.Collections.Generic;
using System.Linq;
using Reqweldzen.Extensions;
using UnityEngine;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	///     迷路ビルダー
	/// </summary>
	public class MazeBuilder
	{
		private static readonly Point[] Neighbor =
			{new Point(0, 1), new Point(-1, 0), new Point(0, -1), new Point(1, 0)};

		private readonly MazeBuildOptions _buildOptions;
		private bool _builtAisle;

		private bool _builtRoom;
		private bool _cleanup = true;
		private HashSet<Aisle> _rawAisleList;

		private RoomList _roomList;

		private MazeBuilder(MazeBuildOptions buildOptions)
		{
			_buildOptions = buildOptions;
		}

		/// <summary>
		///     迷路のビルドクラスを作成
		/// </summary>
		/// <returns></returns>
		public static MazeBuilder CreateBlank()
		{
			return new MazeBuilder(new MazeBuildOptions());
		}

		/// <summary>
		///     迷路のビルドクラスを作成
		/// </summary>
		/// <returns></returns>
		public static MazeBuilder CreateSquare(int width, int height)
		{
			return new MazeBuilder(new MazeBuildOptions(width, height));
		}

		/// <summary>
		///     迷路のビルドクラスを作成
		/// </summary>
		/// <returns></returns>
		public static MazeBuilder CreateOption(MazeBuildOptions options)
		{
			return new MazeBuilder(options);
		}

		/// <summary>
		///     設定されている大きさで格子状に迷路を作成
		/// </summary>
		/// <returns></returns>
		public MazeBuilder FillGrid()
		{
			return BuildRoom().BuildAisle();
		}

		/// <summary>
		///     部屋を作成する
		/// </summary>
		/// <returns></returns>
		private MazeBuilder BuildRoom()
		{
			_roomList = new RoomList(_buildOptions.Width, _buildOptions.Height);
			_builtRoom = true;
			return this;
		}

		/// <summary>
		///     通路を作成する
		/// </summary>
		/// <returns></returns>
		private MazeBuilder BuildAisle()
		{
			var aisles = new List<Aisle>();

			MakeAisle(ref aisles);

			// 重複する通路データを省く
			_rawAisleList = new HashSet<Aisle>(aisles, new AisleEqualityComparer());

			_builtAisle = true;

			return this;
		}

		/// <summary>
		///     部屋数を短縮する
		/// </summary>
		/// <param name="rate">レート (0-1)</param>
		/// <returns></returns>
		public MazeBuilder ShortenRoom(float rate)
		{
			rate = Mathf.Clamp01(rate);

			var get = Mathf.FloorToInt(_roomList.Length * rate);

			return ShortenRoomInternal(get).CleanupIsolatedRoom();
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

			foreach (var room in _roomList.TakeRandom(count)) room.IsEnable.Value = false;

			_rawAisleList.RemoveWhere(x => !x.Room0.IsEnable.Value || !x.Room1.IsEnable.Value);

			_cleanup = false;

			return this;
		}

		/// <summary>
		///     通路無接続の部屋を無効化
		/// </summary>
		private void CleanupSingleRoom()
		{
			// ぼっちは生きられない
			foreach (var room in _roomList.GetIsolatedRoom(_rawAisleList)) room.IsEnable.Value = false;
		}

		/// <summary>
		///     接続数が少ない部屋を無効化
		/// </summary>
		private void CleanupSmallChainedRoom()
		{
			var roomList = _roomList.Where(x => x.IsEnable.Value).ToList();
			var checkedList = new List<Room>();
			var reserve = new List<List<Room>>();

			var pick = roomList.RandomAt();
			CountChainRooms(pick, ref checkedList);

			if (checkedList.Count < roomList.Count / 2)
			{
				while (true)
				{
					reserve.Add(checkedList.ToList());
					roomList = roomList.Except(reserve.SelectMany(x => x)).ToList();
					checkedList.Clear();

					if (!roomList.Any()) break;

					pick = roomList.RandomAt();
					CountChainRooms(pick, ref checkedList);
				}

				foreach (var room in reserve.OrderByDescending(x => x.Count)
					.ThenByDescending(x => x.OrderByDescending(y => y.Id).ElementAt(0).Id).Skip(1)
					.SelectMany(x => x)) room.IsEnable.Value = false;
			}
			else
			{
				foreach (var room in roomList.Except(checkedList)) room.IsEnable.Value = false;
			}
		}

		/// <summary>
		///     孤立した部屋を消す
		/// </summary>
		/// <returns></returns>
		private MazeBuilder CleanupIsolatedRoom()
		{
			// 単一の部屋を消す
			CleanupSingleRoom();

			// つながりが少ない部屋を消す
			CleanupSmallChainedRoom();

			_rawAisleList.RemoveWhere(x => !x.Room0.IsEnable.Value || !x.Room1.IsEnable.Value);

			_cleanup = true;

			return this;
		}

		/// <summary>
		///     再帰的に部屋が全通かチェックする
		/// </summary>
		/// <returns></returns>
		private void CountChainRooms(Room current, ref List<Room> checkedList)
		{
			// 部屋に接続しているすべての通路
			foreach (var aisle in _rawAisleList.Where(x => x.Room0 == current || x.Room1 == current))
			{
				// つながっている部屋
				Room dest;

				// 自分ではない方を入れる
				if (aisle.Room0 == current)
					dest = aisle.Room1;
				else if (aisle.Room1 == current)
					dest = aisle.Room0;
				else
					throw new MazeException("This aisle is not connected to the room");

				// if (!aisle.IsEnable.Value) continue;

				if (checkedList.Contains(dest)) continue;

				checkedList.Add(dest);

				CountChainRooms(dest, ref checkedList);
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
			for (var k = 0; k < Neighbor.Length; k++)
			{
				var (x, y) = Neighbor[k];

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

		public static implicit operator Maze(MazeBuilder builder)
		{
			return builder.Build();
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
		public MazeBuildOptions(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public int Width { get; }
		public int Height { get; }
	}
}