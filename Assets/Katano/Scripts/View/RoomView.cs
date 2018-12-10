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
	public class RoomView : MonoBehaviour
	{
		public IEnumerable<CharacterSpawner> CharacterSpawners { get; private set; }

		[SerializeField]
		private NavMeshSurface _navMeshSurface;
		
		public Room Room { get; private set; }

		[SerializeField]
		private Transform _gameCameraAnchor;
		public Transform GameCameraAnchor => _gameCameraAnchor;
		
		private readonly AsyncSubject<Unit> _onInitialize = new AsyncSubject<Unit>();
		public IObservable<Unit> OnInitialize => _onInitialize;
		
		private readonly Subject<Unit> _onEnter = new Subject<Unit>();
		public IObservable<Unit> OnEnter => _onEnter;

		private void Awake()
		{
			CharacterSpawners = gameObject.Children().OfComponent<CharacterSpawner>();
		}

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		public void Initialize(Room room)
		{
			Room = room;

			_onInitialize.OnNext(Unit.Default);
			_onInitialize.OnCompleted();
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
		}

		private void OnDestroy()
		{
			_onEnter.Dispose();
		}
	}
}