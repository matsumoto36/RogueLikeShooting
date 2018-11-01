using System.Threading;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.Katano.Maze
{
	public class MazeDebugDirector : MonoBehaviour
	{

		public Button BuildRoom;
		public Button BuildAisle;
		public Button Shortening;
		public Button Decoration;
		public Button Apply;

		private CancellationTokenSource _tokenSource;
			
		private MazeBuilder _builder;
		private MazeBuildOptions _options;
		private bool _isInit;

		private void Awake()
		{
			_tokenSource = new CancellationTokenSource();
			_tokenSource.CancelWith(this);
		}
		
		public void Initialize(MazeBuilder builder, MazeBuildOptions options)
		{
			_builder = builder;
			_options = options;

			_isInit = true;
		}
		
		public UniTask<Maze> ConstructAsync()
		{
			if (!_isInit)
				return UniTask.FromException<Maze>(new MazeException("Director has not been initialize yet."));
			
			return new UniTask<Maze>(ConstructInternal);
		}

		private async UniTask<Maze> ConstructInternal()
		{
			_builder.SetOptions(_options);

			await BuildRoom.OnClickAsync();
			
			_builder.BuildRoom();

			await BuildAisle.OnClickAsync();
			
			_builder.BuildAisle();

			await Shortening.OnClickAsync();
			
			_builder.ShortenRoom(0.5f);

			await Decoration.OnClickAsync();
			
			_builder.Decoration();

			await Apply.OnClickAsync();

			return _builder.Build();
		}
	}
}