using System;
using System.Threading;
using GamepadInput;
using RogueLike.Chikazawa;
using RogueLike.Katano.Managers;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RogueLike.Katano
{
	/// <summary>
	///     ゲームエントリーマネージャ
	/// </summary>
	public class GameTitleManager : MonoBehaviour
	{
		private CancellationToken _token;
		
		/// <summary>
		/// ゲーム設定
		/// </summary>
		public GameSettings GameSettings;

		/// <summary>
		/// UIマネージャ
		/// </summary>
		public GameTitleUIManager UIManager;
		
		/// <summary>
		/// エントリーシステム
		/// </summary>
		public PlayerEntrySystem EntrySystem;
		private TitleState _state;

		private TitleState State
		{
			get => _state;
			set
			{
				_state = value;
				OnStateChanged(value);
			}
		}

		private void Start()
		{
			_token = this.GetCancellationTokenOnDestroy();
			
			State = TitleState.Title;
		}

		/// <summary>
		/// ステート変更イベント
		/// </summary>
		/// <param name="state"></param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private void OnStateChanged(TitleState state)
		{
			switch (state)
			{
				case TitleState.Title:
				{
					TitleCoroutine().Forget();
					break;
				}
				case TitleState.Entry:
				{
					PlayerEntryCoroutine().Forget();
					break;
				}
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		/// <summary>
		///     タイトル画面
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid TitleCoroutine()
		{
			await UIManager.TitleFadeInAsync(_token);
			
			if (_token.IsCancellationRequested) return;
			
			await UniTask.WaitUntil(
				() => Input.GetKeyDown(KeyCode.Space) || 
				      GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any), 
				cancellationToken: _token);

			if (_token.IsCancellationRequested) return;
			
			Log("Press Button");

			await UIManager.TitleFadeOutAsync(_token);
			
			if (_token.IsCancellationRequested) return;

			Log("Entry Start");

			State = TitleState.Entry;
		}

		/// <summary>
		/// エントリー画面
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid PlayerEntryCoroutine()
		{
			// エントリシステムを初期化
			EntrySystem.Initialize();

			var result = await EntrySystem.EntrySequenceAsync(_token);

			if (_token.IsCancellationRequested) return;

			if (result)
			{
				Debug.Log("Entry Success!");
				
				EntrySystem.Save();
				
				SceneManager.LoadScene(GameSettings.TitleSettings.NextScene.ToString());
			}
			else
			{
				State = TitleState.Title;
			}
		}
		
		private static void Log(string log)
		{
			Debug.Log($"[GameTitleManager] {log}");
		}

		private enum TitleState
		{
			Title,
			Entry
		}

		/// <summary>
		/// タイトルシーン設定
		/// </summary>
		[Serializable]
		public class Settings
		{
			/// <summary>
			/// 次のシーン
			/// </summary>
			public GameScenes NextScene;
		}
	}
}