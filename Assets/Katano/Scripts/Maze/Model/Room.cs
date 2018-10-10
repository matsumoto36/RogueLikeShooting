using UniRx;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	/// 部屋
	/// </summary>
	public class Room
	{
		public int Id { get; }
		public IntReactiveProperty Mark { get; } = new IntReactiveProperty();
		public BoolReactiveProperty IsEnable { get; } = new BoolReactiveProperty(true);
		public bool IsCompleted;
		public AdjacentSides AdjacentSide;

		public Room(int id)
		{
			Id = id;
		}
	}
}