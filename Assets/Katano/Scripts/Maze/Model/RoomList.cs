using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	/// 部屋コンテナ
	/// </summary>
	public class RoomList : IEnumerable<Room>
	{
		public int Horizontal { get; }
		public int Vertical { get; }

		private readonly Room[,] _rooms;
		public Room this[int i, int j]
		{
			get
			{
				if (i < 0 || i >= Horizontal) throw new IndexOutOfRangeException(nameof(i));
				if (j < 0 || j >= Vertical) throw new IndexOutOfRangeException(nameof(j));

				return _rooms[i, j];
			}
		}

		public RoomList(int horizontal, int vertical)
		{
			Horizontal = horizontal;
			Vertical = vertical;

			_rooms = new Room[horizontal, vertical];
			for (var i = 0; i < horizontal; i++)
			{
				for (var j = 0; j < vertical; j++)
				{
					_rooms[i, j] = new Room(Vertical * j + i);
				}
			}
		}

		public IEnumerator<Room> GetEnumerator()
		{
			return _rooms.OfType<Room>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}