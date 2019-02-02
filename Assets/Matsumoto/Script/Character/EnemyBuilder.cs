using DDD.Katano.Installers;
using DDD.Katano.View.Character;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Model
{
	public class EnemyBuilder : CharacterBuilder
	{
		private readonly WeaponAsset _weaponAsset;
		
		public EnemyBuilder(
			GameObject prefab, 
			RangedWeaponFactory weaponFactory, 
			WeaponAsset weaponAsset,
			DiContainer container) : base(prefab, weaponFactory, container)
		{
			_weaponAsset = weaponAsset;
		}

		public override CharacterCore Create(CharacterAsset asset, Transform anchor)
		{
			var go = Container.InstantiatePrefab(
				Prefab,
				anchor.position,
				anchor.rotation,
				null);

			go.name = asset.name;
			var enemy = Container.InstantiateComponent<EnemyCore>(go);

//				character._weaponAnchor = character.transform.Find(WeaponBindAnchor);
			enemy.ThemeColor = asset.ThemeColor;
			enemy.CharacterRig = enemy.GetComponent<Rigidbody>();

			enemy.OnSpawn(asset);
//				var weapon = WeaponRanged.Create(weaponAsset.Weapon, anchor);
			var arm = enemy.GetComponent<CharacterArm>();
			arm.Core = enemy;
			arm.Attach(WeaponFactory.Create(_weaponAsset, anchor));


//				character.AttachWeapon(weapon);

			return enemy;
		}
	}
}