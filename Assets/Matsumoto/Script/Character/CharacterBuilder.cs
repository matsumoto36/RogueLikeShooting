using DDD.Katano.Installers;
using DDD.Matsumoto;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Model
{
	/// <summary>
	/// キャラクタービルダー
	/// </summary>
	public abstract class CharacterBuilder
	{
		protected readonly DiContainer Container;
		protected readonly GameObject Prefab;
		protected readonly RangedWeaponFactory WeaponFactory;

		public CharacterBuilder(GameObject prefab, RangedWeaponFactory weaponFactory, DiContainer container)
		{
			Prefab = prefab;
			WeaponFactory = weaponFactory;
			Container = container;
		}

		public abstract CharacterCore Create(CharacterAsset asset, Transform anchor);
	}

	public class PlayerBuilder : CharacterBuilder
	{
		public PlayerBuilder(GameObject prefab, RangedWeaponFactory weaponFactory, DiContainer container) : base(prefab, weaponFactory, container)
		{
		}

		public override CharacterCore Create(CharacterAsset asset, Transform anchor)
		{
			var go = Container.InstantiatePrefab(
				Prefab,
				anchor.position,
				anchor.rotation,
				null);

//				var character = go.AddComponent<T>();
			var player = Container.InstantiateComponent<PlayerCore>(go);

//				character._weaponAnchor = character.transform.Find(WeaponBindAnchor);
			player.ThemeColor = asset.ThemeColor;
			player.CharacterRig = player.GetComponent<Rigidbody>();

			player.OnSpawn(asset);
//				var weapon = WeaponRanged.Create(asset.Weapon, anchor);
			var weapon = WeaponFactory.Create(player.GetFirstWeapon);


//				character.AttachWeapon(weapon);

			return player;
		}
	}
	
	public class EnemyBuilder : CharacterBuilder
	{
		public EnemyBuilder(GameObject prefab, RangedWeaponFactory weaponFactory, DiContainer container) : base(prefab, weaponFactory, container)
		{
		}

		public override CharacterCore Create(CharacterAsset asset, Transform anchor)
		{
			var go = Container.InstantiatePrefab(
				Prefab,
				anchor.position,
				anchor.rotation,
				null);

//				var character = go.AddComponent<T>();
			var enemy = Container.InstantiateComponent<EnemyCore>(go);

//				character._weaponAnchor = character.transform.Find(WeaponBindAnchor);
			enemy.ThemeColor = asset.ThemeColor;
			enemy.CharacterRig = enemy.GetComponent<Rigidbody>();

			enemy.OnSpawn(asset);
//				var weapon = WeaponRanged.Create(asset.Weapon, anchor);
			var weapon = WeaponFactory.Create(enemy.GetFirstWeapon);


//				character.AttachWeapon(weapon);

			return enemy;
		}
	}
}