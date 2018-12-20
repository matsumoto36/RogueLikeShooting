using System;
using RogueLike.Katano.Managers;
using RogueLike.Katano.Maze;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Unity.Linq;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	/// <inheritdoc />
	/// <summary>
	/// プレイヤー転送システム
	/// </summary>
	[DisallowMultipleComponent]
	public class PlayerTransportComponent : BaseRoomComponent
	{
		private TransporterHub _hubPrefab;
		/// <summary>
		/// 転送システムハブ
		/// </summary>
		private TransporterHub TransporterHub { get; set; }
		
		private PlayerTransportSystem _transportSystem;
		private SpawnPlayerComponent _spawnPlayerComponent;
		private SpawnEnemyComponent _spawnEnemyComponent;

		private MazeView _mazeView;

		private void Awake()
		{
			_hubPrefab = Resources.Load<TransporterHub>("Transporters");
		}

		/// <inheritdoc />
		public override void OnInitialize()
		{
			_mazeView = FindObjectOfType<MazeView>();
			
			TransporterHub = Instantiate(_hubPrefab, transform.localPosition, Quaternion.identity, transform);
			
			_transportSystem = FindObjectOfType<PlayerTransportSystem>();

			_spawnPlayerComponent = GetComponent<SpawnPlayerComponent>();
			if (_spawnPlayerComponent)
			{
				var mainGameManager = FindObjectOfType<MainGameManager>();

				mainGameManager.MainEventBroker
					.Receive<MazeSignal.FloorStarted>()
					.Subscribe(_ =>
					{
						RaiseTransporter();
					})
					.AddTo(this);
			}
			
			_spawnEnemyComponent = GetComponent<SpawnEnemyComponent>();
			if (_spawnEnemyComponent)
			{
				
				
				// 敵が全滅したら転送システムを起動する
				_spawnEnemyComponent
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
			
			void InitTransporter(AdjacentSides adjacentSides, TransporterView target, Func<PlayerTransportComponent, TransporterView> selector)
			{
				if (room.ConnectingAisles.ContainsKey(adjacentSides))
				{
					var connectRoom = room.ConnectingAisles[adjacentSides].GetCounterSide(room);
					var roomView = _mazeView.Rooms[connectRoom.Id];
					var transportComponent = roomView.GetComponent<PlayerTransportComponent>();
					var transporter = selector(transportComponent);

					if (transporter == null)
						throw new MazeException("CounterSide transpoter is null.");
					
					target.Initialze(Owner, transporter);
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