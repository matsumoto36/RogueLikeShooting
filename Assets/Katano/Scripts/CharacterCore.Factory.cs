using DDD.Matsumoto.Character.Asset;
using DDD.Nishiwaki.Item;
using UnityEngine;
using Zenject;

namespace DDD.Matsumoto.Character
{
	public abstract partial class CharacterCore
	{
		public class Factory
		{
			private readonly DiContainer _container;

			public Factory(DiContainer container)
			{
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
				
				character._themeColor = asset.ThemeColor;
				character.CharacterRig = character.GetComponent<Rigidbody>();

				character.OnSpawn(asset);
				var weapon = WeaponRanged.Create(asset.Weapon, anchor);
				character.AttachWeapon(weapon);

				return character;
			}
		}
	}
}