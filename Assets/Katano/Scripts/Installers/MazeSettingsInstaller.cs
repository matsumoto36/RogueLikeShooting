using System;
using DDD.Katano.Model;
using DDD.Matsumoto;
using DDD.Matsumoto.Character.Asset;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	[CreateAssetMenu(fileName = "NewMazeSettings", menuName = "Maze/Create Maze Settings")]
	public class MazeSettingsInstaller : ScriptableObjectInstaller<MazeSettingsInstaller>
	{
		public MazeFloorSettings FloorSettings;
		public PlayerAsset PlayerAsset;
		public WeaponAsset PlayerWeaponAsset;
		public WeaponAsset EnemyWeaponAsset;

		public override void InstallBindings()
		{
			Container.BindInstance(FloorSettings);
			Container.BindInstance(PlayerAsset);
			Container.BindInstance(PlayerWeaponAsset).WhenInjectedInto<PlayerBuilder>();
			Container.BindInstance(EnemyWeaponAsset).WhenInjectedInto<EnemyBuilder>();
		}
	}
}