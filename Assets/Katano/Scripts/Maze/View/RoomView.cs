using RogueLike.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

namespace RogueLike.Katano.Maze
{
	public class RoomView : MonoBehaviour
	{
		[SerializeField]
		private NavMeshSurface _navMeshSurface;
		
		[SerializeField]
		private BoxCollider _roomBounds;

		private CharacterSpawner[] _characterSpawners;

		private void Awake()
		{
			_characterSpawners = GetComponentsInChildren<CharacterSpawner>();
		}

		public async UniTaskVoid SpawnEnemyAsync()
		{
			var collision = await _roomBounds.OnCollisionEnterAsObservable().ToUniTask();

			
		}
	}
}