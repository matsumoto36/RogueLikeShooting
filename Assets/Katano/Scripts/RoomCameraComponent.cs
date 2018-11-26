using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UniRx;
using UniRx.Async;
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

			_roomView.OnEnterAsObservable
				.Take(1)
				.Subscribe(_ => OnPlayerEnter().Forget())
				.AddTo(this);
		}

		private async UniTaskVoid OnPlayerEnter()
		{
			var players = GetComponentInChildren<PlayerCore>();
			
			// TODO: PlayerOverlookCamera will include
		}
	}
}