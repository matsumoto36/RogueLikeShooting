using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Katano.View;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano
{
	public class RoomCameraComponent : RoomComponent
	{
		private RoomView _roomView;
		
		private void Awake()
		{
			_roomView = GetComponent<RoomView>();
			if (!_roomView)
				throw new MissingComponentException(nameof(RoomView));
		}
		
		public override void Construct(IEnumerable<CharacterSpawner> spawners)
		{
			throw new System.NotImplementedException();
		}

		private void OnPlayerEnter()
		{
			var players = GetComponentInChildren<PlayerCore>();
			
			// TODO: PlayerOverlookCamera will include
		}

		
	}
}