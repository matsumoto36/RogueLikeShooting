using System;
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
		private BoxCollider _roomBounds;

		[SerializeField]
		private PlayerRoomTriggerSystem _roomTriggerSystem;
		
		public Room Room { get; private set; }
		
		private readonly Subject<Unit> _onEnterSubject = new Subject<Unit>();
		public IObservable<Unit> OnEnterAsObservable => _onEnterSubject;
		
		private readonly Subject<Unit> _onExitSubject = new Subject<Unit>();
		public IObservable<Unit> OnExitAsObservable => _onExitSubject;

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
			_onExitSubject.OnNext(Unit.Default);
		}
	}
}