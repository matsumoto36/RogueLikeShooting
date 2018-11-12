using RogueLike.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 部屋のViewオブジェクト
	/// </summary>
	public class RoomView : MonoBehaviour
	{
		[SerializeField]
		private NavMeshSurface _navMeshSurface;
		
		[SerializeField]
		private BoxCollider _roomBounds;

		private CharacterSpawner[] _characterSpawners;
		
		public Room Room { get; private set; }

		private void Awake()
		{
			_characterSpawners = GetComponentsInChildren<CharacterSpawner>();
		}

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		public void Construct(Room room)
		{
			Room = room;
		}
		
		public async UniTaskVoid SpawnEnemyAsync()
		{
			var collision = await _roomBounds.OnCollisionEnterAsObservable().ToUniTask();

			
		}
	}
}