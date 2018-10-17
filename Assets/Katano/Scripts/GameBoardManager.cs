using System;
using System.Threading;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	/// ゲームボードマネージャ
	/// </summary>
	public class GameBoardManager : MonoBehaviour
	{
		private CancellationTokenSource _tokenSource;
		
		public Button CreateButton;
		
		public int Width = 4;
		public int Height = 4;
		
		private readonly AsyncSubject<Maze> _onBuiltMaze = new AsyncSubject<Maze>();
		public IObservable<Maze> OnBuiltMaze => _onBuiltMaze;
		
		
		private void Start()
		{
			async UniTaskVoid OnStart()
			{
				await CreateButton.OnClickAsync(_tokenSource.Token);
				
				var maze = MazeBuilder.CreateSquare(Width, Height)
					.FillGrid()
					.ShortenRoom(0.5f)
					.Decoration<LabyrinthDecorator>();

				_onBuiltMaze.OnNext(maze);
				_onBuiltMaze.OnCompleted();
			}

			_tokenSource = new CancellationTokenSource();
			_tokenSource.CancelWith(this);

			OnStart().Forget();
		}
	}
}