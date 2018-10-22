using System.Collections.Generic;
using System.Linq;

namespace RogueLike.Katano.Maze
{
	public static class MazeExtensions
	{
		public static MazeBuilder Decoration(this MazeBuilder builder, IMazeDecorator decorator)
		{
			return decorator.Decoration(builder);
		}

		public static Aisle WithState(this Aisle aisle, AisleChainState aisleChainState)
		{
			aisle.AisleChainState = aisleChainState;
			return aisle;
		}
		
		public static void SetMark(this Room room, int mark)
		{
			room.Mark = mark;
		}

		public static void SetMarkAndComplete(this Room room, int mark)
		{
			room.Mark = mark;
			room.IsCompleted = true;
		}
		
		public static void SetMarkAndComplete(this Room room, Room from)
		{
			room.Mark = from.Mark;
			room.IsCompleted = true;
		}

		public static IEnumerable<Aisle> GetConnectingAisle(this IEnumerable<Aisle> aisles, Room room)
		{
			bool Predicate(Aisle aisle)
			{
				return aisle.Room0 == room || aisle.Room1 == room;
			}

			return aisles.Where(Predicate);
		}

		public static void Reset(this Aisle aisle)
		{
			aisle.IsEnable = true;
			aisle.IsCompleted = false;
		}

		public static IEnumerable<Room> GetIsolatedRoom(this Room[,] roomList, IEnumerable<Aisle> aisles)
		{
			return GetIsolatedRoomInternal(roomList, aisles);
		}

		private static IEnumerable<Room> GetIsolatedRoomInternal(Room[,] roomList, IEnumerable<Aisle> aisles)
		{
			var aisleList = aisles.ToArray();

			foreach (var room in roomList)
			{
				if (!aisleList.Any(aisle => room == aisle.Room0 || room == aisle.Room1))
					yield return room;
			}
		}
	}
}