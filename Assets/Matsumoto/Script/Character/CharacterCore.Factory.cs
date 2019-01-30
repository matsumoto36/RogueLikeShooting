using DDD.Katano.Installers;
using DDD.Katano.Model;
using DDD.Katano.View.Character;
using DDD.Matsumoto.Character.Asset;
using DDD.Nishiwaki.Item;
using UnityEngine;
using Zenject;

namespace DDD.Matsumoto.Character
{
	public abstract partial class CharacterCore
	{
		public const string CharacterPrefabPath = "Prefab/CharacterPrefab";
		private const string WeaponBindAnchor = "WeaponAnchor";
		
		public abstract WeaponAsset GetFirstWeapon { get; }
		
		public class Factory
		{
			private readonly DiContainer _container;
			private readonly RangedWeaponFactory _rangedWeaponFactory;

			public Factory(RangedWeaponFactory rangedWeaponFactory, DiContainer container)
			{
				_rangedWeaponFactory = rangedWeaponFactory;
				_container = container;
			}

			public CharacterCore Create<T>(CharacterAsset asset, Transform anchor) where T : CharacterCore
			{
//				var prefab = Resources.Load<GameObject>(CharacterPrefabPath);
//				var go = Instantiate(prefab, anchor.position, anchor.rotation);
				var go = _container.InstantiatePrefabResource(
					CharacterPrefabPath, 
					anchor.position, 
					anchor.rotation,
					null);

//				var character = go.AddComponent<T>();
				var character = _container.InstantiateComponent<T>(go);

//				character._weaponAnchor = character.transform.Find(WeaponBindAnchor);
				character.ThemeColor = asset.ThemeColor;
				character.CharacterRig = character.GetComponent<Rigidbody>();

				character.OnSpawn(asset);
//				var weapon = WeaponRanged.Create(asset.Weapon, anchor);
				var weapon = _rangedWeaponFactory.Create(character.GetFirstWeapon);


//				character.AttachWeapon(weapon);

				return character;
			}
		}
	}
}