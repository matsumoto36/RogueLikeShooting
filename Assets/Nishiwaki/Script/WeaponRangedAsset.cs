using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Item
{
    [CreateAssetMenu(fileName = "NewWeaponRangedAsset", menuName = "WeaponRanged/Create WeaponRanged Asset")]

    public class WeaponRangedAsset : ScriptableObject
    {
        public WeaponRangedParameter WeaponRangedParameter;
        public GameObject WeaponRangedPrefab;
        public BulletAsset BulletAsset;
    }
}