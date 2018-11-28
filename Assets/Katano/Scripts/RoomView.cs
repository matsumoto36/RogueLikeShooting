using System;
using RogueLike.Matsumoto;
using UniRx;
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
		private RoomTriggerSystem _roomTriggerSystem;
		
		public Room Room { get; private set; }

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		public void Construct(Room room)
		{
			var spawners = GetComponentsInChildren<CharacterSpawner>();
			
			Room = room;
			_roomTriggerSystem.Construct(spawners);
		}

		public void Initialize()
		{
			_roomTriggerSystem.Initialize();
		}

		public void Enter()
		{
			_roomTriggerSystem.Spawn();
		}
	
		public void Exit()
		{
			
		}
	}
}