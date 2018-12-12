using System;

namespace RogueLike.Katano.Maze
{
	public enum EnumDecorationState
	{
		None,
		Labyrinth,
	}
	
	public class MazeDirector
	{
		private readonly MazeBuilder _mazeBuilder;
		private readonly MazeBuildOptions _options;

		public MazeDirector(MazeBuilder mazeBuilder, MazeBuildOptions options)
		{
			_mazeBuilder = mazeBuilder;
			_options = options;
		}

		public Maze Construct()
		{
			_mazeBuilder.SetOptions(_options);
			
			_mazeBuilder.BuildRoom();
			_mazeBuilder.BuildAisle();
			_mazeBuilder.ShortenRoom(0.5f);
			_mazeBuilder.Decoration();
			_mazeBuilder.OverrideAttribute();
			
			
			return _mazeBuilder.Build();
		}
	}
}