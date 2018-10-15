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
			return decorator.Decoration(builder);
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
	}
}