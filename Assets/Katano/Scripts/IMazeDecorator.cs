namespace RogueLike.Katano.Maze
{
	public interface IMazeDecorator
	{
		MazeBuilder Decoration(MazeBuilder maze);
	}
}