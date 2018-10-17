using System;
using UniRx;
using UnityEngine;

namespace RougeLike.Katano.Maze
{
	/// <summary>
	///     ゲームボードマネージャ
	/// </summary>
	public class GameBoardManager : MonoBehaviour
	{
		private readonly AsyncSubject<Maze> _onBuiltMaze = new AsyncSubject<Maze>();
		public IObservable<Maze> OnBuiltMaze => _onBuiltMaze;
		
		[SerializeField]
		private bool _buildOnAwake = true;
		
		public int Width = 4;
		public int Height = 4;

		private void Start()
		{
			if (_buildOnAwake)
				OnStart();
		}

		public void OnStart()
		{
			var maze = MazeBuilder.CreateSquare(Width, Height)
				.FillGrid()
				.ShortenRoom(0.3f)
				.Decoration(new LabyrinthDecorator());

			_onBuiltMaze.OnNext(maze);
			_onBuiltMaze.OnCompleted();
		}
	}
}