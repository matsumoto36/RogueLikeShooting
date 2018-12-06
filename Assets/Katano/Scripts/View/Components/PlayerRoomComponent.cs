using System.Collections.Generic;
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

		
		private void Awake()
		{
			var roomView = GetComponent<RoomView>();
			if (roomView == null)
				throw new MissingComponentException("RoomView");
		}

		public override void OnInitialize()
		{
			
		}

		public override void Initialize()
		{
			var list = new List<CharacterCore>();
			foreach (var spawner in _spawners)
			{
				var player = spawner.Spawn();
				player.transform.SetParent(transform);
				
				list.Add(player);
			}

			_gamePlayers.Register(list.ToArray());
		}
	}
}