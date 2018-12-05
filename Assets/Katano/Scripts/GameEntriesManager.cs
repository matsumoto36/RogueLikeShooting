using System;
using GamepadInput;
using RogueLike.Chikazawa;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano
{
	/// <summary>
	///     ゲームエントリーマネージャ
	/// </summary>
	public class GameEntriesManager : MonoBehaviour
	{
		[SerializeField]
		private PlayerEntrySystem _entrySystem;
		private TitleState _state;

		private TitleState State
		{
			get => _state;
			set
			{
				_state = value;
				OnStateChanged();
			}
		}

		private void Start()
		{
			State = TitleState.Title;
		}

		private void OnStateChanged()
		{
			switch (State)
			{
				case TitleState.Title:
				{
					OnTitle().Forget();
					break;
				}
				case TitleState.Entry:
				{
					OnPlayerEntry().Forget();
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
		private async UniTaskVoid OnTitle()
		{
			await UniTask.WaitUntil(() =>
				GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any) || Input.GetKeyDown(KeyCode.Space));
			Debug.Log("Trans");

			await UniTask.Delay(200);

			Debug.Log("Entry");

			State = TitleState.Entry;
		}

		private async UniTaskVoid OnPlayerEntry()
		{
			// エントリシステムを初期化
			_entrySystem.Initialize();

			var result = await _entrySystem.PlayerEntryAsync();

			if (result)
			{
				Debug.Log("Entry Success!");
				_entrySystem.Save();
				// SceneManager.LoadScene("GamaeScene");
			}
			else
			{
				State = TitleState.Title;
			}
		}

		private enum TitleState
		{
			Title,
			Entry
		}
	}
}