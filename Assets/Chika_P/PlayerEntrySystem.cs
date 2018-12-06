using System;
using System.Collections.Generic;
using System.Linq;
using GamepadInput;
using RogueLike.Katano;
using UniRx;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Chikazawa
{
    /// <summary>
    ///     エントリーシステム
    /// </summary>
    public class PlayerEntrySystem : MonoBehaviour
	{
	    /// <summary>
	    ///     プレイヤーバインドデータ
	    /// </summary>
	    [SerializeField]
		private PlayerBindData _bindData;

		[SerializeField]
		private List<GameObject> _playerObjects; //スポーン（エントリー）したときのオブジェクト
		
		private readonly List<ControllerIndex> _controllerIndices = new List<ControllerIndex>(new ControllerIndex[4]);

		// public int[] ControllerList = new int[4]; //参加人数と使用コントローラーの状況
		
	    /// <summary>
	    ///     初期化
	    /// </summary>
	    public void Initialize()
		{
			for (var i = 0; i < _controllerIndices.Count; i++) _controllerIndices[i] = ControllerIndex.Invalid;
		}

		public async UniTask<bool> PlayerEntryAsync()
		{
			while (true)
			{
				OnInputKeyboard();
				OnInputGamepad();

				if (_controllerIndices[0] != ControllerIndex.Invalid)
				{
					var index = _controllerIndices[0];
					
					switch (index)
					{
						case ControllerIndex.One:
						case ControllerIndex.Two:
						case ControllerIndex.Three:
						case ControllerIndex.Four:
						{
							if (GamePad.GetButtonDown(GamePad.Button.Start, index.ToGamePadIndex()))
								return true;
							break;
						}
						case ControllerIndex.Keyboard:
							if (Input.GetKeyDown(KeyCode.Return))
								return true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				else
				{
					if (GamePad.GetButtonDown(GamePad.Button.Back, GamePad.Index.Any) 
					    || Input.GetKeyDown(KeyCode.Escape))
						return false;
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

					_playerObjects[slot].SetActive(true);
				}
			}

			//Deleteで退出
			if (Input.GetKeyDown(KeyCode.Delete) && _controllerIndices.Contains(ControllerIndex.Keyboard))
			{
				var slot = _controllerIndices.IndexOf(ControllerIndex.Keyboard);
				
				//プレイヤー操作リストから探し出して
				_controllerIndices[slot] = ControllerIndex.Invalid;
				
				//操作オブジェクトを非表示
				_playerObjects[slot].SetActive(false);
				
			}
		}

		private static readonly GamePad.Index[] PadIndices =
			Enum.GetValues(typeof(GamePad.Index))
				.OfType<GamePad.Index>()
				.Skip(1)
				.ToArray();

		private void OnInputGamepad()
		{
			foreach (var padIndex in PadIndices)
			{
				//スタートボタンでエントリー
				if (GamePad.GetButtonDown(GamePad.Button.Start, padIndex) && !_controllerIndices.Contains(padIndex.ToControllerIndex()))
				{
					if (_controllerIndices.Any(x => x == ControllerIndex.Invalid))
					{
						var slot = _controllerIndices.IndexOf(ControllerIndex.Invalid);
					
						_controllerIndices[slot] = padIndex.ToControllerIndex();

						_playerObjects[slot].SetActive(true);
					}
				}

				//セレクト(Back)で退出
				if (GamePad.GetButtonDown(GamePad.Button.Back, padIndex) && _controllerIndices.Contains(padIndex.ToControllerIndex()))
				{
					var slot = _controllerIndices.IndexOf(padIndex.ToControllerIndex());
				
					//プレイヤー操作リストから探し出して
					_controllerIndices[slot] = ControllerIndex.Invalid;
				
					//操作オブジェクトを非表示
					_playerObjects[slot].SetActive(false);
				}
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
			for (var i = 0; i < 4; i++) _bindData.PlayerEntries[i] = _controllerIndices[i];
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