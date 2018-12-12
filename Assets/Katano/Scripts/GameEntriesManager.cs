using System;
using GamepadInput;
using RogueLike.Chikazawa;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

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
				OnStateChanged(value);
			}
		}

		private void Start()
		{
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
					OnTitleState().Forget();
					break;
				}
				case TitleState.Entry:
				{
					OnEntryState().Forget();
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
		private async UniTaskVoid OnTitleState()
		{
			await UniTask.WaitUntil(() =>
				GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any) || Input.GetKeyDown(KeyCode.Space));
			Debug.Log("Trans");

			await UniTask.Delay(200);

			Debug.Log("Entry");

			State = TitleState.Entry;
		}

		/// <summary>
		/// エントリー画面
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid OnEntryState()
		{
			// エントリシステムを初期化
			_entrySystem.Initialize();

			var result = await _entrySystem.EntrySequenceAsync();

			if (result)
			{
				Debug.Log("Entry Success!");
				
				_entrySystem.Save();
				
				SceneManager.LoadScene("GameFlowSample");
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