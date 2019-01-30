using DDD.Katano.Model;
using DDD.Matsumoto;
using DDD.Matsumoto.Character.Asset;
using DDD.Nishiwaki.Item;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	[CreateAssetMenu(menuName = "Game/Create Weapon")]
	public class GameCharacterMiscInstallers : ScriptableObjectInstaller<GameCharacterMiscInstallers>
	{
		public CharacterAsset PlayerAsset;
		public WeaponAsset PlayerWeapon;
		public WeaponAsset EnemyWeapon;
		
		public override void InstallBindings()
		{
			Container.BindInstance(PlayerAsset).AsSingle();
			Container.BindInstance(PlayerWeapon).AsSingle().WhenInjectedInto<PlayerCore>();
		}
	}
}