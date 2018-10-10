using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace RougeLike.Katano.Maze
{
	public class BoardManager : MonoBehaviour
	{
		private IMazeGenerator _mazeGenerator;
		public Button CreateButton;
		
		public int Height = 4;
		public int Width = 4;
		
		private void Start()
		{
			_mazeGenerator = GetComponent<IMazeGenerator>();
			
			CreateButton.OnClickAsObservable().Subscribe(_ =>
			{
				var maze = _mazeGenerator.Generate(Width, Height);
				_mazeGenerator.CreateMap(maze);
			});
		}
	}
}