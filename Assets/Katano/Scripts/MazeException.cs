using System;

namespace RougeLike.Katano.Maze
{
	public class MazeException : Exception
	{
		public MazeException()
		{
			
		}

		public MazeException(string message) : base(message)
		{
			
		}

		public MazeException(string message, Exception inner) : base(message, inner)
		{
			
		}
	}
}