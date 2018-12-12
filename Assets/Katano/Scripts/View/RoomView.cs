using System;
using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Matsumoto;
using UniRx;
using Unity.Linq;
using UnityEngine;
using UnityEngine.AI;
// ReSharper disable NotAccessedField.Local

namespace RogueLike.Katano.View
{
	/// <summary>
	/// 部屋のViewオブジェクト
	/// </summary>
	[SelectionBase]
	public class RoomView : MonoBehaviour
	{
		public Room Room { get; private set; }
		
		[SerializeField]
		private NavMeshSurface _navMeshSurface;

		[SerializeField]
		private Transform _gameCameraAnchor;
		/// <summary>
		/// ゲームカメラアンカー
		/// </summary>
		public Transform GameCameraAnchor => _gameCameraAnchor;
		
		private readonly AsyncSubject<Unit> _onInitializeAsync = new AsyncSubject<Unit>();
		/// <summary>
		/// 初期化イベント
		/// </summary>
		public IObservable<Unit> OnInitializeAsync => _onInitializeAsync;
		
		private readonly Subject<Unit> _onEnterObservable = new Subject<Unit>();
		/// <summary>
		/// プレイヤー入場イベント
		/// </summary>
		public IObservable<Unit> OnEnterObservable => _onEnterObservable;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="room"></param>
		public void Construct(Room room)
		{
			Room = room;
		}
		
		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		public void Initialize()
		{
			_onInitializeAsync.OnNext(Unit.Default);
			_onInitializeAsync.OnCompleted();
		}

		/// <summary>
		/// 部屋に入場する
		/// </summary>
		/// <param name="players"></param>
		public void Enter(IEnumerable<PlayerCore> players)
		{
			foreach (var player in players)
			{
				player.transform.SetParent(transform);
			}
			
			_onEnterObservable.OnNext(Unit.Default);
		}

		private void OnDestroy()
		{
			_onEnterObservable.Dispose();
		}
	}
}