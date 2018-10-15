using System;
using System.Collections.Generic;
using System.Linq;
using Reqweldzen.Extensions;

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

		public static MazeBuilder CreateBlank()
		{
			return new MazeBuilder(new MazeBuildOptions());
		}

		public static MazeBuilder CreateSquare(int width, int height)
		{
			return new MazeBuilder(new MazeBuildOptions(width, height));
		}

		public static MazeBuilder CreateOption(MazeBuildOptions options)
		{
			return new MazeBuilder(options);
		}

		public MazeBuilder BuildRoom()
		{
			_roomList = new RoomList(_buildOptions.Horizontal, _buildOptions.Vertical);
			_builtRoom = true;
			return this;
		}

		public MazeBuilder BuildAisle()
		{
			var aisles = new List<Aisle>();

			FillGrid(ref aisles);

			// 重複する通路データを省く
			_rawAisleList = new HashSet<Aisle>(aisles, new AisleEqualityComparer());

			_builtAisle = true;

			return this;
		}

		public MazeBuilder TakeDisableRoom(int count)
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

		private void CleanupSingleRoom()
		{
			// ぼっちは生きられない
			foreach (var room in _roomList.Where(room =>
				!_rawAisleList.Any(aisle => aisle.Room0 == room || aisle.Room1 == room)))
				room.IsEnable.Value = false;
		}

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
		public MazeBuilder CleanupIsolatedRoom()
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

		public Maze Build()
		{
			if (!_builtRoom) throw new MazeException("A room container has not been built yet.");
			if (!_builtAisle) throw new MazeException("Aisles has not been built yet.");
			if (!_cleanup) throw new MazeException("Maze has not been cleaned yet.");

			return new Maze(_roomList, _rawAisleList.ToArray());
		}

		private void FillGrid(ref List<Aisle> aisles)
		{
			for (var i = 0; i < _buildOptions.Horizontal; i++)
			for (var j = 0; j < _buildOptions.Vertical; j++)
			for (var k = 0; k < Neighbor.Length; k++)
			{
				var (x, y) = Neighbor[k];

				if (i + x < 0 || i + x >= _buildOptions.Horizontal) continue;
				if (j + y < 0 || j + y >= _buildOptions.Vertical) continue;

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