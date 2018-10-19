using RogueLike.Matsumoto;
using RougeLike.Katano;
using RougeLike.Katano.Maze;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.Serialization;

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
		[FormerlySerializedAs("PlayerCamera")]
		public DebugPlayerCamera DebugPlayerCamera;

		private void Start()
		{
			async UniTaskVoid OnStart()
			{
				var maze = await GameBoardManager.OnBuiltMaze;
				
				MazeViewBuilder.BuildView(maze);

				var character = CharacterSpawner.Spawn();

				DebugPlayerCamera.Target = character.transform;
			}

			OnStart().Forget();
		}
	}
}