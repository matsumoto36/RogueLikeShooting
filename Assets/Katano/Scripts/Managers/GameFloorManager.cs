using System.Linq;
using DDD.Katano.Installers;
using DDD.Katano.Maze;
using DDD.Katano.Model;
using DDD.Katano.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Managers
{
	/// <summary>
	/// 階層マネージャ
	/// </summary>
	[DisallowMultipleComponent]
	public class GameFloorManager : MonoBehaviour
	{
		[Inject]
		private IMessageReceiver _messageReceiver;

		[Inject]
		private MazeSettings _mazeSettings;

		[SerializeField]
		private MazeFloorSettings _floorSettings;

		[SerializeField]
		private PlayerTransportSystem _transportSystem;

		[Inject]
		private MazeViewBuilder.Factory _mazeViewBuilderFactory;
		
		private MazeView _mazeView;

		private bool _isReady;
		
		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize()
		{
			_messageReceiver
				.Receive<MazeSignal.FloorStarted>()
				.Subscribe(_ => Startup());
			
			Log("Initialized.");
		}

		/// <summary>
		/// スタートアップ
		/// </summary>
		/// <exception cref="MazeException"></exception>
		public void Startup()
		{
			if (!_isReady)
				throw new MazeException("Maze has not been generated.");
			
			
			
			Log("Startup.");
		}
		
		/// <summary>
		/// Maze生成
		/// </summary>
		public void Construct()
		{
			var maze = ConstructMaze();
			var view = ConstructMazeView(maze);
			_mazeView = view;

			foreach (var roomView in _mazeView.Rooms.Values)
			{
				roomView.Initialize();
			}

			var entryPoint = maze.RoomList.Cast<Room>().First(x => x.RoomAttribute == Room.RoomAttributes.FloorStart);
			var startRoom = view.Rooms[entryPoint.Id];
			
			_transportSystem.Initialize(startRoom);
			
			_isReady = true;
			
			Log("Constructed.");
		}

		/// <summary>
		/// Maze破棄
		/// </summary>
		public void Destruct()
		{
			Destruct(_mazeView);
			
			_isReady = false;
			
			Log("Destructed.");
		}

		/// <summary>
		/// 迷宮を生成
		/// </summary>
		/// <returns></returns>
		private Maze.Maze ConstructMaze()
		{
			var builder = new MazeBuilder();
			var options = new MazeBuildOptions(_floorSettings.Width, _floorSettings.Height, EnumDecorationState.Labyrinth);
			var director = new MazeDirector(builder, options);
			
			return director.Construct();
		}

		/// <summary>
		/// 迷宮を実体化する
		/// </summary>
		/// <param name="maze"></param>
		/// <returns></returns>
		private MazeView ConstructMazeView(Maze.Maze maze)
		{
			var viewBuilder = _mazeViewBuilderFactory.Create(maze);

			return viewBuilder.Construct();
		}

		private static void Destruct(MazeView view)
		{
			// Destroy MazeView
			Destroy(view.gameObject);
		}
		
		private static void Log(string log)
		{
			Debug.Log($"[FloorManager] {log}");
		}
	}
}