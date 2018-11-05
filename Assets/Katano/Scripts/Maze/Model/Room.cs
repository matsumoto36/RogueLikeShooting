using System;
using UniRx;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 部屋
	/// </summary>
	public class Room : IEquatable<Room>
	{
		public int Id { get; }
		public int Mark { get; set; }
		public bool IsEnable { get; set; } = true;
		public bool IsCompleted { get; set; }
		public AdjacentSides AdjacentSide { get; set; }

		public Room(int id)
		{
			Id = id;
		}

		public bool Equals(Room other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Room) obj);
		}

		public override int GetHashCode()
		{
			return Id;
		}
		
		public static bool operator ==(Room left, Room right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Room left, Room right)
		{
			return !Equals(left, right);
		}

		public static Aisle operator +(Room left, Room right)
		{
			return new Aisle(left, right, AisleChainState.Invalid);
		}
	}
}