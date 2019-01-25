using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDD.Katano.Model;
using DDD.Katano.Managers;
using DDD.Katano.Maze;
using DDD.Katano.View;
using UniRx;
using UnityEngine.Events;
using Zenject;
using System;

namespace DDD.Matsumoto.Minimap {

	public enum MinimapObject {
		None = 0,
		Floor = 1,
		Players = 2,
		Stair = 4,
	}

	/// <summary>
	/// ミニマップ表示機能
	/// </summary>
	public class MiniMapSystem : MonoBehaviour {

		private const string MazeFloorSettingsPath = "MazeFloorSettings";

		private PlayerCore _player;
		private Point _prevStayRoom;
		private Point _playerPosition;

		private RoomView _currentRoomView;

		[Inject]
		private IMessageReceiver _messageReceiver;

		public event Action<int[,]> OnMapChanged;
		public event Action OnStarted;

		private int[,] _mapData;

		public Point MapSize {
			get { return new Point(_mapData.GetLength(1), _mapData.GetLength(0)); }
		}

		// Start is called before the first frame update
		void Start() {

			var settings = Resources.Load<MazeFloorSettings>(MazeFloorSettingsPath);

			//0と偶数に部屋データ、それ以外に通路データを入れる
			_mapData = new int[settings.Height * 2 - 1, settings.Width * 2 - 1];

			//フロア破壊時マップを初期化
			_messageReceiver.Receive<Katano.MazeSignal.FloorDestruct>()
				.Subscribe((_) => Initialize())
				.AddTo(this);

			//フロアに入ったとき
			_messageReceiver.Receive<Katano.MazeSignal.FloorStarted>()
				.Subscribe((_) => {
					EnterRoom();
					ClearRoom();
				})
				.AddTo(this);

			//部屋に入ったとき
			_messageReceiver.Receive<RoomSignal.RoomStarted>()
				.Subscribe((_) => EnterRoom())
				.AddTo(this);

			//部屋をクリアしたとき
			_messageReceiver.Receive<RoomSignal.RoomCleared>()
				.Subscribe((_) => ClearRoom())
				.AddTo(this);

			Initialize();
			OnStarted?.Invoke();
			OnMapChanged?.Invoke(_mapData);

			Debug.Log("started system");

		}

		/// <summary>
		/// ミニマップ情報の初期化
		/// </summary>
		void Initialize() {

			for (int i = 0; i < _mapData.GetLength(0); i++) {
				for(int j = 0; j < _mapData.GetLength(1); j++) {
					_mapData[i, j] = (int)MinimapObject.None;
				}
			}

			_prevStayRoom = new Point(-1, -1);
		}

		/// <summary>
		/// 部屋に入ったとき
		/// </summary>
		void EnterRoom() {

			Debug.Log("enter room");

			if(!_player)
				_player = FindObjectOfType<PlayerCore>();

			_currentRoomView = _player.transform.GetComponentInParent<RoomView>();
			_playerPosition = _currentRoomView.Room.Coordinate;

			//プレイヤーのいた部屋を移動
			if (_prevStayRoom.X != -1) {
				_mapData[_prevStayRoom.Y * 2, _prevStayRoom.X * 2] &= ~(int)MinimapObject.Players;
			}

			_mapData[_playerPosition.Y * 2, _playerPosition.X * 2] |= (int)MinimapObject.Floor;
			_mapData[_playerPosition.Y * 2, _playerPosition.X * 2] |= (int)MinimapObject.Players;

			_prevStayRoom = _playerPosition;

			OnMapChanged?.Invoke(_mapData);
		}

		/// <summary>
		/// 部屋をクリアしたとき
		/// </summary>
		void ClearRoom() {

			var aisles = _currentRoomView.Room.ConnectingAisles;

			var mapPosition = new Point(_playerPosition.X * 2, _playerPosition.Y * 2);

			//廊下を出す
			foreach (var item in aisles) {
				switch (item.Key) {
					case AdjacentSides.North:
						_mapData[mapPosition.Y - 1, mapPosition.X] |= (int)MinimapObject.Floor;
						break;
					case AdjacentSides.East:
						_mapData[mapPosition.Y, mapPosition.X + 1] |= (int)MinimapObject.Floor;
						break;
					case AdjacentSides.South:
						_mapData[mapPosition.Y + 1, mapPosition.X] |= (int)MinimapObject.Floor;
						break;
					case AdjacentSides.West:
						_mapData[mapPosition.Y, mapPosition.X - 1] |= (int)MinimapObject.Floor;
						break;
				}
			}

			//階段があれば出す
			if (_currentRoomView.Room.RoomAttribute == Room.RoomAttributes.Stair) {
				_mapData[mapPosition.Y, mapPosition.X] |= (int)MinimapObject.Stair;
			}

			OnMapChanged?.Invoke(_mapData);
		}
	}

}