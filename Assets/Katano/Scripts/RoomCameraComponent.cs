using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public class RoomCameraComponent : MonoBehaviour
	{
		private RoomView _roomView;
		
		private void Awake()
		{
			_roomView = GetComponent<RoomView>();
			if (!_roomView)
				throw new MissingComponentException(nameof(RoomView));
		}

		private void OnPlayerEnter()
		{
			var players = GetComponentInChildren<PlayerCore>();
			
			// TODO: PlayerOverlookCamera will include
		}
	}
}