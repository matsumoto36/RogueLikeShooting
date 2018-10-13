using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace RougeLike.Katano.Maze
{
	public class BoardManager : MonoBehaviour
	{
		private IMazeGenerator _mazeGenerator;
		private MazeDecorator _mazeDecorator;
		public Button CreateButton;
		
		public int Height = 4;
		public int Width = 4;
		
		private void Start()
		{
			_mazeGenerator = GetComponent<IMazeGenerator>();
			_mazeDecorator = GetComponent<MazeDecorator>();
			
			CreateButton.OnClickAsObservable().Subscribe(_ =>
			{
				var maze = _mazeGenerator.Generate(Width, Height);
				_mazeGenerator.CreateMap(maze);
				_mazeDecorator.Decorate(maze);
			});
		}
	}
}