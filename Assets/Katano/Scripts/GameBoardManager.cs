using System;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.Serialization;

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

		[FormerlySerializedAs("_debugDirector")]
		public MazeDebugDirector DebugDirector;
		
		public int Width = 4;
		public int Height = 4;

		private void Start()
		{
			if (_buildOnAwake)
				OnStart().Forget();
		}

		private async UniTaskVoid OnStart()
		{
			var builder = new MazeBuilder();
			var options = new MazeBuildOptions(Width, Height, EnumDecorationState.Labyrinth);
			DebugDirector.Initialize(builder, options);
			
			_onBuiltMaze.OnNext(await DebugDirector.ConstructAsync());
			_onBuiltMaze.OnCompleted();
		}
	}
}