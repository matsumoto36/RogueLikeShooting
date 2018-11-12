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
	public class GameBoardManager : MonoBehaviour
	{
		[SerializeField]
		private bool _buildOnAwake = true;

		[SerializeField]
		private MazeDataAssetBase _mazeDataAsset;
		
		public int Width = 4;
		public int Height = 4;

		private CancellationTokenSource _tokenSource;

		private void Start()
		{
			_tokenSource = new CancellationTokenSource();
			_tokenSource.CancelWith(this);
			
			if (_buildOnAwake)
				OnStart(_tokenSource.Token).Forget();
		}

		private async UniTaskVoid OnStart(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				var maze = ConstructMaze();
				var view = ConstructMazeView(maze);
				Debug.Log("Maze build done.");

				await UniTask.Delay(150, cancellationToken: token);
				
				Destruct(view);
			}
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

		private void Destruct(MazeView view)
		{
			foreach (var mazeComponents in view.Rooms.Values.Concat<Component>(view.Aisles.Values))
			{
				Destroy(mazeComponents.gameObject);
			}

			Destroy(view.gameObject);
		}
	}
}