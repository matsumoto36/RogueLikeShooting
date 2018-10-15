using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace RougeLike.Katano.Maze
{
	public class BoardManager : MonoBehaviour
	{
		private MazeDecorator _mazeDecorator;
		public Button CreateButton;
		
		public int Width = 4;
		public int Height = 4;
		
		
		private void Start()
		{
			_mazeDecorator = GetComponent<MazeDecorator>();
			
			CreateButton.OnClickAsObservable().Subscribe(_ => OnClickButton());
		}

		private void OnClickButton()
		{
			var maze = MazeBuilder.CreateSquare(Width, Height)
				.FillGrid()
				.ShortenRoom(0.5f)
				.Decoration(new LabyrinthDecorator());
		}
	}
}