using System;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	[CreateAssetMenu(fileName = "NewMazeSettings", menuName = "Maze/Create Maze Settings")]
	public class MazeSettingsInstaller : ScriptableObjectInstaller<MazeSettingsInstaller>
	{
		public MazeSettings MazeSettings;

		public override void InstallBindings()
		{
			Container.BindInstance(MazeSettings);
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