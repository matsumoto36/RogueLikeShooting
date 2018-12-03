using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Katano.View;
using RogueLike.Katano.View.Components;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano
{
	
	public class PlayerRoomComponent : RoomComponent
	{
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
			foreach (var spawner in _spawners)
			{
				spawner.Spawn().transform.SetParent(transform);
			}
		}
	}
}