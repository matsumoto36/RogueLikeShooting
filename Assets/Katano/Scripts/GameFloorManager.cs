using System;
using System.Linq;
using System.Threading;
using RogueLike.Katano.Maze.View;
using UniRx;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	///     ゲームボードマネージャ
	/// </summary>
	public class GameFloorManager : MonoBehaviour
	{
		[SerializeField]
		private bool _buildOnAwake = true;

		[SerializeField]
		private MazeDataAssetBase _mazeDataAsset;

		[SerializeField]
		private DebugPlayerCamera _playerCamera;
		
		public int Width = 4;
		public int Height = 4;

		private MazeView _mazeView;

		private bool _isReady;

		public void Initialize()
		{
			MessageBroker.Default
				.Receive<MazeSignal.FloorStarted>()
				.Subscribe(_ =>
				{
					Startup();
				});
			
			Log("Initialized.");
		}

		public void Startup()
		{
			if (!_isReady)
				throw new MazeException("Maze has not been generated.");
			
			
			
			Log("Startup.");
		}
		
		public void Construct()
		{
			var maze = ConstructMaze();
			var view = ConstructMazeView(maze);
			_mazeView = view;
			
			_mazeView.Startup();

			Log("Constructed.");
			
			_isReady = true;
		}

		public void Destruct()
		{
			Destruct(_mazeView);
			
			Log("Destructed.");
			
			_isReady = false;
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

		private static void Destruct(MazeView view)
		{
			view.Dispose();
		}
		
		private static void Log(string log)
		{
			Debug.Log($"[FloorManager] {log}");
		}
	}
}