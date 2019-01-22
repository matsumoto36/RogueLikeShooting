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
			private DiContainer _container;

			public Factory(DiContainer container)
			{
				_container = container;
			}

			public CharacterCore Create<T>(CharacterAsset asset, Transform anchor) where T : CharacterCore
			{
				var go = Instantiate(Resources.Load<GameObject>(CharacterPrefabPath), anchor.position,
					anchor.rotation);


				var character = go.AddComponent<T>();
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