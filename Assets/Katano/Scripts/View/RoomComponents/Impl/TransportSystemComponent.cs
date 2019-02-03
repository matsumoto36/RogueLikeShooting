using System;
using DDD.Katano.Managers;
using DDD.Katano.Maze;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Unity.Linq;
using UnityEngine;
using Zenject;

namespace DDD.Katano.View.RoomComponents
{
	/// <inheritdoc />
	/// <summary>
	/// プレイヤー転送システム
	/// </summary>
	[DisallowMultipleComponent]
	public class TransportSystemComponent : BaseRoomComponent
	{
		[Inject]
		private IMessageReceiver _messageReceiver;
		
		
		[Inject]
		private PlayerTransportSystem _transportSystem;

		/// <summary>
		/// 転送システムハブ
		/// </summary>
		private TransporterHub _transporterHub;
		private TransporterHub TransporterHub {
			get
			{
				if (_transporterHub == null)
				{
					_transporterHub = GetComponentInChildren<TransporterHub>();
				}

				return _transporterHub;
			}
		}

		private MazeView _mazeView;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			_mazeView = FindObjectOfType<MazeView>();

			var playerRoomComponent = GetComponent<PlayerRoomComponent>();
			if (playerRoomComponent)
			{
				_messageReceiver
					.Receive<MazeSignal.FloorStarted>()
					.Subscribe(_ =>
					{
						RaiseTransporter();
					})
					.AddTo(this);
			}
			
			var enemyRoomComponent = GetComponent<EnemyRoomComponent>();
			if (enemyRoomComponent)
			{
				// 敵が全滅したら転送システムを起動する
				enemyRoomComponent
					.OnRoomCapturedAsync
					.Subscribe(_ =>
					{
						RaiseTransporter();
					})
					.AddTo(this);
			}

			TransporterHub.gameObject.GetAsyncStartTrigger().StartAsync().ContinueWith(() => InitTransporters()).Forget();
		}
		
		private void InitTransporters()
		{
			var room = Owner.Room;
			
			InitTransporter(AdjacentSides.North, TransporterHub.North, component => component.TransporterHub.South);
			InitTransporter(AdjacentSides.East, TransporterHub.East, component => component.TransporterHub.West);
			InitTransporter(AdjacentSides.South, TransporterHub.South, component => component.TransporterHub.North);
			InitTransporter(AdjacentSides.West, TransporterHub.West, component => component.TransporterHub.East);
			
			void InitTransporter(AdjacentSides adjacentSides, TransporterView target, Func<TransportSystemComponent, TransporterView> selector)
			{
				if (room.ConnectingAisles.ContainsKey(adjacentSides))
				{
					var connectRoom = room.ConnectingAisles[adjacentSides].GetCounterSide(room);
					var roomView = _mazeView.Rooms[connectRoom.Id];
					var transportComponent = roomView.GetComponent<TransportSystemComponent>();
					var transporter = selector(transportComponent);

					if (transporter == null)
						throw new MazeException("CounterSide transpoter is null.");
					
					target.Initialize(Owner, transporter);
				}
			}
		}

		private void RaiseTransporter()
		{
			var transporterViews = TransporterHub.gameObject.Children().OfComponent<TransporterView>();
			foreach (var transporter in transporterViews)
			{
				if (transporter.SetVisible())
				transporter.OnTransportStartObservable.Subscribe(destination =>
				{
					_transportSystem.TransportAsync(destination).Forget();
				});
			}
		}
	}
}