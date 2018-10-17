using System.Collections.Generic;
using System.Linq;

namespace RougeLike.Katano.Maze
{
	public static class MazeExtensions
	{
		public static Maze Decoration(this Maze maze, IMazeDecorator decorator)
		{
			return decorator.Decoration(maze);
		}

		public static Maze Decoration(this MazeBuilder builder, IMazeDecorator decorator)
		{
			return decorator.Decoration(builder.Build());
		}
		
		public static void SetMark(this Room room, int mark)
		{
			room.Mark.Value = mark;
		}

		public static void SetMarkAndComplete(this Room room, int mark)
		{
			room.Mark.Value = mark;
			room.IsCompleted = true;
		}
		
		public static void SetMarkAndComplete(this Room room, Room from)
		{
			room.Mark.Value = from.Mark.Value;
			room.IsCompleted = true;
		}

		public static IEnumerable<Aisle> GetConnectingAisle(this Maze maze, Room room)
		{
			bool Predicate(Aisle aisle)
			{
				return aisle.Room0 == room || aisle.Room1 == room;
			}

			return maze.Aisles.Where(Predicate);
		}

		public static void Reset(this Aisle aisle)
		{
			aisle.IsEnable.Value = true;
			aisle.IsCompleted = false;
		}

		public static IEnumerable<Room> GetIsolatedRoom(this RoomList roomList, IEnumerable<Aisle> aisles)
		{
			return GetIsolatedRoomInternal(roomList, aisles);
		}

		private static IEnumerable<Room> GetIsolatedRoomInternal(RoomList roomList, IEnumerable<Aisle> aisles)
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