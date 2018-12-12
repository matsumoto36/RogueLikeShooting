using System;
using RogueLike.Katano.Managers;
using RogueLike.Katano.Maze;
using UniRx;
using UniRx.Async;
using Unity.Linq;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	/// <inheritdoc />
	/// <summary>
	/// プレイヤー転送システム
	/// </summary>
	[DisallowMultipleComponent]
	public class PlayerTransportComponent : RoomComponent
	{
		private TransporterHub _hubPrefab;
		/// <summary>
		/// 転送システムハブ
		/// </summary>
		private TransporterHub TransporterHub { get; set; }
		
		private PlayerTransporter _transporter;
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
			
			_transporter = FindObjectOfType<PlayerTransporter>();

			_spawnPlayerComponent = GetComponent<SpawnPlayerComponent>();
			if (_spawnPlayerComponent)
			{
				var mainGameManager = FindObjectOfType<MainGameManager>();

				mainGameManager.MainEventBroker
					.Receive<MazeSignal.FloorStarted>()
					.Subscribe(_ =>
					{
						InitTransporters();
						RaiseTransporter();
					});
			}
			
			_spawnEnemyComponent = GetComponent<SpawnEnemyComponent>();
			if (_spawnEnemyComponent)
			{
				// 敵が全滅したら転送システムを起動する
				_spawnEnemyComponent
					.OnEnemyDownAsync
					.Subscribe(_ =>
					{
						InitTransporters();
						RaiseTransporter();
					});
			}
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

					target.Initialze(Owner, transporter);
				}
			}
		}

		private void RaiseTransporter()
		{
			var transporterViews = TransporterHub.gameObject.Children().OfComponent<TransporterView>();
			foreach (var transporter in transporterViews)
			{
				transporter.SetVisible();
				transporter.OnTransportStartObservable.Subscribe(_ =>
				{
					_transporter.TransportAsync(transporter.Owner).Forget();
				});
			}
		}
	}
}