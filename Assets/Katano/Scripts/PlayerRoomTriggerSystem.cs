using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public class PlayerRoomTriggerSystem : MonoBehaviour
	{
		[SerializeField]
		private CharacterSpawner[] _playerSpawners;

		private void Awake()
		{
			var roomView = GetComponent<RoomView>();
			if (roomView == null)
				throw new MissingComponentException("RoomView");
		}

		public void Spawn()
		{
			foreach (var spawner in _playerSpawners)
			{
				spawner.Spawn();
			}
		}
	}
}