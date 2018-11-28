using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public class EnemyRoomTriggerSystem : RoomTriggerSystem
	{
		private IEnumerable<CharacterSpawner> _spawners;

		private void Start()
		{
			var roomView = GetComponent<RoomView>();
			if (roomView == null)
				throw new MissingComponentException("RoomView");
		}

		public override void Construct(IEnumerable<CharacterSpawner> spawners)
		{
			_spawners = spawners;
		}

		public override void Initialize()
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