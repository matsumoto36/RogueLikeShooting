using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using DDD.Takahashi;
using GamepadInput;
using DDD.Katano;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.Serialization;

namespace DDD.Chikazawa
{
    /// <summary>
    ///     エントリーシステム
    /// </summary>
    public class PlayerEntrySystem : MonoBehaviour
	{
	    /// <summary>
	    ///     プレイヤーバインドデータ
	    /// </summary>
		public PlayerBindData BindData;

		/// <summary>
		/// プレイヤーオブジェクトリスト
		/// </summary>
		public List<GameObject> PlayerObjects; //スポーン（エントリー）したときのオブジェクト
		
		private readonly List<ControllerIndex> _controllerIndices = new List<ControllerIndex>(new ControllerIndex[4]);

		// public int[] ControllerList = new int[4]; //参加人数と使用コントローラーの状況
		
	    /// <summary>
	    ///     初期化
	    /// </summary>
	    public void Initialize()
		{
			for (var i = 0; i < _controllerIndices.Count; i++) _controllerIndices[i] = ControllerIndex.Invalid;
		}

		/// <summary>
		/// プレイヤーエントリー処理
		/// </summary>
		/// <returns></returns>
		/// <exception cref="InvalidEnumArgumentException"></exception>
		public async UniTask<bool> EntrySequenceAsync(CancellationToken token = default)
		{
			while (true)
			{
				if (token.IsCancellationRequested) return false;
				
				OnInputKeyboard();
				OnInputGamePad();

				var index = _controllerIndices[0];
				switch (index)
				{
					// 各コントローラー
					case ControllerIndex.One:
					case ControllerIndex.Two:
					case ControllerIndex.Three:
					case ControllerIndex.Four:
					{
						// スタートボタンで開始
						if (GamePad.GetButtonDown(GamePad.Button.Start, index.ToGamePadIndex()))
							return true;
						break;
					}

					// キーボード
					case ControllerIndex.Keyboard:
					{
						// Enterキーで開始
						if (Input.GetKeyDown(KeyCode.Return))
							return true;
						break;
					}
					
					// 未エントリー
					case ControllerIndex.Invalid:
					{
						// 戻るボタンで戻る
						var isCancelled = Input.GetKeyDown(KeyCode.Escape) || GamePad.GetButtonDown(GamePad.Button.Back, GamePad.Index.Any);
						if (isCancelled) return false;
						
						break;
					}

					default:
						throw new InvalidEnumArgumentException();
				}

				await UniTask.Yield();
			}
		}

	    /// <summary>
	    ///     キーボードからの入力
	    /// </summary>
	    private void OnInputKeyboard()
		{
			//キーボード
			//スペースキーでエントリー
			if (Input.GetKeyDown(KeyCode.Space) && !_controllerIndices.Contains(ControllerIndex.Keyboard))
			{
				if (_controllerIndices.Any(x => x == ControllerIndex.Invalid))
				{
					var slot = _controllerIndices.IndexOf(ControllerIndex.Invalid);
					
					_controllerIndices[slot] = ControllerIndex.Keyboard;

					SetActive(slot, true);
				}
			}

			//Deleteで退出
			if (Input.GetKeyDown(KeyCode.Delete) && _controllerIndices.Contains(ControllerIndex.Keyboard))
			{
				var slot = _controllerIndices.IndexOf(ControllerIndex.Keyboard);
				
				//プレイヤー操作リストから探し出して
				_controllerIndices[slot] = ControllerIndex.Invalid;
				
				//操作オブジェクトを非表示
				SetActive(slot, false);
				
			}
		}

		private static readonly GamePad.Index[] PadIndices =
			Enum.GetValues(typeof(GamePad.Index))
				.OfType<GamePad.Index>()
				.Skip(1)
				.ToArray();

		private void OnInputGamePad()
		{
			foreach (var padIndex in PadIndices)
			{
				//スタートボタンでエントリー
				if (GamePad.GetButtonDown(GamePad.Button.A, padIndex) && !_controllerIndices.Contains(padIndex.ToControllerIndex()))
				{
					if (_controllerIndices.Any(x => x == ControllerIndex.Invalid))
					{
						var slot = _controllerIndices.IndexOf(ControllerIndex.Invalid);
					
						_controllerIndices[slot] = padIndex.ToControllerIndex();

						SetActive(slot, true);
					}
				}

				//セレクト(Back)で退出
				if (GamePad.GetButtonDown(GamePad.Button.B, padIndex) && _controllerIndices.Contains(padIndex.ToControllerIndex()))
				{
					var slot = _controllerIndices.IndexOf(padIndex.ToControllerIndex());
				
					//プレイヤー操作リストから探し出して
					_controllerIndices[slot] = ControllerIndex.Invalid;
				
					//操作オブジェクトを非表示
					SetActive(slot, false);
				}
			}
		}

		public void SetActive(int slot, bool isActive)
		{
			if (isActive)
			{
				PlayerObjects[slot].GetComponentInChildren<DissolveShaderControl>().Show();
			}
			else
			{
				PlayerObjects[slot].GetComponentInChildren<DissolveShaderControl>().Hide();
			}
		}

//		private bool IsEntry(int Controller)
//		{
//			//リスト内に入力コントローラーがあるか確認
//			foreach (var item in ControllerList)
//				if (item == Controller)
//					return true;
//			return false;
//		}

	    /// <summary>
	    ///     エントリーデータを保存
	    /// </summary>
	    public void Save()
		{
			for (var i = 0; i < 4; i++) BindData.PlayerEntries[i] = _controllerIndices[i];
		}
	}

	public enum ControllerIndex
	{
		Invalid = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Keyboard = 5
	}
}