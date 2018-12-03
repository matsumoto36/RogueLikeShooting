using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Katano.View;
using RogueLike.Katano.View.Components;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public class EnemyRoomComponent : RoomComponent
	{
		private IEnumerable<CharacterSpawner> _spawners;

		private void Start()
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