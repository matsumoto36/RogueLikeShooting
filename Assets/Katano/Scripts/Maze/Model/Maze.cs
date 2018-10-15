namespace RougeLike.Katano.Maze
{
	/// <summary>
	///     迷路データ
	/// </summary>
	public class Maze
	{
		public RoomList RoomList { get; }
		public Aisle[] Aisles { get; }
		
		public Maze(RoomList roomList, Aisle[] aisles)
		{
			RoomList = roomList;
			Aisles = aisles;
		}
	}
}