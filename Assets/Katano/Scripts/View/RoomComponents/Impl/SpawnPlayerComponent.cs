using System;
using System.Collections.Generic;
using System.Linq;
using RogueLike.Chikazawa;
using RogueLike.Katano.Model;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	/// <summary>
	/// プレイヤーを生成するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnPlayerComponent : RoomComponent
	{
		[SerializeField]
		private GamePlayers _gamePlayers;
		
		[SerializeField]
		private List<CharacterSpawner> _spawners = new List<CharacterSpawner>(4);
		
		private PlayerBindData _playerBind;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			var list = new List<PlayerCore>();
			foreach (var spawner in _spawners)
			{
				var player = (PlayerCore) spawner.Spawn();
				
				PlayerSetup(player);
				
				list.Add(player);
			}

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