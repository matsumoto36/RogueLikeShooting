using System;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano.Maze
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
			var builder = new MazeBuilder();
			var options = new MazeBuildOptions(Width, Height, EnumDecorationState.Labyrinth);
			var director = new MazeDirector(builder, options);

			_onBuiltMaze.Subscribe();
			
			_onBuiltMaze.OnNext(director.Construct());
			_onBuiltMaze.OnCompleted();
		}
	}
}