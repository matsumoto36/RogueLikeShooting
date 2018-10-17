using System;
using UniRx;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	/// 通路
	/// </summary>
	public class Aisle
	{
		/// <summary>
		/// 接続している部屋A
		/// </summary>
		public Room Room0 { get; }
		/// <summary>
		/// 接続している部屋B
		/// </summary>
		public Room Room1 { get; }

		public bool IsCompleted;
		public BoolReactiveProperty IsEnable { get; } = new BoolReactiveProperty();
		public AisleTypes AisleType { get; }
		
		public Aisle(Room room0, Room room1, AisleTypes aisleType)
		{
			if (room0 == room1)
				throw new ArgumentException("The arguments are the same.");

			if (aisleType == AisleTypes.Invalid)
				throw new ArgumentException("Invalid argument.", nameof(aisleType));
			
			(Room0, Room1) = room0.Id < room1.Id ? (room0, room1) : (room1, room0);
			AisleType = aisleType;
		}

		public Room GetCounterSide(Room self)
		{
			// 自分ではない方を入れる
			if (Room0 == self)
			{
				return Room1;
			}

			if (Room1 == self)
			{
				return Room0;
			}

			// どちらも自分でなければエラー
			throw new MazeException("This aisle is not connected to the room");
		}

		public override string ToString()
		{
			return $"[Aisle]({Room0.Id},{Room1.Id})";
		}
	}

	public enum AisleTypes
	{
		Invalid,
		Horizontal,
		Vertical
	}
}