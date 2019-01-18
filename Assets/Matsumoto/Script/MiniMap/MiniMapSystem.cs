using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDD.Katano.Model;
using DDD.Katano.Managers;
using DDD.Katano.Maze;
using DDD.Katano.View;
using UniRx;
using Zenject;

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

		[Inject]
		private IMessageReceiver _messageReceiver;

		private int[,] _mapData;
		public int[,] MapData {
			get { return _mapData; }
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

			//部屋に入ったとき
			_messageReceiver.Receive<RoomSignal.RoomStarted>()
				.Subscribe((_) => EnterRoom())
				.AddTo(this);

			//部屋をクリアしたとき
			_messageReceiver.Receive<RoomSignal.RoomCleared>()
				.Subscribe((_) => ClearRoom())
				.AddTo(this);

			Initialize();

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

			if (!_player)
				_player = FindObjectOfType<PlayerCore>();

			var roomView = _player.transform.GetComponentInParent<RoomView>();
			_playerPosition = roomView.Room.Coordinate;

			//プレイヤーのいた部屋を移動
			if (_prevStayRoom.X != -1) {
				_mapData[_prevStayRoom.Y * 2, _prevStayRoom.X * 2] &= ~(int)MinimapObject.Players;
			}

			_mapData[_playerPosition.Y * 2, _playerPosition.X * 2] |= (int)MinimapObject.Floor;
			_mapData[_playerPosition.Y * 2, _playerPosition.X * 2] |= (int)MinimapObject.Players;

			_prevStayRoom = _playerPosition;
		}

		/// <summary>
		/// 部屋をクリアしたとき
		/// </summary>
		void ClearRoom() {

			//廊下を出す

		}
	}

}