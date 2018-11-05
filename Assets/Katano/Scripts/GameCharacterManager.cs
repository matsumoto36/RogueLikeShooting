using RogueLike.Matsumoto;
using RogueLike.Katano;
using RogueLike.Katano.Maze;
using UniRx;
using UniRx.Async;
using UnityEngine;

namespace Katano
{
	/// <summary>
	/// ゲームキャラクターマネージャ
	/// </summary>
	public class GameCharacterManager : MonoBehaviour
	{
		public GameBoardManager GameBoardManager;
		public MazeCharacterSpawner CharacterSpawner;
		public MazeViewBuilder MazeViewBuilder;
		
		private void Start()
		{
			async UniTaskVoid OnStart()
			{
				var maze = await GameBoardManager.OnBuiltMaze;
				
				var viewer = MazeViewBuilder.BuildView(maze);

				CharacterSpawner.Spawn(viewer);
			}

			OnStart().Forget();
		}
	}
}