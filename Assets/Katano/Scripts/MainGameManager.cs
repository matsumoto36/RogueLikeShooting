using RogueLike.Katano.Maze;
using UniRx;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano
{
	/// <summary>
	/// ゲームシーンマネージャ
	/// </summary>
	public class MainGameManager : MonoBehaviour
	{
		public GameFloorManager FloorManager;
		public GameUIManager UIManager;
		
		/// <summary>
		/// 初期化
		/// </summary>
		private void Start()
		{
			FloorManager.Initialize();
			UIManager.Initialize();

			// フロア踏破イベントの購読
			MessageBroker.Default
				.Receive<MazeSignal.FloorEnded>()
				.Subscribe(_ =>
				{
					OnFloorEnded().Forget();
				});
			
			// フロアを準備する
			PreparingMaze().Forget();
		}

		/// <summary>
		/// フロアを準備する
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid PreparingMaze()
		{
			// フロアを構築
			FloorManager.Construct();

			// フェードインする
			await UIManager.FadeInAsync();
			
			// ゲームスタート
			MessageBroker.Default.Publish(new MazeSignal.FloorStarted());
		}

		/// <summary>
		/// フロア踏破時イベント
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid OnFloorEnded()
		{
			// フェードアウトする
			await UIManager.FadeOutAsync();
			
			// フロアを破壊
			FloorManager.Destruct();
			
			// フロアを準備する
			PreparingMaze().Forget();
		}

		public void FloorEnded()
		{
			Log("FloorEnd signal published!");
			
			MessageBroker.Default.Publish(new MazeSignal.FloorEnded());
		}

		private static void Log(string log)
		{
			Debug.Log($"[MainGameManager] {log}");
		}
	}
}