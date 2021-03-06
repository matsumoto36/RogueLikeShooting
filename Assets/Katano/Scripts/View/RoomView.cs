using System;
using System.Collections.Generic;
using DDD.Katano.Maze;
using DDD.Matsumoto;
using UniRx;
using UnityEngine;
using Zenject;
// ReSharper disable NotAccessedField.Local

namespace DDD.Katano.View
{
	/// <summary>
	/// 部屋のViewオブジェクト
	/// </summary>
	[SelectionBase]
	public class RoomView : MonoBehaviour
	{
		public Room Room { get; private set; }
		
		/// <summary>
		/// ゲームカメラアンカー
		/// </summary>
		public Transform GameCameraAnchor { get; private set; }
		
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

		[Inject]
		private IMessagePublisher _messagePublisher;

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		/// <param name="cameraAnchor"></param>
		public void Construct(Room room, Transform cameraAnchor)
		{
			Room = room;
			GameCameraAnchor = cameraAnchor;
		}
		
		/// <summary>
		/// 初期化
		/// </summary>
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
			Debug.Log($"{Room.ToString()} entered.");

			_messagePublisher.Publish(new RoomSignal.RoomStarted());
		}

		private void OnDestroy()
		{
			_onEnterObservable.Dispose();
		}
	}
}