using System.Collections.Generic;
using System.Linq;
using RogueLike.Chikazawa;
using RogueLike.Katano.Model;
using RogueLike.Katano.View;
using RogueLike.Katano.View.Components;
using RogueLike.Matsumoto;
using RogueLike.Matsumoto.Character;
using UnityEngine;

namespace RogueLike.Katano
{
	
	public class PlayerRoomComponent : RoomComponent
	{
		private PlayerBindData _playerBind;
		private GamePlayers _gamePlayers;

		
		private IEnumerable<CharacterSpawner> _spawners;


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

			_gamePlayers.Register(list.Cast<PlayerCore>().ToArray());
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