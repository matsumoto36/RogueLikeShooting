using System.Linq;

namespace DDD.Katano.Maze
{
	
	/// <summary>
	///     迷路データ
	/// </summary>
	public class Maze
	{
		/// <summary>
		/// マップ横幅
		/// </summary>
		public int Width { get; }
		
		/// <summary>
		/// マップ縦幅
		/// </summary>
		public int Height { get; }
		
		/// <summary>
		/// 部屋リスト (2d)
		/// </summary>
		public Room[,] Rooms { get; }
		
		/// <summary>
		/// 通路リスト
		/// </summary>
		public Aisle[] Aisles { get; }
		
		public Maze(Room[,] rooms, Aisle[] aisles, int width, int height)
		{
			Rooms = rooms;
			Aisles = aisles;
			Width = width;
			Height = height;
		}

		/// <summary>
		/// 部屋を取得
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Room GetRoom(int id)
		{
			for (var i = 0; i < Rooms.GetLength(0); i++)
			{
				for (var j = 0; j < Rooms.GetLength(1); j++)
				{
					if (id == Rooms[i, j].Id)
					{
						return Rooms[i, j];
					}
				}
			}

			return null;
		}

		public Room GetEntryPoint()
		{
			for (var i = 0; i < Rooms.GetLength(0); i++)
			{
				for (var j = 0; j < Rooms.GetLength(1); j++)
				{
					if (Rooms[i, j].RoomAttribute == Room.RoomAttributes.FloorStart)
					{
						return Rooms[i, j];
					}
				}
			}
			
			throw new MazeException("Entry Point is not found.");
		}
	}
}