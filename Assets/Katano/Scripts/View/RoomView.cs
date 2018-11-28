using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using Unity.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace RogueLike.Katano.View
{
	/// <summary>
	/// 部屋のViewオブジェクト
	/// </summary>
	public class RoomView : MonoBehaviour
	{
		public IEnumerable<CharacterSpawner> CharacterSpawners { get; private set; }

		[SerializeField]
		private NavMeshSurface _navMeshSurface;
		
		[FormerlySerializedAs("_roomTriggerSystem")]
		[SerializeField]
		private RoomComponent _roomComponent;
		
		public Room Room { get; private set; }

		private void Awake()
		{
			CharacterSpawners = gameObject.Children().OfComponent<CharacterSpawner>();
		}

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		public void Construct(Room room)
		{
			
			
			Room = room;
			_roomComponent.Construct(spawners);
		}

		public void Initialize()
		{
			_roomComponent.Initialize();
		}

		public void Enter()
		{
			_roomComponent.Spawn();
		}
	
		public void Exit()
		{
			
		}
	}
}