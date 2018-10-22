namespace RougeLike.Katano.Maze
{
	public interface IMazeDecorator
	{
		MazeBuilder Decoration(MazeBuilder maze);
	}
}