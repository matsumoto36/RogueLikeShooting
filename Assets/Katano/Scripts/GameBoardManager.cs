using System;
using RogueLike.Katano.Maze.View;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	///     ゲームボードマネージャ
	/// </summary>
	public class GameBoardManager : MonoBehaviour
	{
		private readonly AsyncSubject<MazeView> _onBuiltMaze = new AsyncSubject<MazeView>();
		public IObservable<MazeView> OnBuiltMaze => _onBuiltMaze;
		
		[SerializeField]
		private bool _buildOnAwake = true;

		[SerializeField]
		private MazeDataAssetBase _mazeDataAsset;
		
		public int Width = 4;
		public int Height = 4;

		private void Start()
		{
			if (_buildOnAwake)
				OnStart();
		}

		private void OnStart()
		{
			var maze = ConstructMaze();
			var view = ConstructMazeView(maze);
			
			_onBuiltMaze.OnNext(view);
			_onBuiltMaze.OnCompleted();
		}

		/// <summary>
		/// 迷宮を生成
		/// </summary>
		/// <returns></returns>
		private Maze ConstructMaze()
		{
			var builder = new MazeBuilder();
			var options = new MazeBuildOptions(Width, Height, EnumDecorationState.Labyrinth);
			var director = new MazeDirector(builder, options);
			
			return director.Construct();
		}

		/// <summary>
		/// 迷宮を実体化する
		/// </summary>
		/// <param name="maze"></param>
		/// <returns></returns>
		private MazeView ConstructMazeView(Maze maze)
		{
			var viewBuilder = new MazeViewBuilder(maze, _mazeDataAsset, transform);

			return viewBuilder.Construct();
		}
	}
}