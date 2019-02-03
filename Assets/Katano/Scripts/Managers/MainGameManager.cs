using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using DDD.Katano.Installers;
using DDD.Katano.Model;
using DDD.Matsumoto.Audio;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Debug = UnityEngine.Debug;

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
		private FloorSettings _floorSettings;
		
		[Inject]
		private IMessagePublisher _messagePublisher;

		[Inject]
		private IMessageReceiver _messageReceiver;
		
		[Inject]
		private GameResultData _resultData;
		public FloorManager FloorManager;
		public GameUIManager UIManager;

		private int _currentFloor;

		private void Start()
		{
			SetEvents();
			
			// フロアを準備する
			GamePrepareCoroutine().Forget();
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
			AudioManager.FadeOut(0.5f);
			
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
			AudioManager.FadeOut(0.5f);
			
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

			var settings = _floorSettings.FloorEntries.FirstOrDefault(x => x.Floor == _currentFloor).MazeSettings;
			
			// フロアを構築
			FloorManager.Construct(settings);
			
			_messagePublisher.Publish(new MazeSignal.FloorConstruct(_currentFloor));

			var advBgmName = _currentFloor > 5 ? "bgm_maoudamashii_cyber39" : "bgm_maoudamashii_cyber18";
			
			if (AudioManager.IsPlayingBGM())
			{
				AudioManager.CrossFade(0.5f, advBgmName);
			}
			else
			{
				AudioManager.FadeIn(0.5f, advBgmName);
			}
			
			
			// フェードインする
			await UIManager.FadeInAsync(settings.DungeonName, _currentFloor);
			
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
		private void FloorEnded()
		{
			Log("FloorEnd signal published!");
			
			_messagePublisher.Publish(new MazeSignal.FloorEnded());
		}

		[Conditional("UNITY_EDITOR")]
		private static void Log(string log)
		{
			Debug.Log($"[MainGameManager] {log}");
		}

		[Serializable]
		public class FloorSettings
		{
			public FloorEntry[] FloorEntries;
			
			[Serializable]
			public struct FloorEntry
			{
				public int Floor;
				public MazeSettings MazeSettings;
			}
		}
		
		[Serializable]
		public class Settings
		{
			public GameScenes NextScene;
		}
	}
}