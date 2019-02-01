using DDD.Nishiwaki.Bullet;
using DDD.Nishiwaki.Item;
using UnityEngine;

namespace DDD.Katano.Model
{
	[CreateAssetMenu(menuName = "Game/Create Weapon Asset")]
	public class WeaponAsset : ScriptableObject
	{
		public GameObject WeaponModel;
		public BulletAsset Bullet;
		public WeaponRangedParameter Parameter;
	}
}