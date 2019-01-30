using DDD.Katano.Model;
using DDD.Nishiwaki.Item;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	public class WeaponInstaller : MonoInstaller<WeaponInstaller>
	{
		public GameObject WeaponCore;
		
		public override void InstallBindings()
		{
			Container.BindIFactory<WeaponRanged, RangedWeaponFactory>().AsSingle()
				.WithArguments(WeaponCore);
		}
	}

	public class RangedWeaponFactory : IFactory<WeaponAsset, WeaponRanged>
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