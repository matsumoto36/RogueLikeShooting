using System;
using RogueLike.Katano.Model;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RogueLike.Katano.Managers
{
	/// <summary>
	/// ゲームシーンマネージャ
	/// </summary>
	public class MainGameManager : MonoBehaviour
	{
		[SerializeField]
		private GameResultData _resultData;
		
		[SerializeField]
		private GameSettings _gameSettings;
		
		private readonly MessageBroker _mainEventBroker = new MessageBroker();

		public IMessageBroker MainEventBroker => _mainEventBroker;
		
		public GameFloorManager FloorManager;
		public GameUIManager UIManager;

		private int _currentFloor;
		
		private void Start()
		{
			// 初期化する
			Initialize();
			
			// フロアを準備する
			PreparingMaze().Forget();
		}

		/// <summary>
		/// 初期化
		/// </summary>
		private void Initialize()
		{
			FloorManager.Initialize(_mainEventBroker);
			UIManager.Initialize(_mainEventBroker);

			SetEvents();
		}

		/// <summary>
		/// イベントを購読する
		/// </summary>
		private void SetEvents()
		{
			// フロア踏破イベントの購読
			_mainEventBroker.Receive<MazeSignal.FloorEnded>().Subscribe(_ => OnFloorEnded().Forget()).AddTo(this);

			_mainEventBroker.Receive<MazeSignal.PlayerKilled>().Subscribe(_ => EndGame().Forget()).AddTo(this);
		}

		private async UniTaskVoid EndGame()
		{
			await UIManager.FadeOutAsync();
			
			FloorManager.Destruct();

			SceneManager.LoadScene(_gameSettings.MainGameSettings.NextScene.ToString());
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
			await UIManager.FadeInAsync(++_currentFloor);
			
			// ゲームスタート
			_mainEventBroker.Publish(new MazeSignal.FloorStarted());
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
			
			_mainEventBroker.Publish(new MazeSignal.FloorEnded());
		}

		private static void Log(string log)
		{
			Debug.Log($"[MainGameManager] {log}");
		}

		[Serializable]
		public class Settings
		{
			public GameScenes NextScene;
		}
	}
}