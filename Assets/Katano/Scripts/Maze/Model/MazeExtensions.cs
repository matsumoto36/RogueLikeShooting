namespace RougeLike.Katano.Maze
{
	public static class MazeExtensions
	{
		public static void SetMark(this Room room, int mark)
		{
			room.Mark.Value = mark;
		}
		
		public static void SetMarkAndComplete(this Room room, Room from)
		{
			room.Mark.Value = from.Mark.Value;
			room.IsCompleted = true;
		}
		
		public static MazeBuilder BuildAll(this MazeBuilder builder)
		{
			return builder.BuildRoom().BuildAisle();
		}
	}
}