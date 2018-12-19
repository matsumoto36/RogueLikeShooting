using System;
using RogueLike.Katano.Model;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace RogueLike.Katano.Managers
{
	/// <summary>
	/// ゲームシーンマネージャ
	/// </summary>
	public class MainGameManager : MonoBehaviour
	{
		
		
		private readonly MessageBroker _mainEventBroker = new MessageBroker();

		/// <summary>
		/// メインイベントブローカー
		/// </summary>
		public IMessageBroker MainEventBroker => _mainEventBroker;
		
		[FormerlySerializedAs("_resultData")]
		public GameResultData ResultData;
		[FormerlySerializedAs("_gameSettings")]
		public GameSettings GameSettings;
		public GameFloorManager FloorManager;
		public GameUIManager UIManager;

		private int _currentFloor;
		
		private void Start()
		{
			// 初期化する
			Initialize();
			
			// フロアを準備する
			GamePrepareCoroutine().Forget();
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
			_mainEventBroker
				.Receive<MazeSignal.FloorEnded>()
				.Subscribe(_ => GameFinalizeCoroutine().Forget())
				.AddTo(this);

			// プレイヤー全滅時イベントの購読
			_mainEventBroker
				.Receive<MazeSignal.PlayerKilled>()
				.Subscribe(_ => GameOverCoroutine().Forget())
				.AddTo(this);

			_mainEventBroker
				.Receive<MazeSignal.MazeCleared>()
				.Subscribe(_ => GameClearCoroutine().Forget())
				.AddTo(this);
		}

		/// <summary>
		/// ゲームクリアコルーチン
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid GameClearCoroutine()
		{
			ResultData.Score = 100;
			ResultData.ClearTime = 100;
		
			SceneManager.LoadScene(GameSettings.MainGameSettings.NextScene.ToString());
		}

		/// <summary>
		/// ゲームオーバーコルーチン
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid GameOverCoroutine()
		{
			await UIManager.GameOverFadeOutAsync();
			
			FloorManager.Destruct();

			SceneManager.LoadScene(GameSettings.MainGameSettings.NextScene.ToString());
		}

		/// <summary>
		/// フロアを準備する
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid GamePrepareCoroutine()
		{
			
			
			// フロア数を増やす
			++_currentFloor;
			
			// フロアを構築
			FloorManager.Construct();

			
			
			// フェードインする
			await UIManager.FadeInAsync(_currentFloor);
			
			// ゲームスタート
			_mainEventBroker.Publish(new MazeSignal.FloorStarted());
		}

		/// <summary>
		/// フロアを終了する
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid GameFinalizeCoroutine()
		{
			const int roof = 10;

			// フロア数がクリア階層以上になったら
			if (_currentFloor == roof)
			{
				// ゲームクリア
				_mainEventBroker.Publish(new MazeSignal.MazeCleared());
				
				return;
			}
			
			// フェードアウトする
			await UIManager.FadeOutAsync();
			
			// フロアを破壊
			FloorManager.Destruct();
			
			// フロアを準備する
			GamePrepareCoroutine().Forget();
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