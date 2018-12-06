using UnityEngine;

namespace RogueLike.Matsumoto.Character.Asset {

	public class CharacterAsset : ScriptableObject {

		public int HP;
		public GameObject ModelPrefab;
		public Nishiwaki.Item.WeaponRangedAsset Weapon;
	}
}
