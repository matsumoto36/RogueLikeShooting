using RogueLike.Matsumoto;
using RougeLike.Katano.Maze;
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
		public MazeViewBuilder MazeViewBuilder;
		public CharacterSpawner CharacterSpawner;

		private void Start()
		{
			async UniTaskVoid OnStart()
			{
				var maze = await GameBoardManager.OnBuiltMaze;
				
				MazeViewBuilder.BuildView(maze);

				CharacterSpawner.Spawn();
			}

			OnStart().Forget();
		}
	}
}