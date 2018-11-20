using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public class MazeRoomTriggerSystem : MonoBehaviour
	{
		[SerializeField]
		private CharacterSpawner[] _characterSpawners;

		private void Start()
		{
			var roomView = GetComponent<RoomView>();
			if (roomView == null)
				throw new MissingComponentException("RoomView");
			
			
		}

		public void Spawn()
		{
			foreach (var spawner in _characterSpawners)
			{
				spawner.Spawn();
			}
		}
	}
}