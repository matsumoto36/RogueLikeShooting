using UnityEngine;

namespace DDD.Katano.Model
{
	[CreateAssetMenu(menuName = "Game/Create Weapon Asset")]
	public class WeaponAsset : ScriptableObject
	{
		public GameObject WeaponModel;
	}
}