using System;
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

		private void Awake()
		{
			_hubPrefab = Resources.Load<TransporterHub>("Transporters");
		}

		/// <inheritdoc />
		public override void OnInitialize()
		{
			TransporterHub = Instantiate(_hubPrefab, transform.localPosition, Quaternion.identity, transform);
			
			_transporter = FindObjectOfType<PlayerTransporter>();

			_spawnPlayerComponent = GetComponent<SpawnPlayerComponent>();
			if (_spawnPlayerComponent)
			{
				_spawnPlayerComponent
					.OnPlayerSpawnedAsync
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
			var mazeView = FindObjectOfType<MazeView>();
			var room = Owner.Room;

			if (room.ConnectingAisles.ContainsKey(AdjacentSides.North))
			{
				var counterSideRoom = room.ConnectingAisles[AdjacentSides.North].GetCounterSide(room);
				var counterSide = mazeView.Rooms[counterSideRoom.Id]
					.GetComponent<PlayerTransportComponent>()
					.TransporterHub.South;
				
				TransporterHub.North.Initialze(Owner, counterSide);
			}
			if (room.ConnectingAisles.ContainsKey(AdjacentSides.East))
			{
				var counterSideRoom = room.ConnectingAisles[AdjacentSides.East].GetCounterSide(room);
				var counterSide = mazeView.Rooms[counterSideRoom.Id]
					.GetComponent<PlayerTransportComponent>()
					.TransporterHub.West;
				
				TransporterHub.East.Initialze(Owner, counterSide);
			}
			if (room.ConnectingAisles.ContainsKey(AdjacentSides.South))
			{
				var counterSideRoom = room.ConnectingAisles[AdjacentSides.South].GetCounterSide(room);
				var counterSide = mazeView.Rooms[counterSideRoom.Id]
					.GetComponent<PlayerTransportComponent>()
					.TransporterHub.North;
				
				TransporterHub.South.Initialze(Owner, counterSide);
			}
			if (room.ConnectingAisles.ContainsKey(AdjacentSides.West))
			{
				var counterSideRoom = room.ConnectingAisles[AdjacentSides.West].GetCounterSide(room);
				var counterSide = mazeView.Rooms[counterSideRoom.Id]
					.GetComponent<PlayerTransportComponent>()
					.TransporterHub.East;

				TransporterHub.West.Initialze(Owner, counterSide);
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