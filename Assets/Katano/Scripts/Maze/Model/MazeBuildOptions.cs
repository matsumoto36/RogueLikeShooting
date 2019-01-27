namespace DDD.Katano.Maze
{
	/// <summary>
	///     生成オプション
	/// </summary>
	public struct MazeBuildOptions
	{
		/// <summary>
		/// マップの部屋数(横)
		/// </summary>
		public int Width { get; }
		
		/// <summary>
		/// マップの部屋数(縦)
		/// </summary>
		public int Height { get; }
		
		/// <summary>
		/// 改装モード
		/// </summary>
		public DecorationState DecorationState { get; }
		
		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="decorationState"></param>
		public MazeBuildOptions(int width, int height, DecorationState decorationState)
		{
			Width = width;
			Height = height;
			DecorationState = decorationState;
		}
	}
}