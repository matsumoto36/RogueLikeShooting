using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Chikazawa;
using DDD.Chikazawa.InputEventProvider;
using DDD.Katano.Managers;
using DDD.Katano.Model;
using DDD.Katano.View.Player;
using DDD.Matsumoto;
using UniRx;
using Unity.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace DDD.Katano.View.RoomComponents
{
	/// <summary>
	/// プレイヤーを生成するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnPlayerComponent : BaseRoomComponent
	{
		private GameObject _spawnersParent;
		private CharacterSpawner[] _spawners;
		
		/// <summary>
		/// キーバインドデータ
		/// </summary>
		public PlayerBindData BindData;
		
		/// <summary>
		/// ゲームプレイヤー
		/// </summary>
		public GamePlayers GamePlayers;

		private Transform _parent;

		private MainGameManager _mainGameManager;
		
		private void Awake()
		{
			_parent = transform;
			_mainGameManager = FindObjectOfType<MainGameManager>();
			
			
			var prefab = Resources.Load<GameObject>("PlayerSpawners");
			_spawnersParent = Instantiate(prefab, transform);
			_spawners = _spawnersParent
				.Children()
				.OfComponent<CharacterSpawner>()
				.ToArray();
		}
		
		/// <inheritdoc />
		public override void OnInitialize()
		{
			var list = new List<PlayerCore>();

			for (var i = 0; i < BindData.PlayerEntries.Count; i++)
			{
				var entry = BindData.PlayerEntries[i];
				if (entry == ControllerIndex.Invalid)
					break;

				var player = (PlayerCore) _spawners[i].Spawn();
				
				PlayerSetup(player, entry);
				
				list.Add(player);
			}

			GamePlayers.Register(list.ToArray());
		}

		/// <summary>
		/// プレイヤーの初期設定
		/// </summary>
		/// <param name="player"></param>
		/// <param name="index"></param>
		private void PlayerSetup(PlayerCore player, ControllerIndex index)
		{
			player.transform.SetParent(_parent);
			player.gameObject.AddComponent<PlayerStateChanger>();
			player.MainGameManager = _mainGameManager;
			
			switch (index)
			{
				// コントローラー入力
				case ControllerIndex.One:
				case ControllerIndex.Two:
				case ControllerIndex.Three:
				case ControllerIndex.Four:
				{
					player.InputEventProvider = new InputController((int) index.ToGamePadIndex());
					break;
				}
				// キーボード入力
				case ControllerIndex.Keyboard:
				{
					player.InputEventProvider = new InputKeyBoard();
					break;
				}
				default:
					throw new ArgumentOutOfRangeException(nameof(index), index, null);
			}
		}
	}
}