using DDD.Katano.Model;
using DDD.Nishiwaki.Bullet;
using DDD.Nishiwaki.Item;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	public class WeaponInstaller : MonoInstaller<WeaponInstaller>
	{
		public GameObject WeaponCore;
		public Material Material;
		
		public override void InstallBindings()
		{
			Container.Bind<RangedWeaponFactory>().AsSingle()
				.WithArguments(WeaponCore);
		}
	}

	public class RangedWeaponFactory : WeaponFactory
	{
		
	}
	
	public class WeaponFactory : IFactory<WeaponAsset, Transform, WeaponRanged>
	{
		private DiContainer _container;
		private GameObject _coreObject;

		[Inject]
		private void Construct(GameObject coreObject, DiContainer container)
		{
			_container = container;
			_coreObject = coreObject;
		}

		public WeaponRanged Create(WeaponAsset asset, Transform anchor)
		{
			var weaponObj = Object.Instantiate(asset.WeaponModel, anchor.position, anchor.rotation);
			var weapon = _container.InstantiateComponent<WeaponRangedAuto>(weaponObj);
			_container.InstantiatePrefab(_coreObject, weapon.transform);
			weapon.CoreObject = weaponObj;
			weapon.CoreRenderer = weaponObj.GetComponentInChildren<Renderer>();

			weapon.WeaponRangedPara = asset.Parameter;
			weapon.iBullet = BulletBase.Create(asset.Bullet, weapon);
			weapon.playerSetPosition = weaponObj.transform.Find("PlayerSetPosition");
			
			return weapon;
		}
	}
}