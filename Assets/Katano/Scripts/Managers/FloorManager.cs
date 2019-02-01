using System.Diagnostics;
using System.Linq;
using DDD.Katano.Installers;
using DDD.Katano.Maze;
using DDD.Katano.Model;
using DDD.Katano.View;
using UniRx;
using Unity.Linq;
using UnityEngine;
using Zenject;
using Debug = UnityEngine.Debug;

namespace DDD.Katano.Managers
{
	
	/// <summary>
	/// 階層マネージャ
	/// </summary>
	[DisallowMultipleComponent]
	public class FloorManager : MonoBehaviour
	{
		[Inject]
		private IMessageReceiver _messageReceiver;

		[Inject]
		private MazeSettings _mazeSettings;

		[Inject]
		private MazeFloorSettings _floorSettings;

		[Inject]
		private PlayerTransportSystem _transportSystem;

		[Inject]
		private MazeViewBuilder.Factory _mazeViewBuilderFactory;
		
		private MazeView _mazeView;

		private bool _isReady;
		
		public MazeView Create()
		{
			var maze = ConstructMaze();
			var view = ConstructMazeView(maze);
			
			view.Initialize();

			return view;
		}
		
		/// <summary>
		/// Maze生成
		/// </summary>
		public void Construct()
		{
			var maze = ConstructMaze();
			var view = ConstructMazeView(maze);
			_mazeView = view;

			_mazeView.Initialize();

			var entryPoint = maze.GetEntryPoint();
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
			_mazeView.gameObject.Destroy();
			
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
			var options = new MazeBuildOptions(_floorSettings.Width, _floorSettings.Height, DecorationState.Labyrinth);
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
		
		[Conditional("UNITY_EDITOR")]
		private static void Log(string log)
		{
			Debug.Log($"[FloorManager] {log}");
		}
	}
}