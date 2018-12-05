using System;
using GamepadInput;
using RogueLike.Chikazawa;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

namespace RogueLike.Katano
{
	/// <summary>
	/// ゲームエントリーマネージャ
	/// </summary>
	public class GameEntriesManager : MonoBehaviour
	{
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
		
		private PlayerEntrySystem _entrySystem;

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
					break;
				}
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private async UniTaskVoid OnTitle()
		{
			await UniTask.WaitUntil(() => GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any));
		}

		private enum TitleState
		{
			Title,
			Entry,
		}
	}
}