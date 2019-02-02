using DDD.Katano.Installers;
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
}