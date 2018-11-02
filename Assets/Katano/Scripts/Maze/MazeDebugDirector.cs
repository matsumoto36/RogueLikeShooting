using System.Threading;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.Katano.Maze
{
	public class MazeDebugDirector : MonoBehaviour
	{
		[SerializeField]
		private Button _stepButton;

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

			await ButtonClickAsync("Build Room");
			
			_builder.BuildRoom();

			await ButtonClickAsync("Build Aisle");
			
			_builder.BuildAisle();

			await ButtonClickAsync("Shorten Room");
			
			_builder.ShortenRoom(0.5f);

			await ButtonClickAsync("Decoration");
			
			_builder.Decoration();

			await ButtonClickAsync("Apply Changes!");

			return _builder.Build();
		}

		private UniTask ButtonClickAsync(string label)
		{
			var text = _stepButton.GetComponentInChildren<Text>();
			text.text = label;

			return _stepButton.OnClickAsync();
		}
	}
}