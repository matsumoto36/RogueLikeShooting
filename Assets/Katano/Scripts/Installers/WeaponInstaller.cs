using DDD.Katano.Model;
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
				.WithArguments(WeaponCore, Material);
		}
	}

	public class RangedWeaponFactory : WeaponFactory
	{
		
	}
	
	public class WeaponFactory : IFactory<WeaponAsset, WeaponRanged>
	{
		private DiContainer _container;
		private GameObject _coreObject;
		private Material _injectMaterial;

		[Inject]
		private void Construct(GameObject coreObject, Material injectMaterial, DiContainer container)
		{
			_container = container;
			_coreObject = coreObject;
			_injectMaterial = injectMaterial;
		}

		public WeaponRanged Create(WeaponAsset asset)
		{
			var weaponObj = Object.Instantiate(asset.WeaponModel);
			var weapon = _container.InstantiateComponent<WeaponRanged>(weaponObj);
			_container.InstantiatePrefab(_coreObject, weapon.transform);
			
			return weapon;
		}
	}
}