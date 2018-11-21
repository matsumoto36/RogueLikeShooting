using System;
using RogueLike.Matsumoto;
using UniRx;
using UniRx.Async.Triggers;
using UnityEngine;
using UnityEngine.AI;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 部屋のViewオブジェクト
	/// </summary>
	public class RoomView : MonoBehaviour
	{
		private NavMeshSurface _navMeshSurface;
		private RoomTriggerSystem _roomTriggerSystem;
		
		public Room Room { get; private set; }
		
		private readonly Subject<Unit> _onEnterSubject = new Subject<Unit>();
		public IObservable<Unit> OnEnterAsObservable => _onEnterSubject;
		
		private readonly Subject<Unit> _onExitSubject = new Subject<Unit>();
		public IObservable<Unit> OnExitAsObservable => _onExitSubject;

		private void Awake()
		{
			_navMeshSurface = GetComponent<NavMeshSurface>();
			_roomTriggerSystem = GetComponent<RoomTriggerSystem>();
		}

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		public void Construct(Room room)
		{
			Room = room;
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