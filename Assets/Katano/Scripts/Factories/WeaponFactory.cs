using DDD.Katano.Model;
using DDD.Nishiwaki.Bullet;
using DDD.Nishiwaki.Item;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
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
			var core = _container.InstantiatePrefab(_coreObject, weapon.transform);
			weapon.CoreObject = core;
			weapon.CoreRenderer = core.GetComponent<Renderer>();
			weapon.CoreRenderer.material.EnableKeyword("_EMISSION");

			weapon.WeaponRangedPara = asset.Parameter;
			weapon.iBullet = BulletBase.Create(asset.Bullet, weapon);
			weapon.playerSetPosition = weaponObj.transform.Find("PlayerSetPosition");
			
			return weapon;
		}
	}
}