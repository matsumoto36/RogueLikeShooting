using System;
using System.Collections.Generic;
using DDD.Chikazawa;
using DDD.Chikazawa.InputEventProvider;
using DDD.Katano.Managers;
using DDD.Katano.Model;
using DDD.Katano.View.Player;
using DDD.Matsumoto;
using UnityEngine;
using Zenject;

namespace DDD.Katano.View.RoomComponents
{
	/// <summary>
	///     プレイヤーを生成するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public class PlayerRoomComponent : BaseRoomComponent
	{
		/// <summary>
		///     キーバインドデータ
		/// </summary>
		[Inject]
		private PlayerBindData _bindData;

		/// <summary>
		///     ゲームプレイヤー
		/// </summary>
		[Inject]
		private GamePlayers _gamePlayers;

		[Inject]
		private MainGameManager _mainGameManager;

		[Inject]
		private GameObject _playerSpawnerPrefab;

		[Inject]
		private PlayerSpawnerFactory _spawnerFactory;

		private Transform _transformCache;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			_transformCache = transform;

			var spawners = _spawnerFactory.Create(_transformCache);

			var list = new List<PlayerCore>();

			for (var i = 0; i < _bindData.PlayerEntries.Count; i++)
			{
				var entry = _bindData.PlayerEntries[i];
				if (entry == ControllerIndex.Invalid)
					break;

				var player = (PlayerCore) spawners[i].Spawn();

				PlayerSetup(player, entry);

				list.Add(player);
			}

			_gamePlayers.Register(list.ToArray());
		}

		/// <summary>
		///     プレイヤーの初期設定
		/// </summary>
		/// <param name="player"></param>
		/// <param name="index"></param>
		private void PlayerSetup(PlayerCore player, ControllerIndex index)
		{
			player.transform.SetParent(_transformCache);
			player.gameObject.AddComponent<PlayerStateChanger>();

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

	public class PlayerSpawnerFactory
	{
		private DiContainer _container;
		private GameObject _playerSpawner;

		[Inject]
		private void Construct(GameObject playerSpawner, DiContainer container)
		{
			_playerSpawner = playerSpawner;
			_container = container;
		}

		public CharacterSpawner[] Create(Transform parent)
		{
			return _container.InstantiatePrefab(_playerSpawner, parent).GetComponentsInChildren<CharacterSpawner>();
		}
	}
}