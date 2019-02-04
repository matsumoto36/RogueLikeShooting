using System;
using DDD.Katano;
using DDD.Katano.Maze;
using DDD.Katano.Model;
using DDD.Katano.View;
using UniRx;
using UniRx.Async;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace DDD.Matsumoto.Navigation
{
	public enum MinimapObject
	{
		None = 0,
		Floor = 1,
		Players = 2,
		Stair = 4
	}

	/// <summary>
	///     ミニマップ表示機能
	/// </summary>
	public class MiniMapSystem : IInitializable, IDisposable
	{
//		private const string MazeFloorSettingsPath = "MazeFloorSettings";

		private RoomView _currentRoomView;

		private int[,] _mapData;

		[Inject]
		private IMessageReceiver _messageReceiver;

		[Inject]
		private MazeFloorSettings _floorSettings;

		private PlayerCore _player;
		private Point _playerPosition;
		private Point _prevStayRoom;

		public Point MapSize => new Point(_mapData.GetLength(1), _mapData.GetLength(0));

//		public event Action<int[,]> OnMapChanged;
//		public event Action OnStarted;
		
		private readonly Subject<Unit> _onStarted = new Subject<Unit>();
		public IObservable<Unit> OnStarted => _onStarted;

		private readonly Subject<int[,]> _onMapChanged = new Subject<int[,]>();
		public IObservable<int[,]> OnMapChanged => _onMapChanged;
		
		// Start is called before the first frame update
		void IInitializable.Initialize()
		{
			//0と偶数に部屋データ、それ以外に通路データを入れる
			_mapData = new int[_floorSettings.Height * 2 - 1, _floorSettings.Width * 2 - 1];

			//フロア破壊時マップを初期化
			_messageReceiver.Receive<MazeSignal.FloorDestruct>()
				.Subscribe(_ => Initialize())
				.AddTo(_disposables);

			//フロアに入ったとき
			_messageReceiver.Receive<MazeSignal.FloorStarted>()
				.Subscribe(_ =>
				{
					EnterRoom();
					ClearRoom();
				})
				.AddTo(_disposables);

			//部屋に入ったとき
			_messageReceiver.Receive<RoomSignal.RoomStarted>()
				.Subscribe(_ => EnterRoom())
				.AddTo(_disposables);

			//部屋をクリアしたとき
			_messageReceiver.Receive<RoomSignal.RoomCleared>()
				.Subscribe(_ => ClearRoom())
				.AddTo(_disposables);

			Initialize();
			_onStarted.OnNext(Unit.Default);
			_onMapChanged.OnNext(_mapData);

			Debug.Log("started system");
		}
		
		/// <summary>
		///     ミニマップ情報の初期化
		/// </summary>
		private void Initialize()
		{
			for (var i = 0; i < _mapData.GetLength(0); i++)
			for (var j = 0; j < _mapData.GetLength(1); j++)
				_mapData[i, j] = (int) MinimapObject.None;

			_prevStayRoom = new Point(-1, -1);
		}

		/// <summary>
		///     部屋に入ったとき
		/// </summary>
		private void EnterRoom()
		{
			Debug.Log("enter room");

			if (!_player)
				_player = Object.FindObjectOfType<PlayerCore>();

			_currentRoomView = _player.transform.GetComponentInParent<RoomView>();
			_playerPosition = _currentRoomView.Room.Coordinate;

			//プレイヤーのいた部屋を移動
			if (_prevStayRoom.X != -1)
				_mapData[_prevStayRoom.Y * 2, _prevStayRoom.X * 2] &= ~(int) MinimapObject.Players;

			_mapData[_playerPosition.Y * 2, _playerPosition.X * 2] |= (int) MinimapObject.Floor;
			_mapData[_playerPosition.Y * 2, _playerPosition.X * 2] |= (int) MinimapObject.Players;

			_prevStayRoom = _playerPosition;

			_onMapChanged.OnNext(_mapData);
		}

		/// <summary>
		///     部屋をクリアしたとき
		/// </summary>
		private void ClearRoom()
		{
			var aisles = _currentRoomView.Room.ConnectingAisles;

			var mapPosition = new Point(_playerPosition.X * 2, _playerPosition.Y * 2);

			//廊下を出す
			foreach (var item in aisles)
				switch (item.Key)
				{
					case AdjacentSides.North:
						_mapData[mapPosition.Y - 1, mapPosition.X] |= (int) MinimapObject.Floor;
						break;
					case AdjacentSides.East:
						_mapData[mapPosition.Y, mapPosition.X + 1] |= (int) MinimapObject.Floor;
						break;
					case AdjacentSides.South:
						_mapData[mapPosition.Y + 1, mapPosition.X] |= (int) MinimapObject.Floor;
						break;
					case AdjacentSides.West:
						_mapData[mapPosition.Y, mapPosition.X - 1] |= (int) MinimapObject.Floor;
						break;
				}

			//階段があれば出す
			if (_currentRoomView.Room.RoomAttribute == Room.RoomAttributes.Stair)
				_mapData[mapPosition.Y, mapPosition.X] |= (int) MinimapObject.Stair;

			_onMapChanged.OnNext(_mapData);
		}

		private readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Dispose()
		{
			_disposables.Dispose();
			
			_onStarted.OnCompleted();
			_onMapChanged.OnCompleted();
		}
	}
}