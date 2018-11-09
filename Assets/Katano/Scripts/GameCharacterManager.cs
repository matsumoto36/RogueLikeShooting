using RogueLike.Katano.Maze;
using RogueLike.Katano.Maze.View;
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
		
		private void Start()
		{
			async UniTaskVoid OnStart()
			{
				var maze = await GameBoardManager.OnBuiltMaze;
				
				
				
				//CharacterSpawner.Spawn((SpawnDataAsset)null);
			}

			// OnStart().Forget();
		}

		/// <summary>
		/// プレイヤーのスポーン場所を選定する
		/// </summary>
		/// <param name="view"></param>
		private void ChoosePlayerSpawnPoint(MazeView view)
		{
			
		}
	}
}