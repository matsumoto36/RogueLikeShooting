using System;
using DDD.Katano.Model;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	[CreateAssetMenu(fileName = "NewMazeSettings", menuName = "Maze/Create Maze Settings")]
	public class MazeSettingsInstaller : ScriptableObjectInstaller<MazeSettingsInstaller>
	{
		public MazeSettings MazeSettings;
		public MazeFloorSettings FloorSettings;

		public override void InstallBindings()
		{
			Container.BindInstance(MazeSettings);
			Container.BindInstance(FloorSettings);
		}
	}

	[Serializable]
	public class MazeSettings
	{
		public string DungeonName;

		[Header("Room Objects")]
		public GameObject PlayerRoom;
		public GameObject EnemyRoom;
		public GameObject BirdsEyeCamera;
	}
}