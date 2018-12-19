namespace RogueLike.Katano.Maze
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
		public Room[,] RoomList { get; }
		
		/// <summary>
		/// 通路リスト
		/// </summary>
		public Aisle[] Aisles { get; }
		
		public Maze(Room[,] roomList, Aisle[] aisles, int width, int height)
		{
			RoomList = roomList;
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
			for (var i = 0; i < RoomList.GetLength(0); i++)
			{
				for (var j = 0; j < RoomList.GetLength(1); j++)
				{
					if (id == RoomList[i, j].Id)
					{
						return RoomList[i, j];
					}
				}
			}

			return null;
		}
	}
}