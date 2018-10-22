using UniRx;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	/// 部屋
	/// </summary>
	public class Room
	{
		public int Id { get; }
		public int Mark { get; set; }
		public bool IsEnable { get; set; }
		public bool IsCompleted { get; set; }
		public AdjacentSides AdjacentSide { get; set; }

		public Room(int id)
		{
			Id = id;
		}
	}
}