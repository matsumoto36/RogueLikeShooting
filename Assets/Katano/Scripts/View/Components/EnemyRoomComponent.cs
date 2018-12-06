using System.Collections.Generic;
using RogueLike.Katano.View.Components;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public class EnemyRoomComponent : RoomComponent
	{
		private IEnumerable<CharacterSpawner> _spawners;

		public override void OnInitialize()
		{
			
		}

		public override void Spawn()
		{
			foreach (var spawner in _spawners)
			{
				spawner.Spawn();
			}
		}
	}
}