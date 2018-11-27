using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UniRx;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public class EnemyRoomTriggerSystem : MonoBehaviour
	{
		[SerializeField]
		private CharacterSpawner[] _characterSpawners;

		private void Start()
		{
			var roomView = GetComponent<RoomView>();
			if (roomView == null)
				throw new MissingComponentException("RoomView");

			roomView.OnEnterAsObservable.Subscribe(_ => Spawn());
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