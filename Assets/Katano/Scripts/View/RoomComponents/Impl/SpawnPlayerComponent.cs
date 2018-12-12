using System;
using System.Collections.Generic;
using System.Linq;
using RogueLike.Chikazawa;
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
	public class SpawnPlayerComponent : RoomComponent
	{
		private GameObject _spawnersParent;
		private CharacterSpawner[] _spawners;
		
		[SerializeField]
		private PlayerBindData _bindData;
		
		[SerializeField]
		private GamePlayers _gamePlayers;
		
		private PlayerBindData _playerBind;

		private void Awake()
		{
			var prefab = Resources.Load<GameObject>("PlayerSpawners");
			_spawnersParent = Instantiate(prefab, transform.position, Quaternion.identity, transform);
			_spawners = _spawnersParent
				.Children()
				.OfComponent<CharacterSpawner>()
				.Where(x => x.gameObject.activeSelf)
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
				
				PlayerSetup(player);
				
				list.Add(player);
			}
			
//			
//			foreach (var spawner in spawners.Children().OfComponent<CharacterSpawner>().Where(x => x.gameObject.activeSelf))
//			{
//				var player = (PlayerCore) spawner.Spawn();
//				
//				PlayerSetup(player);
//				
//				list.Add(player);
//			}

			_gamePlayers.Register(list.ToArray());
		}

		/// <summary>
		/// プレイヤーの初期設定
		/// </summary>
		/// <param name="player"></param>
		private void PlayerSetup(PlayerCore player)
		{
			player.transform.SetParent(transform);
		}
	}
}