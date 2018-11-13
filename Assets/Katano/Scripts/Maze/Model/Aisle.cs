using System;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 通路
	/// </summary>
	public class Aisle : IEquatable<Aisle>
	{
		private static int _uniqueId;
		
		/// <summary>
		/// ID
		/// </summary>
		public int Id { get; }
		
		/// <summary>
		/// 接続している部屋A
		/// </summary>
		public Room Room0 { get; }
		/// <summary>
		/// 接続している部屋B
		/// </summary>
		public Room Room1 { get; }

		/// <summary>
		/// 迷路内で有効フラグ
		/// </summary>
		public bool IsEnable { get; set; }
		
		/// <summary>
		/// 処理フラグ
		/// </summary>
		public bool IsCompleted { get; set; }
		
		/// <summary>
		/// 通路のタイプ
		/// </summary>
		public AisleChainState AisleChainState { get; set; }
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="room0"></param>
		/// <param name="room1"></param>
		/// <param name="aisleChainState"></param>
		/// <exception cref="ArgumentException"></exception>
		public Aisle(Room room0, Room room1, AisleChainState aisleChainState = AisleChainState.Invalid)
		{
			if (room0 == null)
				throw new ArgumentNullException(nameof(room0));

			if (room1 == null)
				throw new ArgumentNullException(nameof(room1));
			
			if (room0.Equals(room1))
				throw new ArgumentException("The arguments are the same.");

			Id = _uniqueId++;
			
//
//			if (aisleType == AisleTypes.Invalid)
//				throw new ArgumentException("Invalid argument.", nameof(aisleType));
			
			(Room0, Room1) = room0.Id < room1.Id ? (room0, room1) : (room1, room0);
			AisleChainState = aisleChainState;
		}

		/// <summary>
		/// 接続している反対側の部屋を取得
		/// </summary>
		/// <param name="origin"></param>
		/// <returns></returns>
		/// <exception cref="MazeException"></exception>
		public Room GetCounterSide(Room origin)
		{
			// 自分ではない方を返す
			if (Room0.Equals(origin))
			{
				return Room1;
			}

			if (Room1.Equals(origin))
			{
				return Room0;
			}

			// どちらも自分でなければエラー
			throw new MazeException("This aisle is not connected to the room");
		}

		public bool IsValid()
		{
			return Room0.IsEnable && Room1.IsEnable;
		}
		
		public override string ToString()
		{
			return $"[Aisle] Couple:{Room0.Id},{Room1.Id}";
		}

		public bool Equals(Aisle other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Room0.Equals(other.Room0) && Room1.Equals(other.Room1);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Aisle) obj);
		}

		public override int GetHashCode()
		{
			return Room0.Id.GetHashCode() ^ Room1.Id.GetHashCode() << 2;
		}

		public static bool operator ==(Aisle left, Aisle right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Aisle left, Aisle right)
		{
			return !Equals(left, right);
		}
	}

	public enum AisleChainState
	{
		Invalid,
		Horizontal,
		Vertical
	}
}