using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Reqweldzen.Extensions;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 部屋
	/// </summary>
	public class Room : IEquatable<Room>
	{
		public int Id { get; }
		
		public Point Coordinate { get; }
		public RoomAttributes RoomAttribute { get; set; } = RoomAttributes.None;
		
		public int Mark { get; set; }
		public bool IsEnable { get; set; } = true;
		public bool IsCompleted { get; set; }
		// public AdjacentSides AdjacentSide { get; set; }
		
		public Dictionary<AdjacentSides, Aisle> ConnectingAisles { get; } = new Dictionary<AdjacentSides, Aisle>();

		public Room(int id, Point coordinate)
		{
			Id = id;
			Coordinate = coordinate;
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

		public void RemoveEntries()
		{
			if (!IsEnable)
			{
				ConnectingAisles.Clear();
			}
		}

		public void CheckEntries()
		{
			var list = ConnectingAisles.ToList();
			foreach (var (dir, aisle) in list)
			{
				var connectRoom = aisle.GetCounterSide(this);
				if (!connectRoom.IsEnable)
				{
					// Remove Entry
					ConnectingAisles.Remove(dir);
				}
			}
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
			return new Aisle(left, right);
		}

		[SuppressMessage("ReSharper", "UnusedMember.Global")]
		public new string ToString()
		{
			return $"[Room] Id:{Id} Coord:{Coordinate}";
		}

		/// <summary>
		/// ルームタイプ
		/// </summary>
		public enum RoomAttributes
		{
			/// <summary>
			/// 未設定
			/// </summary>
			None,
			
			/// <summary>
			/// スポーン場所
			/// </summary>
			FloorStart,
			
			/// <summary>
			/// 階段のある部屋
			/// </summary>
			Stair,
			
			/// <summary>
			/// その他
			/// </summary>
			Others
		}
	}
}