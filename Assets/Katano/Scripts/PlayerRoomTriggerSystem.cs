using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano
{
	
	public class PlayerRoomTriggerSystem : RoomTriggerSystem
	{
		private IEnumerable<CharacterSpawner> _spawners;

		private void Awake()
		{
			var roomView = GetComponent<RoomView>();
			if (roomView == null)
				throw new MissingComponentException("RoomView");
		}

		public override void Construct(IEnumerable<CharacterSpawner> spawners)
		{
			_spawners = spawners;
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