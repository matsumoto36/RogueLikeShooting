using System;
using DDD.Katano.Model;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Zenject;

namespace DDD.Katano.Managers
{
	/// <summary>
	/// ゲームシーンマネージャ
	/// </summary>
	public class MainGameManager : MonoBehaviour
	{
		private const int Roof = 10;

		[Inject]
		private Settings _settings;

		[Inject]
		private IMessagePublisher _messagePublisher;

		[Inject]
		private IMessageReceiver _messageReceiver;
		
		
		[Inject]
		private GameResultData _resultData;
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
			FloorManager.Initialize();
			UIManager.Initialize();

			SetEvents();
		}

		/// <summary>
		/// イベントを購読する
		/// </summary>
		private void SetEvents()
		{
			// フロア踏破イベントの購読
			_messageReceiver
				.Receive<MazeSignal.FloorEnded>()
				.Subscribe(_ => GameFinalizeCoroutine().Forget())
				.AddTo(this);

			// プレイヤー全滅時イベントの購読
			_messageReceiver
				.Receive<MazeSignal.PlayerKilled>()
				.Subscribe(_ => GameOverCoroutine().Forget())
				.AddTo(this);

			_messageReceiver
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
			await UIManager.FadeOutAsync();
			
			FloorManager.Destruct();

			_resultData.ReachedFloor = Roof;
			_resultData.IsClear = true;
		
			SceneManager.LoadScene(_settings.NextScene.ToString());
		}

		/// <summary>
		/// ゲームオーバーコルーチン
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid GameOverCoroutine()
		{
			await UIManager.GameOverFadeOutAsync();
			
			FloorManager.Destruct();

			_resultData.ReachedFloor = _currentFloor;
			_resultData.IsClear = false;

			SceneManager.LoadScene(_settings.NextScene.ToString());
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
			_messagePublisher.Publish(new MazeSignal.FloorStarted());
		}

		/// <summary>
		/// フロアを終了する
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid GameFinalizeCoroutine()
		{
			// フロア数がクリア階層以上になったら
			if (_currentFloor == Roof)
			{
				// ゲームクリア
				_messagePublisher.Publish(new MazeSignal.MazeCleared());
				
				return;
			}
			
			// フェードアウトする
			await UIManager.FadeOutAsync();
			
			_messagePublisher.Publish(new MazeSignal.FloorDestruct());
			
			// フロアを破壊
			FloorManager.Destruct();
			
			// フロアを準備する
			GamePrepareCoroutine().Forget();
		}
		
		/// <summary>
		/// フロア終了
		/// </summary>
		public void FloorEnded()
		{
			Log("FloorEnd signal published!");
			
			_messagePublisher.Publish(new MazeSignal.FloorEnded());
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