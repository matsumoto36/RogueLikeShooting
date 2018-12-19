using System;
using System.Collections.Generic;
using System.Linq;
using RogueLike.Chikazawa;
using RogueLike.Chikazawa.InputEventProvider;
using RogueLike.Katano.Model;
using RogueLike.Katano.View.Player;
using RogueLike.Matsumoto;
using UniRx;
using Unity.Linq;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	/// <summary>
	/// プレイヤーを生成するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnPlayerComponent : BaseRoomComponent
	{
		private GameObject _spawnersParent;
		private CharacterSpawner[] _spawners;
		
		[SerializeField]
		private PlayerBindData _bindData;
		
		[SerializeField]
		private GamePlayers _gamePlayers;

		private void Awake()
		{
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

			for (var i = 0; i < _bindData.PlayerEntries.Count; i++)
			{
				var entry = _bindData.PlayerEntries[i];
				if (entry == ControllerIndex.Invalid)
					break;

				var player = (PlayerCore) _spawners[i].Spawn();
				player.gameObject.AddComponent<PlayerStateChanger>();
				
				PlayerSetup(player, entry);
				
				list.Add(player);
			}

			_gamePlayers.Register(list.ToArray());
		}

		/// <summary>
		/// プレイヤーの初期設定
		/// </summary>
		/// <param name="player"></param>
		/// <param name="index"></param>
		private void PlayerSetup(PlayerCore player, ControllerIndex index)
		{
			switch (index)
			{
				case ControllerIndex.One:
				case ControllerIndex.Two:
				case ControllerIndex.Three:
				case ControllerIndex.Four:
				{
					player.InputEventProvider = new InputController((int) index.ToGamePadIndex());
					break;
				}
				case ControllerIndex.Keyboard:
				{
					player.InputEventProvider = new InputKeyBoard();
					break;
				}
				default:
					throw new ArgumentOutOfRangeException(nameof(index), index, null);
			}
			player.transform.SetParent(transform);
		}
	}
}